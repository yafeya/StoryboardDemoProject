using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class Address
    {
        private string mAddress = string.Empty;
        private WorkStatus mStatus = WorkStatus.Good;

        public Address() { }
        public Address(string address)
        {
            mAddress = address;
        }

        public string AddressValue
        {
            get { return mAddress; }
            set { mAddress = value; }
        }
        public WorkStatus Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
    }
}
