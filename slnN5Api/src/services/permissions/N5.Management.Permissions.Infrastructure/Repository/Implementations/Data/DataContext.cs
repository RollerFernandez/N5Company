namespace N5.Management.Permissions.Infrastructure.Repository.Implementations.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PermissionEntity> PermissionEntity { get; set; }
        public DbSet<PermissionTypeEntity> PermissionTypeEntity { get; set; }
        public DbSet<EmployeeEntity> EmployeeEntity { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            _ = builder.ApplyConfiguration(new EmployeesConfiguration(builder));
            _ = builder.ApplyConfiguration(new PermissionTypesConfiguration(builder));
            _ = builder.ApplyConfiguration(new PermissionsConfiguration(builder));
        }
    }
}
