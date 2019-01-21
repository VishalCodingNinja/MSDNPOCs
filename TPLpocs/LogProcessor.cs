using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TPLpocs
{
	
	internal class LogProcessor
	{
		private string logPath;

		private StreamReader _reader;
		private Regex _re = new Regex("GET /SampleClass/");
		private ConcurrentDictionary<string, int> _matches = new ConcurrentDictionary<string, int>();
		public LogProcessor(string logPath)
		{
			if(logPath==null)
			{
				throw new ArgumentNullException("path");
			}
			_reader = new StreamReader(logPath);
			FetchNextLine();
		}

		private void FetchNextLine()
		{
			_reader.ReadLineAsync().ContinueWith(ProcessLine);
		}

		private void ProcessLine(Task<string> t)
		{
			string line = t.Result;
			if(line!=null)
			{
				Match match = _re.Match(line);
				if(match.Success)
				{
					string key = match.Groups[1].Value;
					_matches.AddOrUpdate(key, 1, (k, count) => count + 1);
				}
				FetchNextLine();
			}
			else
			{
				_reader.Close();
				foreach (var pair in _matches.OrderByDescending(p=>p.Value))
				{
					Console.WriteLine("{0}: {1}",pair.Key,pair.Value);
				}
			}
		}
	}
}