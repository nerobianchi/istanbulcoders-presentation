#region licence

// <copyright file="BookRepositoryTests.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	IstanbulCoders.IntegrationTests
// 	Created By: 	erdem
// 	Create Date:	04.08.2016 20:40
// 	Last Changed By:	erdem
// 	Last Change Date:	04.08.2016 20:40
// </summary>

#endregion licence

using FluentAssertions;
using IstanbulCoders.Tests;
using System.Collections.Generic;

using Xunit;

namespace IstanbulCoders.IntegrationTests
{
	public class BookRepositoryTests
	{
		public BookRepositoryTests()
		{
			BookRepositoryHelper.InitializeBookTable();
		}

		[Fact]
		public void given_one_book_when_listing_then_the_count_of_list_should_be_one()
		{
			BookRepositoryHelper.InsertOneBook();

			BookRepository sut = new BookRepository();
			List<Book> list = sut.List();

			list.Count.Should().Be(1);

			list[0].Id.Should().Be("1");
		}

		[Fact]
		public void given_two_books_when_listing_then_the_count_of_list_should_be_two()
		{
			BookRepositoryHelper.InsertTwoBooks();

			BookRepository sut = new BookRepository();
			List<Book> list = sut.List();

			list.Count.Should().Be(2);

			list[0].Id.Should().Be("1");
			list[1].Id.Should().Be("2");
		}
	}
}