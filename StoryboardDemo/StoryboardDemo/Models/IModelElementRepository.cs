using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public interface IModelElementRepository
    {
        void AddElement(ModelElement modelElement);
        void RemoveElement(ModelElement modelElement);
        bool IsCotainsElement(ModelElement element);
        IEnumerable<ModelElement> GetElements();
    }
}
