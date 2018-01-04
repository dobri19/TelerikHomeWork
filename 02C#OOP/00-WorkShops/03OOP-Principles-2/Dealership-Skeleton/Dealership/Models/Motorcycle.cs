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
    public class Motorcycle : Vehicle, IVehicle, ICommentable, IPriceable, IMotorcycle
    {
        private string category;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price)
        {
            this.Type = VehicleType.Motorcycle;
            this.Wheels = (int)VehicleType.Motorcycle;
            this.Category = category;
        }

        public string Category
        {
            get { return this.category; }
            set
            {
                if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentException("Category must be between 1 and 10 characters long!");
                }
                Guard.WhenArgument(value, "Not correct lenght!").IsNull().Throw();
                //Guard.WhenArgument(value.Length, "Not correct lenght!").IsGreaterThan(10).IsLessThan(1).Throw();
                this.category = value;
            }
        }

        public override string ToString()
        {
            return $"Category: {this.Category}";
        }
    }
}
