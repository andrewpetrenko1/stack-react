using stack_react_business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace stack_react_business.Domains.Interfaces
{
  public interface IQuestionDomain
  {
    public IEnumerable<QuestionViewModel> GetQuestions();
    QuestionViewModel GetQuestion(int id);
    int AddQuestion(QuestionViewModel questionView);
    bool EditQuestion(QuestionViewModel questionView);
  }
}
