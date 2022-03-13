using System;
using System.Collections.Generic;
using System.Text;

namespace Kitabxana
{
    internal class Book:Product
    {
        public Book (int no , string name , double price, string genre) :base (no,name,price)
        {
            this.Genre = genre;
        }
        public string Genre;

        public string GetInfo()
        {
            return $"No: {this.No} - Name: {this.Name} - Price: {this.Price} \n Count: {this.Count} - Genre: {this.Genre}";
        }
    }
}
