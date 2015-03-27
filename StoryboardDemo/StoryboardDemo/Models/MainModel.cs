using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace StoryboardDemo
{
    public class MainModel
    {
        private IUnityContainer mContainer;

        public MainModel(IUnityContainer container)
        {
            mContainer = container;
        }

        private IModelElementRepository ModelElementRepository
        {
            get
            {
                return mContainer.Resolve<IModelElementRepository>();
            }
        }

        public IEnumerable<ModelElement> GetModelElements()
        {
            return ModelElementRepository.GetElements();
        }
    }
}
