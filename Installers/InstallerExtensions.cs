using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }

        public static void Unflatten<TSource, TDestination, TMember>(this IMemberConfigurationExpression<TSource, TDestination, TMember> config, bool usePrefix)
        {
            config.MapFrom((source, destination, member, resolutionContext) =>
            {
                string prefix = usePrefix ? typeof(TMember).Name : "";

                TMember resolvedObject = (TMember)Activator.CreateInstance(typeof(TMember));

                PropertyInfo[] targetProperties = resolvedObject.GetType().GetProperties();

                foreach (var sourceMember in source.GetType().GetProperties())
                {
                    // find the matching target property and populate it
                    PropertyInfo matchedProperty = targetProperties.FirstOrDefault(p => sourceMember.Name == prefix + p.Name);

                    matchedProperty?.SetValue(resolvedObject, sourceMember.GetValue(source));
                }

                return resolvedObject;
            });
        }
    }
}
