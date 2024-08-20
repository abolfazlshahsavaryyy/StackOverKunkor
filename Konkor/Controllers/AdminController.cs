using Konkor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Data;

namespace Konkor.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(Admin admin)
        {
            var test = _db.Admins.First();
            var find_admin=_db.Admins.Where(x=>x.Name=="thisisname").Where(x=>x.RamsShab=="thisispassword").FirstOrDefault();
            if (find_admin == null)
            {
                return RedirectToAction("Index");
            }
            
            return View("AdminPage");
        }
        public IActionResult AddQuestion()
        {
            return View();
        }
        public IActionResult AddQuestionForm(Talk talk)
        {
            var existingTalk = _db.Talks.Local.FirstOrDefault(t => t.Id == talk.Id);
            if (existingTalk != null)
            {
                // Detach the existing entity if it's already being tracked
                _db.Entry(existingTalk).State = EntityState.Detached;
            }

            var find_talk = _db.Talks.Find(talk.Id);
            if (find_talk == null)
            {
                _db.Talks.Add(talk);
            }
            else
            {
                _db.Entry(find_talk).CurrentValues.SetValues(talk);
            }

            _db.SaveChanges();
            return View("AdminPage");
        }
        public IActionResult Delete(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var find_talk= _db.Talks.FirstOrDefault(talk => talk.Id == id);
            if(find_talk == null)
            {
                return NotFound();
            }
            _db.Talks.Remove(find_talk);
            _db.SaveChanges();
            return View("AdminPage");
        }


        public IActionResult viewList()
        {
            var all_question = _db.Talks.Where(x => x.Answer != null).ToList();
            return View(all_question);
        }
        public IActionResult StudentQuestion()
        {
            var all_question = _db.Talks.Where(x => x.Answer == null).ToList();
            return View("viewList",all_question);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var find_talk=_db.Talks.Find(id);
            if(find_talk == null)
            {
                return NotFound();
            }
            return View("AddQuestion", find_talk);
        }
    }
}
