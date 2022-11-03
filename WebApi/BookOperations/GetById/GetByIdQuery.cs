using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetById
{
    public class GetByIdQuery
    {
        public int BookId {get; set;}
        private readonly BookStoreDbContext _dbContext;
         public GetByIdQuery(BookStoreDbContext dbContext,int id)
        {
            BookId=id;
            _dbContext=dbContext;
        }

        public BooksViewModel Handle()
        {
             var book = _dbContext.Books.Where(x=> x.Id == BookId).SingleOrDefault(); 

            BooksViewModel Model = new BooksViewModel();
            Model.Title = book.Title;
            Model.PageCount=book.PageCount;
            Model.PublishDate=book.PublishDate;
            Model.Genre=((GenreEnum)book.GenreId).ToString();

            return Model;
            
        }

         public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
