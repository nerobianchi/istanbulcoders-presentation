using System.Collections.Generic;

namespace IstanbulCoders
{
	public class BookService
	{
		private readonly IBookRepository bookRepository;

		public BookService(IBookRepository bookRepository)
		{
			this.bookRepository = bookRepository;
		}

		public List<Book> List()
		{
			List<Book> books = this.bookRepository.List();

			if (books == null || books.Count == 0)
			{
				throw new ThereIsNoBook();
			}

			return books;
		}
	}
}