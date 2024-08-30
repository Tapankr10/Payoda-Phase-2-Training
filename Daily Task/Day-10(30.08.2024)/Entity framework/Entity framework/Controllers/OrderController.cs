using Entity_framework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Entity_framework.Controllers
{
    public class OrderController : Controller
    {
        private readonly CustomerDbconnect _context;

        public OrderController(CustomerDbconnect context)
        {
            _context = context;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            IEnumerable<Order> ords = _context.Orders.Include(c => c.Customer).ToList();

            return View(ords);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            Order ords = _context.Orders.Include(c => c.Customer).FirstOrDefault(o=> o.orderId == id) ?? new Order();
            return View(ords);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            ViewBag.custID = new SelectList(_context.Customers, "custID", "custName");

            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order o)
        {
            try
            {
                ViewBag.custID = new SelectList(_context.Customers, "custID", "custName", o.custID);
                _context.Add(o);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.custID = new SelectList(_context.Customers, "custID", "custName");
            Order ords = _context.Orders.Include(c => c.Customer).FirstOrDefault(o => o.orderId == id) ?? new Order();
            return View(ords);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order o)
        {
            try
            {
                ViewBag.custID = new SelectList(_context.Customers, "custID", "custName", o.custID);
                _context.Orders.Update(o);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
           ViewBag.custID = new SelectList(_context.Customers, "custID", "custName");
            Order ords = _context.Orders.Include(c => c.Customer).FirstOrDefault(o => o.orderId == id) ?? new Order();

            return View(ords);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order o)
        {
            try
            {
                ViewBag.custID = new SelectList(_context.Customers, "custID", "custName", o.custID);
                _context.Remove(o);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
               
            }
            catch
            {
                return View();
            }
        }
    }
}
