using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBanking.Models;

namespace NetBanking.Controller
{
    class PerformTransaction
    {
        static double maxWithdrwalAmount=0;

        public static void DepositMoney(string accountNo, Dictionary<string, Accounts> accData)
        {
            double creditAmt;
            try
            {
                Console.WriteLine("Enter Amount You want to desposit..");
                creditAmt = Double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Amount");
                return;
            }

            if (creditAmt%100==0 && creditAmt>0)
            {
                
                    List<Transactions> transctlist = accData[accountNo].TransactionsList;
                    Transactions trans = new Transactions();
                if (transctlist.Count==0)
                    {
                        trans.CreditAmount=creditAmt;
                        trans.TotalBalance=creditAmt;
                        trans.TransactionTime=DateTime.Now;
                        trans.lastTransaction=DateTime.Now;
                        trans.Transactionperhour=1;
                        transctlist.Add(trans);
                    }
                    else
                    {
                        
                        Transactions lasttrans = transctlist[transctlist.Count-1];
                        TimeSpan diff = DateTime.Now - lasttrans.lastTransaction;

                        if (diff.TotalHours > 1)
                        {
                            trans.lastTransaction = DateTime.Now;
                            trans.Transactionperhour=1;
                        }
                        else
                        {
                            trans.lastTransaction=lasttrans.lastTransaction;
                            if (lasttrans.Transactionperhour==4)
                            {
                                Console.WriteLine("Sorry, You have exceeded maximum amount of transactoin per hour..");
                                Thread.Sleep(1000);
                                return;
                            }
                            trans.Transactionperhour=lasttrans.Transactionperhour+1;
                        }
                        trans.TransactionTime = DateTime.Now;
                        trans.CreditAmount= creditAmt;
                        trans.TotalBalance=lasttrans.TotalBalance+creditAmt;
                        transctlist.Add(trans);
                        accData[accountNo].TransactionsList= transctlist;
                        //foreach (Transactions t in transctlist)
                        //{
                        //    Console.WriteLine("1] "+t.CreditAmount+" 2]"+t.TotalBalance+" 3]"+t.Transactionperhour+" 4]"+t.lastTransaction);
                        //}

                    
                    }
                    Console.WriteLine("Succesfully Credited "+creditAmt+" Rs");
                    Console.WriteLine("Your net balance is "+trans.TotalBalance);
                    Thread.Sleep(2000);

            }
            else if(creditAmt<0)
            {
                Console.WriteLine("Invalid Amount..");
                Thread.Sleep(1000);
                return;
            }
            else
            {
                Console.WriteLine("Sorry, You can only deposit money in multiples of 100..");
                Thread.Sleep(1000);
                return;
            }

        }

