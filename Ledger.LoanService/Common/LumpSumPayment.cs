namespace Ledger.LoanService.Common
{
    public class LumpSumPayment
    {
        public double LumpSumAmount { get; set; }
        public int EmiNumber { get; set; }

        public LumpSumPayment(double lumpSumAmount, int emiNumber)
        {
            LumpSumAmount = lumpSumAmount;
            EmiNumber = emiNumber;
        }

    }
}