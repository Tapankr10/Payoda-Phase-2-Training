using ADO.DataAccess;
using ADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADO.Controllers
{
    public class ProductController : Controller
    {
        ProductDataAccess prod = new ProductDataAccess();

        public IActionResult Index()
        {
            List<Product> lst = prod.Fetch();
                return View();
        }
    }
}
