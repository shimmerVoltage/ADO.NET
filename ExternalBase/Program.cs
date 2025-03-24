using System;
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
			//Connector.Select("*", "Disciplines");
			Connector.Select("*", "Teachers");
			Console.WriteLine("---------------------------------");
			Console.WriteLine(Connector.ReturnDisciplineID("JavaScript"));
			Console.WriteLine(Connector.ReturnDisciplineID("NodeJS"));
			Console.WriteLine("---------------------------------");
			Console.WriteLine(Connector.ReturnTeacherID("Лялька"));
			Console.WriteLine(Connector.ReturnTeacherID("Свищев"));
		}
	}
}
