global using MediatR;
global using Autofac;
global using AutoMapper;
global using FluentValidation.AspNetCore;

global using System.Linq.Expressions;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;
global using N5.Management.Permissions.Application.Dtos.Permissions;

global using N5.Management.Permissions.Domain.Models;

global using N5.Management.Permissions.Application.Queries.Definitions;
global using N5.Management.Permissions.Application.Interfaces;
global using N5.Management.Commons.Configurations;

global using N5.Management.Commons;
global using N5.Management.Commons.Exceptions;
global using N5.Management.Infrastructure.Repository.Interfaces.Data;
global using N5.Management.Permissions.Infrastructure.Repository.Implementations.Data;
global using N5.Management.Permissions.Infrastructure.Repository.Interfaces;
global using N5.Management.Permissions.Infrastructure.Cores;
