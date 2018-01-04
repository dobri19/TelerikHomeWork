using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Bytes2you.Validation;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle, ICommentable, IPriceable
    {
        private int wheels;
        private VehicleType type;
        private string make;
        private string model;
        private IList<IComment> comments;
        private decimal price;

        public Vehicle(string make, string model, decimal price)
        {
            //this.Wheels = wheels;
            //this.Type = type;
            this.Make = make;
            this.Model = model;
            //this.comments = comments;
            this.Comments = new List<IComment>();
            this.Price = price;
        }

        public int Wheels
        {
            get { return this.wheels; }
            protected set { this.wheels = value; }
        }
        public VehicleType Type
        {
            get { return this.type; }
            set
            {
                if (!Enum.IsDefined(typeof(VehicleType), value)) throw new ArgumentException("Invalid vehicle type!");
                this.type = value;
            }
        }
        public string Make
        {
            get { return this.make; }
            set
            {
                if (value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentException("Make must be between 2 and 15 characters long!");
                }
                Guard.WhenArgument(value, "Make cannot be null!").IsNull().Throw();
                //Guard.WhenArgument(value.Length, "Not correct lenght!").IsGreaterThan(15).IsLessThan(2).Throw();
                this.make = value;
            }
        }
        public string Model
        {
            get { return this.model; }
            set
            {
                if (value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentException("Model must be between 1 and 15 characters long!");
                }
                Guard.WhenArgument(value, "Model cannot bee null!").IsNull().Throw();
                //Guard.WhenArgument(value.Length, "Not correct lenght!").IsGreaterThan(15).IsLessThan(1).Throw();
                this.model = value;
            }
        }
        public IList<IComment> Comments
        {
            get { return this.comments; }
            set
            {
                Guard.WhenArgument(value, "Enter a comment").IsNull().Throw();
                this.comments = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0 || value > 100000)
                {
                    throw new ArgumentException("Price must be between 0 and 1000000!");
                }
                //Guard.WhenArgument(value, "Not correct lenght!").IsGreaterThan(100000).IsLessThan(0).Throw();
                this.price = value;
            }
        }
    }
}
