using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWindowsVliegtuig.Pages;
using ProjectWindowsVliegtuig.View;

namespace ProjectWindowsVliegtuig.ViewModel
{
    class ProductsBannerViewModel
    {
        public ProductsBannerViewModel()
        {
        }

        /// <summary>
        /// Invoked when the user taps the app logo.
        /// </summary>
        public void ProductsLogoTapped()
        {
            // Navigate to the 'FrontPage' page (if we aren't already on it).
            if (App.AppFrame.CurrentSourcePageType == typeof(OrderFood))
            {
                return;
            }

            App.AppFrame.Navigate(typeof(OrderFood));
        }
    }
}
