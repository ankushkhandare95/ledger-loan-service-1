using System;
using System.Collections.Generic;
using System.IO;
using Ledger.LoanService.Common;

namespace Ledger.LoanService
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = File.OpenText("/Users/in-ankush.khandare/Study/DotNet/Ledger.LoanService/Ledger.LoanService/Input/LoanInput.txt");
            var manageLoan = new ManageLoan();
            try
            {
                string command;
                while ((command = reader.ReadLine()) != null)
                {
                    var input = command.Split(' ');
                    switch (input[0])
                    {
                        case "LOAN":
                            manageLoan.Loans.Add(new Loan(input[1], input[2], double.Parse(input[3]), double.Parse(input[4]),
                                int.Parse(input[5])));
                            break;
                        case "PAYMENT":
                            manageLoan.MakePayment(new Payment(input[1], input[2], double.Parse(input[3]), int.Parse(input[4])));

                            break;
                        case "BALANCE":
                            manageLoan.CheckBalance(new Balance(input[1], input[2], int.Parse(input[3])));

                            break;
                        default:
                            Console.WriteLine("Invalid COMMAND");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}