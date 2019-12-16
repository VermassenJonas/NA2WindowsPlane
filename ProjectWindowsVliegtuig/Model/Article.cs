using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.Model
{
    class Article
    {
        public Article(string title, decimal price)
        {
            this.Title = title;
            this.Price = price;
        }

        public string Title { get; private set; }

        public decimal Price { get; private set; }
    }
}
