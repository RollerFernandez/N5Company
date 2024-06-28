namespace N5.Management.Infrastructure.Configurations.Base
{
    public interface IEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
    }
}
