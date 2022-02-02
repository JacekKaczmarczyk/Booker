using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Booker.Models;
using Booker.Repositories;

namespace Booker.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksRepository bookRepository;

        public BookController(IBooksRepository booksRepository)
        {
            bookRepository = booksRepository;
        }
        // GET: BookController
        public ActionResult Index()
        {
            return View(bookRepository.GetBooks());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View(bookRepository.GetBookByID(id));
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View(new Books());
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Books bookModel)
        {
            bookRepository.InsertBook(bookModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(bookRepository.GetBookByID(id));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Books bookModel)
        {
           bookRepository.UpdateBook(id, bookModel);
           return RedirectToAction(nameof(Index));
           
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bookRepository.GetBookByID(id));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Books bookModel)
        {
            bookRepository.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
