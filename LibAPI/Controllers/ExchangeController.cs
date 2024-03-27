namespace LibAPI;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/exchanges/")]
public class ExchangeController : ControllerBase
{
    private readonly ILibManager _libManager;

    public ExchangeController(ILibManager libManager)
    {
        _libManager = libManager;
    }

    [HttpPost("request")]
    public void ExchangeRequest([FromBody] ExchangeDataForm dataForm)
    {   
        dataForm.ConfirmStatus = false;
        _libManager.CreateRequest(dataForm);
    }

    [HttpPut("{exchangeID}/confirm")]
    public void Confirm(int exchangeID)
    {   
        ExchangeDataForm dataForm = _libManager.GetExchangeById(exchangeID);
        _libManager.AddUserBook(dataForm.ToUserID, dataForm.OldBookID);
        _libManager.DeleteUserBook(dataForm.ToUserID, dataForm.NewBookID);
        _libManager.AddUserBook(dataForm.FromUserID, dataForm.NewBookID);
        _libManager.DeleteUserBook(dataForm.FromUserID, dataForm.OldBookID);

        _libManager.Confirm(exchangeID);
    }

    [HttpGet("{userID}/requests")]
    public IActionResult GetUserRequests(int userID)
    {
        return Ok(_libManager.GetUserRequests(userID));
    }
}