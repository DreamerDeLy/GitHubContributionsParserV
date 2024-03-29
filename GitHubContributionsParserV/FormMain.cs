﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Newtonsoft.Json;
using ScottPlot;

namespace GitHubContributionsParserV
{
	public partial class FormMain : Form
	{
		static Data _data;

		static List<string> last_users = new List<string>();
		const string last_users_file = "last_users.txt";

		const string my_username = "DreamerDeLy";

		public FormMain()
		{
			InitializeComponent();

			LoadLastUsers();
		}

		private void SaveLastUsers()
		{
			try
			{
				File.WriteAllLines(last_users_file, last_users);
			}
			catch
			{
				//
			}
		}

		private void LoadLastUsers()
		{
			try
			{
				string[] lines = File.ReadAllLines(last_users_file);
				last_users = lines.ToList();
			}
			catch
			{
				//
			}

			if (!last_users.Contains(my_username))
			{
				last_users.Insert(0, my_username);
			}

			cbUser.Items.Clear();
			cbUser.Items.AddRange(last_users.ToArray());
			cbUser.SelectedIndex = 0;
		}

		private async void btnParse_Click(object sender, EventArgs e)
		{
			string user = cbUser.Text;
			_data = await ParseAsync(user);

			cbYear.Enabled = true;

			GenerateYearsMenu();
			Analyze(_data, cbYear.SelectedIndex);

			if (!last_users.Contains(user))
			{
				last_users.Add(user);
				cbUser.Items.Add(user);
			}
		}

		private void RenderGraphMonthsData(Data data, int year_i)
		{
			YearData last_year = data.years[year_i];

			double avg = last_year.months_data.Where(e => (e.date.Month <= DateTime.Now.Month)).Average(e => e.counter);

			double[] xs = DataGen.Consecutive(last_year.months_data.Count);
			double[] ys = new double[last_year.months_data.Count];
			string[] labels = new string[last_year.months_data.Count];

			for (int i = 0; i < last_year.months_data.Count; i++)
			{
				ys[i] = last_year.months_data[i].counter;
				labels[i] = last_year.months_data[i].date.ToString("MMMM").Substring(0, 3).ToUpper();
			}

			double[] ys_forecast = new double[ys.Length];
			Array.Copy(ys, ys_forecast, ys.Length);

			for (int i = 0; i < ys_forecast.Length; i++)
			{
				ys_forecast[i] = last_year.months_data[i].commits_per_month_forecast;
			}

			xs = xs.Reverse().ToArray();

			fpMonths.plt.Clear();

			fpMonths.plt.PlotVLine(x: 1000 / 12, color: Color.Red);
			fpMonths.plt.PlotVLine(x: avg, color: Color.Gold);

			fpMonths.plt.PlotBar(xs, ys_forecast, horizontal: true, fillColor: Color.Azure, label: "Forecast");
			fpMonths.plt.PlotBar(xs, ys, horizontal: true, fillColor: Color.SteelBlue, label: "Commits", showValues: true);

			fpMonths.plt.Grid(enableHorizontal: false, lineStyle: LineStyle.Dot);
			fpMonths.plt.YTicks(xs, labels);

			fpMonths.Render();
		}

		private void RenderGraphDaysOfWeek(Data data, int year_i)
		{
			YearData last_year = data.years[year_i];

			double[] xs = DataGen.Consecutive(last_year.dayofweek_data.Count);
			double[] ys = new double[last_year.dayofweek_data.Count];
			string[] labels = new string[last_year.dayofweek_data.Count];

			for (int i = 0; i < last_year.dayofweek_data.Count; i++)
			{
				ys[i] = last_year.dayofweek_data[i].counter;
				labels[i] = last_year.dayofweek_data[i].day_of_week.ToString().Substring(0, 3);
			}

			xs = xs.Reverse().ToArray();

			fpDayOfWeek.plt.Clear();

			fpDayOfWeek.plt.PlotVLine(x: ys.Average(), color: Color.Gold);

			fpDayOfWeek.plt.PlotBar(xs, ys, horizontal: true, fillColor: Color.SteelBlue, showValues: true);
			fpDayOfWeek.plt.Grid(enableHorizontal: false, lineStyle: LineStyle.Dot);
			fpDayOfWeek.plt.YTicks(xs, labels);

			fpDayOfWeek.Render();
		}

