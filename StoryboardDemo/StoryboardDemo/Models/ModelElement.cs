using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public abstract class ModelElement
    {
        private string mName = string.Empty;
        private string mPersistentID = Guid.NewGuid().ToString();
        private string mIcon = string.Empty;

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public string PersistentID
        {
            get { return mPersistentID; }
            set { mPersistentID = value; }
        }
        public string Icon
        {
            get { return mIcon; }
            set { mIcon = value; }
        }
    }
}
