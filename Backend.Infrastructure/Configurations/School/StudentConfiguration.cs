using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities.School;

namespace Backend.Infrastructure.Configurations.School
{
    public class StudentConfiguration : BaseModelConfig, IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            TableName = "students";
            builder.ToTable(TableName);

            builder.Property(p => p.StudentId)

                .IsRequired(true);

            builder.Property(t => t.Name)
                .HasMaxLength((Int32)EnumColumnLength.VARCHAR_STANDARDENTRIES_DESCRIPTION)
                .IsRequired(true);

            builder.Property(t => t.Address)
                .HasMaxLength((Int32)EnumColumnLength.VARCHAR_STANDARDENTRIES_DESCRIPTION)
                .IsRequired(false);
        }
    }
}
