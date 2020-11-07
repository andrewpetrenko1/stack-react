using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stack_react_business.Domains.Interfaces;
using stack_react_business.ViewModels;

namespace stack_react_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QuestionController : ControllerBase
  {
    private IQuestionDomain _questionDomain;

    public QuestionController(IQuestionDomain questionDomain)
    {
      _questionDomain = questionDomain;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(_questionDomain.GetQuestions());
    }

    [HttpGet("{id}")]
    public IActionResult GetQuestion(int id)
    {
      var question = _questionDomain.GetQuestion(id);
      if (question != null)
        return Ok(question);

      return BadRequest();
    }

    [HttpPost]
    public IActionResult Add(QuestionViewModel questionView)
    {
      questionView.Id = _questionDomain.AddQuestion(questionView);
      if (questionView.Id > 0)
        return Ok(questionView);

      return BadRequest();
    }

    [HttpPut]
    public IActionResult EditQuestion(QuestionViewModel questionView)
    {
      if (_questionDomain.EditQuestion(questionView))
        return Ok(questionView);

      return BadRequest();
    }
  }
}
