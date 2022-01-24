using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBanking.Models;

namespace NetBanking.Models
{
    public class Customer
    {

        private int pinNo;
        private List<Accounts> accountNo;
        private string customerId;
        private string customerFName;
        private string customerLName;

        public Customer()
        {

        }

        public Customer(string customerId,string customerFName,string customerLName,int pinNo)
        {
            accountNo = new List<Accounts>();
            this.customerId = customerId;
            this.customerFName =customerFName;
            this.customerLName =customerLName;
            this.pinNo =pinNo;
        }
        public string CustomerId {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
            }
        }
        public string CustomerFName
        {
            get
            {
                return customerFName;
            }
            set
            {
                customerFName = value;
            }
        }
        public string CustomerLNAme
        {
            get
            {
                return customerLName;
            }
            set
            {
                customerLName = value;
            }
        }
        public int PinNo {
            get
            {
                return pinNo;
            }
            set
            {
                pinNo = value;
            } 
        }
        public List<Accounts> AccountNo
        {
            get
            {
                return accountNo;
            }
            set
            {
                accountNo = value;
            }
        } 
    }
}
