using BookStore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;

        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public void Handle()
        {
            var Book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if (Book is null)
                throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı");

            Book.GenreId = Model.GenreId != default ? Model.GenreId : Book.GenreId;
            Book.Title = Model.Title != default ? Model.Title : Book.Title;

            _dbContext.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }

            public int GenreId { get; set; }
        }
    }
}
