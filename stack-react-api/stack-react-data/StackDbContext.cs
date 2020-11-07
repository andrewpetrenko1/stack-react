using Microsoft.EntityFrameworkCore;
using stack_react_data.Entities;
using System;
using System.Collections.Generic;

namespace stack_react_data
{
  public class StackDbContext : DbContext, IStackDbContext
  {
    public StackDbContext(DbContextOptions contextOptions) : base(contextOptions)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      var question = builder.Entity<Question>();

      question
        .Property(q => q.Title)
        .IsRequired()
        .HasMaxLength(100);

      question
        .Property(q => q.QuestionText)
        .IsRequired();

      question
        .Property(q => q.Author)
        .IsRequired();

      question
        .Property(q => q.Date)
        .IsRequired();

      question
        .HasData(new[]
        {
          new Question
          {
            Id = 1, Answers = new List<Answer>(), Date = DateTime.Now, Author = "Author 1",
            QuestionText = "Question text", Title = "Question title", Views = 0
          }
        });

      var answer = builder.Entity<Answer>();

      answer
        .HasOne(a => a.Question)
        .WithMany(q => q.Answers)
        .HasForeignKey(a => a.QuestionId);

      answer
        .Property(a => a.AnswerText)
        .IsRequired();
    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
  }
}
