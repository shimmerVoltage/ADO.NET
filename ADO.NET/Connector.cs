using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
	internal class Connector
	{
		public SqlConnection connection;
		public SqlCommand command;
		public SqlDataReader reader;

		public Connector(string CONNECTION_STRING, string cmd)
		{
			connection = new SqlConnection(CONNECTION_STRING);
			command = new SqlCommand(cmd, connection);			
		}

		public void OnScreen(int PADDING)
		{
			connection.Open();
			reader = command.ExecuteReader();

			if (reader.HasRows)
			{
				
				Console.WriteLine("========================================================================================================");
				for (int i = 0; i < reader.FieldCount; i++)
					Console.Write(reader.GetName(i).PadRight(PADDING));
				Console.WriteLine();
				Console.WriteLine("========================================================================================================");
				while (reader.Read())
				{
					//Console.WriteLine($"{reader[0].ToString().PadRight(5)}{reader[2].ToString().PadRight(15)}{reader[1].ToString().PadRight(15)}");
					for (int i = 0; i < reader.FieldCount; i++)
					{
						Console.Write(reader[i].ToString().PadRight(PADDING));
					}
					Console.WriteLine();
				}
			}

			reader.Close();
			connection.Close();
		}
	}
}
