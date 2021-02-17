using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    //inherits from IBookStoreRepository.cs, inherits its attributes and definitions (IQueryable)
    public class EFBookStoreRepository : IBookStoreRepository
    {
        private BookStoreDbContext _context;

        //constructor
        public EFBookStoreRepository (BookStoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
