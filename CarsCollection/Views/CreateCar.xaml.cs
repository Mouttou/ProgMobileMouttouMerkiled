using System;
using System.Collections.Generic;
using CarsCollection.ViewModels;
using Xamarin.Forms;

namespace CarsCollection.Views
{
    public partial class CreateCar : ContentPage
    {
        CarViewModel vm = new CarViewModel();
        public CreateCar()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        async void OnAlertSimpleClicked(object sender, EventArgs e)
        {
            
           await DisplayAlert("Success", "This car was created", "OK");

        }
    }
}
