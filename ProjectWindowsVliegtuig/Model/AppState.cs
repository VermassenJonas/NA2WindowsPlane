using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.Model
{
    static class AppState
    {
        /// <summary>
        /// The 'ShoppingCart' instance that is shared between pages.
        /// </summary>
        public static ShoppingCart ShoppingCart { get; } = new ShoppingCart();
    }
}
