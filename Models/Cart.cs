using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //adds a single book item to the cart list
        public virtual void AddItem (Book book, int quantity)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //removes single line
        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        //removes all contents of cart
        public virtual void Clear() => Lines.Clear();

        //this totals the price for all books in the list when called
        public decimal ComputeTotalSum()
        {
            return Lines.Sum(e => e.Book.Price * e.Quantity);
        }

        //CartLine class that stores the information to pass to the razor page
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
