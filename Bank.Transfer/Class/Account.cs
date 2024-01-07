using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Transfer
{
    public class Account
    {
        private TypeAccount TypeAccount { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }



        public Account(TypeAccount typeAccount, double balance, double credit, string name)
        {
            this.TypeAccount = typeAccount;
            this.Balance = balance;
            this.Credit = credit;       
            this.Name = name;
        }

        public bool Withdraw(double withdrawValue) 
        {
            //Validation if there is enough money
            if(this.Balance - withdrawValue < (this.Credit * -1)){
                Console.WriteLine("Not enough money");
                return false;
            }
            this.Balance -= withdrawValue;
            Console.WriteLine("Current account balance of {0} it's {1}", this.Name, this.Balance);
            return true;
        }

        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;
            Console.WriteLine("Current account balance of {0} it's {1}", this.Name, this.Balance);
        }

        public void Transfer(double transferValue, Account destinationAccount)
        {
            if(this.Withdraw(transferValue))
            {
                destinationAccount.Deposit(transferValue);
            }
        }

        public override string ToString()
		{
            string return_string = "";
            return_string += "Account Type " + this.TypeAccount + " | ";
            return_string += "Name " + this.Name + " | ";
            return_string += "Balance " + this.Balance + " | ";
            return_string += "Credit " + this.Credit;
			return return_string;
		} 


    }
}