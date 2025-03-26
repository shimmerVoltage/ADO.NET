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

		public DataTable Select(string columns, string tables, string condition = "")
		{
			DataTable table = null;

			string cmd = $"SELECT {columns} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
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
