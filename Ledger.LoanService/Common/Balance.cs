namespace Ledger.LoanService.Common
{
    public class Balance: Account
    {
        public int EmiNumber { get; set; }

        public Balance(string bankName, string borrowerName, int emiNumber) : base(bankName,
            borrowerName)
        {
            EmiNumber = emiNumber;
        }
    }
}