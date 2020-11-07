using Microsoft.EntityFrameworkCore;
using stack_react_data.Entities;

namespace stack_react_data
{
  public interface IStackDbContext
  {
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    public int SaveChanges();
  }
}
