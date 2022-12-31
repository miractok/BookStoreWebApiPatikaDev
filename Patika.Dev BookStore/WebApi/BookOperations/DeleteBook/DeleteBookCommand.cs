using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookID { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=> x.Id == BookID);
            if(book == null)
                throw new InvalidOperationException("Girdiğiniz Id hiçbir kitapla eşleşmemektedir.");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}