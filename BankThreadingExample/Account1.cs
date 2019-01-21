//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;

//namespace BankThreadingExample
//{
	
//	class BankAccount
//	{
//		public readonly int AccountNumber;
//		double _balance;
//		public BankAccount(int accNum,double initDeposit)
//		{
//			AccountNumber = accNum;
//			_balance = initDeposit;
//		}
//		public void Credit(double amt)
//		{
//			double temp = _balance;
//			temp += amt;
//			Thread.Sleep(1);
//			_balance = temp;
//		}
//		public void Debit(double amt)
//		{
//			Credit(-amt);
//		}
//		public double Balance {
//			get
//			{
//				return _balance;
//			}
			
//		}
//		public void TransferFrom(BankAccount otherAcct,double amt)
//		{
//			Console.WriteLine("[{0}] Transfering {1:C0} from account {2} to {3}",Thread.CurrentThread.Name,amt,otherAcct.AccountNumber,this.AccountNumber);
//			otherAcct.Debit(amt);
//			this.Credit(amt);
//		}
//	}
//}
