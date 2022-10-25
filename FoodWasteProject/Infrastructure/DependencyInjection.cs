/* Project includes */
using Domain.Core.Repositories;
using Domain.Campaigns.Repositories;
using Domain.Donations.Repositories;
using Domain.Locations.Repositories;
using Domain.Messages.Repositories;
using Domain.Products.Repositories;
using Domain.Orders.Repositories;
using Domain.Users.Repositories;
using Domain.Statistics.Repositories;
using Infrastructure.Chats;
using Infrastructure.Chats.Repositories;
using Infrastructure.Donations;
using Infrastructure.Donations.Repositories;
using Infrastructure.Campaigns;
using Infrastructure.Campaigns.Repositories;
using Infrastructure.Locations;
using Infrastructure.Locations.Repositories;
using Infrastructure.Products;
using Infrastructure.Products.Repositories;
using Infrastructure.Orders;
using Infrastructure.Orders.Repositories;
using Infrastructure.Users;
using Infrastructure.Users.Repositories;
using Infrastructure.Statistics;
using Infrastructure.Statistics.Repositories;

/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Infrastructure.Notifications;
using Domain.Notifications.Repositories;
using Infrastructure.Notifications.Repositories;
using Infrastructure.Utilities;
using Domain.Utilities.Repositories;
using Infrastructure.Utilities.Repositories;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        // Adding DBContexts and Repositories
        public static IServiceCollection AddInfrastructureLayer(
            this IServiceCollection services, string connectionString) {
            services.AddDbContext<UsersDbContext>
                (options => options.UseSqlServer(connectionString), 
                ServiceLifetime.Transient);
            services.AddDbContext<DonationDbContext>
                (options => options.UseSqlServer(connectionString),
                ServiceLifetime.Transient);
            services.AddDbContext<CampaignDbContext>
                (options => options.UseSqlServer(connectionString),
                ServiceLifetime.Transient);
            services.AddDbContext<LocationDBContext>
                (options => options.UseSqlServer(connectionString),
                ServiceLifetime.Transient);
            services.AddDbContext<ProductDbContext>
                (options => options.UseSqlServer(connectionString),
                ServiceLifetime.Transient);
            services.AddDbContext<OrderDbContext>
                (options => options.UseSqlServer(connectionString),
                ServiceLifetime.Transient);
            services.AddDbContext<MessageDbContext>
                (options => options.UseSqlServer(connectionString),
                ServiceLifetime.Transient);
            services.AddDbContext<StatisticDbContext>
                (options => options.UseSqlServer(connectionString),
                ServiceLifetime.Transient);
            services.AddDbContext<UtilitiesDbContext>
                (options => options.UseSqlServer(connectionString),
                ServiceLifetime.Transient);
            services.AddDbContext<UtilitiesDbContext>
                (options => options.UseSqlServer(connectionString),
                ServiceLifetime.Transient);
            services.AddDbContext<NotificationDbContext>
                (options => options.UseSqlServer(connectionString),
               ServiceLifetime.Transient);
            services.AddDbContext<UtilitiesDbContext>
                (options => options.UseSqlServer(connectionString),
                ServiceLifetime.Transient);


            // Donation services
            services.AddTransient<IDonationRepository, DonationRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<IAllergenRepository, AllergenRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IFoodTypeRepository, FoodTypeRepository>();
            services.AddScoped<IStatisticRepository, StatisticRepository>();

            // Campaign Services
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<ICampaignProductRepository, CampaignProductRepository>();

            // Chat services
            services.AddScoped<IMessageRepository, MessageRepository>();

            //Notification services
            services.AddScoped<INotificationRepository, NotificationRepository>();

            // Login
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IConfirmationCodeRepository,
                ConfirmationCodeRepository>();
            services.AddTransient<IPersonalUserRepository, PersonalUserRepository>();
            services.AddTransient<IBusinessUserRepository, BusinessUserRepository>();
            services.AddTransient<IAdministratorRepository, AdministratorRepository>();

            // Utilities
            services.AddTransient<IRedirectInformationRepository, RedirectInformationRepository>();

            // Filters Services
            services.AddScoped<IUserFoodPreferencesRepository, UserFoodPreferencesRepository>();
            return services;
        }
    }
}
