namespace LibAPI;

public interface IExchangeRepository
{
    public List<ExchangeDataForm> GetUserRequests(int userID);
    public void Confirm(int exchangeID);
    public void CreateRequest(ExchangeDataForm dataForm);
    public ExchangeDataForm GetExchangeById(int exchangeID);
}