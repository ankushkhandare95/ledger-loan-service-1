using System;
using System.Collections.Generic;

namespace Ledger.LoanService.Common
{
    public class Loan: Account
    {
        public double Principal { get; private set; }
        public double Interest { get; private set; }
        public List<LumpSumPayment> LumpSumPayments { get; private set; }
        public int Emi { get; private set; }


        public Loan(string bankName, string borrowerName, double principal, double numberOfYears, double rateOfInterest): base(bankName, borrowerName)
        {
            Principal = principal;
            Interest = principal * numberOfYears * (rateOfInterest / 100);
            Emi = (int)(Math.Ceiling((principal + Interest) / (numberOfYears * 12)));
            LumpSumPayments = new List<LumpSumPayment>();
        }
    }
}