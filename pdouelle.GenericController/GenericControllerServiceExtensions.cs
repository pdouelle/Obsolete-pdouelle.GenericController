using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using pdouelle.GenericMediatR.Handlers.Generics.Commands.Create;

namespace pdouelle.GenericController
{
    public static class GenericControllerServiceExtensions
    {
        public static IServiceCollection AddGenericControllers(this IServiceCollection services,
            params Assembly[] assemblies)
        {
            services.AddMediatR(typeof(CreateCommandHandler<,>).Assembly);
            
            IncludedGenericControllerEntities.Assemblies = assemblies;

            services.AddMvc().ConfigureApplicationPartManager(p =>
                p.FeatureProviders.Add(new GenericControllerFeatureProvider()));

            return services;
        }
    }
}