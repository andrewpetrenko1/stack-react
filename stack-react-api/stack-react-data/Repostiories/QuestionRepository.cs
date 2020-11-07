using Microsoft.EntityFrameworkCore;
using stack_react_data.Entities;
using stack_react_data.Repostiories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace stack_react_data.Repostiories
{
  public class QuestionRepository : IQuestionRepository
  {
    private readonly IStackDbContext _context;

    public QuestionRepository(IStackDbContext dbContext) 
    {
      _context = dbContext;
    }

    public IEnumerable<Question> GetAllQuestions()
    {
      return _context.Questions.Include(q => q.Answers).ToList();
    }

    public Question GetQuestion(int id)
    {
      var quest = IncViews(id);
      _context.Answers.Where(a => a.QuestionId == quest.Id).Load();
      return quest;
    }

    private Question Get(int id)
      => _context.Questions.Find(id);

    private Question IncViews(int id)
    {
      var oldQuest = _context.Questions.Find(id);
      oldQuest.Views = oldQuest.Views + 1;
      _context.SaveChanges();
      return oldQuest;
    }


    public int AddQuestion(Question question)
    {
      _context.Questions.Add(question);
      _context.SaveChanges();
      return question.Id;
    }

    public bool EditQuestion(Question question)
    {
      var oldQuest = _context.Questions.Find(question.Id);
      oldQuest.Title = question.Title; 
      oldQuest.QuestionText = question.QuestionText; 
      return _context.SaveChanges() > 0;
    }
  }
}
