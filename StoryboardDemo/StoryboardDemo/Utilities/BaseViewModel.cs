using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;

namespace StoryboardDemo
{
    public class BaseViewModel : NotificationObject
    {
        protected void OnPropertyChanged(string propertyName)
        {
            RaisePropertyChanged(propertyName);
        }
    }

    public class ModelViewModel<T> : BaseViewModel where T : class
    {
        protected T mModel;

        public ModelViewModel(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }
            mModel = model;
        }
    }
}
