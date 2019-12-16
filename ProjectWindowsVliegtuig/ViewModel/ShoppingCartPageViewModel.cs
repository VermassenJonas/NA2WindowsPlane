using ProjectWindowsVliegtuig.Model;
using ProjectWindowsVliegtuig.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace ProjectWindowsVliegtuig.ViewModel
{
    class ShoppingCartPageViewModel : NotificationBase
    {
        private ObservableCollection<ShoppingCartEntryViewModel> _entries = null;
        private CoreDispatcher _uiDispatcher = null;
        private bool _isLoaded = false;

        public ShoppingCartPageViewModel()
        {
            this.ShoppingCart = AppState.ShoppingCart;

            _uiDispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        }

        /// <summary>
        /// The shopping cart we are using.
        /// </summary>
        public ShoppingCart ShoppingCart
        {
            private set;
            get;
        }

        /// <summary>
        /// The list of view models for the shopping cart entries.
        /// </summary>
        public ReadOnlyObservableCollection<ShoppingCartEntryViewModel> Entries
        {
            private set;
            get;
        }

        /// <summary>
        /// The cost of all the items combined, as a properly formatted string.
        /// </summary>
        public string SubtotalString
        {
            private set;
            get;
        }

        /// <summary>
        /// The total cost of the order, as a properly formatted string.
        /// </summary>
        public string TotalCostString
        {
            private set;
            get;
        }

        /// <summary>
        /// Whether or not the 'Checkout' button is enabled.
        /// </summary>
        public bool CheckoutButtonEnabled
        {
            private set;
            get;
        }

        /// <summary>
        /// Called when the page is loaded in XAML.
        /// </summary>
        public void OnLoaded()
        {
            CheckForSupportedPaymentMethods();

            // Register the shopping cart change notifications.
            this.ShoppingCart.EntriesChanged += OnShoppingCartEntriesChangedCallback;
            
            // Ensure our generated values are up to date.
            ResetEntries();
            UpdateCostsSummaryStrings();

            _isLoaded = true;
        }

        /// <summary>
        /// Called when the page is unloaded in XAML.
        /// </summary>
        public void OnUnloaded()
        {
            _isLoaded = false;

            // Unregister the shopping cart change notifications.
            // Since the shopping cart's lifetime will outlive this page, we don't want the shopping cart
            // holding a reference to this class as this will prevent the memory from being freed.
            this.ShoppingCart.EntriesChanged -= OnShoppingCartEntriesChangedCallback;

            _entries.Clear();
        }

        /// <summary>
        /// Called when one of the entry's 'remove' button is clicked.
        /// </summary>
        public void OnEntryRemoveClick(ShoppingCartEntryViewModel entryViewModel)
        {
            this.ShoppingCart.Remove(entryViewModel.ArticleViewModel.Article);
        }

        /// <summary>
        /// Called when the 'Windows Checkout' button is clicked.
        /// </summary>
        public async void OnWindowsCheckoutClicked()
        {
            // await WindowsPaymentOperation.CheckoutAsync(this.ShoppingCart);
            //TODO : Wat moet er gebeuren als er op de checkout knop gedrukt wordt.
            
        }

        /// <summary>
        /// Called when the 'Entries' list in the shopping cart changes.
        /// </summary>
        private void OnShoppingCartEntriesChangedCallback(ShoppingCart sender, ShoppingCartEntriesChangedEventArgs args)
        {
            _uiDispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {
                    OnShoppingCartEntriesChanged(sender, args);
                });
        }

        /// <summary>
        /// Called when the 'Entries' list in the shopping cart changes.
        /// </summary>
        private void OnShoppingCartEntriesChanged(ShoppingCart sender, ShoppingCartEntriesChangedEventArgs args)
        {
            if (!_isLoaded)
            {
                return;
            }

            switch (args.Type)
            {
                case ShoppingCartEntriesChangedType.EntryAdded:
                    var entryViewModel = new ShoppingCartEntryViewModel(this.ShoppingCart, this.ShoppingCart.Entries[args.Index]);
                    _entries.Insert(args.Index, entryViewModel);
                    break;

                case ShoppingCartEntriesChangedType.EntryRemoved:
                    _entries.RemoveAt(args.Index);
                    break;

                case ShoppingCartEntriesChangedType.EntryUpdated:
                    _entries[args.Index].Update(this.ShoppingCart.Entries[args.Index]);
                    break;

                case ShoppingCartEntriesChangedType.EntriesReset:
                default:
                    ResetEntries();
                    break;
            }
        }

        /// <summary>
        /// Completely re-creates the list of shopping cart entry view models.
        /// </summary>
        private void ResetEntries()
        {
            var newEntryViewModels =
                from entry in this.ShoppingCart.Entries
                select new ShoppingCartEntryViewModel(this.ShoppingCart, entry);

            _entries = new ObservableCollection<ShoppingCartEntryViewModel>(newEntryViewModels);
            this.Entries = new ReadOnlyObservableCollection<ShoppingCartEntryViewModel>(_entries);

            this.RaisePropertyChanged(nameof(this.Entries));
        }
        

        /// <summary>
        /// Updates the strings that display the cost summary (e.g. sub-total, tax, etc.) of the shopping cart.
        /// </summary>
        private void UpdateCostsSummaryStrings()
        {
            ShoppingCartCostsSummary costsSummary = this.ShoppingCart.CostsSummary;

            // Update values.
            this.SubtotalString = PriceStringUtilities.CreatePriceString(costsSummary.ItemsSubtotal);
            this.TotalCostString = PriceStringUtilities.CreatePriceString(costsSummary.Total);

            // Raise all the 'PropertyChanged' events.
            this.RaisePropertyChanged(nameof(this.SubtotalString));
            this.RaisePropertyChanged(nameof(this.TotalCostString));
        }

        /// <summary>
        /// Checks to see if the OS supports one of our supported payment methods and enables/disables the 'Checkout'
        /// button based on the result.
        /// </summary>
        private async void CheckForSupportedPaymentMethods()
        {
            bool hasSupportedPaymentMethod = true;

            // Update values.
            this.CheckoutButtonEnabled = hasSupportedPaymentMethod;

            // Raise all the 'PropertyChanged' events.
            this.RaisePropertyChanged(nameof(this.CheckoutButtonEnabled));
        }
    }
}
