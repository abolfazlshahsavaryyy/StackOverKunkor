using Konkor.Models;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Data;

namespace Konkor.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StudentPage()
        {
            return View();
        }
        public IActionResult ListQuestion()
        {
            var list_show=_db.Talks.Where(x=>x.Answer!=null).ToList();
            return View(list_show);
        }
        public IActionResult Search(string searchcontent)
        {
            string[] words_in_search=searchcontent.Split(' ');
            var list_show1 = _db.Talks.Where(x => x.Answer != null).Where(x => x.Answer.Contains(searchcontent)).ToList();
            var list_show2 = _db.Talks.Where(x => x.Answer != null).Where(x => x.Question.Contains(searchcontent)).ToList();
            for (int i = 0; i < words_in_search.Length; i++)
            {
                list_show1.AddRange(_db.Talks.Where(x => x.Answer != null).Where(x => x.Answer.Contains(words_in_search[i])));
                list_show1.AddRange(_db.Talks.Where(x => x.Answer != null).Where(x => x.Question.Contains(words_in_search[i])));
            }
            list_show1.AddRange(list_show2);
            list_show1=list_show1.Distinct().ToList();
            return View("ListQuestion", list_show1);
        }
        public IActionResult See(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var find_talk = _db.Talks.Find(id);
            if(find_talk == null)
            {
                return NotFound();
            }
            return View("ViewTalkPage",find_talk);

        }
        public IActionResult AddQuestion()
        {
            return View();
        }
        public IActionResult AddQuestionForm(Talk new_question)
        {
            if (new_question == null)
            {
                RedirectToAction("Index");
            }
            _db.Talks.Add(new_question);
            _db.SaveChanges();
            return RedirectToAction("StudentPage");
        }
    }
}
