namespace N5.Management.Permissions.Application.Cores
{
    public static class AddApplicationServices
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            IServiceCollection serviceCollection = services.AddAutoMapper(Assembly.GetExecutingAssembly());

            _ = services.Configure<AppSettings>(opt => configuration.GetSection(AppSettings.Name).Bind(opt));
            //_ = services.Configure<List<ParameterDto>>(opt => configuration.GetSection(ParameterDto.Key).Bind(opt));

            _ = services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            _ = services.AddInfrastructureService(configuration);

            return services;
        }
    }
}
