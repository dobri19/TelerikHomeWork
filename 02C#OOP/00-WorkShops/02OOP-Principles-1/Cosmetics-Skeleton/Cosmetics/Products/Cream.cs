using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Cream : Product, IProduct
    {
        private ScentType scent;
        //private decimal price;
        private string name;
        private string brand;

        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent)
            : base(name, brand, price, gender)
        {
            this.Scent = scent;
        }

        //public override decimal Price
        //{
        //    get
        //    {
        //        return this.price;
        //    }
        //    set
        //    {
        //        Guard.WhenArgument(value, "Price cannot be nagetive").IsLessThan(0).Throw();
        //        this.price = value;
        //    }
        //}

        public override string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Guard.WhenArgument(value, "You need to enter a cream name!").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Price cannot be nagetive").IsLessThan(3).IsGreaterThan(15).Throw();
                this.name = value;
            }
        }

        public override string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                Guard.WhenArgument(value, "You need to enter a product brand!").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Price cannot be nagetive").IsLessThan(3).IsGreaterThan(15).Throw();
                this.brand = value;
            }
        }

        public ScentType Scent
        {
            get { return this.scent; }
            private set
            {
                if (!Enum.IsDefined(typeof(ScentType), value))
                {
                    throw new ArgumentException("Invalid scent");
                }
                this.scent = value;
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("#" + this.Name + " " + this.Brand);
            sb.AppendLine(" #Price: $" + this.Price);
            sb.AppendLine(" #Gender: " + this.Gender);
            sb.Append(" #ScentType: " + this.Scent);

            return sb.ToString();
        }
    }
}
