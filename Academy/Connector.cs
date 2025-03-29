﻿//#define OLD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace Academy
{
	public class Connector
	{
		readonly string CONNECTION_STRING;// = ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString;
		SqlConnection connection;

		public Connector(string connection_string)
		{
			//CONNECTION_STRING = ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString;
			CONNECTION_STRING = connection_string;
			connection = new SqlConnection(CONNECTION_STRING);
			AllocConsole();
			Console.WriteLine(CONNECTION_STRING);
		}

		~Connector() 
		{
			FreeConsole();
		}

		public Dictionary<string, int> GetDictionary(string columns, string tables)
		{
			Dictionary<string, int> values = new Dictionary<string, int>();
			string cmd = $"SELECT {columns} FROM {tables}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					values[reader[1].ToString()] = Convert.ToInt32(reader[0]);
				}
			}
			reader.Close();
			connection.Close();
			return values;
		}

		public DataTable Select(string columns, string tables, string condition = "", string group_by = "")
		{
			DataTable table = null;

			string cmd = $"SELECT {columns} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
			if (group_by  != "") cmd += $" GROUP BY {group_by}";
			cmd += ";";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();

			if (reader.HasRows)
			{
				table = new DataTable();
				table.Load(reader);
#if OLD
				for (int i = 0; i < reader.FieldCount; i++)
				{
					table.Columns.Add();
				}

				while (reader.Read())
				{
					DataRow row = table.NewRow();
					for (int i = 0; i < reader.FieldCount; i++)
					{
						row[i] = reader[i];
					}
					table.Rows.Add(row);
				}
#endif
			}

			reader.Close();
			connection.Close();
			return table; 
		}

		

		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();

		public int Count(string table)
		{
			int count = 0;
			string cmd = $"SELECT COUNT(*) FROM {table}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			count = Convert.ToInt32(command.ExecuteScalar());
			connection.Close();
			return count;
		}
	}
}
