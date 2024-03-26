namespace LibAPI;

public interface IUserLibraryRepository
{
    public void AddUserBook(int userID, int bookID);
    public void DeleteUserBook(int userID, int bookID);
    public List<Book> GetAllUserBooks(int userID);

}