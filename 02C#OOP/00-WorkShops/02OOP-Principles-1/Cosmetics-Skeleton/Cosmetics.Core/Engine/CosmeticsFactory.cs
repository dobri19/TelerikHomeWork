using Cosmetics.Cart;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;

namespace Cosmetics.Core.Engine
{
    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            return new Category(name);
        }

        public Shampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            Shampoo shamp = new Shampoo(name, brand, price, gender, milliliters, usage);
            return shamp;
        }

        public Toothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            string nnn = string.Join(", ", ingredients);
            Toothpaste tooth = new Toothpaste(name, brand, price, gender, nnn);
            return tooth;
        }

        public Cream CreateCream(string name, string brand, decimal price, GenderType gender, ScentType scent)
        {
            Cream cream = new Cream(name, brand, price, gender, scent);
            return cream;
        }

        public ShoppingCart CreateShoppingCart()
        {
            ShoppingCart cart = new ShoppingCart();
            return cart;
        }
    }
}
