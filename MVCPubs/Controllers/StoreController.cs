using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPubs.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCPubs.Controllers
{
    public class StoreController : Controller
    {

        private readonly pubsContext context;

        public StoreController(pubsContext context)
        {
            this.context = context;
        }


        //GET: Store o Store/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", context.Stores.ToList());
        }


        [HttpGet]
        public IActionResult TraerUna(string id)
        {
            Store store = context.Stores.Find(id);
            if (store == null)
            {
                return NotFound();
            }
            else
            {
                return View("Index", store);
            }
        }


        
        public IActionResult TraerXCiudad(string City)
        {
            IEnumerable<Store> list = BuscaXCiudad(City);
            if (list == null)
            {
                return NotFound();
            }
            else
            {
                return View("Index", list);
            }
        }

        [NonAction]
        public IEnumerable<Store> BuscaXCiudad(string ciudad)
        {
            IEnumerable<Store> list = (from a in context.Stores
                                where a.City.ToUpper() == ciudad.ToUpper()
                                select a).ToList();
            return list;
        }


        [HttpGet]
        public IActionResult Create()
        {
            Store store = new Store();
            return View("Create", store);
        }

        [HttpPost]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                context.Stores.Add(store);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create");
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            Store store = context.Stores.Find(id);
            if (store != null)
            {
                return View("Delete", store);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            Store store = context.Stores.Find(id);

            context.Stores.Remove(store);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Store store = context.Stores.Find(id);
            if (store == null)
            {
                return NotFound();
            }
            else
            {
                return View("Edit", store);
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                context.Entry(store).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit",store);
            }
        }


        //GET: Pubs/Details
        [HttpGet]
        public IActionResult Details(string id)
        {
            Store store = context.Stores.Find(id);
            if (store == null) return NotFound();
            return View("Details", store);
        }

    }
}
