using ProjectWindowsVliegtuig.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectWindowsVliegtuig.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShoppingCartPage : Page
    {
        internal ShoppingCartPageViewModel ViewModel { private set; get; }

        public ShoppingCartPage()
        {
            this.InitializeComponent();
            this.ViewModel = new ShoppingCartPageViewModel();

            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.ViewModel.OnLoaded();
        }

        private void OnUnloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.ViewModel.OnUnloaded();
        }

        private void OnRemoveClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var button = (HyperlinkButton)sender;
            var entryViewModel = (ShoppingCartEntryViewModel)button.Tag;

            this.ViewModel.OnEntryRemoveClick(entryViewModel);
        }

        private void OnWindowsCheckoutClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.ViewModel.OnWindowsCheckoutClicked();
        }
    }
}
