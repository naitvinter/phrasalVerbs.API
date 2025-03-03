using PhrasalVerbs.API.Mapping;
using PhrasalVerbs.Application;

namespace PhrasalVerbs.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDatabase(builder.Configuration.GetConnectionString("Default"));
        builder.Services.AddApplication();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseMiddleware<ValidationMappingMiddleware>();
        app.MapControllers();

        app.Run();
    }
}
