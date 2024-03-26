
namespace LibAPI;
public class BookForAPI
{
    
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
    public int? CreatingYear { get; set; }
    public int? PublishingYear { get; set; }
    public string? Description { get; set; }

    public BookForAPI(int id, string name, string author, string genre, int creatingYear, int publishingYear, string description)
    {
        ID = id;
        Name = name;
        Author = author;
        Genre = genre;
        CreatingYear = creatingYear;
        PublishingYear = publishingYear;
        Description = description;
    }
    public BookForAPI(){}
}