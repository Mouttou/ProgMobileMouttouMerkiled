using System;
using System.Collections.Generic;
using CarsCollection.ViewModels;
using Xamarin.Forms;

namespace CarsCollection.Views
{
    public partial class UpdateCar : ContentPage
    {
        CarViewModel vm = new CarViewModel();

        public UpdateCar()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        async void OnAlertSimpleClicked(object sender, EventArgs e)
        {

            await DisplayAlert("Success", "This car was updated", "OK");

        }
    }
}
