using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NoteTaker.Models;

namespace NoteTaker.Controllers
{
    public class NotesController : Controller
    {
        private NoteContext context;

        public NotesController(NoteContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List()
        {
            List<Note> notes;
            notes = context.Notes
                .OrderBy(p => p.NoteID).ToList();

            // create the view model
            var model = new NotesViewModel
            {
                Notes = notes
            };

            // pass the view model to the view
            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var note = context.Notes.Find(id);
            return View(note);
        }

        [HttpPost]
        public IActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                if (note.NoteID == 0)
                    context.Notes.Add(note);
                else
                    context.Notes.Update(note);
                context.SaveChanges();
                return RedirectToAction("List", "Notes");
            }
            else
            {
                ViewBag.Action = (note.NoteID == 0) ? "Add" : "Edit";
                return View(note);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Note());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = context.Notes.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Note note)
        {
            context.Notes.Remove(note);
            context.SaveChanges();
            return RedirectToAction("List", "Notes");
        }
    }
}