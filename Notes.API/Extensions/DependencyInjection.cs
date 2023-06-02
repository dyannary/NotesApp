using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Notes.AddNote;
using Notes.Persistence.Context;

namespace Notes.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<NotesDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        //add scoped life time for all classes and interfaces from Infrastructure module
        services.Scan(
            selector => selector
                .FromAssemblies(Persistence.AssemblyReference.Assembly)
                .AddClasses(false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(AddNoteCommand));
        services.AddAutoMapper(typeof(AddNoteCommand));

        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        return services;
    }
}