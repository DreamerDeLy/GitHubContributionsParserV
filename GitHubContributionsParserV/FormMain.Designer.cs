namespace GitHubContributionsParserV
{
	partial class FormMain
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnParse = new System.Windows.Forms.Button();
			this.tbUser = new System.Windows.Forms.TextBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.fpMonths = new ScottPlot.FormsPlot();
			this.fpDayOfWeek = new ScottPlot.FormsPlot();
			this.btnAnalyze = new System.Windows.Forms.Button();
			this.cbYear = new System.Windows.Forms.ComboBox();
			this.tbStartYear = new System.Windows.Forms.TextBox();
			this.fpYears = new ScottPlot.FormsPlot();
			this.SuspendLayout();
			// 
			// btnParse
			// 
			this.btnParse.Location = new System.Drawing.Point(257, 11);
			this.btnParse.Name = "btnParse";
			this.btnParse.Size = new System.Drawing.Size(75, 22);
			this.btnParse.TabIndex = 0;
			this.btnParse.Text = "Parse";
			this.btnParse.UseVisualStyleBackColor = true;
			this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
			// 
			// tbUser
			// 
			this.tbUser.Location = new System.Drawing.Point(12, 12);
			this.tbUser.Name = "tbUser";
			this.tbUser.Size = new System.Drawing.Size(100, 20);
			this.tbUser.TabIndex = 1;
			this.tbUser.Text = "DreamerDeLy";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.richTextBox1.Location = new System.Drawing.Point(338, 206);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(321, 401);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = "";
			// 
			// fpMonths
			// 
			this.fpMonths.Location = new System.Drawing.Point(12, 40);
			this.fpMonths.Name = "fpMonths";
			this.fpMonths.Size = new System.Drawing.Size(320, 273);
			this.fpMonths.TabIndex = 4;
			// 
			// fpDayOfWeek
			// 
			this.fpDayOfWeek.Location = new System.Drawing.Point(12, 331);
			this.fpDayOfWeek.Name = "fpDayOfWeek";
			this.fpDayOfWeek.Size = new System.Drawing.Size(320, 273);
			this.fpDayOfWeek.TabIndex = 5;
			// 
			// btnAnalyze
			// 
			this.btnAnalyze.Enabled = false;
			this.btnAnalyze.Location = new System.Drawing.Point(338, 12);
			this.btnAnalyze.Name = "btnAnalyze";
			this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
			this.btnAnalyze.TabIndex = 6;
			this.btnAnalyze.Text = "Analyze";
			this.btnAnalyze.UseVisualStyleBackColor = true;
			this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
			// 
			// cbYear
			// 
			this.cbYear.Enabled = false;
			this.cbYear.FormattingEnabled = true;
			this.cbYear.Location = new System.Drawing.Point(419, 14);
			this.cbYear.Name = "cbYear";
			this.cbYear.Size = new System.Drawing.Size(121, 21);
			this.cbYear.TabIndex = 7;
			this.cbYear.DropDown += new System.EventHandler(this.cbYear_DropDown);
			// 
			// tbStartYear
			// 
			this.tbStartYear.Location = new System.Drawing.Point(214, 12);
			this.tbStartYear.MaxLength = 4;
			this.tbStartYear.Name = "tbStartYear";
			this.tbStartYear.Size = new System.Drawing.Size(37, 20);
			this.tbStartYear.TabIndex = 8;
			this.tbStartYear.Text = "2017";
			// 
			// fpYears
			// 
			this.fpYears.Location = new System.Drawing.Point(338, 41);
			this.fpYears.Name = "fpYears";
			this.fpYears.Size = new System.Drawing.Size(320, 159);
			this.fpYears.TabIndex = 9;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(671, 618);
			this.Controls.Add(this.fpYears);
			this.Controls.Add(this.tbStartYear);
			this.Controls.Add(this.cbYear);
			this.Controls.Add(this.btnAnalyze);
			this.Controls.Add(this.fpDayOfWeek);
			this.Controls.Add(this.fpMonths);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.tbUser);
			this.Controls.Add(this.btnParse);
			this.Name = "FormMain";
			this.Text = "ContributionsParserV";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnParse;
		private System.Windows.Forms.TextBox tbUser;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private ScottPlot.FormsPlot fpMonths;
		private ScottPlot.FormsPlot fpDayOfWeek;
		private System.Windows.Forms.Button btnAnalyze;
		private System.Windows.Forms.ComboBox cbYear;
		private System.Windows.Forms.TextBox tbStartYear;
		private ScottPlot.FormsPlot fpYears;
	}
}

