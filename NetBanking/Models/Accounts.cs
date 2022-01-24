using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBanking.Models;

namespace NetBanking.Models
{
    public class Accounts
    {
        private string _cid;
        private string accType;
        private string accNo;
        private List<Transactions> transactionsList;
        private double balance;


        public Accounts(string cid,string accType, string accNo)
        {
            this._cid = cid;
            this.accType = accType;
            this.accNo = accNo;
            transactionsList=new List<Transactions>();
        }

        public string Cid
        {
            get { return _cid; }
            set { _cid = value; }
        }
        public string AccType
        {
            get { return accType; }
            set { accType = value; }
        }

        public string AccNo
        {
            get { return accNo; }   
            set { accNo = value; }
        }

        public List<Transactions> TransactionsList
        {
            get { return transactionsList; }
            set { transactionsList = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
    }
}
