namespace LibAPI;

public interface ILibManager
{
    public List<BookForAPI> GetAllBooks();
    public BookForAPI GetBookById(int id);
    public void AddBook(Book book);
    public void DeleteBook(int id);
    public void UpdateBook(int id, Book bookToUpdate);
    public string SetCoverPath(IFormFile cover, int id);
    public Book ConvertToBook(BookForAPI bfa);
    public void AddUserBook(int userID, int bookID);
    public void DeleteUserBook(int userID, int bookID);
    public List<BookForAPI> GetAllUserBooks(int userID);
    public List<ExchangeDataForm> GetUserRequests(int userID);
    public void Confirm(int exchangeID);
    public void CreateRequest(ExchangeDataForm dataForm);
    public ExchangeDataForm GetExchangeById(int exchangeID);
    public void AddReview(string reviewText, int bookID);
    public List<string> GetReviews(int bookID);

}