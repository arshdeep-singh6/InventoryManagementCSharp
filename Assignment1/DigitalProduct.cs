using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class DigitalProduct: Product
    {
        //fields
        private double _downloadSize;
        private double _LicenseDuration;

        //properties

        public double DownloadSize
        {
            get; set;
        }

        public double LicenseDuration
        {
            get; set;
        }

        //constructor

        public DigitalProduct(int prodId, string prodName, ProductType prodType, double prodPrice, double downloadSize, double licenseDuration ):base(prodId, prodName, prodType, prodPrice)
        {
            DownloadSize = downloadSize;
            LicenseDuration = licenseDuration;
        }

        //methods

        public override double CalculatePrice()
        {
            double finalPrice = ProductPrice * LicenseDuration;
            return  finalPrice;
        }

        public override string ToString()
        {
            return $"{ProductId}\t{ProductName}\t{ProdType}\t\t{CalculatePrice()}\t{DownloadSize}\t\t{LicenseDuration}\n";
                //"Id\tName\tType\t\tPrice\tDownload Size\tLicense Duration\n
        }
    }
}