        public static void WithdrawMoney(string accountNo, Dictionary<string, Accounts> accData)
        {
            double debitAmt;
            try
            {
                Console.WriteLine("Enter Amount You want to Withdraw..");
                debitAmt = Double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Amount");
                return;
            }


            if (debitAmt%100==0 && debitAmt>0)
            {
            }
            else
            {
                Console.WriteLine("Sorry, You can only withdraw money in multiples of 100..");
                Thread.Sleep(1000);
                return;
            }

            List<Transactions> transctlist = accData[accountNo].TransactionsList;
            if(transctlist.Count==0)
            {
                Console.WriteLine("Sorry, You don't have enough Balance to withdraw Money.");
                Thread.Sleep(1000);
                return;
            }

            Transactions lasttrans = transctlist[transctlist.Count-1];
            if (debitAmt>lasttrans.TotalBalance)
            {
                Console.WriteLine("Sorry, You don't have enough Balance to withdraw Money.");
                Thread.Sleep(1000);
                return;
            }

            if(debitAmt>50000)
            {
                Console.WriteLine("Sorry, You can not withdraw 50,000Rs in 1 transaction");
                Thread.Sleep(1000);
                return;
            }

           
            Transactions trans = new Transactions();
            TimeSpan diff = DateTime.Now - lasttrans.lastTransaction;

            if(debitAmt>30000 && (lasttrans.TotalBalance-debitAmt-30<0))
            {
                Console.WriteLine("Sorry, You are running out of balance to perform transaction.");
                Thread.Sleep(500);
                return;
            }

            if (diff.TotalHours > 1)
            {
                trans.lastTransaction = DateTime.Now;
                trans.Transactionperhour=1;
                maxWithdrwalAmount=0;
            }
            
            else
            {
                
                trans.lastTransaction=lasttrans.lastTransaction;
                if (lasttrans.Transactionperhour==4)
                {
                    Console.WriteLine("Sorry, You have exceeded maximum amount of transactoin per hour..");
                    Thread.Sleep(1000);
                    return;
                }
                maxWithdrwalAmount=maxWithdrwalAmount+debitAmt;
                if (maxWithdrwalAmount>200000)
                {
                    Console.WriteLine("Sorry, You have exceeded maximum amount of transactoin per hour..");
                    Thread.Sleep(1000);
                    return;
                }
                trans.TransactionTime = DateTime.Now;
                trans.Transactionperhour=lasttrans.Transactionperhour+1;
            }

            trans.TotalBalance=lasttrans.TotalBalance-debitAmt;
            trans.DebitAmount= debitAmt;
            if (debitAmt>30000)
            {
                Transactions debitextra = new Transactions();
                debitextra.DebitAmount= 30;
                debitextra.TransactionTime = DateTime.Now;
                debitextra.TotalBalance=trans.TotalBalance-debitextra.DebitAmount;
                debitextra.Transactionperhour=trans.Transactionperhour;
                debitextra.lastTransaction=trans.lastTransaction;
                transctlist.Add(trans);
                transctlist.Add(debitextra);

            }
            else
                transctlist.Add(trans);



            accData[accountNo].TransactionsList= transctlist;
            //foreach (Transactions t in transctlist)
            //{
            //    Console.WriteLine("1] "+t.DebitAmount+" 2]"+t.TotalBalance+" 3]"+t.Transactionperhour);
            //}

            Console.WriteLine("Succesfully Debited "+debitAmt+" Rs");
            Console.WriteLine("Your net balance is "+trans.TotalBalance);
            Thread.Sleep(2000);
        }

        public static void ShowAccountBalance(string accountNo, Dictionary<string,Accounts> accData)
        {
            List<Transactions> transctlist = accData[accountNo].TransactionsList;
            if(transctlist.Count==0)
            {
                Console.WriteLine("Sorry you have not yet performed any transactions in this Account.");
                Thread.Sleep(1000);
                return ;
            }
            Transactions lasttrans = transctlist[transctlist.Count-1];
            Console.WriteLine("Your net balance is "+lasttrans.TotalBalance);
            Console.WriteLine();
        }

        public static void ShowCustomerAccountBalance(string customerID,Dictionary<string,Customer> cusData,Dictionary<string,Accounts> accData)
        {
            Console.WriteLine("Welcome "+cusData[customerID].CustomerFName+" "+cusData[customerID].CustomerLNAme+" ...");
            List<Accounts> custAcc = cusData[customerID].AccountNo;
            foreach(Accounts acc in custAcc)
            {
                Console.WriteLine("Your Account is of type: "+acc.AccType);
                ShowAccountBalance(acc.AccNo, accData);
            }
            Console.WriteLine("Press Enter key to Exit");
            Console.ReadLine();
        }

        public static void ShowAccountStatement(string accountNo,Dictionary<string,Accounts> accData)
        {
            List<Transactions> transctlist = accData[accountNo].TransactionsList;
            if (transctlist.Count==0)
            {
                Console.WriteLine("Sorry you have not yet performed any transactions in this Account.");
                Thread.Sleep(1000);
                return;
            }
            Console.WriteLine("Date\t\tTime\t\tDebit\tCredit\tTotal Balance");
            foreach(Transactions trans in transctlist)
            {
                if (trans.DebitAmount==0)
                    Console.WriteLine(value: trans.TransactionTime.ToShortDateString()+"\t"+trans.TransactionTime.ToShortTimeString()+"\t-\t"+trans.CreditAmount+"\t"+trans.TotalBalance);

                if (trans.CreditAmount==0)
                    Console.WriteLine(trans.TransactionTime.ToShortDateString()+"\t"+trans.TransactionTime.ToShortTimeString()+"\t"+trans.DebitAmount+"\t-\t"+trans.TotalBalance);

            }
            Console.WriteLine("Press Enter key to Exit");
            Console.ReadLine();
        }
    }
}
