using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        //primary key, asp will auto-increment this value and assign it
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        //regex verifies a 10 or 13 character ISBN
        [Required]
        [RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$", ErrorMessage = "Please enter a valid ISBN.")]
        public string ISBN { get; set; }

        [Required]
        public string Category { get; set; }

        //regex verifies if the input is a valid form of currency input
        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Please enter a valid currency.")]
        public decimal Price { get; set; }
    }
}
