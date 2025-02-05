using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    enum ProductType
    {
        Physical,
        Digital,
    }
    internal abstract class Product
    {

        //fields

        private int _productId;
        private string _productName;
        private ProductType _prodType;
        private double _productPrice;


        //properties
        public int ProductId 
        {
            get; set;
        }

        public string ProductName
        {
            get; set;
        }

        public ProductType ProdType
        {
            get; set;
        }

        public double ProductPrice
        {
            get; set;
        }


        //constructor
        public Product(int productId, string productName, ProductType productType, double productPrice)
        {
            ProductId = productId;
            ProductName = productName;
            ProdType = productType;
            ProductPrice = productPrice;
        }


        //methods
        public abstract double CalculatePrice();

        
    }
}
