using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AWEntities ctx = new AWEntities();
            var selectedProduct = ctx.Products.Find(777);
            selectedProduct.Name = "Another New Name";
            //ctx.SaveChanges();

            var newProduct = new Product()
            {
                Name = "Added product",
                Color = "Red",
                FinishedGoodsFlag = true,
                ListPrice = 1000,
                StandardCost = 500,
                ProductSubcategoryID = 10,
                rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now,
                ProductNumber = "CA-1010",
                MakeFlag = true,
                SafetyStockLevel = 10,
                ReorderPoint = 10,
                DaysToManufacture = 0,
                SellStartDate = DateTime.Now,
                
            };
            ctx.Products.Add(newProduct);

            var productToDelete = ctx.Products.Find(1);
            ctx.Products.Remove(productToDelete);

            ctx.SaveChanges();

            var products = ctx.Products.ToList();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID}.{product.Name}\t{product.Color}\t{product.ListPrice}");
            }

            Console.ReadKey();
        }
    }
}
