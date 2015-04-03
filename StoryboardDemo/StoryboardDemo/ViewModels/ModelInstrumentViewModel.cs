using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class ModelInstrumentViewModel : ModelElementViewModel
    {
        private ObservableCollection<AddressViewModel> mAddresses = new ObservableCollection<AddressViewModel>();

        public ModelInstrumentViewModel(ModelInstrument model)
            : base(model)
        {
            foreach (var address in model.Addresses)
            {
                var addressViewModel = new AddressViewModel(address);
                Addresses.Add(addressViewModel);
            }
        }

        private ModelInstrument ModelInstrument
        {
            get { return mModel as ModelInstrument; }
        }

        public ObservableCollection<AddressViewModel> Addresses
        {
            get { return mAddresses; }
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
