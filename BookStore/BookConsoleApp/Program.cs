using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using BookStore.Library;
using BookStore.Library.Interfaces;
using BookStore.Library.Models;
using BookStore.Library.Repository;

namespace BookConsoleApp
{
	public static class Program
	{
		static void Main()
		{
			using var dependencies = new Dependencies();
			XmlSerializer serializer = dependencies.CreateXmlSerializer();

			ICustomerRepository customerRepository = dependencies.CreatCustomerRepository();
			IBookRepository bookRepository = dependencies.CreateBookRepository();
			RunUi(bookRepository, serializer);
		}

		public static void RunUi(IBookRepository bookRepository, XmlSerializer serializer)
		{

			Console.WriteLine("Book Store");

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("c:\tManage customers.");
				Console.WriteLine("o:\tManage orders.");
				Console.WriteLine("b:\tDisplay or Manage books.");
				Console.WriteLine("s:\tSave data to disk.");
				Console.WriteLine();
				Console.Write("Enter valid menu option, or \"q\" to quit: ");

				var input = Console.ReadLine();

				if (input == "c")
			}

		}
		
	}
}
	

	