using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class ModelInstrument : ModelElement
    {
        private bool mIsNeedRescanning = false;
        private bool mIsPinned = false;
        private List<string> mParentIDList = new List<string>();
        private IEnumerable<Address> mAddresses = new Address[] { };

        public ModelInstrument()
        {
            Icon = KnownConsts.INSTRUMENT_ICON;
        }

        public bool IsNeedRescanning
        {
            get { return mIsNeedRescanning; }
            set { mIsNeedRescanning = value; }
        }
        public bool IsPinned
        {
            get { return mIsPinned; }
            set { mIsPinned = value; }
        }
        public IEnumerable<string> SupportedInterfaceIDs
        {
            get { return mParentIDList; }
        }
        public IEnumerable<Address> Addresses
        {
            get { return mAddresses; }
            set { mAddresses = value; }
        }

        public void AddParentID(string parentID)
        {
            if (!mParentIDList.Contains(parentID))
            {
                mParentIDList.Add(parentID);
            }
        }
    }
}
