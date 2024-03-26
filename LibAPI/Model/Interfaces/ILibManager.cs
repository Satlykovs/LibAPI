namespace LibAPI;

public interface ILibManager
{
    public List<FormDataModel> GetAllBooks();
    public Book GetBookById(int id);
    public void AddBook(Book book);
    public void DeleteBook(int id);
    public void UpdateBook(int id, Book bookToUpdate);
    public string SetCoverPath(IFormFile cover);
    public Book ConvertToBook(BookForAPI bfa);
    public void AddUserBook(int userID, int bookID);
    public void DeleteUserBook(int userID, int bookID);
    public List<Book> GetAllUserBooks(int userID);

}