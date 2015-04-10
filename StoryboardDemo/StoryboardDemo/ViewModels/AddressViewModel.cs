using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class AddressViewModel : ModelViewModel<Address>
    {
        private string mIcon;

        public AddressViewModel(Address address)
            : base(address)
        {
            Icon = address.Status == WorkStatus.Good ? KnownConsts.GOOD_STATUS_ICON : KnownConsts.BROKEN_STATUS_ICON;
        }

        public string Address
        {
            get { return mModel.AddressValue; }
            set 
            {
                if (mModel.AddressValue != value)
                {
                    mModel.AddressValue = value;
                    OnPropertyChanged("Address");
                }
            }
        }
        public WorkStatus Status
        {
            get { return mModel.Status; }
            set 
            {
                if (mModel.Status != value)
                {
                    mModel.Status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        public string Icon
        {
            get { return mIcon; }
            set
            {
                if (mIcon != value)
                {
                    mIcon = value;
                    OnPropertyChanged("Icon");
                }
            }
        }

        public Address GetAddressModel()
        {
            return mModel;
        }
    }
}
