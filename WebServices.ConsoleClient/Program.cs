using System;
using System.Threading.Tasks;

namespace WebServices.ConsoleClient
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var output = Helpers.InvokeFibonacciService(10);
			Console.WriteLine($"the 10th element of Fibonacci sequence is {output}");
			Console.ReadLine();
		}
	}
}
