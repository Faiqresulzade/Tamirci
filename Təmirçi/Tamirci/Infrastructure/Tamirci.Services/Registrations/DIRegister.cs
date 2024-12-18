using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tamirci.Services.Filters.CraftsmanFilters;
using Tamirci.Shared.Models;
using FluentValidation;
using Tamirci.Application;
using System.Globalization;
using Tamirci.Application.Validations;
using FluentValidation.AspNetCore;

namespace Tamirci.Services.Registrations;

public static class DIRegister
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews(options => options.Filters.Add(typeof(CraftsmanExistFilter)));

        services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
        services.AddFluentValidationAutoValidation();
        services.AddHttpContextAccessor();


        services.Configure<TokenSetting>(configuration.GetSection("JWt"));
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("az");
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });
    }
}
