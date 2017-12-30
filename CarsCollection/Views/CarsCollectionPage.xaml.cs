using CarsCollection.ViewModels;
using Xamarin.Forms;

namespace CarsCollection
{
    public partial class CarsCollectionPage : ContentPage
    {
        public CarsCollectionPage()
        {
            InitializeComponent();
            CarViewModel vm = new CarViewModel();
            BindingContext = vm;
        }
    }
}
