using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Socialmedia.Models;
using Socialmedia.Repository;

namespace Socialmedia.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController

        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }
        public ActionResult Index()
        {
            IEnumerable<User> u = _user.GetAll();

            return View(u);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View(_user.GetUserById(id));
       
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User collection)
        {
            try
            {
                _user.AddUser((User)collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_user.GetUserById(id));//return View(_hotel.GetHotelById(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User u)
        {
            try
            {
                _user.UpdateUser(id,u);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_user.GetUserById(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User u)
        {
            try
            {
                _user.DeleteUser(id,u);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
