using ProjectWindowsVliegtuig.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.ViewModel
{
    class OrderFoodViewModel
    {
        public OrderFoodViewModel()
        {
            this.ShoppingCart = AppState.ShoppingCart;
            // this.ProductList = ArticleDatabase.ArticleList.Select((product) => new ArticleViewModel(product)).ToList();
            this.ProductList = ArticleList.Select((product) => new ArticleViewModel(product)).ToList();
        }

        public static readonly Article[] ArticleList = new Article[]
        {
            new Article("Cola", 2.00m),
            new Article("Fanta", 2.00m),
            new Article("Bier", 4.50m),
            new Article("Pinda's", 1.50m)
        };

        /// <summary>
        /// The list of products (as view models) to display
        /// </summary>
        public IReadOnlyList<ArticleViewModel> ProductList
        {
            private set;
            get;
        }

        /// <summary>
        /// The shopping cart currently in use.
        /// </summary>
        public ShoppingCart ShoppingCart
        {
            private set;
            get;
        }

        //public void OnProductListItemClicked(ArticleViewModel articleViewModel)
        //{
        //    App.AppFrame.Navigate(typeof(ProductDetailsPage), articleViewModel);
        //}

        public void OnBuyClick(ArticleViewModel articleViewModel)
        {
            this.ShoppingCart.Add(articleViewModel.Article, quantity: 1);
        }
    }
}
