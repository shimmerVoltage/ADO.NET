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
		public Main()
		{
			InitializeComponent();

			Connector connector = new Connector
				(
					ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString
				);

			dgvStudents.DataSource = connector.Select("*", "Students");
		}

		private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
		
		}
		
		private void Main_Load(object sender, EventArgs e)
		{
		
		}
	}
}
