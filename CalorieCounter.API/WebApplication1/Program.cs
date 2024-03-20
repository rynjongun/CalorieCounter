using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// SServices added to container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        policyBuilder =>
        {
            policyBuilder.WithOrigins("http://localhost:5000") // Ajudst to align with blazor app
                        .AllowAnyHeader()
                        .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();
