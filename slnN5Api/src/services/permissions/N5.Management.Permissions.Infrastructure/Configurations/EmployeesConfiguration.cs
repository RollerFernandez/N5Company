namespace N5.Management.Permissions.Infrastructure.Configurations
{
    public class EmployeesConfiguration : EntityConfiguration<EmployeeEntity>
    {
        public EmployeesConfiguration(ModelBuilder builder)
        {
            var entityBuilder = builder.Entity<EmployeeEntity>();
            _ = entityBuilder.ToTable("Employees", "Admin");
            _ = entityBuilder.HasKey(c => c.Id);
            _ = entityBuilder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            _ = entityBuilder.Property(e => e.Name).HasColumnName("Name").IsRequired();
            _ = entityBuilder.Property(e => e.Email).HasColumnName("Email").IsRequired();
            //_ = entityBuilder.Property(e => e.Status).HasColumnName("ch_status").IsRequired();
            _ = entityBuilder.HasMany(e => e.Permissions)
                             .WithOne(p => p.Employee)
                             .HasForeignKey(p => p.EmployeeId);

            Configure(entityBuilder);
        }
    }
}
