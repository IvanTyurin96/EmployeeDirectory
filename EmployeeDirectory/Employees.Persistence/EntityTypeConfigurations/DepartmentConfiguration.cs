using Employees.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Persistence.EntityTypeConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(department => department.Id);
            builder.HasIndex(department => department.Id).IsUnique();
            builder.Property(employee => employee.Name).HasMaxLength(250);
        }
    }
}
