using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.Model
{
    /// <summary>
    /// The type of change made to the shopping cart entries list.
    /// </summary>
    enum ShoppingCartEntriesChangedType
    {
        /// <summary>
        /// The entries list has had significant modification made to it.
        /// </summary>
        EntriesReset,

        /// <summary>
        /// An entry has been added.
        /// </summary>
        EntryAdded,

        /// <summary>
        /// An entry has been removed.
        /// </summary>
        EntryRemoved,

        /// <summary>
        /// An entry has been modified.
        /// </summary>
        EntryUpdated,
    }

    /// <summary>
    /// The event arguments for the 'ShoppingCart.EntriesChanged' event.
    /// </summary>
    class ShoppingCartEntriesChangedEventArgs
    {
        public ShoppingCartEntriesChangedEventArgs(ShoppingCartEntriesChangedType type, int index)
        {
            this.Type = type;
            this.Index = index;
        }

        /// <summary>
        /// The type of change that was made.
        /// </summary>
        public ShoppingCartEntriesChangedType Type
        {
            private set;
            get;
        }

        /// <summary>
        /// The index of the changed entry (if applicable).
        /// </summary>
        public int Index
        {
            private set;
            get;
        }
    }
}
