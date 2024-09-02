using Commerce.Models;
using Commerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Commerce.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrders _order;
        private readonly ICustomers _customer;

        public OrdersController(IOrders order, ICustomers customer)
        {
            _order = order;
            _customer = customer;
        }



        // GET: OrdersController
        public ActionResult Index()
        {
            return View(_order.GetOrders());
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View(_order.GetOrdersById(id));
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            ViewBag.CustId = new SelectList(_customer.GetCustomers(), "CustId", "CustId");
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Orders o)
        {
            try
            {
                ViewBag.CustId = new SelectList(_customer.GetCustomers(), "CustId", "CustId",o.custID);
                _order.AddOrders(o);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CustId = new SelectList(_customer.GetCustomers(), "CustId", "CustId");
            return View(_order.GetOrdersById(id));
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Orders collection)
        {
            try
            {
                ViewBag.CustId = new SelectList(_customer.GetCustomers(), "CustId", "CustId", collection.custID);
                _order.UpdateOrders(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_order.GetOrdersById(id));
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Orders collection)
        {
            try
            {
                _order.DeleteOrders(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
