using System;
using System.Collections.Generic;
using System.Linq;
using ProjectWindowsVliegtuig.Util;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.Model
{
    delegate void ShoppingCartEntriesChangedEventHandler(ShoppingCart sender, ShoppingCartEntriesChangedEventArgs args);
    delegate void ShoppingCartCostsSummaryChangedEventHandler(ShoppingCart sender);

    struct ShoppingCartEntry
    {
        public Article Article;
        public int Quantity;
    }

    /// <summary>
    /// The costs summary (e.g. sub-total, tax, etc.) of a shopping cart.
    /// </summary>
    struct ShoppingCartCostsSummary
    {
        public decimal ItemsSubtotal;
        public decimal Total;
    }

    class ShoppingCart
    {
        private List<ShoppingCartEntry> _shoppingCartEntries = null;
        
        public ShoppingCart()
        {
            _shoppingCartEntries = new List<ShoppingCartEntry>();
        }

        /// <summary>
        /// The list of entries in the shopping cart.
        /// </summary>
        public IReadOnlyList<ShoppingCartEntry> Entries
        {
            get
            {
                return _shoppingCartEntries;
            }
        }

        /// <summary>
        /// Raised when the 'Entries' list is changed or when one of its items is updated.
        /// </summary>
        public event ShoppingCartEntriesChangedEventHandler EntriesChanged;

        /// <summary>
        /// Raised when the 'CostsSummary' property is changed.
        /// </summary>
        public event ShoppingCartCostsSummaryChangedEventHandler CostsSummaryChanged;

        /// <summary>
        /// The costs summary (e.g. sub-total, tax, etc.) of the shopping cart
        /// </summary>
        public ShoppingCartCostsSummary CostsSummary
        {
            private set;
            get;
        }

        private void AddOrUpdateEntry(Article article, Func<ShoppingCartEntry, ShoppingCartEntry> updateFunc)
        {
            int productIndex = _shoppingCartEntries.IndexOf((entry) => (entry.Article == article));

            if (productIndex == -1)
            {
                // Create new entry.
                ShoppingCartEntry entry = new ShoppingCartEntry()
                {
                    Article = article,
                    Quantity = 0,
                };

                // Allow update.
                entry = updateFunc(entry);

                // Add to list.
                _shoppingCartEntries.Add(entry);

                // Raise changed event.
                RaiseEntriesChangedEvent(ShoppingCartEntriesChangedType.EntryAdded, _shoppingCartEntries.Count - 1);
            }
            else
            {
                ShoppingCartEntry entry = _shoppingCartEntries[productIndex];

                // Apply update
                entry = updateFunc(entry);
                _shoppingCartEntries[productIndex] = entry;

                // Raise changed event.
                RaiseEntriesChangedEvent(ShoppingCartEntriesChangedType.EntryUpdated, productIndex);
            }
        }

        /// <summary>
        /// Adds the specified quantity of the product in the cart. If the product doesn't currently exist
        /// it will be added.
        /// </summary>
        public void Add(Article article, int quantity)
        {
            AddOrUpdateEntry(
                article,
                (entry) =>
                {
                    int newQuantity = entry.Quantity + quantity;

                    if (newQuantity < 0)
                    {
                        throw new Exception("Quantity can't go below 0.");
                    }

                    entry.Quantity = newQuantity;
                    return entry;
                });
        }

        /// <summary>
        /// Sets the quantity of the specified product within the shopping cart. This will add
        /// the product to the cart if it doesn't already exist. Otherwise the existing quantity will
        /// be updated.
        /// </summary>
        public void SetArticleQuantity(Article article, int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("'quantity' can't be less than 0.");
            }

            AddOrUpdateEntry(
                article,
                (entry) =>
                {
                    entry.Quantity = quantity;
                    return entry;
                });
        }

        private void RemoveIf(Func<ShoppingCartEntry, bool> pred)
        {
            int lastRemovedIndex = -1;
            int removedCount = 0;

            for (int i = _shoppingCartEntries.Count - 1; i >= 0; --i)
            {
                if (pred(_shoppingCartEntries[i]))
                {
                    _shoppingCartEntries.RemoveAt(i);
                    lastRemovedIndex = i;
                    removedCount++;
                }
            }

            // Raise changed event
            if (removedCount == 1)
            {
                RaiseEntriesChangedEvent(ShoppingCartEntriesChangedType.EntryRemoved, lastRemovedIndex);
            }
            else if (removedCount > 1)
            {
                // Too many items were changed.
                // So just report a reset.
                RaiseEntriesChangedEvent(ShoppingCartEntriesChangedType.EntriesReset);
            }
        }

        /// <summary>
        /// Removes the specified product from the shopping cart.
        /// </summary>
        /// <param name="product">The product to be removed.</param>
        public void Remove(Article article)
        {
            RemoveIf((entry) => entry.Article == article);
        }

        /// <summary>
        /// Removes all the items from the Shopping Cart.
        /// </summary>
        public void Clear()
        {
            RemoveIf((entry) => true);
        }

        /// <summary>
        /// Goes through the items in the shopping cart and removes any items that have a 'Quantity' of 0.
        /// </summary>
        public void RemoveZeroQuantityItems()
        {
            RemoveIf((entry) => (entry.Quantity <= 0));
        }

        /// <summary>
        /// Checks whether or not the shopping cart contains the specified 'Product'.
        /// </summary>
        /// <param name="product">The product to check for.</param>
        /// <returns>Whether or not the product is in the shopping cart.</returns>
        public bool Contains(Article article)
        {
            return _shoppingCartEntries.Any((entry) => (entry.Article == article));
        }

        /// <summary>
        /// Called when the 'Entries' list has changed, so that listeners can be notified.
        /// </summary>
        private void RaiseEntriesChangedEvent(ShoppingCartEntriesChangedType type, int itemIndex = -1)
        {
            // Update 'CostsSummary' property.
            UpdateCostsSummary();

            // Invoke public event.
            var args = new ShoppingCartEntriesChangedEventArgs(type, itemIndex);
            this.EntriesChanged?.Invoke(this, args);
        }

        /// <summary>
        /// Updates the 'CostsSummary' property.
        /// </summary>
        private void UpdateCostsSummary()
        {
            this.CostsSummary = CalculateCostsSummary(this.Entries);
            this.CostsSummaryChanged?.Invoke(this);
        }

        /// <summary>
        /// Calculate the summary of costs (e.g. sub-total, tax, etc.) for the given list of shopping cart entries.
        /// </summary>
        private static ShoppingCartCostsSummary CalculateCostsSummary(IReadOnlyList<ShoppingCartEntry> entries)
        {
            ShoppingCartCostsSummary costsSummary = new ShoppingCartCostsSummary();

            foreach (ShoppingCartEntry entry in entries)
            {
                costsSummary.ItemsSubtotal += entry.Quantity * entry.Article.Price;
            }
            
            costsSummary.Total = costsSummary.ItemsSubtotal;

            return costsSummary;
        }
    }
}
