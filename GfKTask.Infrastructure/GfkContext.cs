using GfKTask.Core.Entities;
using GfKTask.Infrastructure.EntityConfigurations;
using System.Data.Entity;

namespace GfKTask.Infrastructure
{
    public class GfkContext : DbContext
    {
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public GfkContext() : base("name=GfkContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new AnswerConfiguration());
        }
    }
}
