using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class ModelElementRepository : IModelElementRepository
    {
        private ConcurrentDictionary<string, ModelElement> mModelElementsDictionary = new ConcurrentDictionary<string, ModelElement>();

        #region IModelElementRepository Members

        public void AddElement(ModelElement modelElement)
        {
            mModelElementsDictionary.AddOrUpdate(modelElement.PersistentID, modelElement, (k, v) => v);
        }

        public void RemoveElement(ModelElement modelElement)
        {
            ModelElement deletedElement;
            mModelElementsDictionary.TryRemove(modelElement.PersistentID, out deletedElement);
        }

        public bool IsCotainsElement(ModelElement element)
        {
            return mModelElementsDictionary.ContainsKey(element.PersistentID);
        }

        public IEnumerable<ModelElement> GetElements()
        {
            return mModelElementsDictionary.Where(p => true).Select(p => p.Value);
        }

        #endregion
    }
}
