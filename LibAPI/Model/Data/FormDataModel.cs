namespace LibAPI;

public class FormDataModel
{

    public IFormFile Cover { get; set; }
    public BookForAPI DataBook { get; set; }

    public FormDataModel(IFormFile cover, BookForAPI dataBook)
    {
        Cover = cover;
        DataBook = dataBook;
    }
    public FormDataModel(){}

}