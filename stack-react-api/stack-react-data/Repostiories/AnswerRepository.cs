using stack_react_data.Entities;
using stack_react_data.Repostiories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stack_react_data.Repostiories
{
  public class AnswerRepository : IAnswerRepository
  {
    private readonly IStackDbContext _context;

    public AnswerRepository(IStackDbContext stackDb)
    {
      _context = stackDb;
    }

    public IEnumerable<Answer> GetQuestionAnswers(int questId)
      => _context.Answers.Where(a => a.QuestionId == questId);

    public int AddAnswer(Answer answer)
    {
      _context.Answers.Add(answer);
      _context.SaveChanges();
      return answer.Id;
    }
  }
}
