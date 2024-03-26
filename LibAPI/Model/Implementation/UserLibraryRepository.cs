namespace LibAPI;

public class UserLibraryRepository : IUserLibraryRepository
{
    private readonly LibContext _context;
    public UserLibraryRepository(LibContext context)
    {
        _context = context;
    }

    public void AddUserBook(int userID, int bookID)
    {

        if (_context.UserBooks.FirstOrDefault(b => b.UserID == userID && b.BookID == bookID) == null)
        {   
            if (_context.Books.FirstOrDefault(b => b.ID == bookID) != null)
            {
                UserBook book = new UserBook(userID, bookID);
                _context.UserBooks.Add(book);
                _context.SaveChanges();
            }
        }   
    }

    public void DeleteUserBook(int userID, int bookID)
    {
        UserBook book = _context.UserBooks.FirstOrDefault(b => b.UserID == userID && b.BookID == bookID);
        if (book != null)
        {
            _context.UserBooks.Remove(book);
            _context.SaveChanges();
        }
    }
    
    public List<Book> GetAllUserBooks(int userID)
    {
        List<int> bookIDs = _context.UserBooks.Where(b => b.UserID == userID).Select(b => b.BookID).ToList();
        return _context.Books.Where(b=> bookIDs.Contains(b.ID)).ToList();
    }

}