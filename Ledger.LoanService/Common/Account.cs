namespace Ledger.LoanService.Common
{
    public class Account
    {
        public string BankName { get; set; }
        public string BorrowerName { get; set; }

        protected Account(string bankName, string borrowerName)
        {
            BankName = bankName;
            BorrowerName = borrowerName;
        }
    }
}