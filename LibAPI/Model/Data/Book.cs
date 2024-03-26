
namespace LibAPI;
public class Book : BookForAPI
{
    public string? CoverPath {get; set; }

    public Book(int id, string name, string author, string genre, int creatingYear,
     int publishingYear, string description, string coverPath) : 
     base(id, name, author, genre, creatingYear, publishingYear,description)
     {
        CoverPath = coverPath;
     }
    public Book(){}
}