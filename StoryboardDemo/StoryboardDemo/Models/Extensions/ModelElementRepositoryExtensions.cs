using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StoryboardDemo
{
    public static class ModelElementRepositoryExtensions
    {
        public static void AddElements(this IModelElementRepository repository, IEnumerable<ModelElement> elements)
        {
            if (repository == null)
            {
                throw new ArgumentNullException();
            }

            if (elements == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in elements)
            {
                if(element==null)
                {
                    throw new ArgumentNullException();
                }

                repository.AddElement(element);
            }
        }
        public static void FillData(this IModelElementRepository repository)
        {
            var basetype = typeof(IModelElementRepository);
            var localAssembly = basetype.Assembly;

            Action<Type> loadElementsAction = type =>
                {
                    if (typeof(IModelElementProvider).IsAssignableFrom(type)
                    && !type.IsAbstract
                    && !type.IsInterface)
                    {
                        var provider = Activator.CreateInstance(type) as IModelElementProvider;
                        var elements = provider.FindElements();
                        repository.AddElements(elements);
                    }
                };
            Action<Type> loadMultiParentsInstsAction = type =>
                {
                    if (typeof(IMultiParentsINSTProvider).IsAssignableFrom(type)
                      && !type.IsAbstract
                      && !type.IsInterface)
                    {
                        var provider = Activator.CreateInstance(type, repository) as IMultiParentsINSTProvider;
                        var elements = provider.GetInstruments();
                        repository.AddElements(elements);
                    }
                };
            localAssembly.SearchTypes(loadElementsAction);
            localAssembly.SearchTypes(loadMultiParentsInstsAction);

        }

        private static string GenerateInterfaceName(int intfIndex)
        {
            return GenerateName(KnownConsts.INTERFACE_BASENAME, intfIndex);
        }
        private static string GenerateInstrumentName(int instIndex)
        {
            return GenerateName(KnownConsts.INSTRUMENT_BASENAME, instIndex);
        }
        private static string GenerateName(string baseName, int nameIndex)
        {
            var builder = new StringBuilder();
            builder.Append(baseName).Append(nameIndex);
            var name = builder.ToString();
            return name;
        }
    }
}
