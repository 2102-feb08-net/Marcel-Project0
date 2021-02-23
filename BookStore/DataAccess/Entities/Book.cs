using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
            Orders = new HashSet<Order>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
