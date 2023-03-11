using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo { Title = "Wema Analytics Reports API", Version = "v1" }));
            services.AddScoped<IDeposit, DepositService>();
            services.AddScoped<ILoan, LoanService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<ICommissionsAndFeesService, CommissionsAndFeesService>();
            services.AddScoped<IAPRService, APRService>();
            services.AddScoped<IPPRService, PPRService>();
            services.AddScoped<IMPRReport, MPRReportService>();
            services.AddScoped<ICardsService, CardsService>();
            services.AddScoped<IAgencyOnboardingService, AgencyOnboardingService>();
            services.AddScoped<SqlDataAccess, SqlDataAccess>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
