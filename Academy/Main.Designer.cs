namespace Academy
{
	partial class Main
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
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageStudents = new System.Windows.Forms.TabPage();
			this.dgvStudents = new System.Windows.Forms.DataGridView();
			this.tabPageGroups = new System.Windows.Forms.TabPage();
			this.dgvGroups = new System.Windows.Forms.DataGridView();
			this.tabPageDirections = new System.Windows.Forms.TabPage();
			this.dgvDirections = new System.Windows.Forms.DataGridView();
			this.tabPageDisciplines = new System.Windows.Forms.TabPage();
			this.dgvDisciplines = new System.Windows.Forms.DataGridView();
			this.tabPageTeacher = new System.Windows.Forms.TabPage();
			this.dgvTeachers = new System.Windows.Forms.DataGridView();
			this.cbGroupsDirection = new System.Windows.Forms.ComboBox();
			this.statusStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageStudents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
			this.tabPageGroups.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
			this.tabPageDirections.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).BeginInit();
			this.tabPageDisciplines.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDisciplines)).BeginInit();
			this.tabPageTeacher.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
			this.statusStrip.Location = new System.Drawing.Point(0, 428);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(800, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip";
			this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
			// 
			// toolStripStatusLabelCount
			// 
			this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
			this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 15);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageStudents);
			this.tabControl.Controls.Add(this.tabPageGroups);
			this.tabControl.Controls.Add(this.tabPageDirections);
			this.tabControl.Controls.Add(this.tabPageDisciplines);
			this.tabControl.Controls.Add(this.tabPageTeacher);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(800, 428);
			this.tabControl.TabIndex = 1;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
			this.tabControl.ContextMenuStripChanged += new System.EventHandler(this.Main_Load);
			// 
			// tabPageStudents
			// 
			this.tabPageStudents.Controls.Add(this.dgvStudents);
			this.tabPageStudents.Location = new System.Drawing.Point(4, 29);
			this.tabPageStudents.Name = "tabPageStudents";
			this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStudents.Size = new System.Drawing.Size(792, 395);
			this.tabPageStudents.TabIndex = 0;
			this.tabPageStudents.Text = "Students";
			this.tabPageStudents.UseVisualStyleBackColor = true;
			this.tabPageStudents.Click += new System.EventHandler(this.tabPageStudents_Click);
			// 
			// dgvStudents
			// 
			this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStudents.Location = new System.Drawing.Point(0, 61);
			this.dgvStudents.Name = "dgvStudents";
			this.dgvStudents.RowHeadersWidth = 62;
			this.dgvStudents.RowTemplate.Height = 28;
			this.dgvStudents.Size = new System.Drawing.Size(792, 338);
			this.dgvStudents.TabIndex = 0;
			// 
			// tabPageGroups
			// 
			this.tabPageGroups.Controls.Add(this.cbGroupsDirection);
			this.tabPageGroups.Controls.Add(this.dgvGroups);
			this.tabPageGroups.Location = new System.Drawing.Point(4, 29);
			this.tabPageGroups.Name = "tabPageGroups";
			this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGroups.Size = new System.Drawing.Size(792, 395);
			this.tabPageGroups.TabIndex = 1;
			this.tabPageGroups.Text = "Groups";
			this.tabPageGroups.UseVisualStyleBackColor = true;
			// 
			// dgvGroups
			// 
			this.dgvGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGroups.Location = new System.Drawing.Point(0, 41);
			this.dgvGroups.Name = "dgvGroups";
			this.dgvGroups.RowHeadersWidth = 62;
			this.dgvGroups.RowTemplate.Height = 28;
			this.dgvGroups.Size = new System.Drawing.Size(792, 360);
			this.dgvGroups.TabIndex = 0;
			// 
			// tabPageDirections
			// 
			this.tabPageDirections.Controls.Add(this.dgvDirections);
			this.tabPageDirections.Location = new System.Drawing.Point(4, 29);
			this.tabPageDirections.Name = "tabPageDirections";
			this.tabPageDirections.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDirections.Size = new System.Drawing.Size(792, 395);
			this.tabPageDirections.TabIndex = 2;
			this.tabPageDirections.Text = "Directions";
			this.tabPageDirections.UseVisualStyleBackColor = true;
			// 
			// dgvDirections
			// 
			this.dgvDirections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDirections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDirections.Location = new System.Drawing.Point(0, 75);
			this.dgvDirections.Name = "dgvDirections";
			this.dgvDirections.RowHeadersWidth = 62;
			this.dgvDirections.RowTemplate.Height = 28;
			this.dgvDirections.Size = new System.Drawing.Size(792, 326);
			this.dgvDirections.TabIndex = 0;
			// 
			// tabPageDisciplines
			// 
			this.tabPageDisciplines.Controls.Add(this.dgvDisciplines);
			this.tabPageDisciplines.Location = new System.Drawing.Point(4, 29);
			this.tabPageDisciplines.Name = "tabPageDisciplines";
			this.tabPageDisciplines.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDisciplines.Size = new System.Drawing.Size(792, 395);
			this.tabPageDisciplines.TabIndex = 3;
			this.tabPageDisciplines.Text = "Disciplines";
			this.tabPageDisciplines.UseVisualStyleBackColor = true;
			// 
			// dgvDisciplines
			// 
			this.dgvDisciplines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDisciplines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDisciplines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDisciplines.Location = new System.Drawing.Point(3, 71);
			this.dgvDisciplines.Name = "dgvDisciplines";
			this.dgvDisciplines.RowHeadersWidth = 62;
			this.dgvDisciplines.RowTemplate.Height = 28;
			this.dgvDisciplines.Size = new System.Drawing.Size(789, 330);
			this.dgvDisciplines.TabIndex = 0;
			// 
			// tabPageTeacher
			// 
			this.tabPageTeacher.Controls.Add(this.dgvTeachers);
			this.tabPageTeacher.Location = new System.Drawing.Point(4, 29);
			this.tabPageTeacher.Name = "tabPageTeacher";
			this.tabPageTeacher.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTeacher.Size = new System.Drawing.Size(792, 395);
			this.tabPageTeacher.TabIndex = 4;
			this.tabPageTeacher.Text = "Teacher";
			this.tabPageTeacher.UseVisualStyleBackColor = true;
			// 
			// dgvTeachers
			// 
			this.dgvTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvTeachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTeachers.Location = new System.Drawing.Point(0, 75);
			this.dgvTeachers.Name = "dgvTeachers";
			this.dgvTeachers.RowHeadersWidth = 62;
			this.dgvTeachers.RowTemplate.Height = 28;
			this.dgvTeachers.Size = new System.Drawing.Size(792, 327);
			this.dgvTeachers.TabIndex = 0;
			// 
			// cbGroupsDirection
			// 
			this.cbGroupsDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbGroupsDirection.FormattingEnabled = true;
			this.cbGroupsDirection.Location = new System.Drawing.Point(483, 7);
			this.cbGroupsDirection.Name = "cbGroupsDirection";
			this.cbGroupsDirection.Size = new System.Drawing.Size(303, 28);
			this.cbGroupsDirection.TabIndex = 1;
			this.cbGroupsDirection.SelectedIndexChanged += new System.EventHandler(this.cbGroupsDirection_SelectedIndexChanged);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.statusStrip);
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Academy";
			this.Load += new System.EventHandler(this.Main_Load);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageStudents.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
			this.tabPageGroups.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
			this.tabPageDirections.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).EndInit();
			this.tabPageDisciplines.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDisciplines)).EndInit();
			this.tabPageTeacher.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageStudents;
		private System.Windows.Forms.TabPage tabPageGroups;
		private System.Windows.Forms.TabPage tabPageDirections;
		private System.Windows.Forms.TabPage tabPageDisciplines;
		private System.Windows.Forms.TabPage tabPageTeacher;
		private System.Windows.Forms.DataGridView dgvStudents;
		private System.Windows.Forms.DataGridView dgvGroups;
		private System.Windows.Forms.DataGridView dgvDirections;
		private System.Windows.Forms.DataGridView dgvDisciplines;
		private System.Windows.Forms.DataGridView dgvTeachers;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
		private System.Windows.Forms.ComboBox cbGroupsDirection;
	}
}

