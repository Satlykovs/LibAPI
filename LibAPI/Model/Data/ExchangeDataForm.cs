namespace LibAPI;

public class ExchangeDataForm
{
    public int ExchangeID { get; set; }
    public int FromUserID { get; set; }
    public int ToUserID { get; set; }
    public int OldBookID { get; set; }
    public int NewBookID { get; set;}
    public bool ConfirmStatus { get; set; }

}