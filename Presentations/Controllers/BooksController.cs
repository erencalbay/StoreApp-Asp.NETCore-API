using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentations.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentations.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))] //logfilter action
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]                                       //Fromquery ile query string alacağız exmp: /books?pageNumber=2&pageSize=10
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookParameters bookParameters)
        {

            var pagedResult = await _manager
                .BookService
                .GetAllBooksAsync(bookParameters, false);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
            
            var book = await _manager
                .BookService
                .GetOneBookByIdAsync(id, false);

            return Ok(book);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))] //action filter
        [HttpPost]  
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
            var book = await _manager.BookService.CreateOneBookAsync(bookDto);
            return StatusCode(201, book);
        }
        
        [ServiceFilter(typeof(ValidationFilterAttribute))] //action filter
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id,
            [FromBody] BookDtoForUpdate bookDto)
        {

            await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);
            return NoContent(); //204

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAllBooksAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.BookService.DeleteOneBookAsync(id, false);
            return NoContent();
        }
    }
}
