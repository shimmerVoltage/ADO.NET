namespace AcademyDataSet
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbGroups = new System.Windows.Forms.ComboBox();
			this.cbDirections = new System.Windows.Forms.ComboBox();
			this.btn_refresh = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbGroups
			// 
			this.cbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGroups.FormattingEnabled = true;
			this.cbGroups.Location = new System.Drawing.Point(12, 12);
			this.cbGroups.Name = "cbGroups";
			this.cbGroups.Size = new System.Drawing.Size(396, 28);
			this.cbGroups.TabIndex = 0;
			// 
			// cbDirections
			// 
			this.cbDirections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDirections.FormattingEnabled = true;
			this.cbDirections.Location = new System.Drawing.Point(414, 11);
			this.cbDirections.Name = "cbDirections";
			this.cbDirections.Size = new System.Drawing.Size(374, 28);
			this.cbDirections.TabIndex = 1;
			this.cbDirections.SelectedIndexChanged += new System.EventHandler(this.cbDirections_SelectedIndexChanged);
			// 
			// btn_refresh
			// 
			this.btn_refresh.Location = new System.Drawing.Point(12, 45);
			this.btn_refresh.Name = "btn_refresh";
			this.btn_refresh.Size = new System.Drawing.Size(776, 393);
			this.btn_refresh.TabIndex = 2;
			this.btn_refresh.Text = "Refresh";
			this.btn_refresh.UseVisualStyleBackColor = true;
			this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btn_refresh);
			this.Controls.Add(this.cbDirections);
			this.Controls.Add(this.cbGroups);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cbGroups;
		private System.Windows.Forms.ComboBox cbDirections;
		private System.Windows.Forms.Button btn_refresh;
	}
}

