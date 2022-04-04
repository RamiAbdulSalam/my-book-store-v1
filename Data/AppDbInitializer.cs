using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebAPIApplication.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            SeedBook(applicationBuilder);
            SeedPublisher(applicationBuilder);
            SeedAuthor(applicationBuilder);
        }

        public static void SeedBook(IApplicationBuilder applicationBuilder)
        {
            //Scope with App Services
            using (var ServiceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // get db
                var context = ServiceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Models.Books()
                    {
                        Title = "first books",
                        Description = "first book description",
                        CoverUrl = "Https....",
                        DateAdded = DateTime.Now.AddDays(-5),
                        DateRead = DateTime.Now,
                        Genre = "Comdey",
                        IsRead = true,
                        Rate = 6,
                        PublisherId = 1
                    },
                        new Models.Books()
                        {
                            Title = "second books",
                            Description = "second book description",
                            CoverUrl = "Https....",
                            DateAdded = DateTime.Now.AddDays(-5),
                            Genre = "Comdey",
                            IsRead = false,
                            PublisherId = 1
                        });
                    context.SaveChanges();

                }
            }
        }

        public static void SeedPublisher(IApplicationBuilder applicationBuilder)
        {
            using (var ServiceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = ServiceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new Models.Publisher()
                    {
                        Name = "Publisher 1 "
                    },
                        new Models.Publisher()
                        {
                            Name = "Publisher 2 "
                        });
                    context.SaveChanges();

                }
            }
        }

        public static void SeedAuthor(IApplicationBuilder applicationBuilder)
        {
            using (var ServiceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = ServiceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new Models.Author()
                    {
                        FullName = "Author 1 "
                    },
                        new Models.Author()
                        {
                            FullName = "Author 2 "
                        });
                    context.SaveChanges();

                }
            }
        }
    }
}
