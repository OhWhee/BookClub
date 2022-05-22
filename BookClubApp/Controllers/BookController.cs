
using BookClub.Memory;
using BookClub.Memory.Repositories;
using BookClub.Memory.Repositories.internals;
using BookClub.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookUsersRepository _bookUsersRepository;
        private readonly IUserRepository _userRepository;
        public BookController(IBookRepository bookRepository, IBookUsersRepository bookUsersRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _bookUsersRepository = bookUsersRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.GetAllAsync().Result;
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View(books);
        }

        public IActionResult AddToUser(int bookid)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            var user = _userRepository.GetUserByName(HttpContext.Session.GetString("username")).Result;
            var book = _bookRepository.GetBookById(bookid).Result;
            _bookUsersRepository.AddAndSaveAsync(
                new BookUsers() { BookId = book.BookId, UserId = user.UserId, User = user, Book = book });

            return RedirectToAction("Index");
        }

        public IActionResult DeleteFromUser(int bookid)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            var user = _userRepository.GetUserByName(HttpContext.Session.GetString("username")).Result;
            var book = _bookRepository.GetBookById(bookid).Result;
            _bookUsersRepository.Delete(user.UserId, book.BookId);
            return RedirectToAction("MyBooks");
        }

        public IActionResult MyBooks()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            var user = _userRepository.GetUserByName(HttpContext.Session.GetString("username")).Result;
            var books = _bookUsersRepository.GetBooksByUserId(user.UserId).Result;
            return View(books);
        }
    }
}
