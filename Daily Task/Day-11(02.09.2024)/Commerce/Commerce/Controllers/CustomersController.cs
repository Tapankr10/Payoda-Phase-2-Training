using Commerce.Models;
using Commerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    public class CustomersController : Controller
    {

        private readonly ICustomers _customer;

        public CustomersController(ICustomers customer)
        {
            _customer = customer;
        }


        // GET: CustomersController
        public ActionResult Index()
        {
            return View(_customer.GetCustomers());
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View(_customer.GetCustomerById(id));
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customers collection)
        {
            try
            {
                _customer.AddCustomer(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_customer.GetCustomerById(id));
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customers collection)
        {
            try
            {
                _customer.UpdateCustomer(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_customer.GetCustomerById(id));
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customers collection)
        {
            try
            {
                _customer.DeleteCustomer(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
    }
