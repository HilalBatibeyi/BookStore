using AutoMapper;
using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(b => b.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadı");

            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            return vm;
        }

        public class BookDetailViewModel
        {
            public string Title { get; set; }

            public string Genre { get; set; }

            public int PageCount { get; set; }

            public string PulishDate { get; set; }
        }
    }
}
