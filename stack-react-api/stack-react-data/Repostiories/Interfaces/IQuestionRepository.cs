using stack_react_data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace stack_react_data.Repostiories.Interfaces
{
  public interface IQuestionRepository
  {
    IEnumerable<Question> GetAllQuestions();
    int AddQuestion(Question question);
    Question GetQuestion(int id);
    bool EditQuestion(Question question);
  }
}
