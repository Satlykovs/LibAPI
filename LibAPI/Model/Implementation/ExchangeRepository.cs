namespace LibAPI;

public class ExchangeRepository : IExchangeRepository
{
    private LibContext _context;

    public ExchangeRepository(LibContext context)
    {
        _context = context;
    }

    public List<ExchangeDataForm> GetUserRequests(int userID)
    {
        return _context.ExchangeForms.Where(e => e.ToUserID == userID).ToList();
    }

    public ExchangeDataForm GetExchangeById(int exchangeID)
    {
        return _context.ExchangeForms.FirstOrDefault(e => e.ExchangeID == exchangeID);
    }

    public void Confirm(int exchangeID)
    {
        ExchangeDataForm dataForm = _context.ExchangeForms.FirstOrDefault(e => e.ExchangeID == exchangeID);
        if (dataForm != null)
        {
            dataForm.ConfirmStatus = true;
        }
        _context.SaveChanges();
    }

    public void CreateRequest(ExchangeDataForm dataForm)
    {
        _context.ExchangeForms.Add(dataForm);
        _context.SaveChanges();
    }
}