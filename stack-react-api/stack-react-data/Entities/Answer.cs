using System;

namespace stack_react_data.Entities
{
  public class Answer
  {
    public int Id { get; set; }
    public Question Question { get; set; }
    public int QuestionId { get; set; }
    public string AnswerText { get; set; }
    public DateTime Date { get; set; }
  }
}
