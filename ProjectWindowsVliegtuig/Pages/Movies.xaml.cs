using ProjectWindowsVliegtuig.Model;
using ProjectWindowsVliegtuig.ViewModel;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;


namespace ProjectWindowsVliegtuig.Pages
{
    public sealed partial class Movies : Page
    {
        public Movies()
        {
            this.DataContext = new MoviesVM();
            this.InitializeComponent();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(MovieDetail), e.ClickedItem);
        }
    }
}
