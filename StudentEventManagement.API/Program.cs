using Microsoft.EntityFrameworkCore;
using StudentEventManagement.Application.Interfaces;
using StudentEventManagement.Infrastructure.Persistence;
using StudentEventManagement.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // use this if AddOpenApi() gives error
builder.Services.AddSwaggerGen();          // use this if AddOpenApi() gives error

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? Register services before building the app
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IEventService, EventService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();         // use this if MapOpenApi() gives error
    app.UseSwaggerUI();       // use this if MapOpenApi() gives error
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
