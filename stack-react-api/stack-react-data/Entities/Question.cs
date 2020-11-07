using System;
using System.Collections.Generic;

namespace stack_react_data.Entities
{
  public class Question
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string QuestionText { get; set; }
    public DateTime Date { get; set; }
    public string Author { get; set; }
    public int Views { get; set; }
    public List<Answer> Answers { get; set; }

    public Question()
    {
      Answers = new List<Answer>();
    }
  }
}
