using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class ModelInstrument : ModelElement
    {
        private IEnumerable<string> mSupportedInterfacesID;

        public ModelInstrument()
        {
            Icon = KnownConsts.INSTRUMENT_ICON;
        }

        public IEnumerable<string> SupportedInterfacesID 
        {
            get { return mSupportedInterfacesID; }
            set { mSupportedInterfacesID = value; }
        }
    }
}
