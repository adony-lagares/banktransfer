﻿using System;
using System.Collections.Generic;
using Bank.Transfer;

namespace DIO.Bank
{
	class Program
	{
		static List<Account> listAccount = new List<Account>();
		static void Main(string[] args)
		{
			string optionUser = GetUserOption();

			while (optionUser.ToUpper() != "X")
			{
				switch (optionUser)
				{
					case "1":
						ListAccounts();
						break;
					case "2":
						InsertAccount();
						break;
					case "3":
						Transfer();
						break;
					case "4":
						Withdraw();
						break;
					case "5":
						Deposit();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				optionUser = GetUserOption();
			}
			
			Console.WriteLine("Thank you for using our services.");
			Console.ReadLine();
		}

		private static void Deposit()
		{
			Console.Write("Enter account number: ");
			int indexAccount = int.Parse(Console.ReadLine());

			Console.Write("Enter the amount to be deposited: ");
			double valueDeposit = double.Parse(Console.ReadLine());

            listAccount[indexAccount].Deposit(valueDeposit);
		}

		private static void Withdraw()
		{
			Console.Write("Enter account number: ");
			int indexAccount = int.Parse(Console.ReadLine());

			Console.Write("Enter the amount to be withdrawn: ");
			double valueWithdraw = double.Parse(Console.ReadLine());

            listAccount[indexAccount].Withdraw(valueWithdraw);
		}

		private static void Transfer()
		{
			Console.Write("Enter the originating account number: ");
			int indexOriginAccount = int.Parse(Console.ReadLine());

            Console.Write("Enter the destination account number: ");
			int indexDestAccount = int.Parse(Console.ReadLine());

			Console.Write("Enter the amount to be transferred: ");
			double valueTrasnfer = double.Parse(Console.ReadLine());

            listAccount[indexOriginAccount].Transfer(valueTrasnfer, listAccount[indexDestAccount]);
		}

		private static void InsertAccount()
		{
			Console.WriteLine("Enter new account");

			Console.Write("Enter 1 for Physical Account or 2 for Legal Account: ");
			int enterTypeAccount = int.Parse(Console.ReadLine());

			Console.Write("Enter Customer Name: ");
			string enterName = Console.ReadLine();

			Console.Write("Enter the opening balance: ");
			double enterBalance = double.Parse(Console.ReadLine());

			Console.Write("Enter credit: ");
			double enterCredit = double.Parse(Console.ReadLine());

			Account newAccount = new Account(typeAccount: (TypeAccount)enterTypeAccount,
										balance: enterBalance,
										credit: enterCredit,
										name: enterName);

			listAccount.Add(newAccount);
		}

		private static void ListAccounts()
		{
			Console.WriteLine("List accounts");

			if (listAccount.Count == 0)
			{
				Console.WriteLine("No accounts registered");
				return;
			}

			for (int i = 0; i < listAccount.Count; i++)
			{
				Account account = listAccount[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(account);
			}
		}

		private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- List accounts");
			Console.WriteLine("2- Enter new account");
			Console.WriteLine("3- Transfer");
			Console.WriteLine("4- Withdraw");
			Console.WriteLine("5- Deposit");
            Console.WriteLine("C- Clear Screen");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string optionUser = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return optionUser;
		}
	}
}