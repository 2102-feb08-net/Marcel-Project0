using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
