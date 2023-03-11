using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        
        public static class Common
        {
            public const string GetMaxDate = Base + "/maxdate";
            public const string GetDirectorates = Base + "/structure/global";
            public const string GetRetailStructure = Base + "/structure/retail";

            public const string GetDirectoratesRetail = Base + "/structure/directorates";
            public const string GetRegionsRetail = Base + "/structure/regions";
            public const string GetClustersRetail = Base + "/structure/clusters";
            public const string GetZones = Base + "/structure/zones";
            public const string GetBranchesRetail = Base + "/structure/branches";
            public const string GetBranchesMain = Base + "/structure/branches-main";
            public const string GetSbus = Base + "/structure/sbus";
            public const string GetAccountOfficers = Base + "/structure/account-officers";
            public const string GetTransactions = Base + "/structure/transactions";
            public const string GetGLAccounts = Base + "/structure/gl-accounts";
            public const string GetCaptions = Base + "/structure/captions";
            public const string GetBranchesAccountWithGLSubHeadCodes = Base + "/structure/branchesAccounts";

            public const string GetDepartments = Base + "/departments";
            public const string GetExchangeRates = Base + "/exchangeRates";
            public const string GetGlSubHeads = Base + "/glsubheads";

        }

        public static class Reports
        {
            public static class DepositsByCluster
            {
                public const string GetAll = Base + "/reports/depositsByCluster";
                public const string GetAccounts = Base + "/reports/depositsByClusterAccounts";  // getDepositReportAccounts
            }

            public static class AlcoDepositsByCluster
            {
                public const string GetAll = Base + "/reports/alcoDepositsByCluster";
                public const string GetAccounts = Base + "/reports/alcoDepositsByClusterAccounts";  // getAlcoDepositReportAccounts
            }

            public static class AccountStatusByCluster
            {
                public const string GetAll = Base + "/reports/accountStatusByCluster";
                public const string GetAccounts = Base + "/reports/accountStatusByClusterAccounts";
            }

            public static class LoansByCluster
            {
                public const string GetAll = Base + "/reports/loansByCluster";
                public const string GetAccounts = Base + "/reports/loansByClusterAccounts";  // getLoanReportAccounts
            }

            public static class AlcoLoansByCluster
            {
                public const string GetAll = Base + "/reports/alcoLoansByCluster";
                public const string GetAccounts = Base + "/reports/alcoLoansByClusterAccounts";  // getAlcoLoanReportAccounts
            }

            public static class MTDAccountActivityByCluster
            {
                public const string GetAll = Base + "/reports/mtdAccountActivityByCluster";
                public const string GetAccounts = Base + "/reports/mtdAccountActivityByClusterAccounts";
            }

            public static class YTDAccountActivityByCluster
            {
                public const string GetAll = Base + "/reports/ytdAccountActivityByCluster";
                public const string GetAccounts = Base + "/reports/ytdAccountActivityByClusterAccounts";
            }

            public static class CardIssuanceByCluster
            {
                public const string GetAll = Base + "/reports/cardIssuanceByCluster";
                public const string GetCards = Base + "/reports/cardIssuanceByClusterAccounts";
            }

            public static class NewToBankAlatByCluster
            {
                public const string GetAll = Base + "/reports/newToBankAlatByCluster";
                public const string GetAccounts = Base + "/reports/newToBankAlatByClusterAccounts";
            }

            public static class NewLoanSalesByCluster
            {
                public const string GetAll = Base + "/reports/newLoanSalesByCluster";
                public const string GetAccounts = Base + "/reports/newLoanSalesByClusterAccounts";
            }

            public static class AgentOnboardingByCluster
            {
                public const string GetAll = Base + "/reports/agentOnboardingByCluster";
                public const string GetAgency = Base + "/reports/agentOnboardingByClusterAgents";
            }

            public static class BranchesExpense
            {
                public const string GetAllBranchesExpense = Base + "/report/branchesExpense";
                public const string GetBranchesExpenseTransactions = Base + "/report/branchesExpenseTransactions";
            }
            
            public static class HeadOfficeExpense
            {
                public const string GetAllHeadOfficeExpense = Base + "/report/headOfficeExpense";
                public const string GetHeadOfficeExpenseTransactions = Base + "/report/headOfficeExpenseTransactions";
                public const string GetHeadOfficeExpenseAccounts = Base + "/report/headOfficeExpenseTransactions";
            } 
            
            public static class RetailExpense
            {
                public const string GetAllRetailExpense = Base + "/report/retailExpense";
                public const string GetRetailExpenseTransactions = Base + "/report/retailExpenseTransactions";
            }



            public static class CommissionsAndFees
            {
                public const string GetAll = Base + "/reports/commissionsAndFees";
                public const string GetAccounts = Base + "/reports/commissionsAndFeesAccounts";
            }

            public static class APR_Report
            {
                public const string GetAll = Base + "/reports/aprreport";
                public const string GetFilters = Base + "/reports/aprreport/filters";
                public const string GetViaQuery = Base + "/reports/aprreportQuery";
            }

            public static class MPR_Report
            {
                public const string GetAll = Base + "/reports/mprBalanceSheet";
                public const string GetAllTest = Base + "/reports/mprBalanceSheetTest";
                public const string GetAllIncomeStatement = Base + "/reports/mprIncomeStatement";
                public const string GetLandingViewData = Base + "/reports/mprLandingViewData";
                public const string GetAllIncomeStatementAccount = Base + "/reports/mprIncomeStatementAccounts";
            }

            public static class PPR_Report
            {
                public const string GetAll = Base + "/reports/pprReport";
            }
        }

    }
}
