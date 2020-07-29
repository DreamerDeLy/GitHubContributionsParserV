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
			this.formsPlot1 = new ScottPlot.FormsPlot();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// btnParse
			// 
			this.btnParse.Location = new System.Drawing.Point(118, 11);
			this.btnParse.Name = "btnParse";
			this.btnParse.Size = new System.Drawing.Size(75, 23);
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
			// formsPlot1
			// 
			this.formsPlot1.Location = new System.Drawing.Point(12, 71);
			this.formsPlot1.Name = "formsPlot1";
			this.formsPlot1.Size = new System.Drawing.Size(397, 350);
			this.formsPlot1.TabIndex = 2;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(415, 13);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(585, 408);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = "";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1057, 450);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.formsPlot1);
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
		private ScottPlot.FormsPlot formsPlot1;
		private System.Windows.Forms.RichTextBox richTextBox1;
	}
}

