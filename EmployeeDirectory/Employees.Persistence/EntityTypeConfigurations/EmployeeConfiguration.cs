using Employees.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Employees.Persistence.EntityTypeConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.Id);
            builder.HasIndex(employee => employee.Id).IsUnique();
            builder.Property(employee => employee.Name).HasMaxLength(250);
            builder.Property(employee => employee.PhoneNumber).HasMaxLength(20);
            builder.Property(employee => employee.Photo).HasMaxLength(500);
            builder.HasOne(employee => employee.Department)
                   .WithMany(departments => departments.Employees)
                   .HasForeignKey(employee => employee.DepartmentId);
        }
    }
}
