using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBanking.Models;

namespace NetBanking.DummyData
{
    public class CustomerData : Customer
    {
        public static Dictionary<string,Customer> customerData;
        public static Dictionary<string,Accounts> accountsData;

        public CustomerData()
        {
            customerData = new Dictionary<string,Customer>();
            accountsData = new Dictionary<string,Accounts>();   
        }

        public void LoadData()
        {
            Customer c1 = new Customer(Guid.NewGuid().ToString(),"Vicky","Hemnani",1999);
            Accounts c1a1 = new Accounts(c1.CustomerId,"savings", Guid.NewGuid().ToString());
            Accounts c1a2 = new Accounts(c1.CustomerId,"current", Guid.NewGuid().ToString());
            c1.AccountNo.Add(c1a1);
            c1.AccountNo.Add(c1a2);
            accountsData.Add(c1a1.AccNo, c1a1);
            accountsData.Add(c1a2.AccNo, c1a2);
            customerData.Add(c1.CustomerId, c1);

            Customer c2 = new Customer(Guid.NewGuid().ToString(), "Mihir", "Hemnani", 2002);
            Accounts c2a1 = new Accounts(c2.CustomerId,"Savings", Guid.NewGuid().ToString());
            Accounts c2a2 = new Accounts(c2.CustomerId,"Current", Guid.NewGuid().ToString());
            c2.AccountNo.Add(c2a1);
            c2.AccountNo.Add(c2a2);
            accountsData.Add(c2a1.AccNo, c2a1);
            accountsData.Add(c2a2.AccNo, c2a2);
            customerData.Add(c2.CustomerId, c2);

        }

    }
}
