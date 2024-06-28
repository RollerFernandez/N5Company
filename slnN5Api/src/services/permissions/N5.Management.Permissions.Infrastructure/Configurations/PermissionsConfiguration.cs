namespace N5.Management.Permissions.Infrastructure.Configurations
{
    public class PermissionsConfiguration : EntityConfiguration<PermissionEntity>
    {
        public PermissionsConfiguration(ModelBuilder builder)
        {
            var entityBuilder = builder.Entity<PermissionEntity>();
            _ = entityBuilder.ToTable("Permissions", "Admin");
            _ = entityBuilder.HasKey(c => c.Id);
            _ = entityBuilder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            _ = entityBuilder.Property(e => e.PermissionTypeId).HasColumnName("PermissionTypeId").IsRequired();
            _ = entityBuilder.Property(e => e.EmployeeId).HasColumnName("EmployeeId").IsRequired();
            _ = entityBuilder.Property(e => e.StartDate).HasColumnName("StartDate").IsRequired();
            _ = entityBuilder.Property(e => e.EndDate).HasColumnName("EndDate");
            _ = entityBuilder.Property(e => e.Reason).HasColumnName("Reason").IsRequired();
            //_ = entityBuilder.Property(e => e.Status).HasColumnName("ch_status").IsRequired();
            _ = entityBuilder.HasOne(p => p.Employee)
                             .WithMany(e => e.Permissions)
                             .HasForeignKey(p => p.EmployeeId);
            _ = entityBuilder.HasOne(p => p.PermissionType)
                             .WithMany(pt => pt.Permissions)
                             .HasForeignKey(p => p.PermissionTypeId);

            Configure(entityBuilder);
        }
    }
}
