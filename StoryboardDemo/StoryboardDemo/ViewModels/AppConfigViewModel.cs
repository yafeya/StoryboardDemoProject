using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class AppConfigViewModel : BaseViewModel
    {
        private StickyMode mStickyMode = StickyMode.Favorite;
        private RescanMode mRescanMode = RescanMode.Checking;

        public StickyMode StickyMode
        {
            get { return mStickyMode; }
            set
            {
                if (mStickyMode != value)
                {
                    mStickyMode = value;
                    OnPropertyChanged("StickyMode");
                }
            }
        }
        public RescanMode RescanMode
        {
            get { return mRescanMode; }
            set
            {
                if (mRescanMode != value)
                {
                    mRescanMode = value;
                    OnPropertyChanged("RescanMode");
                }
            }
        }
    }

    public enum StickyMode
    {
        Favorite,
        Pin
    }

    public enum RescanMode
    {
        Checking,
        Refresh
    }
}
