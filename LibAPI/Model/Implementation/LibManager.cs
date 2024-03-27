namespace LibAPI;

public class LibManager : ILibManager
{
    private IBookRepository _bookRepository;
    private IUserLibraryRepository _userLibraryRepository;
    private IExchangeRepository _exchangeRepository;

    public LibManager(IBookRepository bookRepository, IUserLibraryRepository userLibraryRepository,
     IExchangeRepository exchangeRepository)
    {
        _bookRepository = bookRepository;
        _userLibraryRepository = userLibraryRepository;
        _exchangeRepository = exchangeRepository;
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

    public List<BookForAPI> GetAllBooks()
    {
       return _bookRepository.GetAllBooks();
    }

    public BookForAPI GetBookById(int id)
    {
        return _bookRepository.GetBookById(id);
    }
    public string SetCoverPath(IFormFile cover, int id)
    {
        return _bookRepository.SetCoverPath(cover, id);
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
    public List<BookForAPI> GetAllUserBooks(int userID)
    {
        return _userLibraryRepository.GetAllUserBooks(userID);
    }

    public List<ExchangeDataForm> GetUserRequests(int userID)
    {
        return _exchangeRepository.GetUserRequests(userID);
    }
    public void Confirm(int exchangeID)
    {
        _exchangeRepository.Confirm(exchangeID);
    }

    public void CreateRequest(ExchangeDataForm dataForm)
    {
        _exchangeRepository.CreateRequest(dataForm);
    }
    public ExchangeDataForm GetExchangeById(int exchangeID)
    {
       return _exchangeRepository.GetExchangeById(exchangeID);
    }

    public void AddReview(string reviewText, int bookID)
    {
        _bookRepository.AddReview(reviewText, bookID);
    }

    public List<string> GetReviews(int bookID)
    {
        return _bookRepository.GetReviews(bookID);
    }
}