using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using StackOverflowClone.Models;
using Microsoft.Data.Entity;

namespace StackOverflowClone.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public QuestionController( UserManager<ApplicationUser> userManager, ApplicationDbContext db )
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            return View(_db.Questions.Where(x => x.User.Id == currentUser.Id));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Question question)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            question.User = currentUser;
            _db.Questions.Add(question);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisProject = _db.Questions.FirstOrDefault(q => q.QuestionId == id);
            return View(thisProject);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thisProject = await _db.Questions.FirstOrDefaultAsync(q => q.QuestionId == id);
            _db.Questions.Remove(thisProject);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var thisProject = _db.Questions.FirstOrDefault(q => q.QuestionId == id);
            return View(thisProject);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Question question)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            question.User = currentUser;
            _db.Entry(question).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
