﻿using Application.ApiCommandHandlers.Doctors.Handlers.Add;
using Application.ApiCommandHandlers.Doctors.Handlers.Delete;
using Application.ApiCommandHandlers.Doctors.Handlers.Update;
using Application.ApiCommandHandlers.Doctors.Queries.GetAll;
using Application.ApiCommandHandlers.Doctors.Queries.GetById;
using Application.ApiCommandHandlers.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;


namespace Application;

public static class ApplicationModule
{
    public static void AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatr();
        services.InjectCommandHandlers();
        services.InjectServices();
        services.AddModules(configuration);
    }

    private static void AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(ApplicationModule).Assembly);
        });

        var validators = AssemblyScanner.FindValidatorsInAssembly(typeof(ApplicationModule).Assembly);

        foreach (var validator in validators)
        {
            services.AddScoped(validator.InterfaceType, validator.ValidatorType);
        }

        // Add the custom pipeline validation to DI
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandValidator<,>));
    }

    private static void InjectServices(this IServiceCollection services)
    {
    }

    private static void AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceModule(configuration);
    }


    private static void InjectCommandHandlers(this IServiceCollection services)
    {
        services.AddTransient<GetAllDoctorsQueryHandler>();
        services.AddTransient<GetDoctorByIdQueryHandler>();
        services.AddTransient<AddDoctorCommandHandler>();
        services.AddTransient<UpdateDoctorCommandHandler>();
        services.AddTransient<DeleteDoctorCommandHandler>();
    }
}