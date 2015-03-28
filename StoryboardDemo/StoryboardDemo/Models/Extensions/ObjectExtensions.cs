using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StoryboardDemo
{
    public static class ObjectExtensions
    {
        public static void SearchTypes(this Assembly assembly, Action<Type> action)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException();
            }

            if (action == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<Type> types = TryGetTypes(assembly);

            foreach (var type in types)
            {
                action(type);
            }
        }

        private static IEnumerable<Type> TryGetTypes(Assembly assembly)
        {
            IEnumerable<Type> types = Enumerable.Empty<Type>();

            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types;
            }

            return types;
        }
    }
}
