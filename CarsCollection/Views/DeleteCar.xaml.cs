using System;
using System.Collections.Generic;
using CarsCollection.ViewModels;
using Xamarin.Forms;

namespace CarsCollection.Views
{
    public partial class DeleteCar : ContentPage
    {
        CarViewModel vm = new CarViewModel();

        public DeleteCar()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        async void OnAlertSimpleClicked(object sender, EventArgs e)
        {
            if(vm.errorMessage == false){
                await DisplayAlert("Error", "This car doesn't exist", "Retry");
                vm.errorMessage = true;
            }else{
                await DisplayAlert("Success", "This car was deleted", "OK");
            }
        }
    }
}
