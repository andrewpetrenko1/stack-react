using stack_react_data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace stack_react_business.ViewModels
{
  public class QuestionViewModel
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "QuestionText is required")]
    public string QuestionText { get; set; }
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Author is required")]
    public string Author { get; set; }
    public int Views { get; set; }
    public List<AnswerViewModel> Answers { get; set; }

    public QuestionViewModel()
    {
      Answers = new List<AnswerViewModel>();
    }
  }
}
