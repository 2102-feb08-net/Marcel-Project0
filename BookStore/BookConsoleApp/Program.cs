using System;

namespace BookConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var bookInventory = new BookInventory(dataSource);
			Console.WriteLine("Book Store");

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("r:\tDisplay books.");
				Console.WriteLine("a:\tAdd new book.");
				Console.WriteLine("s:\tSave data to disk.");
				Console.WriteLine("l:\tLoad data from disk.");
				Console.WriteLine();
				Console.Write("Enter valid option, or \"q\" to quit: ");
				var input = Console.ReadLine();
				{
					var books = bookInventory.GetBooks().ToList();
				}
			}
		}
	}
}