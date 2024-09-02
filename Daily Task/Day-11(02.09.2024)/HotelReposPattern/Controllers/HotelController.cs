using HotelReposPattern.Models;
using HotelReposPattern.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReposPattern.Controllers
{
    public class HotelController : Controller
    {
        // GET: HotelController

        private readonly IHotel _hotel;

        public HotelController(IHotel hotel)
        {
            _hotel = hotel;
        }
        public ActionResult Index()
        {

            IEnumerable<Hotel> h = _hotel.GetAll();
            return View(h);
        }

        // GET: HotelController/Details/5
        public ActionResult Details(int id)
        {
            return View(_hotel.GetHotelById(id));
        }

        // GET: HotelController/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: HotelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel collection)
        {
            try
            {

                _hotel.AddHotel((Hotel)collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_hotel.GetHotelById(id));
        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hotel h)
        {
            try
            {

                _hotel.UpdateHotel(id,h);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_hotel.GetHotelById(id));
        }

        // POST: HotelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hotel hotel)
        {
            try
            {

                _hotel.DeleteHotel( id, hotel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
