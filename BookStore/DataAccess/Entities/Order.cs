using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string Quantity { get; set; }
        public decimal? Price { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? BookId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
