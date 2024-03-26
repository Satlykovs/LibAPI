namespace LibAPI;

public interface IBookRepository
{
    public List<FormDataModel> GetAllBooks();
    public Book GetBookById(int id);
    public void AddBook(Book book);
    public void DeleteBook(int id);
    public void UpdateBook(int id, Book bookToUpdate);
    public string SetCoverPath(IFormFile cover);
    public Book ConvertToBook(BookForAPI bfa);
}