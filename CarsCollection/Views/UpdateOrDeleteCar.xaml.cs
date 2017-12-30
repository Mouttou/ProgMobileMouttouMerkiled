using System;
using System.Collections.Generic;
using CarsCollection.ViewModels;
using Xamarin.Forms;

namespace CarsCollection.Views
{
    public partial class UpdateOrDeleteCar : ContentPage
    {
        public UpdateOrDeleteCar()
        {
            InitializeComponent();
            CarViewModel vm = new CarViewModel();
            BindingContext = vm;
        }
    }
}
