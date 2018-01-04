using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Text;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo, IProduct
    {
        //private string name;
        //private string brand;
        //private decimal price;
        //private GenderType gender;
        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            //this.Name = name;
            //this.Brand = brand;
            //this.Price = price;
            //this.Gender = gender;
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        //public string Name
        //{
        //    get { return this.name; }
        //    private set
        //    {
        //        Guard.WhenArgument(value, "Name cannot be null").IsNull().Throw();
        //        Guard.WhenArgument(name.Length, "Name length is not correct!").IsLessThan(3).IsGreaterThan(10).Throw();
        //        this.name = value;
        //    }
        //}

        //public string Brand
        //{
        //    get { return this.brand; }
        //    private set
        //    {
        //        Guard.WhenArgument(value, "Brand cannot be null").IsNull().Throw();
        //        Guard.WhenArgument(value.Length, "Brand length is not correct!").IsLessThan(2).IsGreaterThan(10).Throw();
        //        this.brand = value;
        //    }
        //}

        //public decimal Price
        //{
        //    get { return this.price; }
        //    private set
        //    {
        //        Guard.WhenArgument(value, "Price cannot be nagetive").IsLessThan(0).Throw();
        //        this.price = value;
        //    }
        //}

        //public GenderType Gender
        //{
        //    get { return this.gender; }
        //    set { this.gender = value; }
        //}

        public uint Milliliters
        {
            get { return this.milliliters; }
            set { this.milliliters = value; }
        }

        public UsageType Usage
        {
            get { return this.usage; }
            set
            {
                if (!Enum.IsDefined(typeof(UsageType), value))
                {
                    throw new ArgumentException("Invalid usage");
                }
                this.usage = value;
            }
        }

        //new Shampoo(null, "brand", 10m, GenderType.Men, 10, UsageType.EveryDay));

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("#" + this.Name + " " + this.Brand);
            sb.AppendLine(" #Price: $" + this.Price);
            sb.AppendLine(" #Gender: " + this.Gender);
            sb.AppendLine(" #Milliliters: " + this.Milliliters);
            sb.Append(" #Usage: " + this.Usage);

            return sb.ToString();
        }
    }
}
