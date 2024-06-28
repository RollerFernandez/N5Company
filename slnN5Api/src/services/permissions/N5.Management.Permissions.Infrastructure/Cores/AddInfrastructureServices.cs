namespace N5.Management.Permissions.Infrastructure.Cores
{
    public static class AddInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {

            _ = services.AddDbContext<DataContext>(opts =>
            {
                _ = opts.UseSqlServer(configuration.GetSection("AppSettings:DatabaseConfiguration:SqlServer:ConnectionStrings:DefaultConnection").Value);
            });

            _ = services.AddScoped<IUnitOfWork<DataContext>, UnitOfWork<DataContext>>();
            _ = services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<,>));

            return services;
        }
    }
}
