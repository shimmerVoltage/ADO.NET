﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalBase
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Connector.Select("*", "Disciplines");
			Console.WriteLine("---------------------------------");
			Console.WriteLine(Connector.ReturnDisciplineID("JavaScript"));
			Console.WriteLine(Connector.ReturnDisciplineID("NodeJS"));
			Console.WriteLine("---------------------------------");
			Console.WriteLine(Connector.Count("Disciplines"));
			Console.WriteLine("---------------------------------");
			Connector.Select("*", "Teachers");
			Console.WriteLine("---------------------------------");
			Console.WriteLine(Connector.ReturnTeacherID("Свищев"));
			Console.WriteLine(Connector.ReturnTeacherID("Лялька"));
			Console.WriteLine("---------------------------------");
			Console.WriteLine(Connector.Count("Teachers"));
			Console.WriteLine("---------------------------------");
			Connector.Select("*", "Students");
			Console.WriteLine("---------------------------------");
			Console.WriteLine(Connector.Count("Students"));
		}
	}
}
