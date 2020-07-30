﻿using System;
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

		public List<MonthData> months_data = new List<MonthData>();
		public List<DayOfWeekData> dayofweek_data = new List<DayOfWeekData>();

		public YearData(int counter, DateTime date)
		{
			this.counter = counter;
			this.date = date;
		}

		public void CalculateCommitsPerMonths()
		{
			var groupedMonths = calendar
				.GroupBy(d => d.date.Month)
				.Select(grp => grp.ToList())
				.ToList();

			foreach (List<DayData> month in groupedMonths)
			{
				int counter = 0;
				foreach (DayData day in month)
				{
					counter += day.counter;
				}

				months_data.Add(new MonthData(counter, new DateTime(month[0].date.Year, month[0].date.Month, 1)));
			}
		}

		public void CalculateCommitsPerDayOfWeek()
		{
			var groupedDayOfWeek = calendar
				.GroupBy(d => d.date.DayOfWeek)
				.Select(grp => grp.ToList())
				.ToList();

			//((int)DateTime.Now.DayOfWeek + 6) % 7 + 1
			groupedDayOfWeek.Sort((x, y) => (((int)x[0].date.DayOfWeek + 6) % 7 + 1).CompareTo(((int)y[0].date.DayOfWeek + 6) % 7 + 1));

			foreach (List<DayData> dayOfWeek in groupedDayOfWeek)
			{
				int counter = 0;
				foreach (DayData day in dayOfWeek)
				{
					counter += day.counter;
				}

				dayofweek_data.Add(new DayOfWeekData(counter, dayOfWeek[0].date.DayOfWeek));
			}
		}
	}

	public class MonthData
	{
		public int counter;
		public DateTime date;

		public MonthData(int counter, DateTime date)
		{
			this.counter = counter;
			this.date = date;
		}
	}

	public class DayOfWeekData
	{
		public int counter;
		public DayOfWeek day_of_week; //(0 - monday)

		public DayOfWeekData(int counter, DayOfWeek day_of_week)
		{
			this.counter = counter;
			this.day_of_week = day_of_week;
		}
	}
}
