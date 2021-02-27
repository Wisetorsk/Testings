using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingDiscordRPGStuff
{
	public class TestObject
	{
		public int Value1 { get; set; } = 10;
		public string Value2 { get; set; } = "Ten";
		public Random Value3 { get; set; } = new Random();
		public bool Value4 { get; set; } = false;
		public List<int> Collection1 { get; set; } = Enumerable.Range(10, 40).ToList();
		public List<string> Collection2 { get; set; } = Enumerable.Range(10, 40).Select(i => "a" + i.ToString()).ToList();
		public List<Random> Empty { get; set; }
		public int AnotherVal = 2345;
		public Func<int> TestFunc { get; set; } = () => 57;

		public int Math(int a, int b)
		{
			return a * b;
		}

		public void ReadFromJson(string json)
        {
			var parts = json.Split(':');
			foreach(var par in parts)
            {
                Console.WriteLine(par);
            }
        }
	}
}
