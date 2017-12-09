using Bytes2you.Validation;
using Cosmetics.Common;
using System;

namespace Cosmetics.Products
{
    public class Product
    {
        private readonly decimal price;
        private readonly string name;
        private readonly string brand;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            Guard.WhenArgument((name), "The brand is empty!").IsNullOrEmpty().Throw();
            //Guard.WhenArgument((name.Length), "The brand is too short!").IsLessThan(2).Throw();
            //Guard.WhenArgument((name.Length), "The brand is too long!").IsGreaterThan(10).Throw();
            if (name.Length < 2 || name.Length > 10)
            {
                throw new ArgumentOutOfRangeException("The name is not correct!");
            }
            else
            {
                this.name = name;
            }
            //this.name = name;

            Guard.WhenArgument((brand), "The brand is empty!").IsNullOrEmpty().Throw();
            Guard.WhenArgument((brand.Length), "The brand is too short!").IsLessThan(2).Throw();
            Guard.WhenArgument((brand.Length), "The brand is too long!").IsGreaterThan(10).Throw();
            this.brand = brand;

            Guard.WhenArgument(price, "The price is negative!").IsLessThan(0).Throw();
            this.price = price;

            if (!Enum.IsDefined(typeof(GenderType), gender))
            {
                throw new Exception("Gender not valid");
            }

            this.gender = gender;
        }

        public decimal Price
        {
            get { return this.price; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Brand
        {
            get { return this.brand; }
        }

        public GenderType Gender
        {
            get { return this.gender; }
        }

        public string Print()
        {
            return $" #{this.Name} {this.Brand}\r\n #Price: ${this.Price}\r\n #Gender: {this.Gender}\r\n ===";
        }
    }
}
