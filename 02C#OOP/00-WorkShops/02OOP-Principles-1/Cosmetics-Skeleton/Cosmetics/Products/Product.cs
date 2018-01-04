using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Bytes2you.Validation;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public virtual string Name
        {
            get { return this.name; }
            set
            {
                Guard.WhenArgument(value, "Name cannot be null").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Name length is not correct!").IsLessThan(3).IsGreaterThan(10).Throw();
                this.name = value;
            }
        }

        public virtual string Brand
        {
            get { return this.brand; }
            set
            {
                Guard.WhenArgument(value, "Brand cannot be null").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Brand length is not correct!").IsLessThan(2).IsGreaterThan(10).Throw();
                this.brand = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }
            set
            {
                Guard.WhenArgument(value, "Price cannot be nagetive").IsLessThan(0).Throw();
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get { return this.gender; }
            set
            {
                if (!Enum.IsDefined(typeof(GenderType), value))
                {
                    throw new ArgumentException("Invalid gender");
                }
                this.gender = value; }
        }

        public abstract string Print();
    }
}
