using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetById
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookID { get; set; }
        public GetByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BooksViewIdModel Handle()
        {
            var book = _dbContext.Books.Where(book=> book.Id == BookID).SingleOrDefault();
            if(book == null)
                throw new InvalidOperationException("Girdiğiniz Id hiçbir kitapla eşleşmemektedir.");
            BooksViewIdModel vm = new BooksViewIdModel();

            vm.Title = book.Title;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            vm.PageCount = book.PageCount;


            return vm;
        }
    }

    public class BooksViewIdModel
    {
        public string? Title { get; set; }

        public string? Genre { get; set; }

        public int PageCount { get; set; }

        public string? PublishDate { get; set; }
    }
}