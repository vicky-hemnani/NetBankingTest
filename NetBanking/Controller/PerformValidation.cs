using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBanking.Models;
using NetBanking.DummyData;

namespace NetBanking.Controller
{
    class PerformValidation 
    {

        public static bool CheckCustomer(string customerID,Dictionary<string,Customer> custData)
        {
            if (customerID!="")
            {
                if (custData.ContainsKey(customerID)) { return true; }
                else
                {
                    Console.WriteLine("Sorry, We are unable to find your Customer Id");
                    Thread.Sleep(1000);
                    return false;
                }

            }
            else
            {
                Console.WriteLine("Please Enter Something....");
                Thread.Sleep(1000);
                return false;
            }
        }

        public static bool CheckAccount(string accountNo, string customerID, Dictionary<string,Accounts> accData)
        {
            if (accountNo!="")
            {
                if (accData.ContainsKey(accountNo)) 
                { 
                    if(accData[accountNo].Cid==customerID)
                    {
                        Console.WriteLine("Your Account is of type : "+accData[accountNo].AccType);
                        Thread.Sleep(1000);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Sorry the entered Account No. doesn't belongs to you...");
                        Thread.Sleep(1000);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, We are unable to find your Account No.");
                    Thread.Sleep(1000);
                    return false;
                }

            }
            else
            {
                Console.WriteLine("Please Enter Something....");
                Thread.Sleep(1000);
                return false;
            }
        }

        public static bool CheckPin(Dictionary<string,Customer> cusData,string customerID,int pinNo)
        {
            if (cusData[customerID].PinNo==pinNo)
            {
                Console.WriteLine("Correct Pin...");
                Thread.Sleep(500);
                return true;
            }
            else
            {
                Console.WriteLine("Sorry the entered Pin No. was wrong..");
                Thread.Sleep(1000);
                return false;
            }
            
        }
    }
}
