using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Common;

namespace WemaAnalyticsAPI.Domain
{
    public static class StoredProcedureNames
    {
        public static readonly string AccountStatusByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("AccountStatusByCluster").Value;
        public static readonly string AccountStatusByClusterAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("AccountStatusByClusterAccounts").Value;
        public static readonly string AgentOnBoardingByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("AgentOnBoardingByCluster").Value;
        public static readonly string AgentOnBoardingByClusterAgents = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("AgentOnBoardingByClusterAgents").Value;
        public static readonly string CardIssuanceByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("CardIssuanceByCluster").Value;
        public static readonly string CardIssuanceByClusterAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("CardIssuanceByClusterAccounts").Value;
        public static readonly string DepositsByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("DepositsByCluster").Value;
        public static readonly string DepositsByClusterAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("DepositsByClusterAccounts").Value;
        public static readonly string AlcoDepositsByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("AlcoDepositsByCluster").Value;
        public static readonly string AlcoDepositsByClusterAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("AlcoDepositsByClusterAccounts").Value;
        public static readonly string LoansByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("LoansByCluster").Value;
        public static readonly string LoansByClusterAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("LoansByClusterAccounts").Value;
        public static readonly string AlcoLoansByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("AlcoLoansByCluster").Value;
        public static readonly string AlcoLoansByClusterAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("AlcoLoansByClusterAccounts").Value;
        public static readonly string MTDAccountActivityByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("MTDAccountActivityByCluster").Value;
        public static readonly string MTDAccountActivityByClusterAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("MTDAccountActivityByClusterAccounts").Value;
        public static readonly string NewLoansSalesByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("NewLoansSalesByCluster").Value;
        public static readonly string NewLoansSalesByClusterAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("NewLoansSalesByClusterAccounts").Value;
        public static readonly string NewToBankAlatByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("NewToBankAlatByCluster").Value;
        public static readonly string NewToBankAlatByClusterAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("NewToBankAlatByClusterAccounts").Value;
        public static readonly string YTDAccountActivityByCluster = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("YTDAccountActivityByCluster").Value;
        public static readonly string YTDAccountActivityByClusterAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("YTDAccountActivityByClusterAccounts").Value;
   
        // STRUCTURE
        public static readonly string Structure_GLAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Structure").GetSection("GLAccounts").Value;
        public static readonly string Structure_Transactions = Utility.AppConfiguration().GetSection("SP").GetSection("Structure").GetSection("Transactions").Value;
        public static readonly string Structure_Zones = Utility.AppConfiguration().GetSection("SP").GetSection("Structure").GetSection("Zones").Value;
        public static readonly string Structure_Branches_Main = Utility.AppConfiguration().GetSection("SP").GetSection("Structure").GetSection("BranchesMain").Value;
        
        public static readonly string ExchangeRates = Utility.AppConfiguration().GetSection("SP").GetSection("ExchangeRates").Value;

        // EXPENSE REPORT
        public static readonly string BranchesExpenseMTD = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("BranchesExpenseMTD").Value;
        public static readonly string BranchesExpenseYTD = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("BranchesExpenseYTD").Value;
        public static readonly string BranchesExpenseTransactionsMTD = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("BranchesExpenseTransactionsMTD").Value;
        public static readonly string BranchesExpenseTransactionsYTD = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("BranchesExpenseTransactionsYTD").Value;
        public static readonly string BranchesExpenseAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("BranchesExpenseAccounts").Value;
        public static readonly string ExpenseCaptions = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("ExpenseCaptions").Value;

        public static readonly string HeadOfficeExpense = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("HeadOfficeExpense").Value;
        public static readonly string HeadOfficeExpenseTransactions = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("HeadOfficeExpenseTransactions").Value;
        public static readonly string HeadOfficeExpenseAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("HeadOfficeExpenseAccounts").Value;
        
        public static readonly string RetailExpense = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("RetailExpense").Value;
        public static readonly string RetailExpenseTransactions = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("RetailExpenseTransactions").Value;
        public static readonly string RetailExpenseAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("RetailExpenseAccounts").Value;


        // COMMISSIONS AND FEES
        public static readonly string CommissionsAndFees = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("CommissionsAndFees").Value;
        public static readonly string CommissionsAndFeesAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("CommissionsAndFeesAccounts").Value;
   
        // APR REPORT
        public static readonly string APRTop = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("APRTop").Value;
        public static readonly string APRBottom = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("APRBottom").Value;
        public static readonly string APRFilters = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("APRFilters").Value;
        public static readonly string APRSearchQuery = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("APRSearchFilter").Value;

        // MPR BALANCE SHEET
        public static readonly string MPRBalanceSheetTotalAssets = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("MPRBalanceSheetTotalAssets").Value;
        public static readonly string MPRBalanceSheetTotalLiabilities = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("MPRBalanceSheetTotalLiabilities").Value; 
        public static readonly string MPRBalanceSheetCCYAssets = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("MPRBalanceSheetCCYAssets").Value;
        public static readonly string MPRBalanceSheetCCYLiabilities = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("MPRBalanceSheetCCYLiabilities").Value;
        public static readonly string MPRIncomeStatement = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("MPRIncomeStatement").Value;
        public static readonly string MPRIncomeStatementCaptions = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("MPRIncomeStatementCaptions").Value;
        public static readonly string MPRIncomeStatementAccounts = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("MPRIncomeStatementAccounts").Value;
        public static readonly string MPRLandingViewData = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("MPRLandingViewData").Value;

        //PPR REPORT
        public static readonly string PPR = Utility.AppConfiguration().GetSection("SP").GetSection("Reports").GetSection("PPR").Value;

        // DEPARTMENTS
        public static readonly string Departments = Utility.AppConfiguration().GetSection("SP").GetSection("Structure").GetSection("Departments").Value;
       
        // GL Sub Heads
        public static readonly string GlSubHeads = Utility.AppConfiguration().GetSection("SP").GetSection("Structure").GetSection("GlSubHeads").Value;
    }
}
