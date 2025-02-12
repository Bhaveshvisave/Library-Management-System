using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.DataAccess;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowRecordsController : Controller
    {
        private readonly LibraryRepository _repository;
        public BorrowRecordsController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new LibraryRepository(connectionString);
        }
        public IActionResult Index()
        {
            var records = _repository.GetBorrowRecords();
            return View(records);
        }
        public IActionResult Create()
        {
            ViewBag.Books = _repository.GetBooks();
            ViewBag.Members = _repository.GetMembers();
            return View();
        }

        [HttpPost]
        public IActionResult Create(BorrowRecord record)
        {
            if (ModelState.IsValid)
            {
                _repository.AddBorrowRecord(record);
                TempData["SuccessMessage"] = "The Borrow Record was added successfully";
                return RedirectToAction("Index");
            }
            ViewBag.Books = _repository.GetBooks();
            ViewBag.Members = _repository.GetMembers();
            return View(record);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var record = _repository.GetBorrowRecords().FirstOrDefault(r => r.Id == id);
            if (record == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Books = _repository.GetBooks();
            ViewBag.Members = _repository.GetMembers();
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(BorrowRecord record)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateBorrowRecord(record);
                TempData["SuccessMessage"] = "The Borrow Record details were updated successfully";
                return RedirectToAction("Index");
            }
            ViewBag.Books = _repository.GetBooks();
            ViewBag.Members = _repository.GetMembers();
            return View(record);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteBorrowRecord(id);
            TempData["SuccessMessage"] = "The Borrow Record was deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
