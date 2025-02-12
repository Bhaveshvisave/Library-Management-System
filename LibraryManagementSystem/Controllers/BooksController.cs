using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.DataAccess;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryRepository _repository;

        public BooksController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new LibraryRepository(connectionString);
        }
        public IActionResult Index()
        {
            var books = _repository.GetBooks();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.AddBook(book);
                TempData["SuccessMessage"] = "The Book was added successfully";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _repository.GetBooks().FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateBook(book);
                TempData["SuccessMessage"] = "The Book details were updated successfully";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteBook(id);
            TempData["SuccessMessage"] = "The Book was deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
