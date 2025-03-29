using System;
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
		Dictionary<string, int> d_directions;
		DataGridView[] tables;
		Query[] queries = new Query[]
			{
				new Query
				(
					"last_name,first_name,middle_name,birth_date,group_name,direction_name",
					"Students,Groups,Directions",
					"[group]=group_id AND direction=direction_id"
				),
				new Query
				(
					"group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
					"Groups,Directions",
					"direction=direction_id"
				),
				new Query
				(
					"direction_name,COUNT(DISTINCT group_id) AS N'Количество группов', COUNT(stud_id) AS N'Количество студентов'",
					"Students RIGHT JOIN Groups ON ([group]=group_id) RIGHT JOIN Directions ON (direction=direction_id)",
					"",
					"direction_name"
				),
				new Query
				(
						"*",
						"Disciplines"
				),
				new Query
				(
						"*",
						"Teachers"
				)


			};

		string[] status_messages = new string[]
			{
				$"Количество студентов: ",
				$"Количество групп: ",
				$"Количество направлений: ",
				$"Количество дисциплин: ",
				$"Количество преподавателей: "
			};


		public Main()
		{
			InitializeComponent();

			connector = new Connector
				(
					ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString
				);
			d_directions = connector.GetDictionary("*", "Directions");
			cbGroupsDirection.Items.AddRange(d_directions.Select(k => k.Key).ToArray());
			tables = new DataGridView[]
			{
				dgvStudents,
				dgvGroups,
				dgvDirections,
				dgvDisciplines,
				dgvTeachers
			};

			//dgvStudents.DataSource = connector.Select
			//			(
			//				"last_name,first_name,middle_name,birth_date,group_name,direction_name",
			//				"Students,Groups,Directions",
			//				"[group]=group_id AND direction=direction_id"
			//			);
			//dgvGroups.DataSource = connector.Select
			//			(
			//				"group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
			//				"Groups,Directions",
			//				"direction=direction_id"
			//			);
			//dgvDirections.DataSource = connector.Select
			//			(
			//				"direction_name,COUNT(DISTINCT group_id) AS N'Количество группов', COUNT(stud_id) AS N'Количество студентов'", 
			//				"Students,Groups,Directions",
			//				"[group]=group_id AND direction=direction_id",
			//				"direction_name"
			//			);
			//dgvDirections.DataSource = connector.Select
			//			(
			//				"direction_name,COUNT(DISTINCT group_id) AS N'Количество группов', COUNT(stud_id) AS N'Количество студентов'",
			//				"Students RIGHT JOIN Groups ON ([group]=group_id) RIGHT JOIN Directions ON (direction=direction_id)",
			//				"",
			//				"direction_name"
			//			);
			//dgvDisciplines.DataSource = connector.Select
			//			(
			//				"*", 
			//				"Disciplines"
			//			);
			//dgvTeachers.DataSource = connector.Select
			//			(
			//				"*", 
			//				"Teachers"
			//			);

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
			int i = tabControl.SelectedIndex;
			Query query = queries[i];
			tables[i].DataSource = 
				connector.Select(query.Columns, query.Tables, query.Condition, query.Group_by);
			toolStripStatusLabelCount.Text = status_messages[i] + CountRecordsInDGV(tables[i]);
			//switch (tabControl.SelectedIndex)
			//{ 
			//	case 0: 
			//		dgvStudents.DataSource = 
			//			connector.Select
			//			(
			//				"last_name,first_name,middle_name,birth_date,group_name,direction_name", 
			//				"Students,Groups,Directions",
			//				"[group]=group_id AND direction=direction_id"
			//			);
			//		toolStripStatusLabelCount.Text = $"Количество студентов: {dgvStudents.RowCount - 1}";
			//	break;
			//	case 1:
			//		dgvStudents.DataSource = connector.Select
			//			(
			//				"group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
			//				"Groups,Directions",
			//				"direction=direction_id"
			//			);
			//		toolStripStatusLabelCount.Text = $"Количество группов: {dgvGroups.RowCount - 1}";
			//	break;
			//	case 2:
			//		dgvStudents.DataSource = connector.Select("*", "Directions");
			//		toolStripStatusLabelCount.Text = $"Количество направлений: {dgvDirections.RowCount - 1}";
			//	break;
			//	case 3:
			//		dgvStudents.DataSource = connector.Select("*", "Disciplines");
			//		toolStripStatusLabelCount.Text = $"Количество дисциплинов: {dgvDisciplines.RowCount - 1}";
			//	break;
			//	case 4:
			//		dgvStudents.DataSource = connector.Select("*", "Teachers");
			//		toolStripStatusLabelCount.Text = $"Количество преподавателев: {dgvTeachers.RowCount - 1}";
			//	break;				
			//}
		}

		private void cbGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			dgvGroups.DataSource = connector.Select
						(
							"group_name,dbo.GetLearningDaysFor(group_name) AS weekdays,start_time,direction_name",
							"Groups,Directions",
							$"direction=direction_id AND direction = N'{d_directions[cbGroupsDirection.SelectedItem.ToString()]}'"
						);
			toolStripStatusLabelCount.Text = $"Количество групп: {CountRecordsInDGV(dgvGroups)}";
		}

		int CountRecordsInDGV(DataGridView dgv)
		{
			return dgv.Rows.Count == 0 ? 0 : dgv.RowCount - 1;
		}
	}
}
