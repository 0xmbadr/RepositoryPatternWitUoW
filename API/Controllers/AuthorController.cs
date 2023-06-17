using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IBaseRepository<Author> _AuthorRepo;

        public AuthorController(IBaseRepository<Author> authorRepo)
        {
            _AuthorRepo = authorRepo;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_AuthorRepo.GetById(1));
        }
    }
}
