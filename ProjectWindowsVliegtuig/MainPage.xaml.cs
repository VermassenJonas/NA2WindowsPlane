﻿using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjectWindowsVliegtuig
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem x = (NavigationViewItem)args.SelectedItem;
            switch (x.Tag)
            {
                case "flightinfo":
                    mainFrame.Navigate(typeof(Pages.FlightInfo));
                    break;
                case "orderfood":
                    mainFrame.Navigate(typeof(Pages.OrderFood));
                    break;
                case "myorders":
                    mainFrame.Navigate(typeof(Pages.MyOrders));
                    break;
                case "chatroom":
                    mainFrame.Navigate(typeof(Pages.Chatroom));
                    break;
                case "movies":
                    mainFrame.Navigate(typeof(Pages.Movies));
                    break;
                case "shoppingcart":
                    mainFrame.Navigate(typeof(View.ShoppingCartPage));
                    break;
            }
        }
    }
}
