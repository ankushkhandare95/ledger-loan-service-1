using System;
using System.Collections.Generic;

namespace Ledger.LoanService.Common
{
    public class ManageLoan
    {
        public List<Loan> Loans { get; set; }
        public ManageLoan()
        {
            Loans = new List<Loan>();
        }
        public void MakePayment(Payment payment)
        {
            var loanAccount = FindAccount(payment.BankName, payment.BorrowerName);
            if (loanAccount == null)
            {
                Console.WriteLine("Account Not Found");
                return;
            }
            loanAccount.LumpSumPayments.Add( new LumpSumPayment(payment.LumpSumAmount, payment.EmiNumber )) ;

        }

        public void CheckBalance(Balance balance)
        {
            var loanAccount = FindAccount(balance.BankName, balance.BorrowerName);
            if (loanAccount == null)
            {
                Console.WriteLine("Account Not Found");
                return;
            }
            
            var lumpSumAmount = GetLumpSumAmountPayed(balance, loanAccount);
            
            var amountToBePayed = loanAccount.Principal + loanAccount.Interest;
            var amountPayed = lumpSumAmount + (loanAccount.Emi * balance.EmiNumber);
            var remainingEmi = Math.Ceiling((amountToBePayed - amountPayed)/ loanAccount.Emi);
            Console.WriteLine("{0} {1} {2} {3}", loanAccount.BankName, loanAccount.BorrowerName, amountPayed, remainingEmi);
        }

        private static double GetLumpSumAmountPayed(Balance balance, Loan loanAccount)
        {
            double lumpSumAmount = 0;
            if (loanAccount.LumpSumPayments.Count > 0)
            {
                foreach (var loanAccountLumpSumPayment in loanAccount.LumpSumPayments)
                {
                    if (loanAccountLumpSumPayment.EmiNumber <= balance.EmiNumber)
                    {
                        lumpSumAmount += loanAccountLumpSumPayment.LumpSumAmount;
                    }
                }
            }

            return lumpSumAmount;
        }
        
        private Loan FindAccount(string bankName, string borrowerName)
        {
            return Loans.Find(loan => loan.BankName.Equals(bankName) && loan.BorrowerName.Equals(borrowerName));
        }
    }
}