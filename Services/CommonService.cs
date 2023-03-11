using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WemaAnalyticsAPI.Services
{
    public class CommonService : ICommonService
    {
        public readonly SqlDataAccess _sqlDataAccess;
        private readonly IConfiguration _config;

        public CommonService(SqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task <dynamic> GetDirectorates(DateTime? inputedMaxDate)
        {
            var maxDateInDb = await GetMaxDate();  // query db for maxDate 2021-06-30

            var maxDate = inputedMaxDate == null ? maxDateInDb : inputedMaxDate;

            string sql = $"select directorate_code, directorate_name, " +
                    $"region_code, region_name, " +
                    $"zone_code, zone_name, " +
                    $"branch_code, branch_name " +
                    $"from vw_base_structure " +
                    $"where month(structure_date) = month('{maxDate?.ToString("yyyy-MM-dd") }') " +
                    $"and year(structure_date) = year('{maxDate?.ToString("yyyy-MM-dd") }') " +
                    $"order by directorate_code, region_code, zone_code, branch_code";

            var data = (await _sqlDataAccess.LoadData<dynamic>(sql));

            var structure = new
            {
                directorates = new List<Directorate>()
            };

            foreach (var rows in data)
            {
                var fields = rows as IDictionary<string, object>;
                var directorateInDb = structure.directorates.Find(x => x.DirectorateCode == (string)fields["directorate_code"]);
                if (directorateInDb == null)
                {
                    structure.directorates.Add(new Directorate
                    {
                        DirectorateCode = (string)fields["directorate_code"],
                        DirectorateName = (string)fields["directorate_name"],
                        Regions = new List<Region> { }
                    });
                }
                if (directorateInDb != null)
                {
                    var regionInDb = directorateInDb.Regions.Find(r => r.RegionCode == (string)fields["region_code"]);
                    if (regionInDb == null)
                    {
                        directorateInDb.Regions.Add(new Region { RegionCode = (string)fields["region_code"], RegionName = (string)fields["region_name"] });
                    }

                    if (regionInDb != null)
                    {
                        var zoneInDb = regionInDb.Zones.Find(z => z.ZoneCode == (string)fields["zone_code"]);
                        if (zoneInDb == null)
                        {
                            regionInDb.Zones.Add(new Zone { ZoneCode = (string)fields["zone_code"], ZoneName = (string)fields["zone_name"] });
                        }

                        if (zoneInDb != null)
                        {
                            var branchInDb = zoneInDb.Branches.Find(b => b.BranchCode == (string)fields["branch_code"]);
                            if (branchInDb == null)
                            {
                                zoneInDb.Branches.Add(new Branch { BranchCode = (string)fields["branch_code"], BranchName = (string)fields["branch_name"] });
                            }

                        }

                    }
                }
            }

            return structure;
        }

        public async Task<dynamic> GetRetailStructure(int? inputMonth, int? intputYear)
        {
            var maxDateInDb = await GetMaxDate();  // query db for maxDate 2021-06-30
            var maxDateInDbMonth = maxDateInDb.Month;
            var maxDateInDbYear = maxDateInDb.Year;
            int? p_month = inputMonth == null ? maxDateInDbMonth : inputMonth;
            int? p_year = intputYear == null ? maxDateInDbYear : intputYear;

            var sql = "sp_get_structure_retail";

            var data = await _sqlDataAccess.SPLoadData<dynamic>(sql, new { p_month, p_year });

            var structure = new
            {
                directorates = new List<Directorate>()
            };

            foreach (var rows in data)
            {
                var fields = rows as IDictionary<string, object>;
                var directorateInDb = structure.directorates.Find(x => x.DirectorateCode == (string)fields["directorate_code"]);
                if (directorateInDb == null)
                {
                    structure.directorates.Add(new Directorate
                    {
                        DirectorateCode = (string)fields["directorate_code"],
                        DirectorateName = (string)fields["directorate_name"],
                        Regions = new List<Region> { }
                    });
                }
                
                directorateInDb = structure.directorates.Find(x => x.DirectorateCode == (string)fields["directorate_code"]);
                if (directorateInDb != null)
                {
                    var regionInDb = directorateInDb.Regions.Find(r => r.RegionCode == (string)fields["region_code"]);
                    if (regionInDb == null)
                    {
                        directorateInDb.Regions.Add(new Region { 
                            RegionCode = (string)fields["region_code"], 
                            RegionName = (string)fields["region_name"],
                            Clusters = new List<Cluster> { }
                        });
                    }

                    regionInDb = directorateInDb.Regions.Find(r => r.RegionCode == (string)fields["region_code"]);
                    if (regionInDb != null)
                    {
                        var clusterInDb = regionInDb.Clusters.Find(z => z.ClusterCode == (string)fields["cluster_code"]);
                        if (clusterInDb == null)
                        {
                            regionInDb.Clusters.Add(new Cluster {
                                ClusterCode = (string)fields["cluster_code"], 
                                ClusterName = (string)fields["cluster_name"],
                                Branches = new List<Branch> { }
                            });
                        }

                        clusterInDb = regionInDb.Clusters.Find(z => z.ClusterCode == (string)fields["cluster_code"]);
                        if (clusterInDb != null)
                        {
                            var branchInDb = clusterInDb.Branches.Find(b => b.BranchCode == (string)fields["branch_code"]);
                            if (branchInDb == null)
                            {
                                clusterInDb.Branches.Add(new Branch {
                                    BranchCode = (string)fields["branch_code"], 
                                    BranchName = (string)fields["branch_name"],
                                    AccountOfficers = new List<AccountOfficer> { }
                                });
                            }

                            branchInDb = clusterInDb.Branches.Find(b => b.BranchCode == (string)fields["branch_code"]);
                            if (branchInDb != null)
                            {
                                var accountOfficerInDb = branchInDb.AccountOfficers.Find(z => z.StaffNumber == (string)fields["staff_id"]);
                                if (accountOfficerInDb == null)
                                {
                                    branchInDb.AccountOfficers.Add(new AccountOfficer
                                    {
                                        StaffNumber = (string)fields["staff_id"],
                                        StaffName = (string)fields["staff_name"],
                                        Sbu = new Sbu()
                                    });
                                }

                                accountOfficerInDb = branchInDb.AccountOfficers.Find(z => z.StaffNumber == (string)fields["staff_id"]);
                                if (accountOfficerInDb != null)
                                {
                                    accountOfficerInDb.Sbu = new Sbu
                                    {
                                        SbuId = (string)fields["sbu_id"],
                                        SbuName = (string)fields["sbu_desc"]
                                    };

                                }

                            }

                        }

                    }
                }
            }

            return structure;
        }

        public async Task<DateTime> GetMaxDate()
        {
            string sql = $"exec [dbo].[sp_max_date_retail]";

            var data = (await _sqlDataAccess.LoadData<dynamic>(sql)).Single<dynamic>();

            foreach (var rows in data)
            {
                data = rows.Value;
            }

            return data;
        }

        public async Task<dynamic> GetDirectoratesRetail(int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var sql = "sp_get_directorates_retail";
            var data = await _sqlDataAccess.SPLoadData<dynamic>(sql, new { p_month = monthAndYear.Month, p_year = monthAndYear.Year});

            return data;
        }
      
        public async Task<dynamic> GetRegionsRetail(string directorateCode, int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var sql = "sp_get_regions_retail";
            var data = await _sqlDataAccess.SPLoadData<dynamic>(sql, new { p_directorate_code = directorateCode, p_month = monthAndYear.Month, p_year = monthAndYear.Year });

            return data;
        }

        public async Task<dynamic> GetClustersRetail(string regionCode, int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var sql = "sp_get_clusters_retail";
            var data = await _sqlDataAccess.SPLoadData<dynamic>(sql, new { p_region_code = regionCode, p_month = monthAndYear.Month, p_year = monthAndYear.Year });

            return data;
        }

        public async Task<dynamic> GetZones(string regionCode, int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var data = await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.Structure_Zones, new { p_region_code = regionCode, p_month = monthAndYear.Month, p_year = monthAndYear.Year });

            return data;
        }

        public async Task<dynamic> GetBranchesRetail(string clusterCode, int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var sql = "sp_get_branches_retail";
            var data = await _sqlDataAccess.SPLoadData<dynamic>(sql, new { p_cluster_code = clusterCode, p_month = monthAndYear.Month, p_year = monthAndYear.Year });

            return data;
        }

        public async Task<dynamic> GetBranchesMain(string zoneCode, int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var data = await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.Structure_Branches_Main, new { p_zone_code = zoneCode, p_month = monthAndYear.Month, p_year = monthAndYear.Year });

            return data;
        }

        public async Task<dynamic> GetSbus(string branchCode, int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var sql = "sp_get_sbus";
            var data = await _sqlDataAccess.SPLoadData<dynamic>(sql, new { branch_code = branchCode, p_month = monthAndYear.Month, p_year = monthAndYear.Year });

            return data;
        }

        public async Task<dynamic> GetAccountOfficers(string branchCode, string sbuCode, int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var sql = "sp_get_account_officers";
            var data = await _sqlDataAccess.SPLoadData<dynamic>(sql, new { p_branch_code = branchCode, p_sbu_code = sbuCode, p_month = monthAndYear.Month, p_year = monthAndYear.Year });

            return data;
        }

        public async Task<DateTime> GetMonthAndYearAsync(int? month, int? year)
        {
            var maxDateInDb = await GetMaxDate();
            var _month = month == null ? maxDateInDb.Month : month;
            var _year = year == null ? maxDateInDb.Year : year;

            return new DateTime((int)_year, (int)_month, 1);
        }

        public async Task<dynamic> GetTransactionsAsync(string branchCode, string glAccount, int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var data = await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.Structure_Transactions, new { p_branch_code = branchCode, p_gl_account = glAccount, p_month = monthAndYear.Month, p_year = monthAndYear.Year });

            return data;
        }

        public async Task<dynamic> GetCaptions()
        {
            var data = await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.ExpenseCaptions);

            return data;
        }
        
        public async Task<dynamic> GetExchangeRates()
        {
            var data = await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.ExchangeRates);

            return data;
        }

        public async Task<dynamic> GetBranchesAccounts(string branchCode, string caption, string staffId, int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var data = await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.BranchesExpenseAccounts, new { pBranch = branchCode, pCaption = caption, pStaffID = staffId, pMonth = monthAndYear.Month, pYear = monthAndYear.Year });

            return data;
        }

        public async Task<dynamic> GetGLAccountsAsync(string branchCode, int? month, int? year)
        {
            var monthAndYear = await GetMonthAndYearAsync(month, year);
            var data = await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.Structure_GLAccounts, 
                new { p_branch_code = branchCode, p_month = monthAndYear.Month, p_year = monthAndYear.Year });

            return data;
        }


        public async Task<dynamic> GetDepartments()
        {
            var data = await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.Departments);

            return data;
        }

        public async Task<dynamic> GetGlSubHeads()
        {
            var data = await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.GlSubHeads);

            return data;
        }
    }
}
