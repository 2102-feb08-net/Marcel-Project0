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

			ICustomerRepository customerRepository = dependencies.CreateCustomerRepository();
			IBookRepository bookRepository = dependencies.CreateBookRepository();
			RunUi(bookRepository, customerRepository, serializer);
		}

		public static void RunUi(IBookRepository bookRepository, ICustomerRepository customerRepository, XmlSerializer serializer)
		{

			Console.WriteLine("Book Store");

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("c:\tDisplay and manage customers.");
				Console.WriteLine("a:\tAdd new customers.");
				Console.WriteLine("b:\tDisplay or Manage books.");
				Console.WriteLine("s:\tSave data to disk.");
				Console.WriteLine();
				Console.Write("Enter valid menu option, or \"q\" to quit: ");

				var input = Console.ReadLine();

				if (input == "c")
				{
					var customers = customerRepository.GetCustomers().ToList();
					Console.WriteLine();
					if (customers.Count == 0)
					{
						Console.WriteLine("No customers.");
					}
					while (customers.Count > 0)
					{
						for (var i = 1; i <= customers.Count; i++)
						{
							Customer customer = customers[i - 1];
							var customerString = $"{i}: \"{customer.FirstName}\"";
							if (customer.Addresses?.Count > 0)
							{
								Console.WriteLine(customerString);
							}
						}
						Console.WriteLine();
						Console.Write("Enter valid menu option, or \"b\" to go back: ");
						input = Console.ReadLine();
						if (int.TryParse(input, out var customerNum)
								&& customerNum > 0 && customerNum <= customers.Count)
						{
							Customer customer = customers[customerNum - 1];
							List<Address> addresses = customer.Addresses;
							while (true)
							{
								Console.WriteLine();
								var customerString = $"\"{customer.FirstName}\"";
								if (customer.Addresses?.Count > 0)
								{
									Console.WriteLine(customerString);
								}
								if (addresses.Count > 0)
								{
									Console.WriteLine("c:\tDisplay addresses.");
								}
								Console.WriteLine("a:\tAdd review.");
								Console.WriteLine("e:\tEdit.");
								Console.WriteLine("d:\tDelete.");
								Console.WriteLine();
								Console.Write("Enter valid menu option, or \"b\" to go back: ");
								input = Console.ReadLine();
								if (input == "c" && addresses.Count > 0)
								{
									while (addresses.Count > 0)
									{
										Console.WriteLine();
										for (var i = 1; i <= addresses.Count; i++)
										{
											Address address = addresses[i - 1];
											Console.WriteLine($"{i}:"
												+ $" From \"{address.City}\""
												+ $" In \"{address.States}\"");

										}
										Console.WriteLine();
										Console.Write("Enter valid menu option,"
												+ " or \"b\" to go back: ");
										input = Console.ReadLine();
										if (int.TryParse(input, out var addressNum)
											&& addressNum > 0 && addressNum <= addresses.Count)
										{
											Console.WriteLine();
											Console.WriteLine("e:\tEdit.");
											Console.WriteLine("d:\tDelete.");
											Console.WriteLine();
											Console.Write("Enter valid menu option, "
												+ "or \"b\" to go back: ");
											input = Console.ReadLine();
										}
										else if (input == "b")
										{
											break;
										}
										else
										{
											Console.WriteLine();
											Console.WriteLine($"Invalid input \"{input}\".");
										}
									}
								}


							}

						}

					}

				}
				else if (input == "a")
				{
					var customer = new Customer();
					while (customer.FirstName == null)
					{
						Console.WriteLine();
						Console.Write("Enter the new customer name: ");
						input = Console.ReadLine();
						try
						{
							customer.FirstName = input;
						}
						catch (ArgumentException ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
					customerRepository.AddCustomer(customer);
					customerRepository.Save();
				}
				else if (input == "s")
				{
					Console.WriteLine();
					var customers = customerRepository.GetCustomers().ToList();
					try
					{
						using (var stream = new FileStream("../../../data.xml", FileMode.Create))
						{
							serializer.Serialize(stream, customers);
						}
						Console.WriteLine("Success.");
					}
					catch (SecurityException ex)
					{
						Console.WriteLine($"Error while saving: {ex.Message}");
					}
					catch (IOException ex)
					{
						Console.WriteLine($"Error while saving: {ex.Message}");
					}
				}
				else if (input == "l")
				{
					Console.WriteLine();
					List<Customer> customers;
					try
					{
						using (var stream = new FileStream("../../../data.xml", FileMode.Open))
						{
							customers = (List<Customer>)serializer.Deserialize(stream);
						}
						Console.WriteLine("Success.");
						foreach (Customer item in customerRepository.GetCustomers())
						{
							customerRepository.DeleteCustomer(item.CustomerId);
						}
						foreach (Customer item in customers)
						{
							customerRepository.AddCustomer(item);
						}
						customerRepository.Save();
					}
					catch (FileNotFoundException)
					{
						Console.WriteLine("No saved data found.");
					}
					catch (SecurityException ex)
					{
						Console.WriteLine($"Error while loading: {ex.Message}");
					}
					catch (IOException ex)
					{
						Console.WriteLine($"Error while loading: {ex.Message}");
					}
				}
				else if (input == "q")
				{
					break;
				}
				else
				{
					Console.WriteLine();
					Console.WriteLine($"Invalid input \"{input}\".");
				}

			}
		}
	}
}
	

	