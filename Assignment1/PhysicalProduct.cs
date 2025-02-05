using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class PhysicalProduct: Product
    {

        //fields
        private double _weight;
        private double _shippingCost;

        //properties
        public double Weight 
        {
            get; set;
        }

        public double ShippingCost
        {
            get; set;
        }

        //constructor
        public PhysicalProduct(int prodId, string prodName, ProductType prodType, double prodPrice, double weight, double shippingCost) :base(prodId, prodName, prodType, prodPrice) 
        {
            Weight = weight;
            ShippingCost = shippingCost;
        }

        //method

        public override double CalculatePrice()
        {
            double finalPrice = ProductPrice + ShippingCost;
            return finalPrice;
        }

        public override string ToString()
        {
            return $"{ProductId}\t{ProductName}\t{ProdType}\t{CalculatePrice()}\t{Weight}\t{ShippingCost}\n";
            //Id\tName\tType\t\tPrice\tWeight\tShipping Cost\n
        }


    }
}
