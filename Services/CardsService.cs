using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Domain;

namespace WemaAnalyticsAPI.Services
{
    public class CardsService : ICardsService
    {
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly IMapper _mapper;
        private readonly ICommonService _commonService;

        public CardsService(SqlDataAccess sqlDataAccess, IMapper mapper, ICommonService commonService)
        {
            _sqlDataAccess = sqlDataAccess;
            _mapper = mapper;
            _commonService = commonService;
        }
        public async Task<dynamic> GetCardIssuanceByCluster(CardIssuanceRequest cardIssuanceRequest)
        {
            var maxMonthYear = await _commonService.GetMonthAndYearAsync(null, null);
            if (cardIssuanceRequest.Month == null || cardIssuanceRequest.Year == null)
            {
                cardIssuanceRequest.Month = maxMonthYear.Month;
                cardIssuanceRequest.Year = maxMonthYear.Year;
            }
            var spName = StoredProcedureNames.CardIssuanceByCluster;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pDirectorateCode = @DirectorateCode ," +
                $"@pRegionCode = @RegionCode," +
                $"@pClusterCode = @ClusterCode," +
                $"@pBranchCode = @BranchCode," +
                $"@pSBU = @SbuCode," +
                $"@pAccountOfficer = @AccountOfficerCode," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, cardIssuanceRequest);
        }

        public async Task<dynamic> GetCardIssuanceByClusterCards(CardIssuanceCardsRequest cardIssuanceCardsRequest)
        {
            var mtdActivityAccount = _mapper.Map<CardsIssuanceCards>(cardIssuanceCardsRequest);

            var maxDateInDb = await _commonService.GetMaxDate();
            mtdActivityAccount.Month = (mtdActivityAccount.Month == null) ? maxDateInDb.Month : mtdActivityAccount.Month;
            mtdActivityAccount.Year = (mtdActivityAccount.Year == null) ? maxDateInDb.Year : mtdActivityAccount.Year;

            var spName = StoredProcedureNames.CardIssuanceByClusterAccounts;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, mtdActivityAccount);
        }
    }
}
