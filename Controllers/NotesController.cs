using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NoteTaker.Models;

namespace GuitarShop.Controllers
{
    public class NotesController : Controller
    {

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}