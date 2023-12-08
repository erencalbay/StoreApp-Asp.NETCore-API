using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Entities.Models;
using Repositories.EFCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _context;

        //Dependency injection, newlenmesi gerek.
        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _context.Books.ToList();
                return Ok(books);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var books = _context
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

                if (books is null)
                {
                    return NotFound(); //404
                }

                return Ok(books);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest(); // 400 

                _context.Books.Add(book);
                _context.SaveChanges();

                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] Book book)
        {

            try
            {
                var entity = _context
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

                if (entity is null)
                    return NotFound();

                if (id != book.Id)
                    return BadRequest();

                entity.Title = book.Title;
                entity.Price = book.Price;

                _context.SaveChanges();

                return Ok(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteAllBooks([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context
                    .Books
                    .Where (b => b.Id.Equals(id))
                    .SingleOrDefault();

                if (entity is null)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"Book with id:{id} could not found."
                    }); //404

                _context.Books.Remove(entity);
                _context.SaveChanges();
                return NoContent(); //204
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
