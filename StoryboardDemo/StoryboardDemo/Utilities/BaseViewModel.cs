using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;

namespace StoryboardDemo
{
    public class ModelViewModel<T> : NotificationObject where T : class
    {
        protected T mModel;

        public ModelViewModel(T model)
        {
            mModel = model;
        }
    }
}
