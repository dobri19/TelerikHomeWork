using Bytes2you.Validation;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics
{
    public class Category
    {
        private readonly string name;
        private readonly List<Product> products;

        public Category(string name)
        {
            Guard.WhenArgument((name), "The brand is empty!").IsNullOrEmpty().Throw();
            Guard.WhenArgument((name.Length), "The brand is too short!").IsLessThan(2).Throw();
            Guard.WhenArgument((name.Length), "The brand is too long!").IsGreaterThan(15).Throw();
            this.name = name;
            this.products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
        }

        public virtual void AddProduct(Product product)
        {
            Guard.WhenArgument(product, "The product is not set!").IsNull().Throw();
            this.Products.Add(product);
        }

        public virtual void RemoveProduct(Product product)
        {
            if (!this.Products.Any(x => x.Name == product.Name))
            {
                throw new ArgumentNullException("Last");
            }
            this.Products.Remove(product);

            //if (!this.Products.Remove(product))
            //{
            //    throw new ArgumentNullException("Last");
            //}

            //Guard.WhenArgument(product, "The product is not set!").IsNull().Throw();
            //Guard.WhenArgument(this.Products, "The product is not set!").IsNullOrEmpty().Throw();

            //if (!this.Products.Contains(product))
            //{
            //    throw new ArgumentNullException("Last");
            //}
            //this.Products.Remove(product);
        }

        public string Print()
        {
            var strBuilder = new StringBuilder();

            strBuilder.Append("#Category: ").Append(this.Name + "\n");
            if (this.Products.Count == 0)
            {
                strBuilder.Append(" #No product in this category");
            }
            else
            {
                foreach (var product in this.products)
                {
                    strBuilder.Append(product.Print());
                }
            }

            return strBuilder.ToString();
        }
    }
}
