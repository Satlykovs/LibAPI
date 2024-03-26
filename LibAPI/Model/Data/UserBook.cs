namespace LibAPI;

public class UserBook
{
    public int UserID { get; set; }
    public int BookID { get; set; }

    public UserBook(int userID, int bookID)
    {
        UserID = userID;
        BookID = bookID;
    }
}