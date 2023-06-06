using Microsoft.AspNetCore.Mvc;
using Notes.Data;
using Notes.Models;

namespace Notes.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NotesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            IEnumerable<Noting> objNotesList = _db.NotesLists;

            return View(objNotesList);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Noting obj)
        {
            if (ModelState.IsValid)
            {
                _db.NotesLists.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Note has been added!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var noteFromDb = _db.NotesLists.Find(id);
            if(noteFromDb == null)
            {
                return NotFound();
            }
            return View(noteFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Noting obj)
        {
            if (ModelState.IsValid)
            {
                _db.NotesLists.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Note has been updated!";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var noteFromDb = _db.NotesLists.Find(id);
            if (noteFromDb == null)
            {
                return NotFound();
            }
            return View(noteFromDb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.NotesLists.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.NotesLists.Remove(obj); 
            _db.SaveChanges();
            TempData["success"] = "Note has been deleted!";

            return RedirectToAction("Index");
       
        }
    }
}

