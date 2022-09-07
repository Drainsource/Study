using DemoLibrary;
using HomeWorkMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkMVC.Controllers
{
    public class AddressesController : Controller
    {
        private readonly ILogger<AddressesController> _logger;

        public AddressesController(ILogger<AddressesController> logger)
        {
            _logger = logger;
        }
        // GET: AddressesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AddressesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddressesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressesModel collection)
        {
            if (ModelState.IsValid == false)
            {
                _logger.LogWarning("The user submitted an invalid Address upon Create.");
                return View();
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddressesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddressesController/Edit/5
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

        // GET: AddressesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddressesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
