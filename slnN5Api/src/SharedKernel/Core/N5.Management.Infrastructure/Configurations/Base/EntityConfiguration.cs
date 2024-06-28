
namespace N5.Management.Infrastructure.Configurations.Base
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            _ = builder.Property("Id").HasColumnName("Id");
            _ = builder.Property("Status").HasColumnName("Status");
        }
    }
}
