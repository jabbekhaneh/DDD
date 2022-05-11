using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portal.Application.Users.Commands.AddUser;
using Portal.Application.Users.Commands.EditUser;
using Portal.Application.Users.Contracts;
using Portal.Application.Users.Queries.GetUserById;
using Portal.EF.Users.Repositories;
using System.Reflection;

namespace Portal.EF.Configurations;

public static class Initializer
{
    public static IServiceCollection ConfigServices(this IServiceCollection services,string connection)
    {
        //---------------------
        services.AddMemoryCache();
        //---------------------
        services.AddDbContext<EFdbApplication>(options =>
        {
            options.UseSqlServer(connection,
                 serverDbContextOptionsBuilder =>
                 {
                     var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                     serverDbContextOptionsBuilder.CommandTimeout(minutes);
                     serverDbContextOptionsBuilder.EnableRetryOnFailure();
                 });
        });
        //---------------------
        services.AddTransient<UserRepository, EFUserRepository>();
        //---------------------
        services.AddMediatR(typeof(AddUserCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(EditUserCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(GetUserByIdQuery).GetTypeInfo().Assembly);
        //---------------------

        return services;
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {

    }
}
