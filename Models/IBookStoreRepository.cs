using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface IBookStoreRepository
    {
        //makes "Books" a queryable instance from the Book class
        IQueryable<Book> Books { get; }
    }
}
