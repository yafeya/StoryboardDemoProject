using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public abstract class AddressStatusPolicy
    {
        public abstract WorkStatus GetStatus(Address address);
    }
}
