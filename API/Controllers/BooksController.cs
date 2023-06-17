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
        private readonly IBaseRepository<Book> _BookRepo;

        public BooksController(IBaseRepository<Book> bookRepo)
        {
            _BookRepo = bookRepo;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_BookRepo.GetById(1));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _BookRepo.GetByIdAsync(1));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_BookRepo.GetAll());
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _BookRepo.GetAllAsync());
        }

        [HttpGet("GetByName")]
        public IActionResult GetOneByName()
        {
            return Ok(_BookRepo.Find(b => b.Title == "The Days"));
        }

        [HttpGet("GetByNameWithAuthor")]
        public IActionResult GetOneByNameWithAuthor()
        {
            return Ok(_BookRepo.Find(b => b.Title == "The Days", new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_BookRepo.FindAll(b => b.Title.Contains("ing"), new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthorsPaginated")]
        public IActionResult GetAllWithAuthorsPaginated()
        {
            return Ok(_BookRepo.FindAll(b => b.Title.Contains("ing"), 1, 1));
        }

        [HttpGet("GetAllOrdered")]
        public IActionResult GetALlOrdered()
        {
            return Ok(
                _BookRepo.FindAll(
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
            return Ok(_BookRepo.Add(new Book { Title = "The Stranger", AuthorId = 1 }));
        }

        [HttpGet("AddMany")]
        public IActionResult AddMany()
        {
            return Ok(
                _BookRepo.AddRange(
                    new List<Book>()
                    {
                        new Book { Title = "The Curlew’s Prayer", AuthorId = 2 },
                        new Book { Title = "Tree of Misery", AuthorId = 2 },
                        new Book { Title = "A Man of Letters", AuthorId = 2 },
                        new Book { Title = "Sufferers: Stories and Polemics", AuthorId = 2 },
                    }
                )
            );
        }
    }
}
