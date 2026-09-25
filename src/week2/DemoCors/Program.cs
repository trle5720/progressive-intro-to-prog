var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader();
        p.AllowAnyMethod();
        p.WithOrigins("http://localhost:4200");
    });
});
// Add services to the container.

var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.a

app.MapGet("/status", () =>
{
    return new StatusResponse("Looks Good!", DateTimeOffset.UtcNow);
});



app.Run();
public record StatusResponse(string Message, DateTimeOffset CheckedAt);
