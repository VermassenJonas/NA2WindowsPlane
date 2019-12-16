using ProjectWindowsVliegtuig.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ProjectWindowsVliegtuig.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderFood : Page, INotifyPropertyChanged
    {
        internal OrderFoodViewModel ViewModel { private set; get; }

        public OrderFood()
        {
            this.ViewModel = new OrderFoodViewModel();

            this.InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Add_Product(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var articleViewModel = (ArticleViewModel)button.Tag;
            this.ViewModel.OnBuyClick(articleViewModel);
        }

        public void RaisePropertyChangeEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
