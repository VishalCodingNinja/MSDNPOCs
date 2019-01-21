using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankThreadingExample
{
	class BankAccount
	{
		public readonly int AccountNumber;
		double _balance;
		object _lock = new object();
		public BankAccount(int acctNum,double initDeposit)
		{
			AccountNumber = acctNum;
			_balance = initDeposit;
		}
		public void Credit(double amt)
		{
			lock(_lock)
			{
				double temp = _balance;
				temp += amt;
				Thread.Sleep(1);
				_balance = temp;
			}
		}
		public void Debit(double amt)
		{
			Credit(-amt);
		}
		public double Balance
		{
			get
			{
				double b = 0;
				lock(_lock)
				{
					b = _balance;
				}
				return (b);
			}
		}
		public void TransferFrom(BankAccount otherAcc,double amt)
		{
			Console.WriteLine("[{0}] Transfering {1:C} from account {2} to {3} ",Thread.CurrentThread.Name,amt,otherAcc.AccountNumber,this.AccountNumber);

			object firstLock;
			object secondLock;
			ChooseLocks(this, otherAcc, out firstLock, out secondLock);

			lock(firstLock)
			{
				Thread.Sleep(10);
				lock(secondLock)
				{
					otherAcc.Debit(amt);
					this.Credit(amt);
				}
			}
		}

		private void ChooseLocks(BankAccount acctOne, BankAccount acctTwo, out object firstLock, out object secondLock)
		{
			if(acctOne.AccountNumber< acctTwo.AccountNumber)
			{
				firstLock = acctOne._lock;
				secondLock = acctTwo._lock;

			}
			else
			{
				firstLock = acctTwo._lock;
				secondLock = acctOne._lock;
			}
		}
	}
	
}
