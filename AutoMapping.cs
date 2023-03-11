using AutoMapper;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.Domain;

namespace ProjectMood.Domain.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // ViewModel  --> Model       --> Entities
            // AccountDTO --> --> Account

         
            // Deposits Report
            CreateMap<GetReportRequest, ReportStructure>();
            CreateMap<AccountRequest, AccountReport>();
            CreateMap<GetAlcoRequest, AlcoReport>();
            CreateMap<GetAlcoAccountRequest, AlcoAccountReport>();

            // Account status
            CreateMap<GetAccountStatusAccountRequest, AccountStatusAccount>();
            CreateMap<GetAccountStatusRequest, AccountStatus>();

            // Card Issuance
            CreateMap<CardIssuanceRequest, CardIssuance>();
            CreateMap<CardIssuanceCardsRequest, CardsIssuanceCards>();
        }
    }
}