using System.Collections.Generic;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Bytes2you.Validation;
using System;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        private int seats;

        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price)
        {
            this.Seats = seats;
            this.Type = VehicleType.Car;
            this.Wheels = (int)VehicleType.Car;
        }

        public int Seats
        {
            get { return this.seats; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Seats must be between 1 and 10!");
                }
                //Guard.WhenArgument(value, "Not correct lenght!").IsGreaterThan(10).IsLessThan(0).Throw();
                this.seats = value;
            }
        }

        public override string ToString()
        {
            return $"Seats: {this.Seats}";
        }
    }
}
