namespace LibAPI;

public class LibManager : ILibManager
{
    private IBookRepository _bookRepository;
    private IUserLibraryRepository _userLibraryRepository;

    public LibManager(IBookRepository bookRepository, IUserLibraryRepository userLibraryRepository)
    {
        _bookRepository = bookRepository;
        _userLibraryRepository = userLibraryRepository;
    }

    public void AddBook(Book book)
    {
        _bookRepository.AddBook(book);
    }

    public void DeleteBook(int id)
    {
        _bookRepository.DeleteBook(id);
    }

    public void UpdateBook(int id, Book book)
    {
        _bookRepository.UpdateBook(id, book);
    }

    public List<FormDataModel> GetAllBooks()
    {
       return _bookRepository.GetAllBooks();
    }

    public Book GetBookById(int id)
    {
        return _bookRepository.GetBookById(id);
    }
    public string SetCoverPath(IFormFile cover)
    {
        return _bookRepository.SetCoverPath(cover);
    }

    public Book ConvertToBook(BookForAPI bfa)
    {
        return _bookRepository.ConvertToBook(bfa);
    }

    public void AddUserBook(int userID, int bookID)
    {
        _userLibraryRepository.AddUserBook(userID, bookID);
    }
    public void DeleteUserBook(int userID, int bookID)
    {
        _userLibraryRepository.DeleteUserBook(userID, bookID);
    }
    public List<Book> GetAllUserBooks(int userID)
    {
        return _userLibraryRepository.GetAllUserBooks(userID);
    }
}