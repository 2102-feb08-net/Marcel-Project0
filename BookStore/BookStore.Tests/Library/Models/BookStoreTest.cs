using System;
using BookStore.Library;
using BookStore.Library.Models;
using Xunit;

namespace BookStore.Tests.Library.Models
{
	public class BookStoreTest
	{
		readonly Book book = new Book();

		[Fact]
		public void Title_NonEmptyValue_StoresCorrectly()
		{
			const string randomTitleValue = "Dracula";
			book.Title = randomTitleValue;
			Assert.Equal(randomTitleValue, book.Title);
		}

		[Fact]
		public void Title_EmptyValue_ThrowsArgumentException()
		{
			Assert.ThrowsAny<ArgumentException>(() => book.Title = string.Empty);
		}

		[Fact]
		public void Author_NonEmptyValue_StoresCorrectly()
		{
			const string randomAuthorValue = "Stephen King";
			book.Author = randomAuthorValue;
			Assert.Equal(randomAuthorValue, book.Author);
		}

		[Fact]
		public void Author_EmptyValue_ThrowsArgumentException()
		{
			Assert.ThrowsAny<ArgumentException>(() => book.Author = string.Empty);
		}

		[Fact]
		public void Price_NonEmptyValue_StoresCorrectly()
		{
			const double randomPriceValue = 15.00;
			book.Price = randomPriceValue;
			Assert.Equal(randomPriceValue, book.Price);
		}

		[Fact]

		public void Price_EmptyValue_ThrowsArgumentException()
		{
			Assert.ThrowsAny<ArgumentException>(() => book.Price = double.NegativeInfinity);
		}


	}
}
