using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public interface IModelElementProvider
    {
        IEnumerable<ModelElement> FindElements();
    }
}
