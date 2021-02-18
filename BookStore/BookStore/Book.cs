using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Library
{
    public class Book
    {
        public Book(string title)
        {
            Title = title;
        }


        // fields
        private string _title;
        private string _author;
        private double _price;

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("invalid name");
                }
                _title = value;
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("invalid name");
                }
                _author = value;
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("invalid price");
                }
                _price = value;
            }
        }

    }
}



