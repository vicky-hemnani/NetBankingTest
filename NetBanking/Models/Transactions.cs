using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBanking.Models
{
    public class Transactions
    {
        private DateTime transactionTime;
        private double creditAmount;
        private double debitAmount;
        private double totalBalance;
        private int transactionperhour;

        public int Transactionperhour
        {
            get { return transactionperhour; }
            set { transactionperhour = value; }
        }

        public DateTime lastTransaction { get; set; }

        public DateTime TransactionTime
        {
            get { return transactionTime; }
            set { transactionTime = value; }
        }

        public Transactions()
        {

        }

        Transactions(DateTime transactionTime,double crediAmount,double totalBalance,DateTime lastTransaction)
        {
            this.transactionTime = transactionTime;
            this.creditAmount = crediAmount;
            this.totalBalance = totalBalance;   
            this.lastTransaction = lastTransaction; 
        }
        Transactions(double debitAount, DateTime transactionTime, double totalBalance, DateTime lastTransaction)
        {
            this.debitAmount = debitAount;
            this.transactionTime = transactionTime;
            this.totalBalance=totalBalance;
            this.lastTransaction=lastTransaction;
        }
        public double CreditAmount
        {
            get { return creditAmount; }
            set { creditAmount = value; }
        }

        public double DebitAmount
        {
            get { return debitAmount; }
            set { debitAmount = value; }
        }

        public double TotalBalance
        {
            get { return totalBalance; }
            set { totalBalance = value; }
        }
    }
}
