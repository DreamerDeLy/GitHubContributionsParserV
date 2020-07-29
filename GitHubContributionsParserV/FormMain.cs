using System;
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
			richTextBox1.Text = JsonConvert.SerializeObject(data, Formatting.Indented);
		}

		private Data Parse()
		{
			Data data = new Data();

			for (int year = 2015; year <= DateTime.Now.Year; year++)
			{
				string url = $"https://github.com/{tbUser.Text}/?tab=overview&from={year}-01-01&to={year}-12-31";

				HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
				HtmlAgilityPack.HtmlDocument doc = web.Load(url);

				HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode("//body/div[4]/main//div[2]/div/div[2]/div[2]/div/div[3]/div[1]/div/h2");
				int counter = Int32.Parse(node.InnerText.Trim().Split()[0]);

				YearData current = new YearData();
				current.counter = counter;
				current.date = new DateTime(year, 1, 1);

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
