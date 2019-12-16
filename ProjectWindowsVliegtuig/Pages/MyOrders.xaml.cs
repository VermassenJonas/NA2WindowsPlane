using ProjectWindowsVliegtuig.ViewModel;
using System;

using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class MyOrders : Page, INotifyPropertyChanged
    {
        //public ObservableCollection<DummyData> DummyData { get; set; } // DummyData aanpassen aan onze Order 
        //private DummyData tempSelectedItem;                            // DummyData aanpassen aan onze Order 
        internal MyOrdersViewModel ViewModel { private set; get; }

        public MyOrders()
        {
            this.InitializeComponent();
            //MyOrdersList.ItemsSource = this.ViewModel.ProductList;
            //MyOrdersList.ItemsSource = DummyData // DummyData aanpassen aan onze Order 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void MyOrdersList_ItemClick(object sender, ItemClickEventArgs e)
        {/*
            DummyData selectedItem = e.ClickedItem as DummyData;

            selectedItem.ShowDetails = true;

            if (tempSelectedItem != null)
            {
                tempSelectedItem.ShowDetails = false;
                selectedItem.ShowDetails = true;
            }

            tempSelectedItem = selectedItem;*/
        }

        public void RaisePropertyChangeEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    /*
     * https://stackoverflow.com/questions/38162112/how-to-update-list-view-item-after-click
        public class DummyData : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }

        private bool showDetails;

        public bool ShowDetails
        {
            get
            {
                return showDetails;
            }
            set
            {
                showDetails = value;
                RaisePropertyChangeEvent(nameof(ShowDetails));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChangeEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
     */
}
