using System;
using System.Collections.Generic;
using CarsCollection.ViewModels;
using Xamarin.Forms;

namespace CarsCollection.Views
{
    public partial class ListOfCarsDetails : ContentPage
    {
        public ListOfCarsDetails()
        {
            InitializeComponent();
            CarViewModel vm = new CarViewModel();
            BindingContext = vm;
        }
    }
}
