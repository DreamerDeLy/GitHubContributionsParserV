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

		public List<MonthData> months_data = new List<MonthData>();
		public List<DayOfWeekData> dayofweek_data = new List<DayOfWeekData>();

		public int longest_streak = 0;
		public DateTime longest_streak_start = new DateTime(2000, 01, 01);
		public DateTime longest_streak_end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

		public int max_per_day = 0;
		public DateTime max_per_day_date;

		public int days_with_commits = 0;
		public int days_without_commits = 0;

		public double commits_per_day_avg = 0;
		public int commits_per_year_forecast = 0;

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

		public void CalculateLongestStreak()
		{
			int current_streak = 0;
			DateTime current_streak_start = new DateTime(2000, 01, 01);

			foreach (DayData day in calendar)
			{
				if (day.counter > 0)
				{
					if (current_streak == 0) current_streak_start = day.date;
					current_streak += 1;
				}
				else
				{
					if (current_streak > longest_streak)
					{
						longest_streak = current_streak;
						longest_streak_start = current_streak_start;
						longest_streak_end = day.date;
					}

					current_streak = 0;
				}
			}
		}

		public void CalculateMaxCommitsPerDay()
		{
			foreach (DayData day in calendar)
			{
				if (day.counter > max_per_day)
				{
					max_per_day = day.counter;
					max_per_day_date = day.date;
				}
			}
		}

		public void CalculateDaysWithCommits()
		{
			days_with_commits = calendar.Where(d => (d.counter > 0)).Count();
			days_without_commits = Convert.ToInt32((DateTime.Now - date).TotalDays) - days_with_commits;
		}

		public void CalculateCommitsPerDayAvg()
		{
			commits_per_day_avg = (double)counter / (double)DateTime.Now.DayOfYear;

			if (DateTime.IsLeapYear(date.Year))
			{
				commits_per_year_forecast = Convert.ToInt32(366.0 * commits_per_day_avg);
			}
			else
			{
				commits_per_year_forecast = Convert.ToInt32(365.0 * commits_per_day_avg);
			}
		}
	}

	public class MonthData
	{
		public int counter;
		public DateTime date;

		public double commits_per_day_avg = 0;
		public int commits_per_month_forecast = 0;

		public MonthData(int counter, DateTime date)
		{
			this.counter = counter;
			this.date = date;
		}

		public void CalculateCommitsPerDayAvg()
		{
			commits_per_day_avg = (double)counter / (double)DateTime.Now.Day;
			commits_per_month_forecast = Convert.ToInt32((double)DateTime.DaysInMonth(date.Year, date.Month) * (double)commits_per_day_avg);
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
