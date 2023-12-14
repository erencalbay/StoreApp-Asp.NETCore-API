using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Presentation
{
    
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {

            var books = _manager.BookService.GetAllBooks(false);
            return Ok(books);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            
            var book = _manager
                .BookService
                .GetOneBookById(id, false);

            return Ok(book);
        }

        [HttpPost]  
        public IActionResult CreateOneBook([FromBody] BookDtoForInsertion bookDto)
        {
            if (bookDto is null)
                return BadRequest(); // 400 

            //validation değerlerinin düzgün gösterilmesi için gerekli. valid control
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState); //422

            var book = _manager.BookService.CreateOneBook(bookDto);

            return StatusCode(201, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] BookDtoForUpdate bookDto)
        {
            if (bookDto is null)
                return BadRequest(); // 400 

            //validation değerlerinin düzgün gösterilmesi için gerekli. valid control
            //422 ile döner valid değilse
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); //422

            _manager.BookService.UpdateOneBook(id, bookDto, false);

            return NoContent(); //204

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteAllBooks([FromRoute(Name = "id")] int id)
        {


            _manager.BookService.DeleteOneBook(id, false);
            return NoContent();


        }
    }
}
