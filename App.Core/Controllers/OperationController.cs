using App.Core.Interfaces;
using App.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class OperationController : ControllerBase
{
    private readonly IOperationBusiness _opB;

    public OperationController(IOperationBusiness opB)
    {
        _opB = opB;
    }

    [HttpGet]
    [Route("GetHistory")]
    [AllowAnonymous]
    public async Task<IActionResult> GetHistory(long cardNumber, PagedParams pagedParams)
    {
        var result = (await _opB.GetHistoryAsync(cardNumber))
                                .OrderBy(d => d.Date)
                                .Skip((pagedParams.Page - 1) * pagedParams.ItemsPerPage)
                                .Take(pagedParams.ItemsPerPage);

        return Ok(result);
    }
}
