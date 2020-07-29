using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubContributionsParserV
{
	public class Data
	{
		public List<YearData> years = new List<YearData>();
	}

	public class DayData
	{
		public int counter;
		public DateTime date;
	}

	public class YearData
	{
		public int counter;
		public DateTime date;
		public List<DayData> calendar = new List<DayData>();
	}
}
