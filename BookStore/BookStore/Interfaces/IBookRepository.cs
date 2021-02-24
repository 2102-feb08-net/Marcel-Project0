using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Library.Models;

namespace BookStore.Library.Interfaces
{
	public interface IBookRepository
	{
		// Returns the collection of books 
		// Does not execute until the result is needed
		IEnumerable<Book> GetBooks(string search = null);

		// Gets book by ID
		// Returns the book
		Book GetBookbyId(int id);

		// Adds a book
		void AddBook(Book book);

		// Deletes a book by ID
		void DeleteBook(int bookId);
		
		// Saves changes to the data source.
		void Save();
	}
}
