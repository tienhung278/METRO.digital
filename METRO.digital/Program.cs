using METRO.digital.Configuration;
using METRO.digital.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureRepository();
builder.Services.ConfigureService();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.Run();