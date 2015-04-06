using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class ModelInstrumentViewModel : ModelElementViewModel
    {
        private AddressViewModel mPrimaryAddress;
        private ObservableCollection<AddressViewModel> mRestAddresses = new ObservableCollection<AddressViewModel>();
        private ObservableCollection<AddressViewModel> mAddresses = new ObservableCollection<AddressViewModel>();
        private bool mIsAddressExpandable = false;

        public ModelInstrumentViewModel(ModelInstrument model)
            : base(model)
        {
            var primaryAddress = model.Addresses.FirstOrDefault();
            if (primaryAddress != null)
            {
                mPrimaryAddress = new AddressViewModel(primaryAddress);
                Addresses.Add(PrimaryAddress);

                var restAddresses = model.Addresses.Except(new[] { primaryAddress });
                foreach (var address in restAddresses)
                {
                    var addressViewModel = new AddressViewModel(address);
                    RestAddresses.Add(addressViewModel);
                    Addresses.Add(addressViewModel);
                }

                IsAddressExpandable = RestAddresses.Count > 0;
            }
        }

        private ModelInstrument ModelInstrument
        {
            get { return mModel as ModelInstrument; }
        }
        public IEnumerable<string> GetParentIDs()
        {
            return ModelInstrument.SupportedInterfaceIDs;
        }
        public AddressViewModel PrimaryAddress
        {
            get { return mPrimaryAddress; }
            set
            {
                mPrimaryAddress = value;
                OnPropertyChanged("PrimaryAddress");
            }
        }
        public ObservableCollection<AddressViewModel> RestAddresses
        {
            get { return mRestAddresses; }
        }
        public ObservableCollection<AddressViewModel> Addresses
        {
            get { return mAddresses; }
        }
        public bool IsAddressExpandable
        {
            get { return mIsAddressExpandable; }
            set
            {
                if (mIsAddressExpandable != value)
                {
                    mIsAddressExpandable = value;
                    OnPropertyChanged("AddressExpandable");
                }
            }
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
