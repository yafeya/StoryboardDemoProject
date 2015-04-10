using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class AddressStatusManager : IAddressStatusManager
    {
        private AddressStatusPolicy mCurrentPolicy;

        public AddressStatusManager(AddressStatusPolicy policy)
        {
            mCurrentPolicy = policy;
        }

        #region IAddressStatusManager Members

        public void RefreshStatus(IEnumerable<Address> addresses)
        {
            foreach (var address in addresses)
            {
                var status = mCurrentPolicy.GetStatus(address);
                address.Status = status;
            }
        }

        #endregion
    }
}
