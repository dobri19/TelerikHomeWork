﻿using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Models;
using FurnitureManufacturer.Models.Furnitures;
using FurnitureManufacturer.Models.Furnitures.Contracts;
using System;

namespace FurnitureManufacturer.Engine.Factories
{
    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public IFurniture CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            return new Table(model, this.GetMaterialType(materialType).ToString(), price, height, length, width);
        }

        public IFurniture CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            return new Chair(model, this.GetMaterialType(materialType).ToString(), price, height, numberOfLegs);
        }

        private MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden;
                case Leather:
                    return MaterialType.Leather;
                case Plastic:
                    return MaterialType.Plastic;
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }
    }
}
