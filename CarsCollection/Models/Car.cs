using System;

using Realms;

namespace CarsCollection.Models
{
    public class Car: RealmObject 
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Seat { get; set; }
    }
}
