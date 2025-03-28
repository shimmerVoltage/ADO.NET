﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Configuration;


namespace Academy
{
	public partial class Main : Form
	{	
		Connector connector;

		public Main()
		{
			InitializeComponent();

			connector = new Connector
				(
					ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString
				);

			dgvStudents.DataSource = connector.Select
						(
							"last_name,first_name,middle_name,birth_date,group_name,direction_name",
							"Students,Groups,Directions",
							"[group]=group_id AND direction=direction_id"
						);
			dgvGroups.DataSource = connector.Select
						(
							"group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
							"Groups,Directions",
							"direction=direction_id"
						);
			dgvDirections.DataSource = connector.Select
						(
							"*", 
							"Directions"
						);
			dgvDisciplines.DataSource = connector.Select
						(
							"*", 
							"Disciplines"
						);
			dgvTeachers.DataSource = connector.Select
						(
							"*", 
							"Teachers"
						);

			toolStripStatusLabelCount.Text = $"Количество студентов: {dgvStudents.RowCount - 1}";
		}		

		private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
				
		}
		
		private void Main_Load(object sender, EventArgs e)
		{
		
		}

		private void tabPageStudents_Click(object sender, EventArgs e)
		{

		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{			
			switch (tabControl.SelectedIndex)
			{ 
				case 0: 
					dgvStudents.DataSource = 
						connector.Select
						(
							"last_name,first_name,middle_name,birth_date,group_name,direction_name", 
							"Students,Groups,Directions",
							"[group]=group_id AND direction=direction_id"
						);
					toolStripStatusLabelCount.Text = $"Количество студентов: {dgvStudents.RowCount - 1}";
				break;
				case 1:
					dgvStudents.DataSource = connector.Select
						(
							"group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
							"Groups,Directions",
							"direction=direction_id"
						);
					toolStripStatusLabelCount.Text = $"Количество группов: {dgvGroups.RowCount - 1}";
				break;
				case 2:
					dgvStudents.DataSource = connector.Select("*", "Directions");
					toolStripStatusLabelCount.Text = $"Количество направлений: {dgvDirections.RowCount - 1}";
				break;
				case 3:
					dgvStudents.DataSource = connector.Select("*", "Disciplines");
					toolStripStatusLabelCount.Text = $"Количество дисциплинов: {dgvDisciplines.RowCount - 1}";
				break;
				case 4:
					dgvStudents.DataSource = connector.Select("*", "Teachers");
					toolStripStatusLabelCount.Text = $"Количество преподавателев: {dgvTeachers.RowCount - 1}";
				break;
				
			}


		}
	}
}
