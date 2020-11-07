using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace stack_react_business.ViewModels
{
  public class AnswerViewModel
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "QuestionId is required")]
    public int QuestionId { get; set; }
    [Required(ErrorMessage = "AnswerText is required")]
    public string AnswerText { get; set; }
    public DateTime Date { get; set; }
  }
}
