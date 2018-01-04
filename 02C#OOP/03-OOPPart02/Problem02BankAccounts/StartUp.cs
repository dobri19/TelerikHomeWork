using System;

namespace Problem02BankAccounts
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bank zzz = new Bank("Zimbabwe");

            Customer Zoro = new Customer("Bai Zoro", "Astana 23", CustomerType.Individual);
            Customer Kirkovo = new Customer("Kirkovo", "Mono 10", CustomerType.Company);

            DepositAccount account01 = new DepositAccount(Zoro, 4567M, 3M);
            LoanAccount account02 = new LoanAccount(Kirkovo, 456757M, 3M);

            //Console.WriteLine(account01.CalcInterestAmount(4));
            //Console.WriteLine(account02.CalcInterestAmount(12));

            zzz.AddAccount(account01);
            zzz.AddAccount(account02);

            Console.WriteLine(zzz.ToString());
        }
    }
}
