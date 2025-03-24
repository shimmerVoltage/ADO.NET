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
			Connector.Select("*", "Disciplines");
			Console.WriteLine("---------------------------------");
			Console.WriteLine(Connector.ReturnID("JavaScript"));
			Console.WriteLine(Connector.ReturnID("NodeJS"));
		}
	}
}
