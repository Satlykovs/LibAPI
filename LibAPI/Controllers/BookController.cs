namespace LibAPI;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/books/")]
public class BookController : ControllerBase
{
    
    private readonly ILibManager _libManager;

    public BookController(ILibManager libManager)
    {
        _libManager = libManager;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        return Ok(_libManager.GetAllBooks());

    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        return Ok(_libManager.GetBookById(id));
    }

    [HttpPost]
    public void AddBook([FromForm]FormDataModel data)
    {
        string path = _libManager.SetCoverPath(data.Cover, data.DataBook.ID);
        Book book = _libManager.ConvertToBook(data.DataBook);
        book.CoverPath = path;
        _libManager.AddBook(book);
        
    }

    [HttpPut("{id}")]
    public void UpdateBook(int id, FormDataModel data)
    {
        Book bookToUpdate = _libManager.ConvertToBook(data.DataBook);

        bookToUpdate.CoverPath = _libManager.SetCoverPath(data.Cover, data.DataBook.ID);
        bookToUpdate.ID = id;
        _libManager.UpdateBook(id, bookToUpdate);
    }

    [HttpDelete("{id}")]
    public void DeleteBook(int id)
    {
        _libManager.DeleteBook(id);
    }    
}