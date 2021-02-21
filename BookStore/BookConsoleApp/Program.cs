using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using BookStore.Library;
using BookStore.Library.Inventory;

namespace BookConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			// Initalizes a list of specified type. Refers to public class defined in Book file.
			var dataSource = new List<Book>();
			var bookInventory = new BookInventory(dataSource);
			_ = new XmlSerializer(typeof(List<Book>));

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
				if (input == "r")
				{
					var books = bookInventory.GetBooks().ToList();
					Console.WriteLine();
					if (books.Count == 0)
					{
						Console.WriteLine("No books.");
					}
					// Displays the book collection
					while (books.Count > 0)
					{
						for (var i = 1; i <= books.Count; i++)
						{
							var book = books[i - 1];
							var bookString = $"{i}: \"{book.Title}\"{book.Author}\"";
							var bookDouble = $"{i}: \"{book.Price}\"";

							Console.WriteLine(bookString);
							Console.WriteLine(bookDouble);
						}
					}

				}
				else if (input == "a")
				{
					var newBook = new Book();
					while (newBook.Title == null)
					{
						Console.WriteLine();
						Console.Write("Enter book title: ");
						input = Console.ReadLine();
						try
						{
							newBook.Title = input;
						}
						catch (ArgumentException ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
					while (newBook.Author == null)
					{
						Console.WriteLine();
						Console.Write("Write author's name: ");
						input = Console.ReadLine();
						try
						{
							newBook.Author = input;
						}
						catch (ArgumentException ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
					while (newBook.Price == 0.00)
					{
						Console.WriteLine();
						Console.Write("Enter price: ");
						input = Console.ReadLine();
						try
						{
							newBook.Price = double.Parse(input);
						}
						catch (FormatException ex)
						{
							Console.WriteLine(ex.Message);
						}
						catch (OverflowException ex)
						{
							Console.WriteLine(ex.Message);
						}
						catch (ArgumentException ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
					bookInventory.AddBook(Book);
					
				}

			}
		}
	}
}