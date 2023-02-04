using Exercise4_Digg_Webshop.Models;
using Exercise4_Digg_Webshop.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace Exercise4_Digg_Webshop.Data


{
    public class AppDbSeeder
    {
        public static void SeedProducts(IApplicationBuilder applicationBuilder)
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

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserType.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserType.Admin));
                if (!await roleManager.RoleExistsAsync(UserType.User))
                    await roleManager.CreateAsync(new IdentityRole(UserType.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@admin.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin123??"); //Coding@1234?
                    await userManager.AddToRoleAsync(newAdminUser, UserType.Admin);
                }

                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.EnsureCreated();
            }
        }

        /*public static void SeedBlog(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();


                context.Database.EnsureCreated();

                if (!context.Images.Any())
                {
                    context.Images.AddRange(new List<Image>()
                        {
                            new Image()
                            {
                                ImageName = "Leather1.jpg",
                                Style = 1
                            },
                            new Image()
                            {
                                ImageName = "Mountain1.jpg",
                                Style = 1
                            },
                            new Image()
                            {
                                ImageName = "Mountain2.jpg",
                                Style = 1
                            },
                            new Image()
                            {
                                ImageName = "Coffee1.jpg",
                                Style = 1
                            },
                        });
                    context.SaveChanges();
                }
                if (!context.SectionImageModules.Any())
                {
                    context.SectionImageModules.AddRange(new List<SectionImageModule>()
                        {
                            new SectionImageModule()
                            {
                                Style = 1,
                                Images = context.Images.ToList(),
                            },
                            new SectionImageModule()
                            {
                                Style = 2,
                                Images = context.Images.ToList(),
                            },
                            new SectionImageModule()
                            {
                                Style = 3,
                                Images = context.Images.ToList(),
                            },
                        });
                    context.SaveChanges();
                }
                if (!context.Sections.Any())
                {
                    context.Sections.AddRange(new List<Section>()
                        {
                            new Section()
                            {
                                BlogArticleId = 1,
                                SectionImageModuleId = 3,
                                Title = "God morgon alla solstrålar!",
                                Description = "Även fast vi är på väg mot ljusare tider, så måste jag säga att det börjar bli riktigt trist att kolla ut genom fönstret, hade verkligen önskat att snön hade lyckats hålla sig kvar åtminstone till julafton, det är alltid lite mysigare då. Men som tur har man all jul belysning som lyser upp hemmet istället. 😍",
                                Style = 1,
                            },
                            new Section()
                            {
                                BlogArticleId = 1,
                                Description = "Igår slog jag in lite julklappar till min lilla pälskling också. Han älskar nämligen att öppna paket, det är nog en av dom bästa sakerna han vet. Han blir som ett barn på julafton, helt klart lyrisk av sig, hahaha! Men han är otroligt duktig av sig, han låter julklapparna vara ifred under granen tills han får öppna dom. 😄Idag är också den där dagen då julstädning står på schemat för min del. Man kommer vara som en liten tomtenisse här som yrar och har sig och studsar upp och ner överallt. Gillar att ha ordning och reda runt mig, ett ny städat hem är den bästa känslan. Jag skulle nog inte säga att jag är sådär extremt pedant av mig, men jag kan störa mig så sjukt mycket på att saker står framme som inte ska vara framme. Vill alltid ha det undanplockat överallt, kanske är man pedant ändå, hahaha! 🤦‍♀️ "
                                Style = 1
                            },
                            new Section()
                            {
                                BlogArticleId = 2,
                                SectionImageModuleId = 2,
                                Title = "Test Title1",
                                Description = "Test Description",
                                Style = 2
                            }
                        });
                    context.SaveChanges();
                }
                if (!context.BlogArticles.Any())
                {
                    context.BlogArticles.AddRange(new List<BlogArticle>()
                        {
                            new BlogArticle()
                            {
                                Title = "10 Reasons to change to Leather❤️",
                                TitleImageUrl = "Leather1.jpg",
                                Style = 1,
                            },
                            new BlogArticle()
                            {
                                Title = "5 adventorous moments with Digg",
                                TitleImageUrl = "Mountain1.jpg",
                                Style = 2,
                            }
                        });
                    context.SaveChanges();
                }
            }
        }*/
    }

}
