﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace AcademyDataSet
{
	public partial class MainForm : Form
	{
		readonly string CONNECTION_STRING = "";
		SqlConnection connection;
		DataSet GroupsRelatedData;
		List<string> tables;
		public MainForm()
		{
			InitializeComponent();
			AllocConsole();
			CONNECTION_STRING = ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString;
			connection = new SqlConnection(CONNECTION_STRING);
			Console.WriteLine(CONNECTION_STRING);

			tables = new List<string>();
			GroupsRelatedData = new DataSet(nameof(GroupsRelatedData));
			//LoadGroupsRelatedData();
			Check();
		}
		void AddTable(string table, string columns)
		{
			string[] separated_colimns = columns.Split(',');
			GroupsRelatedData.Tables.Add(table);
			for (int i = 0; i < separated_colimns.Length; i++)
				GroupsRelatedData.Tables[table].Columns.Add(separated_colimns[i]);
			GroupsRelatedData.Tables[table].PrimaryKey =
				new DataColumn[]
				{ GroupsRelatedData.Tables[table].Columns[separated_colimns[0]] };
			tables.Add($"{table},{columns}");
		}
		public void AddRelation(string name, string child, string parent)
		{
			GroupsRelatedData.Relations.Add
				(
					name,
					GroupsRelatedData.Tables[parent.Split(',')[0]].Columns[parent.Split(',')[1]],
					GroupsRelatedData.Tables[child.Split(',')[0]].Columns[child.Split(',')[1]]

				);
		}
		public void Load()
		{
			string[] tables = this.tables.ToArray();
			for (int i = 0; i < tables.Length; i++)
			{
				string cmd = $"SELECT * FROM {tables[i].Split(',')[0]}";
				SqlDataAdapter adapter = new SqlDataAdapter(cmd, connection);
				adapter.Fill(GroupsRelatedData.Tables[tables[i].Split(',')[0]]);
			}
		}
		void LoadGroupsRelatedData()
		{
			Console.WriteLine(nameof(GroupsRelatedData));
			const string dsTable_Directions = "Directions";
			const string dst_col_direction_id = "direction_id";
			const string dst_col_direction_name = "direction_name";
			GroupsRelatedData.Tables.Add(dsTable_Directions);
			GroupsRelatedData.Tables[dsTable_Directions].Columns.Add(dst_col_direction_id, typeof(byte));
			GroupsRelatedData.Tables[dsTable_Directions].Columns.Add(dst_col_direction_name, typeof(string));
			GroupsRelatedData.Tables[dsTable_Directions].PrimaryKey =
				new DataColumn[] { GroupsRelatedData.Tables[dsTable_Directions].Columns[dst_col_direction_id] };

			const string dsTable_Groups = "Groups";
			const string dst_Groups_col_group_id = "group_id";
			const string dst_Groups_col_group_name = "group_name";
			const string dst_Groups_col_direction = "direction";
			GroupsRelatedData.Tables.Add(dsTable_Groups);
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_group_id, typeof(int));
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_group_name, typeof(string));
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_direction, typeof(byte));
			GroupsRelatedData.Tables[dsTable_Groups].PrimaryKey =
				new DataColumn[] { GroupsRelatedData.Tables[dsTable_Groups].Columns[dst_Groups_col_group_id] };

			string dsRelation_GroupsDirections = "GroupsDirections";
			GroupsRelatedData.Relations.Add
				(
					dsRelation_GroupsDirections,
					GroupsRelatedData.Tables["Directions"].Columns["direction_id"],
					GroupsRelatedData.Tables["Groups"].Columns["direction"]
				);

			string directions_cmd = "SELECT * FROM Directions";
			string groups_cmd = "SELECT * FROM Groups";
			SqlDataAdapter directionsAdapter = new SqlDataAdapter(directions_cmd, connection);
			SqlDataAdapter groupsAdapter = new SqlDataAdapter(groups_cmd, connection);

			connection.Open();
			directionsAdapter.Fill(GroupsRelatedData.Tables[dsTable_Directions]);
			groupsAdapter.Fill(GroupsRelatedData.Tables[dsTable_Groups]);
			connection.Close();

			foreach (DataRow row in GroupsRelatedData.Tables[dsTable_Directions].Rows)
			{
				Console.WriteLine($"{row[dst_col_direction_id]}\t{row[dst_col_direction_name]}");
			}
			Console.WriteLine("\n------------------------------------------------------\n");
			foreach (DataRow row in GroupsRelatedData.Tables[dsTable_Groups].Rows)
			{
				Console.WriteLine($"{row[dst_Groups_col_group_id]}\t{row[dst_Groups_col_group_name]}\t{row.GetParentRow(dsRelation_GroupsDirections)[dst_col_direction_name]}");
			}
		}
		void Print(string table)
		{
			Console.WriteLine("\n----------------------------------------------\n");
			Console.WriteLine(HasParents(table));
			foreach (DataRow row in GroupsRelatedData.Tables[table].Rows)
			{
				for (int i = 0; i < row.ItemArray.Length; i++)
				{
					Console.Write(row[i].ToString() + "\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine("\n----------------------------------------------\n");
		}
		bool HasParents(string table)
		{
			for (int i = 0; i < GroupsRelatedData.Relations.Count; i++)
			{				
				if (GroupsRelatedData.Relations[i].ChildTable.TableName == table) return true;				
			}
			return false;
		}
		void Check()
		{
			AddTable("Directions", "direction_id,direction_name");
			AddTable("Groups", "group_id,group_name,direction");
			AddRelation("GroupsDirections", "Groups,direction", "Directions,direction_id");
			Load();
			Print("Directions");
			Print("Groups");
		}
		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();		
	}
}