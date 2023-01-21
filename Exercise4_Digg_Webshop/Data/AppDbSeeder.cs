using Exercise4_Digg_Webshop.Models;
using Microsoft.AspNetCore.Builder;
using Exercise4_Digg_Webshop.Models.Entities;

namespace Exercise4_Digg_Webshop.Data


{
    public class AppDbSeeder
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            

                context.Database.EnsureCreated();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ProductName = "ASYOU Stickad hoodie",
                            ProductDescription = "Viscose is made from wood and can use more or less harmful chemicals in its production processes. ",
                            ProductCategory = "hoodie",
                            Rating = 3,
                            BasePrice = 399,
                            ImageUrl = "showcase-img-2.png",
                        },
                        new Product()
                        {
                            ProductName = "Tommy Hillfiger shirt",
                            ProductDescription = "Made from sustainably controlled sources and production processes",
                            ProductCategory = "shirt",
                            Rating = 5,
                            BasePrice = 449,
                            PromotionPrice = 339,
                            ImageUrl = "showcase-img-1.png",
                        },
                        new Product()
                        {
                            ProductName = "KI$K Black Dress",
                            ProductDescription = "It can cut emissions and water impact by 50%",
                            ProductCategory = "dress",
                            Rating = 4,
                            BasePrice = 799,
                            ImageUrl = "black-dress.png",
                        },
                        new Product()
                        {
                            ProductName = "NLY Red Dress",
                            ProductDescription = "compared to traditional viscose much more enviromentally friendly",
                            ProductCategory = "dress",
                            Rating = 4,
                            BasePrice = 799,
                            PromotionPrice = 599,
                            ImageUrl = "red-dress.png",
                        },
                        new Product()
                        {
                            ProductName = "SURF Red hoodie",
                            ProductDescription = "more sustainable materials and produced in a more sustainable way",
                            ProductCategory = "hoodie",
                            Rating = 4,
                            BasePrice = 349,
                            ImageUrl = "red-hoodie.jpg",
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
