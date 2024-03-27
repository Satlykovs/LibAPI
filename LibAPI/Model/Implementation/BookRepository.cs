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
        Book book = _context.Books.FirstOrDefault(b => b.ID == id);
        if  (book != null)
        {   
            book.Name = bookToUpdate.Name;
            book.Author = bookToUpdate.Author;
            book.Genre = bookToUpdate.Genre;
            book.CreatingYear = bookToUpdate.CreatingYear;
            book.PublishingYear = bookToUpdate.PublishingYear;
            book.Description = bookToUpdate.Description;

            _context.SaveChanges(); 
        }
    }

    public List<BookForAPI> GetAllBooks()
    {
        List<Book> books = _context.Books.ToList();
        return books.Cast<BookForAPI>().ToList();

        
    }

    public BookForAPI GetBookById(int id)
    {
        Book book = _context.Books.FirstOrDefault(b => b.ID == id);
        BookForAPI bookForAPI = new BookForAPI
        {
            ID = book.ID,
            Name = book.Name,
            Author = book.Author,
            Genre = book.Genre,
            CreatingYear = book.CreatingYear,
            PublishingYear = book.PublishingYear,
            Description = book.Description
        };
        return bookForAPI;
    }

    public string SetCoverPath(IFormFile cover, int id)
    {   
        Book book = _context.Books.FirstOrDefault(b => b.ID == id);
        if (book != null)
        {
            string oldPath = book.CoverPath;
            File.Delete(oldPath);
        }
        string path = "Assets\\" + cover.FileName;
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

    public void AddReview(string reviewText, int bookID)
    {
        Review review = new Review
        {
            ReviewText = reviewText,
            BookID = bookID
        };
        _context.Reviews.Add(review);
        _context.SaveChanges();
    }
    
    public List<string> GetReviews(int bookID)
    {
        return _context.Reviews.Where(r => r.BookID == bookID).Select(r => r.ReviewText).ToList(); 
    }
}