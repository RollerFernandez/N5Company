using Autofac;
using Autofac.Extensions.DependencyInjection;
using N5.Management.Commons;
using N5.Management.Commons.Middleware;
using N5.Management.Permissions.Application.Cores;
using N5.Management.Permissions.Infrastructure.Cores;
using N5.Management.SharedKernel.Infrastructure.Elasticsearch.Implementations;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Serilog;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("N5.Management.IntegrationTests")]
var builder = WebApplication.CreateBuilder(args);

// Configurar Elasticsearch
builder.Services.Configure<ElasticsearchOptions>(builder.Configuration.GetSection("Elasticsearch"));
builder.Services.AddSingleton<ElasticsearchService>();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAplicationServices(builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        _ = options.RegisterModule(new InfrastructureAutoFacModule());
        _ = options.RegisterModule(new ApplicationAutoFacModule());
    });

// Configure Kafka
var kafkaBootstrapServers = builder.Configuration["KafkaConfig:BootstrapServers"];
if (string.IsNullOrEmpty(kafkaBootstrapServers))
{
    throw new InvalidOperationException("Kafka BootstrapServers configuration is missing in appsettings.json");
}

builder.Services.AddSingleton<KafkaProducerService>(sp =>
    new KafkaProducerService(kafkaBootstrapServers, Constants.Core.Topic.PERMISSIONS));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ResponseMiddleware>();

app.MapControllers();

app.Run();
public partial class Program { }