using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Services
{
    public class DepositService : IDeposit
    {
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly IMapper _mapper;
        private readonly ICommonService _commonService;

        public DepositService(IServiceProvider provider, SqlDataAccess sqlDataAccess, IMapper mapper, ICommonService commonService)
        {
            _sqlDataAccess = sqlDataAccess;
            _mapper = mapper;
            _commonService = commonService;
        }

        public async Task<dynamic> GetDepositReports(GetReportRequest depositRequest)
        {
            var depositReportRequest = _mapper.Map<ReportStructure>(depositRequest);

            if (depositReportRequest.ReportDate == null)
            {
                depositReportRequest.ReportDate = await _commonService.GetMaxDate();
            }

            var spName = StoredProcedureNames.DepositsByCluster;
            //string storedProcedureName = "sp_deposits_retail";
            string sql = $"exec [dbo].[{spName}]" +
                $"@pDirectorateCode = @DirectorateCode ," +
                $"@pRegionCode = @RegionCode," +
                $"@pClusterCode = @ClusterCode," +
                $"@pBranchCode = @BranchCode," +
                $"@pSBU = @SbuCode," +
                $"@pAccountOfficer = @AccountOfficerCode," +
                $"@pStaffID = @StaffId," +
                $"@pRunDate = @ReportDate";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, depositReportRequest);
        }

        public async Task<dynamic> GetDepositAccounts(AccountRequest accountRequest)
        {
            var accountDepositReportRequest = _mapper.Map<AccountReport>(accountRequest);

            if (accountDepositReportRequest.ReportDate == null)
            {
                accountDepositReportRequest.ReportDate = await _commonService.GetMaxDate();
            }
            var spName = StoredProcedureNames.DepositsByClusterAccounts;
            string sql = $"exec  [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@pRunDate = @ReportDate";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, accountDepositReportRequest);
        }

        public async Task<dynamic> GetAlcoDepositReports(GetAlcoRequest alcoDepositRequest)
        {
            var alcoDepositReport = _mapper.Map<AlcoReport>(alcoDepositRequest);

            if (alcoDepositReport.DateFrom == null && alcoDepositReport.DateTo == null)
            {
                var maxDate =  await _commonService.GetMaxDate();
                alcoDepositReport.DateFrom = maxDate;
                alcoDepositReport.DateTo = maxDate;
            }

            var spName = StoredProcedureNames.AlcoDepositsByCluster;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pDirectorateCode = @DirectorateCode ," +
                $"@pRegionCode = @RegionCode," +
                $"@pClusterCode = @ClusterCode," +
                $"@pBranchCode = @BranchCode," +
                $"@pSBU = @SbuCode," +
                $"@pAccountOfficer = @AccountOfficerCode," +
                $"@pStaffID = @StaffId," +
                $"@p_date_from = @DateFrom," +
                $"@p_date_to = @DateTo";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, alcoDepositReport);
        }

        public async Task<dynamic> GetAlcoDepositAccounts(GetAlcoAccountRequest accountRequest)
        {
            var alcoDepositAccountReport = _mapper.Map<AlcoAccountReport>(accountRequest);

            if (alcoDepositAccountReport.ReportDate == null)
            {
                alcoDepositAccountReport.ReportDate = await _commonService.GetMaxDate();
            }
            var spName = StoredProcedureNames.AlcoDepositsByClusterAccounts;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@pType = @Type," +
                $"@pRunDate = @ReportDate";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, alcoDepositAccountReport);
        }

    }
}

