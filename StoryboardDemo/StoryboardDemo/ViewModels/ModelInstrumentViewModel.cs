using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class ModelInstrumentViewModel : ModelElementViewModel
    {
        private bool mIsSelected = false;

        public ModelInstrumentViewModel(ModelInstrument model)
            : base(model)
        { }

        private ModelInstrument ModelInstrument
        {
            get { return mModel as ModelInstrument; }
        }

        public IEnumerable<string> GetParentIDs()
        {
            return ModelInstrument.SupportedInterfaceIDs;
        }

        public bool IsSelected
        {
            get { return mIsSelected; }
            set
            {
                if (mIsSelected != value)
                {
                    mIsSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
    }
}
