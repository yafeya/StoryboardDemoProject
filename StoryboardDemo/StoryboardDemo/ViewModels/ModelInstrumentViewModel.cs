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
            get { return ModelInstrument.IsNeedRescanning; }
            set
            {
                if (ModelInstrument.IsNeedRescanning != value)
                {
                    ModelInstrument.IsNeedRescanning = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
        public bool IsPinned
        {
            get { return ModelInstrument.IsPinned; }
            set
            {
                if (ModelInstrument.IsPinned != value)
                {
                    ModelInstrument.IsPinned = value;
                    OnPropertyChanged("IsPinned");
                }
            }
        }
    }
}
