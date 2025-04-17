﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AcademyDataSet
{
	internal class Cache
	{
		readonly string CONNECTION_STRING = "";
		SqlConnection connection;
		public DataSet Set { get; set; }
		List<string> tables;
		List<string> commands;
		public Cache() 
		{
			CONNECTION_STRING = ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString;
			connection = new SqlConnection(CONNECTION_STRING);
			Console.WriteLine(CONNECTION_STRING);

			tables = new List<string>();
			Set = new DataSet(nameof(Set));
			//LoadGroupsRelatedData();
			//Check();
		}

		public void AddTable(string table, string columns)
		{
			string[] separated_colimns = columns.Split(',');
			Set.Tables.Add(table);
			for (int i = 0; i < separated_colimns.Length; i++)
				Set.Tables[table].Columns.Add(separated_colimns[i]);
			Set.Tables[table].PrimaryKey =
				new DataColumn[]
				{ Set.Tables[table].Columns[separated_colimns[0]] };
			tables.Add($"{table},{columns}");
		}
		
		public void AddRelation(string name, string child, string parent)
		{
			Set.Relations.Add
				(
					name,
					Set.Tables[parent.Split(',')[0]].Columns[parent.Split(',')[1]],
					Set.Tables[child.Split(',')[0]].Columns[child.Split(',')[1]]
				);
		}

		public void Load()
		{
			string[] tables = this.tables.ToArray();
			for (int i = 0; i < tables.Length; i++)
			{
				string columns = "";
				DataColumnCollection column_Collection = Set.Tables[tables[i].Split(',')[0]].Columns;
				foreach (DataColumn column in column_Collection)
				{
					columns += $"[{column.ColumnName}],";
				}
				columns = columns.Remove(columns.LastIndexOf(','));
				Console.WriteLine(columns);
				string cmd = $"SELECT * FROM {tables[i].Split(',')[0]}";
				SqlDataAdapter adapter = new SqlDataAdapter(cmd, connection);
				adapter.Fill(Set.Tables[tables[i].Split(',')[0]]);
			}
		}

		void LoadGroupsRelatedData()
		{
			Console.WriteLine(nameof(Set));
			const string dsTable_Directions = "Directions";
			const string dst_col_direction_id = "direction_id";
			const string dst_col_direction_name = "direction_name";
			Set.Tables.Add(dsTable_Directions);
			Set.Tables[dsTable_Directions].Columns.Add(dst_col_direction_id, typeof(byte));
			Set.Tables[dsTable_Directions].Columns.Add(dst_col_direction_name, typeof(string));
			Set.Tables[dsTable_Directions].PrimaryKey =
				new DataColumn[] { Set.Tables[dsTable_Directions].Columns[dst_col_direction_id] };

			const string dsTable_Groups = "Groups";
			const string dst_Groups_col_group_id = "group_id";
			const string dst_Groups_col_group_name = "group_name";
			const string dst_Groups_col_direction = "direction";
			Set.Tables.Add(dsTable_Groups);
			Set.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_group_id, typeof(int));
			Set.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_group_name, typeof(string));
			Set.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_direction, typeof(byte));
			Set.Tables[dsTable_Groups].PrimaryKey =
				new DataColumn[] { Set.Tables[dsTable_Groups].Columns[dst_Groups_col_group_id] };

			string dsRelation_GroupsDirections = "GroupsDirections";
			Set.Relations.Add
				(
					dsRelation_GroupsDirections,
					Set.Tables["Directions"].Columns["direction_id"],
					Set.Tables["Groups"].Columns["direction"]
				);

			string directions_cmd = "SELECT * FROM Directions";
			string groups_cmd = "SELECT * FROM Groups";
			SqlDataAdapter directionsAdapter = new SqlDataAdapter(directions_cmd, connection);
			SqlDataAdapter groupsAdapter = new SqlDataAdapter(groups_cmd, connection);

			connection.Open();
			directionsAdapter.Fill(Set.Tables[dsTable_Directions]);
			groupsAdapter.Fill(Set.Tables[dsTable_Groups]);
			connection.Close();

			foreach (DataRow row in Set.Tables[dsTable_Directions].Rows)
			{
				Console.WriteLine($"{row[dst_col_direction_id]}\t{row[dst_col_direction_name]}");
			}
			Console.WriteLine("\n------------------------------------------------------\n");
			foreach (DataRow row in Set.Tables[dsTable_Groups].Rows)
			{
				Console.WriteLine($"{row[dst_Groups_col_group_id]}\t{row[dst_Groups_col_group_name]}\t{row.GetParentRow(dsRelation_GroupsDirections)[dst_col_direction_name]}");
			}
		}

		public void Print(string table)
		{
			Console.WriteLine("\n------------------------------------\n");
			Console.WriteLine(HasParents(table));
			string relation_name = "No relation";
			string parent_table_name = "";
			string parent_column_name = "";
			int parent_index = -1;
			if (HasParents(table))
			{
				relation_name = Set.Tables[table].ParentRelations[0].RelationName;
				parent_table_name = Set.Tables[table].ParentRelations[0].ParentTable.TableName;
				parent_column_name = parent_table_name.ToLower().Substring(0, parent_table_name.Length - 1) + "_name";
				Console.WriteLine(parent_table_name);
				//DataColumn parent_column = GroupsRelatedData.Tables[parent_table_name].Columns["direction_name"];
				//Console.WriteLine(parent_column.ColumnName);
				parent_index =
					Set.Tables[table].Columns.
					IndexOf(parent_table_name.ToLower().Substring(0, parent_table_name.Length - 1));
				Console.WriteLine("parent_index " + parent_index);
			}
			foreach (DataRow row in Set.Tables[table].Rows)
			{
				for (int i = 0; i < row.ItemArray.Length; i++)
				{
					if (i == parent_index)
					{
						DataRow parent_row = row.GetParentRow(relation_name);
						Console.Write(parent_row[parent_column_name]);
						//Console.Write(row.GetParentRow(relation_name)[parent_column_name]);
						//GroupsRelatedData.Tables;
					}
					else
						Console.Write(row[i].ToString() + "\t");
					//Console.WriteLine(row[i].GetType());					
				}
				//if (HasParents(table))
				//{
				//	DataRow parent_row = row.GetParentRow(GroupsRelatedData.Tables[table].ParentRelations[0].RelationName);
				//	//for (int j = 0; j < parent_row.ItemArray.Length; j++)
				//	//Console.Write(parent_row[j] + "\t");
				//	Console.Write(parent_row["direction_name"]);
				//}
				Console.WriteLine();
			}
			Console.WriteLine("\n------------------------------------\n");
		}
		bool HasParents(string table)
		{

			return Set.Tables[table].ParentRelations.Count > 0;
			//for (int i = 0; i < GroupsRelatedData.Relations.Count; i++)
			//{				
			//	if (GroupsRelatedData.Relations[i].ChildTable.TableName == table) return true;				
			//}
			//return false;
		}
		void Check()
		{
			AddTable("Directions", "direction_id,direction_name");
			AddTable("Groups", "group_id,group_name,direction");
			AddTable("Students", "stud_id,last_name,first_name,middle_name,birth_date,group");
			AddRelation("GroupsDirections", "Groups,direction", "Directions,direction_id");
			AddRelation("StudentsGroups", "Students,group", "Groups,group_id");
			Load();
			Print("Directions");
			Print("Groups");
			Print("Students");
		}
	}
}
