using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public static class ModelElementRepositoryExtensions
    {
        public static void AddElements(this IModelElementRepository repository, params ModelElement[] elements)
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
            for (int i = 0; i < 5; i++)
            {
 
            }
        }
    }
}
