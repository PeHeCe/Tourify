
using api.Config;
using Microsoft.EntityFrameworkCore;

namespace api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddCors(options =>
		{
			options.AddPolicy("AllowAllOrigins",
				builder =>
				{
					builder.AllowAnyOrigin()  // Permite qualquer origem
						   .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc.)
						   .AllowAnyHeader(); // Permite qualquer cabeçalho
				});
		});

		builder.Services.AddDbContext<AppDBContext>();

        builder.Services.AddControllers();
        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

		app.UseCors("AllowAllOrigins");

		app.MapControllers();

        app.Run();
    }
}
