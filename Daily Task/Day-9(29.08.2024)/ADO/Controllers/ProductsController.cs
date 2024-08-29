using ADO.DataAccess;
using ADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADO.Controllers
{
    public class ProductsController : Controller
    {
        ProductDataAccess prod = new ProductDataAccess();
        // GET: ProductsController1
        public ActionResult Index()
        {
            List<Product> lst = prod.Fetch();
            return View(lst);
        }

        // GET: ProductsController1/Details/5
        public ActionResult Details(int id)
        {

           
          Product pro= prod.Search(id);
            return View(pro);
        }

        // GET: ProductsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController1/Delete/5
        public ActionResult Delete(int id)
        {
            Product pro = prod.Search(id);
            return View(pro);
        }

        // POST: ProductsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product p)
        {
            try
            {
                prod.delete(id, p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
