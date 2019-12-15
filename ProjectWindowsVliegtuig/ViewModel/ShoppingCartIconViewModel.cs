using ProjectWindowsVliegtuig.Model;
using ProjectWindowsVliegtuig.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ProjectWindowsVliegtuig.ViewModel
{
    class ShoppingCartIconViewModel : NotificationBase
    {
        public ShoppingCartIconViewModel()
        {
            this.ShoppingCart = AppState.ShoppingCart;
        }

        /// <summary>
        /// The shopping cart model.
        /// </summary>
        public ShoppingCart ShoppingCart
        {
            private set;
            get;
        }

        /// <summary>
        /// The number of items in the shopping cart.
        /// </summary>
        public int ItemCount
        {
            private set;
            get;
        }

        /// <summary>
        /// Whether or not to show the item count over the icon.
        /// </summary>
        public Visibility ItemCountVisibility
        {
            private set;
            get;
        }

        /// <summary>
        /// Called when the 'ShoppingCartIcon' control is loaded into the XAML tree.
        /// </summary>
        public void OnLoaded()
        {
            // Register the shopping cart change notifications.
            this.ShoppingCart.EntriesChanged += ShoppingCartEntriesChanged;

            // Ensure our generated values are up to date.
            UpdateGeneratedFields();
        }

        /// <summary>
        /// Called when the 'ShoppingCartIcon' control is unloaded from the XAML tree.
        /// </summary>
        public void OnUnloaded()
        {
            // Unregister the shopping cart change notifications.
            // Since the shopping cart's lifetime will outlive this page, we don't want the shopping cart
            // holding a reference to this class as this will prevent the memory from being freed.
            this.ShoppingCart.EntriesChanged -= ShoppingCartEntriesChanged;
        }

        /// <summary>
        /// Called when the user taps on the icon.
        /// </summary>
        public void IconTapped()
        {
            // Nagivate to the shopping cart page (if we aren't on it already).
            if (App.AppFrame.CurrentSourcePageType == typeof(ShoppingCartPage))
            {
                return;
            }

            App.AppFrame.Navigate(typeof(ShoppingCartPage));
        }

        /// <summary>
        /// Called when the entries list in the shopping cart has been changed.
        /// </summary>
        private void ShoppingCartEntriesChanged(ShoppingCart sender, ShoppingCartEntriesChangedEventArgs args)
        {
            UpdateGeneratedFields();
        }

        /// <summary>
        /// Updates the properties that are generated from data within the shopping cart.
        /// </summary>
        private void UpdateGeneratedFields()
        {
            this.ItemCount = ShoppingCart.Entries.Select(entry => entry.Quantity).Sum();
            this.ItemCountVisibility = this.ItemCount != 0 ? Visibility.Visible : Visibility.Collapsed;

            RaisePropertyChanged(nameof(this.ItemCount));
            RaisePropertyChanged(nameof(this.ItemCountVisibility));
        }
    }
}
