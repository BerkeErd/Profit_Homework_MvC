using Microsoft.AspNetCore.Identity.UI.Services;
using Profit_Homework_MvC.Config;
using Profit_Homework_MvC.Customs;

namespace Profit_Homework_MvC.Services
{
    public static class EmailSenderService
    {
           public static IServiceCollection AddEmailSender(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            var emailConfig = configuration.GetSection("EmailSender").Get<EmailConfig>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, CustomEmailSender>();
            return services;
        }
    }
}
