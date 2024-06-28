namespace N5.Management.Permissions.Infrastructure.Configurations
{
    public class PermissionTypesConfiguration : EntityConfiguration<PermissionTypeEntity>
    {
        public PermissionTypesConfiguration(ModelBuilder builder)
        {
            var entityBuilder = builder.Entity<PermissionTypeEntity>();
            _ = entityBuilder.ToTable("PermissionTypes", "Admin");
            _ = entityBuilder.HasKey(c => c.Id);
            _ = entityBuilder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            _ = entityBuilder.Property(e => e.Name).HasColumnName("Name").IsRequired();
            _ = entityBuilder.Property(e => e.Description).HasColumnName("Description").IsRequired();
            //_ = entityBuilder.Property(e => e.Status).HasColumnName("Status").IsRequired();
            _ = entityBuilder.HasMany(pt => pt.Permissions)
                             .WithOne(p => p.PermissionType)
                             .HasForeignKey(p => p.PermissionTypeId);

            Configure(entityBuilder);
        }
    }
}
