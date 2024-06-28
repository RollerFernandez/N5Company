namespace N5.Management.Permissions.Application.Cores
{
    public class ApplicationAutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            _ = builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Registrar MediatR
            _ = builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            // Registrar todos los MediatR handlers
            _ = builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();

            _ = builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>))
                .AsImplementedInterfaces();

            _ = builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();
        }
    }
}
