using Bytes2you.Validation;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Cart
{
    public class ShoppingCart
    {
        private readonly ICollection<Product> productList;

        public ShoppingCart()
        {
            this.productList = new List<Product>();
        }

        public ICollection<Product> ProductList
        {
            get { return this.productList; }
        }

        public void AddProduct(Product product)
        {
            Guard.WhenArgument(product, "The product is not set!").IsNull().Throw();
            this.productList.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Guard.WhenArgument(product, "The product is not set!").IsNull().Throw();
            if (!this.ProductList.Any(x => x.Name == product.Name))
            {
                throw new ArgumentNullException("Last");
            }
            this.productList.Remove(product);
        }

        public bool ContainsProduct(Product product)
        {
            Guard.WhenArgument(product, "The brand is empty!").IsNull().Throw();
            if (this.ProductList.Contains(product))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal TotalPrice()
        {
            decimal result = 0m;
            foreach (var item in this.ProductList)
            {
                result += item.Price;
            }
            return result;
        }
    }
}
