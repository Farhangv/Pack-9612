using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AWEntities ctx = new AWEntities();
            //var products = ctx.Products.ToList();

            //var products = from p in ctx.Products
            //               where p.ListPrice >= 100
            //               orderby p.Name descending
            //               select p;


            var products = ctx.Products//.ToList()
                            .Where(p => p.ListPrice >= 100)
                            //.Where(p => p.Name.Split(' ')[0] == "Bike")
                            .OrderByDescending(p => p.Name)
                            .Select(p => new { Name = p.Name, p.Color, Price = p.ListPrice, p.ProductSubcategory })
                            .ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name}\t{product.Color}\t{product.Price}\t{product.ProductSubcategory?.Name ?? "[NoCategory]"}");
            }

            Console.ReadKey();
        }


    }

    public class ProductBrief
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double ListPrice { get; set; }
        public string ProductSubCategoryName { get; set; }
    }
}
