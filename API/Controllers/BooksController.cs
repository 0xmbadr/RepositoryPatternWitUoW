using Core.Consts;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public BooksController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_uow.Books.GetById(1));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _uow.Books.GetByIdAsync(1));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_uow.Books.GetAll());
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _uow.Books.GetAllAsync());
        }

        [HttpGet("GetByName")]
        public IActionResult GetOneByName()
        {
            return Ok(_uow.Books.Find(b => b.Title == "The Days"));
        }

        [HttpGet("GetByNameWithAuthor")]
        public IActionResult GetOneByNameWithAuthor()
        {
            return Ok(_uow.Books.Find(b => b.Title == "The Days", new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_uow.Books.FindAll(b => b.Title.Contains("ing"), new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthorsPaginated")]
        public IActionResult GetAllWithAuthorsPaginated()
        {
            return Ok(_uow.Books.FindAll(b => b.Title.Contains("ing"), 1, 1));
        }

        [HttpGet("GetAllOrdered")]
        public IActionResult GetALlOrdered()
        {
            return Ok(
                _uow.Books.FindAll(
                    b => b.Title.Contains("ing"),
                    null,
                    null,
                    b => b.Id,
                    OrderBy.Descending
                )
            );
        }

        // -------------------------------------
        [HttpGet("AddOne")]
        public IActionResult AddOne()
        {
            var book = _uow.Books.Add(new Book { Title = "The Stranger", AuthorId = 1 });
            _uow.Complete();

            return Ok(book);
        }

        [HttpGet("AddMany")]
        public IActionResult AddMany()
        {
            var books = _uow.Books.AddRange(
                new List<Book>()
                {
                    new Book { Title = "The Curlew’s Prayer", AuthorId = 2 },
                    new Book { Title = "Tree of Misery", AuthorId = 2 },
                    new Book { Title = "A Man of Letters", AuthorId = 2 },
                    new Book { Title = "Sufferers: Stories and Polemics", AuthorId = 2 },
                }
            );

            _uow.Complete();

            return Ok(books);
        }
    }
}
