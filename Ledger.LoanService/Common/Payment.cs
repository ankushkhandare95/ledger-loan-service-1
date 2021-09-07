namespace Ledger.LoanService.Common
{
    public class Payment: Account
    {
        public double LumpSumAmount { get; set; }
        public int EmiNumber { get; set; }

        public Payment(string bankName, string borrowerName, double lumpSumAmount, int emiNumber) : base(bankName,
            borrowerName)
        {
            LumpSumAmount = lumpSumAmount;
            EmiNumber = emiNumber;
        }

    }
}