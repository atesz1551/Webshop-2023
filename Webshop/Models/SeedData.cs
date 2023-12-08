using Microsoft.EntityFrameworkCore;
using Webshop.DAL;

namespace Webshop.Models
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                Category MaleShirts = new Category { Name = "Férfi pólók", Slug = "ferfi_polo" };
                Category FemaleShirts = new Category { Name = "Női pólók", Slug = "noi_polo" };

                context.Products.AddRange(
                        new Product
                        {
                            Name = "3-STRIPES TEE - Nyomott mintás póló",
                            Slug = "ferfi_adidas",
                            Description = "Méret: L \r\n Külső szövet anyaga: \r\n    100% pamut\r\nSzövet: \r\n    Dzsörzé\r\nKezelési utasítások: \r\n    Gépi mosás 30 °C-on, gépi mosás kíméletes programon",
                            Price = 100M,
                            Category = MaleShirts,
                            Image = "adidas_3_stripes_green.jpg"
                        },
                        new Product
                        {
                            Name = "Nike Club Tee - Basic póló",
                            Slug = "ferfi_nike",
                            Description = "Méret: L \r\n Külső szövet anyaga: \r\n    100% pamut\r\nSzövet: \r\n    Dzsörzé\r\nKezelési utasítások: \r\n    Gépi mosás 30 °C-on, ne fehérítse",
                            Price = 90M,
                            Category = MaleShirts,
                            Image = "nike_clubtee_navy.jpg"
                        },
                        new Product
                        {
                            Name = "Lacoste Sportfelső",
                            Slug = "ferfi_lacoste",
                            Description = "Méret: M \r\n Sport: \r\n    Tréning, Tenisz, Urban Outdoor\r\nNyakkivágás: \r\n    Kereknyakú\r\nExtrák: \r\n    Gyorsan száradó\r\nMinta: \r\n    Sima\r\nTulajdonságok: \r\n    Légáteresztő, gyorsan száradó",
                            Price = 290M,
                            Category = MaleShirts,
                            Image = "lacoste_sport_black.jpg"
                        },
                        new Product
                        {
                            Name = "Nike Dry Tee Crew Solid Sportfelső",
                            Slug = "ferfi_nike",
                            Description = "Méret: S \r\n Külső szövet anyaga: \r\n    59% pamut, 41% poliészter\r\nSzövet: \r\n    Dzsörzé\r\nTechnológia: \r\n    Dri-Fit (Nike)\r\nKezelési utasítások: \r\n    Gépi mosás 30 °C-on",
                            Price = 190M,
                            Category = MaleShirts,
                            Image = "nike_dry_tee_black.jpg"
                        },
                        new Product
                        {
                            Name = "Levi's Original Tee Basic póló",
                            Slug = "ferfi_levis",
                            Description = "Méret: XL \r\n Külső szövet anyaga: \r\n    100% pamut\r\nSzövet: \r\n    Dzsörzé\r\nKezelési utasítások: \r\n    Gépi mosás 30 °C-on",
                            Price = 50M,
                            Category = MaleShirts,
                            Image = "levis_blue.jpg"
                        },
                        //
                        new Product
                        {
                            Name = "Lacoste Basic póló",
                            Slug = "noi_lacoste",
                            Description = "Méret: S \r\n Külső szövet anyaga: \r\n    100% pamut\r\nSzövet: \r\n    Dzsörzé\r\nKezelési utasítások: \r\n    Ne szárítsa szárítógépben, gépi mosás 30 °C-on",
                            Price = 100M,
                            Category = FemaleShirts,
                            Image = "lacoste_basic.jpg"
                        },
                        new Product
                        {
                            Name = "Levi's Perfect Tee mintás póló",
                            Slug = "noi_levis",
                            Description = "Méret: M \r\n Külső szövet anyaga: \r\n    100% pamut\r\nSzövet: \r\n    Dzsörzé\r\nKezelési utasítások: \r\n    Gépi mosás 30 °C-on",
                            Price = 93M,
                            Category = FemaleShirts,
                            Image = "levis_perfect-blue.jpg"
                        },
                        new Product
                        {
                            Name = "Tommy Hilfiger Heritage mintás póló",
                            Slug = "noi_tommyhilfiger",
                            Description = "Méret: L \r\n Külső szövet anyaga: \r\n    100% pamut\r\nSzövet: \r\n    Dzsörzé\r\nKezelési utasítások: \r\n    Ne fehérítse, ne szárítsa szárítógépben, gépi mosás 30 °C-on, gépi mosás kíméletes programon",
                            Price = 99M,
                            Category = FemaleShirts,
                            Image = "tommy_hilfiger_heritage.jpg"
                        },
                        new Product
                        {
                            Name = "Adidas Essentials Basic póló",
                            Slug = "noi_adidas",
                            Description = "Méret: S \r\n Külső szövet anyaga: \r\n    100% pamut\r\nSzövet: \r\n    Dzsörzé\r\nKezelési utasítások: \r\n    Ne szárítsa szárítógépben, gépi mosás 30 °C-on, gépi mosás kíméletes programon",
                            Price = 110M,
                            Category = FemaleShirts,
                            Image = "adidas_essentials.jpg"
                        },
                        new Product
                        {
                            Name = "Polo Ralph Lauren Basic póló",
                            Slug = "noi_poloralph",
                            Description = "Méret: M \r\n Külső szövet anyaga: \r\n    100% pamut\r\nSzövet: \r\n    Dzsörzé\r\nKezelési utasítások: \r\n    Gépi mosás 30 °C-on, gépi mosás kíméletes programon",
                            Price = 300M,
                            Category = FemaleShirts,
                            Image = "polo_ralph.jpg"
                        }



                );

                context.SaveChanges();
            }
        }
    }
}

