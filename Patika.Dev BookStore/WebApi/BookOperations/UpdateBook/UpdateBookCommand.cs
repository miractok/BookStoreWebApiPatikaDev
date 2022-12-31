using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookID { get; set; }
        public UpdateViewIdModel Model { get; set; }
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=> x.Id == BookID);
            if(book == null)
                throw new InvalidOperationException("Girdiğiniz Id hiçbir kitapla eşleşmemektedir.");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateViewIdModel
    {
        public string? Title { get; set; }

        public int GenreId { get; set; }
    }
}