using Microsoft.Extensions.DependencyInjection;
using Paramore.Darker.AspNetCore;
using SlankaToys.Application.UseCases.GetProducts;
using Paramore.Brighter;
using Paramore.Brighter.Extensions.DependencyInjection;
using SlankaToys.Application.UseCases.AddOrder;

namespace SlankaToys.API.Config
{
    public static class ParamoreExtensionMethods
    {

        public static void AddParamoreDarker(this IServiceCollection services)
        {
            services.AddDarker( options =>
            {
                options.QueryProcessorLifetime = ServiceLifetime.Scoped;
            }).AddHandlersFromAssemblies(typeof(GetProductsQueryHandler).Assembly);
        }

        public static void RegisterParamoreBrighterCommands(this IServiceCollection services)
        {
            var subscriberRegistry = new SubscriberRegistry();
            subscriberRegistry.RegisterAsync<AddToCartCommand, AddToCartCommandHandler>();

            services.AddBrighter(options =>
            {
                options.PolicyRegistry = new DefaultPolicy();
                options.CommandProcessorLifetime = ServiceLifetime.Scoped;
            }).AsyncHandlersFromAssemblies(typeof(AddToCartCommandHandler).Assembly);
        }
    }
}
