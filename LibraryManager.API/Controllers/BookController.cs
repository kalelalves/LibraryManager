using LibraryManager.Application.DTOs;
using LibraryManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDTO>> GetById(int id)
    {
        var book = await _bookService.GetByIdAsync(id);
        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetByCategory(int categoryId)
    {
        var books = await _bookService.GetByCategoryAsync(categoryId);
        return Ok(books);
    }

    [HttpGet("available")]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetAvailable()
    {
        var books = await _bookService.GetAvailableAsync();
        return Ok(books);
    }

    [HttpPost]
    public async Task<ActionResult<BookDTO>> Create(CreateBookDTO bookDto)
    {
        var createdBook = await _bookService.CreateAsync(bookDto);
        return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateBookDTO bookDto)
    {
        if (id != bookDto.Id)
            return BadRequest();

        await _bookService.UpdateAsync(bookDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _bookService.DeleteAsync(id);
        return NoContent();
    }
} 