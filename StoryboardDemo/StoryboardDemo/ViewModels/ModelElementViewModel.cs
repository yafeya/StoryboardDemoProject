using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class ModelElementViewModel : ModelViewModel<ModelElement>
    {
        public ModelElementViewModel(ModelElement model)
            : base(model)
        { }

        public string Name
        {
            get { return mModel.Name; }
        }

        public string PersistentID
        {
            get { return mModel.PersistentID; }
        }

        public string Icon
        {
            get { return mModel.Icon; }
        }
    }
}
