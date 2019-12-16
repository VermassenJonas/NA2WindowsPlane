using ProjectWindowsVliegtuig.Model;
using ProjectWindowsVliegtuig.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.ViewModel
{
    class ArticleViewModel
    {
        public ArticleViewModel(Article article)
        {
            this.Article = article;
            this.PriceString = PriceStringUtilities.CreatePriceString(this.Article.Price);
        }

        /// <summary>
        /// The product details.
        /// </summary>
        public Article Article
        {
            private set;
            get;
        }

        /// <summary>
        /// The cost of the product, in a properly formatted string.
        /// </summary>
        public string PriceString
        {
            private set;
            get;
        }
    }
}
