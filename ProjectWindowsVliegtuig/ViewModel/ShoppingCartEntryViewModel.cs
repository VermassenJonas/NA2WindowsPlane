using ProjectWindowsVliegtuig.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.ViewModel
{
    class ShoppingCartEntryViewModel : NotificationBase
    {
        ShoppingCart _shoppingCart;

        public ShoppingCartEntryViewModel(ShoppingCart shoppingCart, ShoppingCartEntry entry)
        {
            _shoppingCart = shoppingCart;
            this.ArticleViewModel = new ArticleViewModel(entry.Article);

            Update(entry);
        }

        public ArticleViewModel ArticleViewModel
        {
            private set;
            get;
        }

        public Article Article
        {
            get
            {
                return this.ArticleViewModel.Article;
            }
        }

        /// <summary>
        /// The quantity of the product to be bought, as a string.
        /// </summary>
        private string _quantityString = string.Empty;
        public string QuantityString
        {
            get
            {
                return _quantityString;
            }

            set
            {
                // Try to parse the string.
                int newQuantitiy = 0;
                bool parseSucceeded = int.TryParse(value, out newQuantitiy);

                // Check if the parse succeeded.
                if (parseSucceeded && newQuantitiy >= 0)
                {
                    // Update the quantity of the product in the shopping cart.
                    // This should result in our 'Update' function getting called.
                    _shoppingCart.SetArticleQuantity(this.Article, newQuantitiy);
                }
                else
                {
                    // Parse failed.
                    // Inform XAML that we have refused their change.
                    RaisePropertyChanged(nameof(this.QuantityString));
                }
            }
        }

        /// <summary>
        /// Updates this view model with the latest information from the shopping cart entry.
        /// </summary>
        /// <param name="entry"></param>
        public void Update(ShoppingCartEntry entry)
        {
            if (this.Article != entry.Article)
            {
                throw new Exception("Updating with wrong 'Product' entry.");
            }

            _quantityString = entry.Quantity.ToString();
            RaisePropertyChanged(nameof(QuantityString));
        }
    }
}
