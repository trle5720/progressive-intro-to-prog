using Banking.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Api.Controllers;

public class AccountController(IProvideBonusesForBankAccountDeposits bonusCalculator) : ControllerBase
{

    [HttpGet("/account")]
    public ActionResult  GetAccount()
    {
        var amount = bonusCalculator.CalculateBonusFor(10000, 1000);
        return Ok("Did it: " + amount);
    }
}
