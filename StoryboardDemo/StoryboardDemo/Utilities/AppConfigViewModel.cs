using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class AppConfigManager
    {
        private StickyMode mStickyMode = StickyMode.Favorite;
        private RescanMode mRescanMode = RescanMode.Checking;
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
        }

        public StickyMode StickyMode
        {
            get { return mStickyMode; }
        }
        public RescanMode RescanMode
        {
            get { return mRescanMode; }
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
