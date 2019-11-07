using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReivewCode
{
	class Program
	{
		static void Main( string[] args )
		{

			Rhodecode rhodecode = new Rhodecode();
			rhodecode.Start();
			Console.WriteLine( "Test" );
			Console.ReadKey();
		}
	}
}
