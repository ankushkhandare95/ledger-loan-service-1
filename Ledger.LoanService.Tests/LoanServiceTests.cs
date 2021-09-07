using System;
using System.Linq;
using Ledger.LoanService.Common;
using Xunit;

namespace Ledger.LoanService.Tests
{
    public class LoanServiceTests
    {
        [Fact]
        public void LoanClass_InitializeMembers_WhenConstructorIsCalled()
        {
            var loan = new Loan("BankName", "borrowerName", 20000, 3, 5);
            
            Assert.Equal("BankName", loan.BankName);
            Assert.Equal("borrowerName", loan.BorrowerName);
            Assert.Equal(20000, loan.Principal);
            Assert.Equal(3000, loan.Interest);
            Assert.Equal(639, loan.Emi);
            Assert.Empty(loan.LumpSumPayments);
        }
        
        [Fact]
        public void PaymentClass_InitializeMembers_WhenConstructorIsCalled()
        {
            var payment = new Payment("BankName", "borrowerName", 2000, 3);
            
            Assert.Equal("BankName", payment.BankName);
            Assert.Equal("borrowerName", payment.BorrowerName);
            Assert.Equal(3, payment.EmiNumber);
            Assert.Equal(2000, payment.LumpSumAmount);
        }
        
        [Fact]
        public void BalanceClass_InitializeMembers_WhenConstructorIsCalled()
        {
            var balance = new Balance("BankName", "borrowerName",  3);
            
            Assert.Equal("BankName", balance.BankName);
            Assert.Equal("borrowerName", balance.BorrowerName);
            Assert.Equal(3, balance.EmiNumber);
        }

        [Fact]
        public void ManageLoanClass_ShouldInitialize_WhenConstructorIsCalled()
        {
            var manageLoan = new ManageLoan();
            
            Assert.Empty(manageLoan.Loans);
        }
        
        [Fact]
        public void MakePaymentMethod_ShouldAddLumpSumPaymentObject_WhenCalled()
        {
            var manageLoan = new ManageLoan();
            manageLoan.Loans.Add(new Loan("BankName", "borrowerName", 20000, 3, 5));
            manageLoan.Loans.Add(new Loan("BankName1", "borrowerName1", 10000, 2, 5));
            
            manageLoan.MakePayment(new Payment("BankName", "borrowerName", 2000, 3));
            
            Assert.Single(manageLoan.Loans.Find( loan =>loan.BorrowerName == "borrowerName").LumpSumPayments);
        }
        
        [Fact]
        public void MakePaymentMethod_Should_Not_AddLumpSumPaymentObject_WhenLoanNotFound()
        {
            var manageLoan = new ManageLoan();
            manageLoan.Loans.Add(new Loan("BankName", "borrowerName", 20000, 3, 5));
            
            manageLoan.MakePayment(new Payment("incorrectBank", "incorrectBorrower", 2000, 3));
            
            Assert.Empty(manageLoan.Loans.First().LumpSumPayments);
        }
        
        [Fact]
        public void CheckBalanceMethod_Should_AddLumpSumPaymentObject_WhenLoanNotFound()
        {
            var manageLoan = new ManageLoan();
            manageLoan.Loans.Add(new Loan("BankName", "borrowerName", 20000, 3, 5));
            
            manageLoan.MakePayment(new Payment("incorrectBank", "incorrectBorrower", 2000, 3));
            
            Assert.Empty(manageLoan.Loans.First().LumpSumPayments);
        }
    }
}