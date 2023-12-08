using Webshop.DAL;

namespace Webshop.Models
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            //context.Database.Migrate();

            if (!context.Products.Any())
            {
                Category MaleShirts = new Category { Name = "Férfi pólók", Slug = "ferfi_polo" };
                Category FemaleShirts = new Category { Name = "Női pólók", Slug = "noi_polo" };

                context.Products.AddRange(
                        new Product
                        {
                            Name = "3-STRIPES TEE - Nyomott mintás póló",
                            Slug = "ferfi_adidas",
                            Description = "Külső szövet anyaga: \r\n    100% pamut\r\nSzövet: \r\n    Dzsörzé\r\nKezelési utasítások: \r\n    Gépi mosás 30 °C-on, gépi mosás kíméletes programon",
                            Price = 11690M,
                            Category = MaleShirts,
                            Image = "adidas_3_stripes_green.jpg"
                        }
                        
                );

                context.SaveChanges();
            }
        }
    }
}

