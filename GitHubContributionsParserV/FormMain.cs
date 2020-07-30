﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace GitHubContributionsParserV
{
	public partial class FormMain : Form
	{
		//static Data data;

		public FormMain()
		{
			InitializeComponent();
		}

		private async void btnParse_Click(object sender, EventArgs e)
		{
			Data data = await ParseAsync();

			YearData last_year = data.years[data.years.Count - 1];


			richTextBox1.Text += "Year: \r\n";
			foreach (YearData year in data.years)
			{
				richTextBox1.Text += $"{year.date.Year} - {year.counter}\r\n";
			}

			richTextBox1.Text += "Month: \r\n";
			last_year.CalculateCommitsPerMonths();
			foreach (MonthData month in last_year.months_data)
			{
				richTextBox1.Text += $"{month.date.Month} - {month.counter}\r\n";
			}

			richTextBox1.Text += "DayOfWeek: \r\n";
			last_year.CalculateCommitsPerDayOfWeek();
			foreach (DayOfWeekData dayOfWeekData in last_year.dayofweek_data)
			{
				richTextBox1.Text += $"{dayOfWeekData.day_of_week.ToString().Substring(0, 3)} - {dayOfWeekData.counter}\r\n";
			}

			last_year.CalculateMaxCommitsPerDay();
			richTextBox1.Text += String.Format("Max commits per day: {0} ({1})\r\n", 
				last_year.max_per_day, 
				last_year.max_per_day_date.ToString("yyyy-MM-dd")
				);

			last_year.CalculateLongestStreak();
			richTextBox1.Text += String.Format("Longest streak: {0} ({1} - {2})\r\n", 
				last_year.longest_streak, 
				last_year.longest_streak_start.ToString("yyyy-MM-dd"), 
				last_year.longest_streak_end.ToString("yyyy-MM-dd")
				);

			last_year.CalculateDaysWithCommits();
			richTextBox1.Text += String.Format("Days with commits:    {0} ({1:##.##}%)\r\n", 
				last_year.days_with_commits,
				((double)last_year.days_with_commits / (double)((double)last_year.days_with_commits + (double)last_year.days_without_commits)) * 100.0
				);
			richTextBox1.Text += String.Format("Days without commits: {0} ({1:##.##}%)\r\n",
				last_year.days_without_commits,
				((double)last_year.days_without_commits / (double)((double)last_year.days_with_commits + (double)last_year.days_without_commits)) * 100.0
				);
		}

		private Data Parse()
		{
			Data data = new Data();

			for (int year = 2017; year <= DateTime.Now.Year; year++)
			{
				string url = $"https://github.com/{tbUser.Text}/?tab=overview&from={year}-01-01&to={year}-12-31";

				HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
				HtmlAgilityPack.HtmlDocument doc = web.Load(url);

				HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode("//h2[@class='f4 text-normal mb-2']");
				int counter = Int32.Parse(node.InnerText.Trim().Split()[0]);

				YearData current = new YearData(counter, new DateTime(year, 1, 1));

				foreach (HtmlNode nodeDay in doc.DocumentNode.SelectNodes("//rect[@class='day']"))
				{
					DayData day = new DayData();

					string data_count = nodeDay.Attributes["data-count"].Value;
					string data_date = nodeDay.Attributes["data-date"].Value;

					day.counter = Int32.Parse(data_count);
					day.date = DateTime.Parse(data_date);

					current.calendar.Add(day);
				}

				data.years.Add(current);
			}

			return data;
		}

		public async Task<Data> ParseAsync()
		{
			return await Task.Run(() => Parse());
		}
	}
}
