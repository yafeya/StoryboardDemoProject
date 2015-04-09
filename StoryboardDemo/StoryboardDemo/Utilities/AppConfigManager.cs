using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class AppConfigManager : BaseViewModel
    {
        private StickyMode mStickyMode = StickyMode.Favorite;
        private RescanMode mRescanMode = RescanMode.Checking;
        private EnumViewModel mInstrumentModeItems;
        private EnumItemViewModel mInstrumentMode;
        private static AppConfigManager mConfigManager = new AppConfigManager();

        private AppConfigManager()
        {
            var rescanMode = ConfigurationManager.AppSettings["rescan"];
            var stickyMode = ConfigurationManager.AppSettings["sticky"];

            switch (rescanMode)
            {
                case "checking": mRescanMode = RescanMode.Checking; break;
                case "refresh": mRescanMode = RescanMode.Refresh; break;
                default: mRescanMode = RescanMode.Refresh; break;
            }

            switch (stickyMode)
            {
                case "favorite": mStickyMode = StickyMode.Favorite; break;
                case "pin": mStickyMode = StickyMode.Pin; break;
                default: mStickyMode = StickyMode.Favorite; break;
            }

            var entireMode = new EnumItemViewModel<InstrumentViewMode> 
            { 
                Icon = KnownConsts.ENTIREMODE_ICON, 
                Item = InstrumentViewMode.Entire 
            };
            var condenseMode = new EnumItemViewModel<InstrumentViewMode>
            {
                Icon = KnownConsts.CONDENSEMODE_ICON,
                Item = InstrumentViewMode.Condense
            };
            InstrumentMode = entireMode;
            mInstrumentModeItems = new EnumViewModel(new[] { entireMode, condenseMode });
        }

        public StickyMode StickyMode
        {
            get { return mStickyMode; }
        }
        public RescanMode RescanMode
        {
            get { return mRescanMode; }
        }
        public EnumViewModel InstrumentModeItems
        {
            get { return mInstrumentModeItems; }
        }
        public EnumItemViewModel InstrumentMode
        {
            get { return mInstrumentMode; }
            set
            {
                if (mInstrumentMode!=value)
                {
                    mInstrumentMode = value;
                    OnPropertyChanged("InstrumentMode");
                }
            }
        }
        public static AppConfigManager ConfigManager
        {
            get { return mConfigManager; }
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
