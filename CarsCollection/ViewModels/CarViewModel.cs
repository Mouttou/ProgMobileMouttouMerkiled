using CarsCollection.Models;
using CarsCollection.Views;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace CarsCollection.ViewModels
{
public class CarViewModel : INotifyPropertyChanged
{
    Realm _getRealmInstance = Realm.GetInstance();
    private List<Car> _listOfCar = null;
    private Car _car = new Car();
    public bool errorMessage = true;

    public List<Car> ListOfCars
    {
        get { return _listOfCar; }
        set
        {
            _listOfCar = value;
            OnPropertyChanged();
        }
    }

    public CarViewModel()
    {

        ListOfCars = _getRealmInstance.All<Car>().ToList();
    }

    public Car CarDetails
    {
        get { return _car; }
        set
        {
            _car = value;
            OnPropertyChanged();
        }
    }

    public Command CreateCommand 
    {
        get
        {
            return new Command(() => {
                if (_car.Name is null)
                    _car.Name = "NULL";
                if(_getRealmInstance.All<Car>().Count()==0)
                _car.Id = _getRealmInstance.All<Car>().Count() + 1;
                else
                {
                    var lastKey = _getRealmInstance.All<Car>().OrderBy(x => x.Id).Last();
                    _car.Id = lastKey.Id + 1;

                }                      
                _getRealmInstance.Write(() =>
                {
                    _getRealmInstance.Add(_car); 
                });
            });
        }
    }

    public Command UpdateCommand 
    {
        get
        {
            return new Command(() =>
            {
                if (_car.Name is null)
                    _car.Name = "NULL";
                var carUpdate = new Car
                {
                    Id = _car.Id,
                    Name = _car.Name,
                    Year = _car.Year,
                    Seat = _car.Seat
                    };

                _getRealmInstance.Write(() =>
                {

                    _getRealmInstance.Add(carUpdate, update: true);
                    });
            });
        }
    }

    public Command RemoveCommand
    {
        get
        {
            return new Command(() =>
            {
                    try{
                        var getAllCarById = _getRealmInstance.All<Car>().First(x => x.Id == _car.Id);
                        using (var transaction = _getRealmInstance.BeginWrite())
                        {
                            _getRealmInstance.Remove(getAllCarById);
                            transaction.Commit();
                        };
                        }
                    catch(System.InvalidOperationException e){
                    errorMessage = false;
                    }
            });
        }
    }


        public Command NavToListCommand
    {
        get
        {
            return new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ListOfCarsDetails());
            });
        }
    }

    public Command NavToCreateCommand
    {
        get
        {
            Debug.WriteLine("OK");

            return new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CreateCar());
            });
        }
    }

    public Command NavToUpdateCommand
    {
        get
        {
            return new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new UpdateCar());
            });
        }
    }

    public Command NavToDeleteCommand
    {
        get
        {
            return new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new DeleteCar());
            });
        }
    }
  
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}
}
