using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            :base(make, model, price)
        {
            this.Type = VehicleType.Truck;
            this.Wheels = (int)VehicleType.Truck;
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get { return this.weightCapacity; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Weight capacity must be between 1 and 100!");
                }
                //Guard.WhenArgument(value, "Not correct lenght!").IsGreaterThan(100).IsLessThan(0).Throw();
                this.weightCapacity = value;
            }
        }

        public override string ToString()
        {
            return $"Weight capacity: {this.WeightCapacity}t";
        }
    }
}
