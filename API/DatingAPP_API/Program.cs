using DatingAPP_API.ExceptionMiddleWare;
using DatingAPP_API.Extensions;
var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
//// Add services to the container.
//builder.Services.AddDbContext<DataContext>(options =>
//{
//    options.UseSqlServer(connectionString);
//});
//builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddApplicaionService(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddIdentityService(builder.Configuration);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandler>();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
