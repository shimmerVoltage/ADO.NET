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
		public Main()
		{
			InitializeComponent();

			Connector connector = new Connector
				(
					ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString
				);

			dgvStudents.DataSource = connector.Select("*", "Students");
			dgvGroups.DataSource = connector.Select("*", "Groups");
			dgvDirections.DataSource = connector.Select("*", "Directions");
			dgvDisciplines.DataSource = connector.Select("*", "Disciplines");
			dgvTeachers.DataSource = connector.Select("*", "Teachers");


			//toolStripStatusLabel1.Text = Convert.ToString(connector.Count("Students"));
			


			Console.WriteLine(connector.Count("Students"));
			Console.WriteLine(connector.Count("Groups"));
			Console.WriteLine(connector.Count("Directions"));
			Console.WriteLine(connector.Count("Disciplines"));
			Console.WriteLine(connector.Count("Teachers"));
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
			Connector connector = new Connector
				(
					ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString
				);

			if (tabControl.SelectedIndex == 0)
			{
				toolStripStatusLabel1.Text = Convert.ToString(connector.Count("Students"));
			}
			if (tabControl.SelectedIndex == 1)
			{
				toolStripStatusLabel1.Text = Convert.ToString(connector.Count("Groups"));
			}
			if (tabControl.SelectedIndex == 2)
			{
				toolStripStatusLabel1.Text = Convert.ToString(connector.Count("Directions"));
			}
			if (tabControl.SelectedIndex == 3)
			{
				toolStripStatusLabel1.Text = Convert.ToString(connector.Count("Disciplines"));
			}
			if (tabControl.SelectedIndex == 4)
			{
				toolStripStatusLabel1.Text = Convert.ToString(connector.Count("Teachers"));
			}

		}
	}
}
