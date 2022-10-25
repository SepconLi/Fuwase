/* Project includes */
using Application.Authentication;
using Application.Authentication.Implementations;

using Application.Campaigns;
using Application.Campaigns.Implementations;

using Application.Donations;
using Application.Donations.Implementations;

using Application.Products;
using Application.Products.Implementations;

using Application.Orders;
using Application.Orders.Implementations;
using Application.Locations;
using Application.Locations.Implementations;
using Application.Users;
using Application.Users.Implementations;

using Application.Chats;
using Application.Chats.Implementations;

using Application.Notifications;
using Application.Notifications.Implementation;

using Application.Statistics;
using Application.Statistics.Implementations;

/* System includes */
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Application.Utilities;
using Application.Utilities.Implementations;


namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer
            (this IServiceCollection services) {
            /* Adding user services */
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IPersonalUserService, PersonalUserService>();
            services.AddTransient<IBusinessUserService, BusinessUserService>();
            services.AddTransient<IAdministratorService, AdministratorService>();
            services.AddTransient<IUserFoodPreferencesService, UserFoodPreferencesService>();
            /* Adding general services */
            services.AddTransient<ILocationService, LocationService>();
            /* Adding donation services */
            services.AddTransient<IDonationService, DonationService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderProductService, OrderProductService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<IAllergenService, AllergenService>();
            services.AddTransient<IFoodTypeService, FoodTypeService>();
            /* Adding order services */
            services.AddTransient<IOrderService, OrderService>();
            /* Adding campaign services */
            services.AddTransient<ICampaignService, CampaignService>();
            services.AddTransient<ICampaignProductService, CampaignProductService>();

            /* Adding chat services */
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IMessageService, MessageService>();
            /* Adding notification services */
            services.AddTransient<INotificationService, NotificationService>();
            /* Adding authentication services */
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IConfirmationCodeService, ConfirmationCodeService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<WebsiteAuthenticator>());
            services.AddScoped<WebsiteAuthenticator>();
            /* Adding statistics services */
            services.AddTransient<IStatisticService, StatisticService>();
            /* Adding utilities services*/
            services.AddTransient<IRedirectInformationService, RedirectInformationService>();
            return services;
        }
    }
}
