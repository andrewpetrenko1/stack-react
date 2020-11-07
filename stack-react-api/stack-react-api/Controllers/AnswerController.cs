using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stack_react_business.Domains.Interfaces;
using stack_react_business.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace stack_react_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnswerController : ControllerBase
  {
    private readonly IAnswerDomain _answerDomain;

    public AnswerController(IAnswerDomain answerDomain)
    {
      _answerDomain = answerDomain;
    }

    [HttpPost]
    public IActionResult Post(AnswerViewModel answerView)
    {
      answerView.Id = _answerDomain.AddAnswer(answerView);
      if (answerView.Id > 0)
        return Ok(answerView);

      return BadRequest();
    }
  }
}
