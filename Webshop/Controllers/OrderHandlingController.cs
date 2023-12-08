using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.DAL;

namespace Webshop.Controllers
{
    [Authorize]
    public class OrderHandlingController : Controller
    {
        private DataContext _dbContext;
        public OrderHandlingController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            var orders = _dbContext.Orders;
            return View(orders);
        }
    }
}
