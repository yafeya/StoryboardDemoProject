using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class ModelInstrument : ModelElement
    {
        private List<string> mParentIDList = new List<string>();

        public ModelInstrument()
        {
            Icon = KnownConsts.INSTRUMENT_ICON;
        }

        public IEnumerable<string> SupportedInterfaceIDs
        {
            get { return mParentIDList; }
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
