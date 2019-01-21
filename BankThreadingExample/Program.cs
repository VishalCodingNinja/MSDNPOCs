using System;
using System.Threading;

namespace BankThreadingExample
{
	
	class SimulationParameters
	{
		public const double INITIAL_DEPOSIT = 1000;
		public const double MIN_TRANSFER_AMOUNT = 25;
		public const double MAX_TRANSFER_AMOUNT = 250;
		public const int NUMBER_OF_ACCOUNTS = 10;
		public const int NUMBER_OF_TRANSFER_THREADS = 4;
		public const int TRANSFER_THREAD_PERIOD = 200;
		public const int SIMULATION_LENGTH = 10000;
	}
	class Bank
	{
		static BankAccount[] s_bankAccounts = new BankAccount[SimulationParameters.NUMBER_OF_ACCOUNTS];
		static volatile bool s_simulationOver = false;
		static void Main(string[] args)
		{

			Thread.CurrentThread.Name = "Main";
			Console.WriteLine("[Main] starting program .Total funds on deposit should always be{0}",SimulationParameters.NUMBER_OF_ACCOUNTS*SimulationParameters.INITIAL_DEPOSIT);

			for(int n=0;n<SimulationParameters.NUMBER_OF_ACCOUNTS;n++)
			{
				s_bankAccounts[n] = new BankAccount(n, SimulationParameters.INITIAL_DEPOSIT);
			}

			Thread[] transferThreads = new Thread[SimulationParameters.NUMBER_OF_TRANSFER_THREADS];
			ThreadStart threadPoc = new ThreadStart(TransferThreadProc);


			//start the transfer threads
			//
			for(int n=0;n<SimulationParameters.NUMBER_OF_TRANSFER_THREADS;n++)
			{
				transferThreads[n] = new Thread(threadProc);
				transferThreads[n].Name = string.Format("TX-{0}", n);
				transferThreads[n].Start();
			}

			//..let the simulation run the prescribe amount of the time

			Thread.Sleep(SimulationParameters.SIMULATION_LENGTH);

			//signal to everyone to acknowledge the simulation is complete
			 
			for(int n=0;n<transferThreads.Length;n++)
			{
				transferThreads[n].Join();
			}

			Console.WriteLine("{Main} simulation complete ,verifying accounts.");
			VerifyAccounts();
		}

		private static void VerifyAccounts()
		{
			string threadName = Thread.CurrentThread.Name;
			double totalDepositsIfNoErrors = SimulationParameters.INITIAL_DEPOSIT * SimulationParameters.NUMBER_OF_ACCOUNTS;
			double totalDeposits = 0;

			//iterate over accounts,adding each accounts balance
			//to a running total

			for(int n=0;n<SimulationParameters.NUMBER_OF_ACCOUNTS;n++)
			{
				totalDeposits += s_bankAccounts[n].Balance;
			}
			if (totalDeposits == totalDepositsIfNoErrors)
			{
				Console.WriteLine("[{0}] Audit result:bank accounts are consistent ({1:C0} on deposite )", threadName, totalDeposits);
			}
			else
			{
				Console.WriteLine("[{0}] Audit result: *** inconsistencies detected ({1:CO} total deposite)",threadName,totalDeposits);
			}

		}

		private static void threadProc(object obj)
		{
			throw new NotImplementedException();
		}

		private static void TransferThreadProc()
		{
			string threadName = Thread.CurrentThread.Name;
			while(!s_simulationOver)
			{
				double transferAmount = GetRandomTransferAmount();
				int debetAccount = GetRandomAccountIndex();
				int creditAccount = GetRandomAccountIndex();
				while(creditAccount==debetAccount)
				{
					creditAccount = GetRandomAccountIndex();
				}
				s_bankAccounts[creditAccount].TransferFrom(s_bankAccounts[debetAccount], transferAmount);
				Thread.Sleep(SimulationParameters.TRANSFER_THREAD_PERIOD);

			}
		}

		private static int GetRandomAccountIndex()
		{
			throw new NotImplementedException();
		}

		private static double GetRandomTransferAmount()
		{
			throw new NotImplementedException();
		}
	}
}
