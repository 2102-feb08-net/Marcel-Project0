using System;
using Xunit;

namespace BookStore.Tests.Library.Models
{
	public class BookStoreTest
	{
		readonly Book book = new Book();
		
		[Fact]
		public void Title_EmptyValue_ThrowsArgumentException()
		{
			Assert.ThrowsAny<ArgumentException>(() => book.Title = string.Empty);
		}
	}
}
