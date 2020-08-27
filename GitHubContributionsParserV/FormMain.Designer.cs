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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.cbYear = new System.Windows.Forms.ComboBox();
			this.tbStartYear = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.fpMonths = new ScottPlot.FormsPlot();
			this.fpYears = new ScottPlot.FormsPlot();
			this.fpDayOfWeek = new ScottPlot.FormsPlot();
			this.fpDaysWihAndWithout = new ScottPlot.FormsPlot();
			this.cbUser = new System.Windows.Forms.ComboBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnParse
			// 
			this.btnParse.Location = new System.Drawing.Point(182, 10);
			this.btnParse.Name = "btnParse";
			this.btnParse.Size = new System.Drawing.Size(75, 22);
			this.btnParse.TabIndex = 0;
			this.btnParse.Text = "Parse";
			this.btnParse.UseVisualStyleBackColor = true;
			this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.richTextBox1.Location = new System.Drawing.Point(689, 39);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(420, 570);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = "";
			// 
			// cbYear
			// 
			this.cbYear.Enabled = false;
			this.cbYear.FormattingEnabled = true;
			this.cbYear.Location = new System.Drawing.Point(341, 11);
			this.cbYear.Name = "cbYear";
			this.cbYear.Size = new System.Drawing.Size(121, 21);
			this.cbYear.TabIndex = 7;
			this.cbYear.DropDown += new System.EventHandler(this.cbYear_DropDown);
			this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
			// 
			// tbStartYear
			// 
			this.tbStartYear.Location = new System.Drawing.Point(139, 11);
			this.tbStartYear.MaxLength = 4;
			this.tbStartYear.Name = "tbStartYear";
			this.tbStartYear.Size = new System.Drawing.Size(37, 20);
			this.tbStartYear.TabIndex = 8;
			this.tbStartYear.Text = "2017";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.Controls.Add(this.fpMonths);
			this.flowLayoutPanel1.Controls.Add(this.fpYears);
			this.flowLayoutPanel1.Controls.Add(this.fpDayOfWeek);
			this.flowLayoutPanel1.Controls.Add(this.fpDaysWihAndWithout);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 39);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(671, 570);
			this.flowLayoutPanel1.TabIndex = 10;
			// 
			// fpMonths
			// 
			this.fpMonths.Location = new System.Drawing.Point(3, 3);
			this.fpMonths.Name = "fpMonths";
			this.fpMonths.Size = new System.Drawing.Size(320, 272);
			this.fpMonths.TabIndex = 5;
			// 
			// fpYears
			// 
			this.fpYears.Location = new System.Drawing.Point(329, 3);
			this.fpYears.Name = "fpYears";
			this.fpYears.Size = new System.Drawing.Size(320, 272);
			this.fpYears.TabIndex = 10;
			// 
			// fpDayOfWeek
			// 
			this.fpDayOfWeek.Location = new System.Drawing.Point(3, 281);
			this.fpDayOfWeek.Name = "fpDayOfWeek";
			this.fpDayOfWeek.Size = new System.Drawing.Size(320, 272);
			this.fpDayOfWeek.TabIndex = 11;
			// 
			// fpDaysWihAndWithout
			// 
			this.fpDaysWihAndWithout.Location = new System.Drawing.Point(329, 281);
			this.fpDaysWihAndWithout.Name = "fpDaysWihAndWithout";
			this.fpDaysWihAndWithout.Size = new System.Drawing.Size(320, 272);
			this.fpDaysWihAndWithout.TabIndex = 12;
			// 
			// cbUser
			// 
			this.cbUser.FormattingEnabled = true;
			this.cbUser.Items.AddRange(new object[] {
            "DreamerDeLy"});
			this.cbUser.Location = new System.Drawing.Point(12, 11);
			this.cbUser.Name = "cbUser";
			this.cbUser.Size = new System.Drawing.Size(121, 21);
			this.cbUser.TabIndex = 11;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1121, 619);
			this.Controls.Add(this.cbUser);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.tbStartYear);
			this.Controls.Add(this.cbYear);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.btnParse);
			this.Name = "FormMain";
			this.Text = "ContributionsParserV";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnParse;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ComboBox cbYear;
		private System.Windows.Forms.TextBox tbStartYear;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private ScottPlot.FormsPlot fpMonths;
		private ScottPlot.FormsPlot fpYears;
		private ScottPlot.FormsPlot fpDayOfWeek;
		private ScottPlot.FormsPlot fpDaysWihAndWithout;
		private System.Windows.Forms.ComboBox cbUser;
	}
}

