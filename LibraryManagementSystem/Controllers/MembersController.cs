using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.DataAccess;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class MembersController : Controller
    {
        private readonly LibraryRepository _repository;
        public MembersController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new LibraryRepository(connectionString);
        }
        public IActionResult Index()
        {
            var members = _repository.GetMembers();
            return View(members);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                _repository.AddMember(member);
                TempData["SuccessMessage"] = "The Member was added successfully";
                return RedirectToAction("Index");
            }
            return View(member);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var member = _repository.GetMembers().FirstOrDefault(m => m.Id == id);
            if (member == null)
            {
                return RedirectToAction("Index");
            }
            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateMember(member);
                TempData["SuccessMessage"] = "The Member Details were updated successfully";
                return RedirectToAction("Index");
            }
            return View(member);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteMember(id);
            TempData["SuccessMessage"] = "The Member was deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
