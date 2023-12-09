using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webshop.DAL;
using Webshop.Models;

namespace Webshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _IWebHostEnvironment;

        public ProductsController(DataContext context, IWebHostEnvironment iWebHostEnvironment)
        {
            _dataContext = context;
            _IWebHostEnvironment = iWebHostEnvironment;
        }
        public async Task<IActionResult> Index(int p = 1) // p = oldal
        {

            int pageSize = 3; // hany db termek legyen egy oldalon
            ViewBag.PageNumber = p; // oldal szam 
            ViewBag.PageRange = pageSize;
            // ViewBag.CategorySlug = categorySlug; // URL
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_dataContext.Products.Count() / pageSize);
            return View(await _dataContext.Products.OrderByDescending(p => p.Id).Include(p=>p.Category).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());


        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name");
          
            return View();


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);

            if (ModelState.IsValid)
            {
                product.Slug = product.Name.ToLower().Replace(" ", "-");

                var slug = await _dataContext.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "A termék már létezik.");
                    return View(product);
                }

                if (product.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_IWebHostEnvironment.WebRootPath, "media/products");
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    product.Image = imageName;
                }

                _dataContext.Add(product);
                await _dataContext.SaveChangesAsync();

                TempData["Success"] = "Termék létrehozva!";

                return RedirectToAction("Index");
            }

            return View(product);
        }
        public async Task<IActionResult> Edit(long id)
        {
            Product product = await _dataContext.Products.FindAsync(id);

            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);

            if (ModelState.IsValid)
            {
                product.Slug = product.Name.ToLower().Replace(" ", "-");

                var slug = await _dataContext.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The product already exists.");
                    return View(product);
                }

                if (product.ImageUpload != null)
                {   
                    string uploadsDir = Path.Combine(_IWebHostEnvironment.WebRootPath, "media/products");
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    product.Image = imageName;
                }

                _dataContext.Update(product);
                await _dataContext.SaveChangesAsync();

                TempData["Success"] = "The product has been edited!";
            }

            return View(product);
        }

        public async Task<IActionResult> Delete(long id)
        {
            Product product = await _dataContext.Products.FindAsync(id);

            if (!string.Equals(product.Image, "noimage.png"))
            {
                string uploadsDir = Path.Combine(_IWebHostEnvironment.WebRootPath, "media/products");
                string oldImagePath = Path.Combine(uploadsDir, product.Image);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();

            TempData["Success"] = "The product has been deleted!";

            return RedirectToAction("Index");
        }
    }
}
