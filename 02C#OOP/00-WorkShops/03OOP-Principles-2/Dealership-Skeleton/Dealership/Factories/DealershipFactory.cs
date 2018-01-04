using Dealership.Contracts;
using System;
using Dealership.Models;
using Dealership.Common.Enums;

namespace Dealership.Factories
{
    public class DealershipFactory : IDealershipFactory
    {
        public Car CreateCar(string make, string model, decimal price, int seats)
        {
            Car car = new Car(make, model, price, seats);
            return car;
        }

        public Motorcycle CreateMotorcycle(string make, string model, decimal price, string category)
        {
            Motorcycle motorcycle = new Motorcycle(make, model, price, category);
            return motorcycle;
        }

        public Truck CreateTruck(string make, string model, decimal price, int weightCapacity)
        {
            Truck truck = new Truck(make, model, price, weightCapacity);
            return truck;
        }

        public IUser CreateUser(string username, string firstName, string lastName, string password, string role)
        {
            IUser user = new User(username, firstName, lastName, password, (Role)Enum.Parse(typeof(Role), role));
            return user;
        }

        public IComment CreateComment(string content)
        {
            IComment comment = new Comment(content);
            return comment;
        }
    }
}
