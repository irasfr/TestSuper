using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Application.Common
{
    internal class AssemblyMap : Profile
    {
        public AssemblyMap(Assembly assembly) => ApplyMappingsFromAssembly(assembly);
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(x => x.GetInterfaces().Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IMapWith<>))).ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] {this});
            }

        }
    }
}
