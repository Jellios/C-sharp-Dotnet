using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using WebAPI.Controllers;
using WebAPI.Models; // Add this line

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<QuoteContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21)),
        mysqlOptions => mysqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null)));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        corsBuilder => // Change this line
        {
            corsBuilder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
     

});

// Add Swagger generator
builder.Services.AddSwaggerGen();

// Register QuoteRepository
builder.Services.AddScoped<QuoteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAllOrigins");

app.MapControllers();

// Add a basic quote to the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<QuoteContext>();
    var quote = new Quote
    {
        Author = "Basic Author",
        Content = "Basic Content",
        QuoteDate = DateTime.Now
    };
    context.Quotes.Add(quote);
    context.SaveChanges();
}

app.Run();