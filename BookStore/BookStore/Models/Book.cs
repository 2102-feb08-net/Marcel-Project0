using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Library.Models
{
    public class Book
    {
        // backing fields for title
        private string _title;

        // The book's ID
        public int Id { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("invalid title", nameof(value));
                }
                _title = value;
            }
        }


	}
}