		private void RenderGraphYearsData(Data data)
		{
			double[] xs = DataGen.Consecutive(data.years.Count);
			double[] ys = new double[data.years.Count];
			string[] labels = new string[data.years.Count];

			for (int i = 0; i < data.years.Count; i++)
			{
				ys[i] = data.years[i].counter;
				labels[i] = data.years[i].date.Year.ToString();
			}

			fpYears.plt.Clear();

			fpYears.plt.PlotHLine(y: ys.Average(), color: Color.Gold);

			fpYears.plt.PlotBar(xs, ys, fillColor: Color.SteelBlue, showValues: true);
			fpYears.plt.Grid(lineStyle: LineStyle.Dot);
			fpYears.plt.XTicks(xs, labels);

			fpYears.Render();
		}

		private void RenderGraphDaysWithAndWithout(Data data, int year_i)
		{
			double[] values =
			{
				data.years[year_i].days_without_commits,
				data.years[year_i].days_with_commits
			};

			string[] labels = { "Days without commits", "Days with commits" };

			fpDaysWihAndWithout.plt.Clear();

			fpDaysWihAndWithout.plt.PlotPie(values, labels, explodedChart: true, showValues: true, showPercentages: true, showLabels: false);

			fpDaysWihAndWithout.plt.Grid(false);
			fpDaysWihAndWithout.plt.Ticks(false, false);

			fpDaysWihAndWithout.plt.Legend();

			fpDaysWihAndWithout.Render();
		}

		private Data Parse(string user)
		{
			try
			{
				int i = Int32.Parse(tbStartYear.Text);

				if (i < 2000 || i > DateTime.Now.Year)
				{
					tbStartYear.Text = "2017";
				}
			}
			catch
			{
				tbStartYear.Text = "2017";
			}

			Data data = new Data();

			for (int year = Int32.Parse(tbStartYear.Text); year <= DateTime.Now.Year; year++)
			{
				string url = $"https://github.com/{user}/?tab=overview&from={year}-01-01&to={year}-12-31";

				HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
				HtmlAgilityPack.HtmlDocument doc = web.Load(url);

				HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode("//h2[@class='f4 text-normal mb-2']");

				YearData current = new YearData(new DateTime(year, 1, 1));

				var dayNodes = doc.DocumentNode.SelectNodes("//td[@class='ContributionCalendar-day']");

				foreach (HtmlNode nodeDay in dayNodes)
				{
					DayData day = new DayData();

					try
					{
						if (nodeDay.Attributes.Contains("data-date"))
                        {
							//string data_count = nodeDay.Attributes["data-count"].Value;
							string data_date = nodeDay.Attributes["data-date"].Value;
							string data_count = "0";

							if (!nodeDay.InnerText.StartsWith("No"))
							{
								data_count = nodeDay.InnerText.Split(' ')[0];
							}

							day.counter = Int32.Parse(data_count);
							day.date = DateTime.Parse(data_date);

							current.calendar.Add(day);
						}
					}
					catch (Exception ex)
					{
						//MessageBox.Show(ex.Message + "\r\n\"" + nodeDay.InnerText + "\"\r\n" + nodeDay.Attributes.Count());
						
					}
					
				}

				current.counter = current.calendar.Sum(d => d.counter);

				if (current.counter > 0) data.years.Add(current);
			}

			return data;
		}

		public async Task<Data> ParseAsync(string user)
		{
			return await Task.Run(() => Parse(user));
		}

