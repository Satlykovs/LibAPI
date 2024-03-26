namespace LibAPI;
using System.Text.Json;
public class BookRepository :  IBookRepository
{
    private readonly LibContext _context;
    public BookRepository(LibContext context)
    {
        _context = context;
    }

    public void AddBook(Book book)
    {
        if (!_context.Books.Contains(book))
        {
            _context.Add(book);
            _context.SaveChanges();
        }
    }

    public void DeleteBook(int id)
    {
        Book book = _context.Books.FirstOrDefault(b => b.ID == id);
        string coverPath = book.CoverPath;
        File.Delete(coverPath);
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    public void UpdateBook(int id, Book bookToUpdate)
    {
        if (_context.Books.Contains(bookToUpdate))
        {   
            _context.Update(bookToUpdate);
            _context.SaveChanges();
            
        }
    }

    public List<FormDataModel> GetAllBooks()
    {
        List<FormDataModel> data = [];
        List<Book> books = _context.Books.ToList();
        foreach (var book in books)
        {
            using (FileStream fileStream = new FileStream(book.CoverPath, FileMode.Open))
            {
                FileInfo info = new FileInfo(book.CoverPath);
                IFormFile cover = new FormFile(fileStream, 0, info.Length, "cover", Path.GetFileName(book.CoverPath));
                BookForAPI bookForAPI = book;
                FormDataModel new_data = new FormDataModel {Cover = cover, DataBook = bookForAPI};
                data.Add(new_data);
            }

        }
        return data;
    }

    public Book GetBookById(int id)
    {
        return _context.Books.FirstOrDefault(b => b.ID == id);
    }

    public string SetCoverPath(IFormFile cover, int id)
    {   
        string path = "..\\Assets\\" + cover.FileName;
        string delete_path = _context.Books.FirstOrDefault(b => b.ID == id).CoverPath;
        if (File.Exists(delete_path))
        {
            File.Delete(delete_path);
        }
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            cover.CopyTo(fileStream);
        }

        return path;
    }


    public Book ConvertToBook(BookForAPI bfa)
    {
        Book book = JsonSerializer.Deserialize<Book>(JsonSerializer.Serialize<BookForAPI>(bfa));
        return book;
    }
    
}