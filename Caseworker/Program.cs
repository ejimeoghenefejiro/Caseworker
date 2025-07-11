using Caseworker.Configurations;
using Caseworker.Extentsions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApplicationCorsOptions>(
    builder.Configuration.GetSection("CorsOptions")
);

builder.Services.AddApplicationCorsPolicy(builder.Configuration);
builder.Services.AddSqlServerDatabase(builder.Configuration.GetConnectionString("SqlServerConnection"));
builder.Services.AddRepositories();
builder.Services.AddJwtAuthentication( builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseRouting();

var corsOptions = app.Services.GetRequiredService<IOptions<ApplicationCorsOptions>>();
app.UseCors(corsOptions.Value.PolicyName);

app.UseAuthentication();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
