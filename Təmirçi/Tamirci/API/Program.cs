using Microsoft.AspNetCore.Identity;
using ServicesRegisterPlugin.Extensions;
using Tamirci.Entities;
using Tamirci.Presentation;
using Tamirci.Repositories;
using Tamirci.Repositories.Registrations;
using Tamirci.Services;
using Tamirci.Services.Contracts;
using Tamirci.Services.Registrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddApplicationPart(typeof(AssemblyReferance).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataProtection();

builder.Services.AddServices(builder.Configuration);

builder.Services.AddIdentityCore<Craftsman>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false; 
    opt.Password.RequiredLength = 2;            
    opt.Password.RequireLowercase = false;       
    opt.Password.RequireUppercase = false;       
    opt.Password.RequireDigit = false;           

    opt.SignIn.RequireConfirmedEmail = false;    
})
.AddRoles<IdentityRole>()                         
.AddEntityFrameworkStores<AppDbContext>()        
.AddDefaultTokenProviders();

builder.Services.RegisterServices(configure =>
{
    configure.AssemblyPrefix = "Tamirci";
});
builder.Services.AddRepository(builder.Configuration);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
