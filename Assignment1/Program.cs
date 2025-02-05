using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            int id = 100;
            products.Add(new PhysicalProduct(++id, "Laptop",ProductType.Physical, 1000, 22, 13 )) ;
            products.Add(new DigitalProduct(++id, "ebook", ProductType.Digital, 29, 38, 3));
            

            
          
            Boolean exit = false;
            while (!exit)
            {
                //creating menu

                Console.WriteLine("\nMenu Options: ");
                Console.WriteLine("------------- ");
                Console.WriteLine("\n1. Add a new Product.");
                Console.WriteLine("2. Delete a Product.");
                Console.WriteLine("3. View All Products.");
                Console.WriteLine("4. View Products By Type.");
                Console.WriteLine("5. Search product By Name.");
                Console.WriteLine("6. Exit.");
                Console.WriteLine("Choose any option from 1 to 6: ");
                int chosenOption = int.Parse(Console.ReadLine());
                switch (chosenOption)
                {
                    case 1:
                        Console.WriteLine("Enter product name");
                        string pName = Console.ReadLine();

                        
                        while (string.IsNullOrEmpty(pName))//(Input Validations in C# at C Sharp for Beginners Course codeeasy.io, n.d.)
                        {
                            Console.WriteLine("Product name cannot be null or empty!");
                            Console.WriteLine("Please enter product name again: ");
                            pName = Console.ReadLine();

                        }
                        

                        Console.WriteLine("Enter product Type: Digital or Physical.");
                        string type = Console.ReadLine();
                        while(!((type.ToLower() == "physical") || (type.ToLower() == "digital")))
                        {
                            Console.WriteLine("Product type can only be Digital or Physical.");
                            Console.WriteLine("Please enter again: ");
                            type = Console.ReadLine();
                        }
                        //initializing a value for productType.
                        ProductType pType = ProductType.Physical;

                        if (type.ToLower() == "digital")
                        {
                            pType = ProductType.Digital;
                        }
                        else if (type.ToLower() == "physical")
                        {
                            pType = ProductType.Digital;
                        }
                        

                        Console.WriteLine("Enter product Price");
                        string strPrice = Console.ReadLine();

                        double price;
                        while (!double.TryParse(strPrice, out price) || price < 0)
                        {
                            Console.WriteLine("Invalid value, enter a number only: ");
                            strPrice = Console.ReadLine();
                        }//(Input Validations in C# at C Sharp for Beginners Course codeeasy.io, n.d.)


                        if (pType == ProductType.Physical)
                        {
                            Console.WriteLine("Enter Product's Weight: ");
                            double pWeight = double.Parse(Console.ReadLine());

                            while(pWeight<=0)
                            {
                                Console.WriteLine("Product weight cannot be less than or equal to zero.");
                                Console.WriteLine("Please enter again: ");
                                pWeight = double.Parse(Console.ReadLine());
                            }
                            Console.WriteLine("Enter Product's Shipping Cost: ");
                            double shipCost = double.Parse(Console.ReadLine());

                            while(shipCost<0)
                            {
                                Console.WriteLine("Shipping cost cannot be negative.");
                                Console.WriteLine("Please enter again: ");
                                shipCost = double.Parse(Console.ReadLine());
                            }
                            Product prod = new PhysicalProduct(++id, pName, pType, price, pWeight, shipCost);
                            products.Add(prod);
                        }
                        else if (pType == ProductType.Digital)
                        {
                            Console.WriteLine("Enter Product's Download Size: ");
                            double downloadSize = double.Parse(Console.ReadLine());

                            while(downloadSize<=0)
                            {
                                Console.WriteLine("Download size cannot be less than or equal to zero!");
                                Console.WriteLine("Please enter again: ");
                                downloadSize = double.Parse(Console.ReadLine());
                            }
                            Console.WriteLine("Enter the license duration: ");
                            double lDuration = double.Parse(Console.ReadLine());

                            while(lDuration<0)
                            {
                                Console.WriteLine("License Duration cannot be negative.");
                                Console.WriteLine("Please enter again: ");
                                lDuration = double.Parse(Console.ReadLine());
                            }
                            Product prod = new DigitalProduct(++id, pName, pType, price, downloadSize, lDuration);
                            products.Add(prod);
                        }
                        Console.WriteLine("Product added to inventory.");
                        
                        break;
                    case 2:
                        
                        Console.WriteLine("Enter the Product's ID to remove: ");
                        int delId = int.Parse(Console.ReadLine());
                        while (delId < 0 || !(products.Exists(prd => prd.ProductId ==delId) ) )
                        {
                            Console.WriteLine("Invalid ID!!!");
                            Console.WriteLine("Please enter a valid ID: ");
                            delId = int.Parse(Console.ReadLine());

                        }
                        Console.WriteLine("Removing Product: " + products.Find(p => p.ProductId == delId));
                        products.Remove(products.Find(p => p.ProductId == delId));
                        Console.WriteLine("Product Removed Successfully. ");
                        
                        break;
                    case 3:
                        foreach (var p in products)
                        {
                            Console.WriteLine(p);
                        }
                        
                        break;
                    case 4:
                        Console.WriteLine("Enter product Type: Digital or Physical.");
                        Boolean enumInvalid = true;

                        while (enumInvalid)
                        {

                            try
                            {
                                ProductType rtype = (ProductType)Enum.Parse(typeof(ProductType), Console.ReadLine());
                                //(C# - Enum.Parse: Convert String to Enum - Dot Net Perls, n.d.)

                                if (rtype == ProductType.Physical)
                                {
                                    var physicalProducts = from prod in products
                                                           where prod.ProdType == ProductType.Physical
                                                           select prod;
                                    foreach (var product in physicalProducts)
                                    {
                                        Console.WriteLine($"Id\tName\tType\t\tPrice\tWeight\tShipping Cost\n {product}");
                                    }
                                }
                                else if (rtype == ProductType.Digital)
                                {
                                    var digitalProducts = from prod in products
                                                          where prod.ProdType == ProductType.Digital
                                                          select prod;
                                    foreach (var product in digitalProducts)
                                    {
                                        Console.WriteLine($"Id\tName\tType\t\tPrice\tDownload Size\tLicense Duration\n{product}");
                                    }

                                }
                                enumInvalid = false;
                            }
                            catch(Exception exc)
                            {
                                Console.WriteLine("Product type does not exist!!");
                                Console.WriteLine("Please enter either Physical or Digital.");
                                Console.WriteLine(exc.Message);
                            }

                            /*
                             * Reference: 
                                C# - Enum.Parse: Convert String to Enum - Dot Net Perls. (n.d.). https://www.dotnetperls.com/enum-parse#google_vignette
                             */

                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter the name of the product: ");
                        string sName = Console.ReadLine();

                        while(!(products.Exists(prod=> prod.ProductName.ToLower() == sName.ToLower()) ))
                        {
                            Console.WriteLine("Product Name does not exist! ");
                            Console.WriteLine("Please enter again: ");
                            sName = Console.ReadLine();
                        }
                        var searchResult = from Product p in products
                                           where p.ProductName.ToLower() == sName.ToLower()
                                           select p;
                        foreach(var product in searchResult)
                        {
                            Console.WriteLine(product);
                        }
                        break;
                    case 6:
                        exit = true;
                        break;
                    
                }
            }
        }

    }
}
/* Reference for validating input: 
                         * 
                         * Input validations in C# at C Sharp for beginners course codeeasy.io. (n.d.). https://codeeasy.io/lesson/input_validation?course=mellanniva
                         */