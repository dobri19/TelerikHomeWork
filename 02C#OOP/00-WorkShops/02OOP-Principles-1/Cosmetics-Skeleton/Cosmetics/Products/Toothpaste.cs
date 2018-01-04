using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste, IProduct
    {
        //private string name;
        //private string brand;
        //private decimal price;
        //private GenderType gender;
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender)
        {
            //this.Name = name;
            //this.Brand = brand;
            //this.Price = price;
            //this.Gender = gender;
            this.Ingredients = ingredients;
        }

        //public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> iLngredients)
        //{
        //    this.Name = name;
        //    this.Brand = brand;
        //    this.Price = price;
        //    this.Gender = gender;
        //    Lingredients = iLngredients;

        //    Guard.WhenArgument(ingredients, "Ingredients cannot be null").IsNull().Throw();
        //}

        //public List<string> Lingredients;

        //public string Name
        //{
        //    get { return this.name; }
        //    set { this.name = value; }
        //}

        //public string Brand
        //{
        //    get { return this.brand; }
        //    set { this.brand = value; }
        //}

        //public decimal Price
        //{
        //    get { return this.price; }
        //    set { this.price = value; }
        //}

        //public GenderType Gender
        //{
        //    get { return this.gender; }
        //    set { this.gender = value; }
        //}

        public string Ingredients
        {
            get { return this.ingredients; }
            set
            {
                Guard.WhenArgument(value, "Ingredients cannot be null").IsNull().Throw();
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("#" + this.Name + " " + this.Brand);
            sb.AppendLine(" #Price: $" + this.Price);
            sb.AppendLine(" #Gender: " + this.Gender);
            sb.Append(" #Ingredients: " + this.Ingredients);

            return sb.ToString();
        }
    }
}