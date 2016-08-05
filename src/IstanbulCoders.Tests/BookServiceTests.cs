#region licence

// <copyright file="BookServiceTests.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	IstanbulCoders.Tests
// 	Created By: 	erdem
// 	Create Date:	04.08.2016 20:14
// 	Last Changed By:	erdem
// 	Last Change Date:	04.08.2016 20:14
// </summary>

#endregion licence

using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IstanbulCoders.Tests
{
	public class BookServiceTests
	{
		[Theory]
		[MemberData("GetList")]
		public void given_any_books_when_listing_then_return_the_count(List<Book> books, int expectedCount)
		{
			Mock<IBookRepository> mockBookRepository = new Mock<IBookRepository>();

			mockBookRepository.Setup(m => m.List()).Returns(books);

			IBookRepository bookRepository = mockBookRepository.Object;
			BookService sut = new BookService(bookRepository);
			List<Book> list = sut.List();

			Assert.Equal(expectedCount, list.Count);
		}

		public static object[] GetList()
		{
			return new object[]
			       {
				       new object[]{new List<Book>(){new Book()},1 },
				       new object[]{new List<Book>(){new Book(),new Book()},2 }
			       };
		}

		[Fact]
		public void given_no_book_when_listing_then_there_is_no_book_message_should_be_thrown()
		{
			Mock<IBookRepository> mockBookRepository = new Mock<IBookRepository>();

			mockBookRepository.Setup(m => m.List()).Returns((List<Book>)null);

			IBookRepository bookRepository = mockBookRepository.Object;
			BookService sut = new BookService(bookRepository);

			Action action = () => sut.List();

			string message = "There is no book !";

			//Assert.Throws<ThereIsNoBook>(action);
			action.ShouldThrow<ThereIsNoBook>().And.Message.Should().Be(message);
		}
	}
}