		private void Analyze(Data data, int year_i)
		{
			YearData current_year = data.years[year_i];

			richTextBox1.Text = "";

			//richTextBox1.Text += "Year: \r\n";
			//foreach (YearData year in data.years)
			//{
			//	richTextBox1.Text += $"{year.date.Year} - {year.counter}\r\n";
			//}

			richTextBox1.Text += "Month: \r\n";
			current_year.CalculateCommitsPerMonths();
			foreach (MonthData month in current_year.months_data)
			{
				int target = 1000 / 12;
				int to_target = month.counter - target;

				if (month.counter > 0)
				{
					richTextBox1.Text += String.Format("{0:##} - {1} ({2})\r\n", month.date.Month, month.counter, to_target);
				}
				else
				{
					richTextBox1.Text += String.Format("{0:##} - {1}\r\n", month.date.Month, month.counter);
				}
			}

			//richTextBox1.Text += "DayOfWeek: \r\n";
			current_year.CalculateCommitsPerDayOfWeek();
			//foreach (DayOfWeekData dayOfWeekData in current_year.dayofweek_data)
			//{
			//	richTextBox1.Text += $"{dayOfWeekData.day_of_week.ToString().Substring(0, 3)} - {dayOfWeekData.counter}\r\n";
			//}

			current_year.CalculateMaxCommitsPerDay();
			richTextBox1.Text += String.Format("Max commits per day: {0} ({1})\r\n",
				current_year.max_per_day,
				current_year.max_per_day_date.ToString("yyyy-MM-dd")
				);

			current_year.CalculateLongestStreak();
			richTextBox1.Text += String.Format("Longest streak: {0} ({1} - {2})\r\n",
				current_year.longest_streak,
				current_year.longest_streak_start.ToString("yyyy-MM-dd"),
				current_year.longest_streak_end.ToString("yyyy-MM-dd")
				);

			current_year.CalculateDaysWithCommits();
			//richTextBox1.Text += String.Format("Days with commits:    {0} ({1:00.00}%)\r\n",
			//	current_year.days_with_commits,
			//	((double)current_year.days_with_commits / (double)((double)current_year.days_with_commits + (double)current_year.days_without_commits)) * 100.0
			//	);
			//richTextBox1.Text += String.Format("Days without commits: {0} ({1:00.00}%)\r\n",
			//	current_year.days_without_commits,
			//	((double)current_year.days_without_commits / (double)((double)current_year.days_with_commits + (double)current_year.days_without_commits)) * 100.0
			//	);

			richTextBox1.Text += "Year:\r\n";
			current_year.CalculateCommitsPerDayAvg();
			richTextBox1.Text += String.Format("Commits per day (without zero): {0:#0.000}\r\n", current_year.commits_per_day_wn_avg);
			richTextBox1.Text += String.Format("Commits per day: {0:#0.000}\r\n", current_year.commits_per_day_avg);
			richTextBox1.Text += String.Format("Commits per year forecast: {0}\r\n", current_year.commits_per_year_forecast);

			if (current_year.date.Year == DateTime.Now.Year)
			{
				richTextBox1.Text += "Month:\r\n";
				MonthData last_month = current_year.months_data[DateTime.Now.Month - 1];
				last_month.CalculateCommitsPerDayAvg();
				richTextBox1.Text += String.Format("Commits per day: {0:#0.000}\r\n", last_month.commits_per_day_avg);
				richTextBox1.Text += String.Format("Commits per month forecast: {0}\r\n", last_month.commits_per_month_forecast);
			}

			RenderGraphMonthsData(data, year_i);
			RenderGraphDaysOfWeek(data, year_i);
			RenderGraphYearsData(data);
			RenderGraphDaysWithAndWithout(data, year_i);
		}

		private void cbYear_DropDown(object sender, EventArgs e)
		{
			GenerateYearsMenu();
		}

		private void GenerateYearsMenu()
		{
			int i = cbYear.SelectedIndex;
			cbYear.Items.Clear();

			foreach (YearData y in _data.years)
			{
				cbYear.Items.Add(y.date.Year.ToString());
			}

			if (i >= 0 && i < cbYear.Items.Count)
			{
				cbYear.SelectedIndex = i;
			}
			else
			{
				cbYear.SelectedIndex = _data.years.Count - 1;
			}
		}

		private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			Data data = new Data();
			data = _data;
			Analyze(data, cbYear.SelectedIndex);
		}

		private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			SaveLastUsers();
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			if (_data != null)
			{
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(saveFileDialog1.FileName, _data.ToCSV());
						MessageBox.Show("Data saved to \r\n" + saveFileDialog1.FileName, "Data saved");
					}
					catch
					{
						MessageBox.Show("Saving data error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
			{
				MessageBox.Show("No data available. Click Parsing first.", "No data available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
