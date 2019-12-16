using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.ViewModel
{
    class MyOrdersViewModel
    {
        public MyOrdersViewModel()
        {
            AddToOrderedItems();
        }

        public IReadOnlyList<ArticleViewModel> ProductList
        {
            private set;
            get;
        }

        public void AddToOrderedItems()
        {
            this.ProductList = OrderFoodViewModel.ArticleList.Select((product) => new ArticleViewModel(product)).ToList();
        }
    }
}
