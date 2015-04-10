using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public interface IAddressStatusManager
    {
        void RefreshStatus(IEnumerable<Address> addresses);
    }
}
