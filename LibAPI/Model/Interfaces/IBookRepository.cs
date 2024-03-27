namespace LibAPI;

public interface IBookRepository
{
    public List<BookForAPI> GetAllBooks();
    public BookForAPI GetBookById(int id);
    public void AddBook(Book book);
    public void DeleteBook(int id);
    public void UpdateBook(int id, Book bookToUpdate);
    public string SetCoverPath(IFormFile cover, int id);
    public Book ConvertToBook(BookForAPI bfa);
    public void AddReview(string reviewText, int bookID);
    public List<string> GetReviews(int bookID);
}