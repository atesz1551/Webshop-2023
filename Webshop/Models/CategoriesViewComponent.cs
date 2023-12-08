using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop.DAL;

namespace Webshop.Models
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly DataContext _context;

        public CategoriesViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Categories.ToListAsync());
    }
}
