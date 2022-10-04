using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContextSeep
    {
        public static void SeepData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product> {
                new Product()
                {
                    Id = "1",
                    Name = "SP 1",
                    Summary = "Summary",
                    Description = "Description",
                    Category = "Category",
                    ImageFile = "imagefile.png",
                    Price = 100
                }
                ,
                new Product()
                {
                    Id = "2",
                    Name = "SP 2",
                    Summary = "Summary 2",
                    Description = "Description 2",
                    Category = "Category 2",
                    ImageFile = "imagefile.png",
                    Price = 100
                },
                new Product()
                {
                    Id = "3",
                    Name = "SP 3",
                    Summary = "Summary 3",
                    Description = "Description 3",
                    Category = "Category 2",
                    ImageFile = "imagefile.png",
                    Price = 100
                }
            };
        }
    }
}
