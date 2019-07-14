using GfKTask.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GfKTask.Infrastructure.EntityConfigurations
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            ToTable("Question");
            HasKey(s => s.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Text)
                    .IsRequired();
            Property(p => p.Type)
                    .IsRequired();
            HasMany(e => e.Answers).WithRequired(e => e.Question).WillCascadeOnDelete(true);
        }
      
    }
}
