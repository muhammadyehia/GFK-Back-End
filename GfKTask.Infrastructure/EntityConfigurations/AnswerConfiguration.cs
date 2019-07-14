using GfKTask.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GfKTask.Infrastructure.EntityConfigurations
{
    public class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            ToTable("Answers");
            HasKey(s => s.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Text)
                .IsRequired();
            Property(p => p.Number)
            .IsRequired();
            HasRequired(a => a.Question);
        }
    }
}
