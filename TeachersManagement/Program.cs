
using Microsoft.EntityFrameworkCore;
using TeachersManagement.Data;
using TeachersManagement.Models;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddScoped<ITeachersRepository, TeachersRepository>();
builder.Services.AddScoped<IPupilsRepository, PupilsRepository>();
builder.Services.AddDbContext<AppDbContext>(o=> o.UseSqlServer(connectionString));
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}"
    );

app.Run();
