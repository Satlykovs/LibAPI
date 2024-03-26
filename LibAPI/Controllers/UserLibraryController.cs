namespace LibAPI;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users/{userID}/library")]
public class UserLibraryController : ControllerBase
{
    private readonly ILibManager _libManager;

    public UserLibraryController(ILibManager libManager)
    {
        _libManager = libManager;
    }

    [HttpGet]
    public IActionResult GetAllUserBooks(int userID)
    {
        return Ok(_libManager.GetAllUserBooks(userID));
    }

    [HttpPost("{bookID}")]
    public void AddUserBook(int userID, int bookID)
    {
        _libManager.AddUserBook(userID, bookID);
    }

    [HttpDelete("{bookID}")]
    public void DeleteUserBook(int userID, int bookID)
    {
        _libManager.DeleteUserBook(userID, bookID);
    }
}