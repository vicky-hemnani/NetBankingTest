using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBanking.DummyData;
using NetBanking.Models;
using NetBanking.Controller;

namespace ConsoleBaking
{
    public class Program
    {
        static Dictionary<string, Customer> custData;
        static Dictionary<string, Accounts> accData;
        static string accountNo,customerID;
        static void Main(string[] args)
        {
            CustomerData o1 = new CustomerData();
            o1.LoadData();

            custData = CustomerData.customerData;
            accData = CustomerData.accountsData;

            string choice = "";

            while (choice!="5")
            {
                Console.Clear();
                Console.WriteLine("**********WELCOME TO BANKING APPLICATION**********");
                Console.WriteLine("Please Select any option...");
                Console.WriteLine("1] CREDIT/DEBIT MONEY.");
                Console.WriteLine("2] DISPLAY BALANCE OF YOUR ACCOUNT.");
                Console.WriteLine("3] DISPLAY BALANCE OF ALL ACCOUNTS");
                Console.WriteLine("4] DISPLAY YOUR ACCOUNT STATEMENT");
                Console.WriteLine("5]Exit");
                choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        DoTransaction();
                        break;
                    case "2":
                        DoDiplayAccountBalance();
                        break;
                    case "3":
                        DoDisplayCutomerAccounts();
                        break;
                    case "4":
                        DoDisplayAccountStatement();
                        break;
                    case "5":
                        Console.WriteLine("Thank you:))");
                        Thread.Sleep(1000);
                        break;
                    default:
                        break;
                }
            }
            
        }

        public static void DoTransaction()
        {

            bool checkAuth=DoAuthorization();
            if (checkAuth==false)
                return;



            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please Enter the Operation you want to perform.");
                Console.WriteLine("1] Deposit Money");
                Console.WriteLine("2] Withdraw Money");
                Console.WriteLine("3] Exit");
                string chtrans = Console.ReadLine();
                switch (chtrans)
                {
                    case "1":
                        {
                            PerformTransaction.DepositMoney(accountNo,accData);
                            //return;
                        }
                        break;
                    case "2":
                        {
                            PerformTransaction.WithdrawMoney(accountNo, accData);
                            //return;
                        }
                        break;
                    case "3":
                        return;
                        break;
                    default:
                        Console.WriteLine("Please, Enter Correct Choice..");
                        Thread.Sleep(1000);
                        break;
                }
            }

            Console.Clear();

        }

        public static void DoDiplayAccountBalance()
        {
            bool checkAuth = DoAuthorization();
            if (checkAuth==false)
                return;
            PerformTransaction.ShowAccountBalance(accountNo,accData);
            Console.WriteLine("Press Enter key to Exit");
            Console.ReadLine();
        }

        public static void DoDisplayCutomerAccounts()
        {
            bool checkCustomer = DoCustomerAuth();
            if (checkCustomer==false)
                return;
            PerformTransaction.ShowCustomerAccountBalance(customerID, custData, accData);

        }

        public static void DoDisplayAccountStatement()
        {
            bool checkAuth = DoAuthorization();
            if (checkAuth==false)
                return;
            PerformTransaction.ShowAccountStatement(accountNo, accData);
        }


        public static bool DoAuthorization()
        {

            bool checkCustomer = DoCustomerAuth();
            if (checkCustomer==false)
                return false;
            foreach (KeyValuePair<string, Accounts> kvp in accData)
            {
                Console.WriteLine("Key = {0}", kvp.Key);
            }

            Console.WriteLine("Please Enter Your Accout No.");
            accountNo = Console.ReadLine();

            bool checkacc = PerformValidation.CheckAccount(accountNo, customerID, accData);
            if (checkacc==false)
                return false;

            return true;
        }

        public static bool DoCustomerAuth()
        {

            foreach (KeyValuePair<string, Customer> kvp in custData)
            {
                Console.WriteLine("Key = {0}", kvp.Key);
            }

            Console.WriteLine("Please Enter your Customer ID");
            customerID = Console.ReadLine();
            bool checkcus = PerformValidation.CheckCustomer(customerID, custData);
            if (checkcus==false)
                return false;

            Console.Clear();

            try
            {
                Console.WriteLine("Please Enter Your Pin No");
                int pinNo = Int32.Parse(Console.ReadLine());
                bool checkpin = PerformValidation.CheckPin(custData, customerID, pinNo);
                if (checkpin==false)
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Pin!");
                Thread.Sleep(500);
                return false;
            }

            Console.Clear();
            return true;
        }
    }
}