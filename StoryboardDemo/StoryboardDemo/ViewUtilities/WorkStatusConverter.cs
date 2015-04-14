using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace StoryboardDemo
{
    public class WorkStatusConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string iconPath = null;
            var status = (WorkStatus)value;
            switch (status)
            {
                case WorkStatus.Good: iconPath = KnownConsts.GOOD_STATUS_ICON; break;
                case WorkStatus.Broken: iconPath = KnownConsts.BROKEN_STATUS_ICON; break;
                case WorkStatus.Question: iconPath = KnownConsts.QUESTION_STATUS_ICON; break;
                case WorkStatus.Refreshing: iconPath = KnownConsts.REFRESHING_STATUS_ICON; break;
                default: iconPath = KnownConsts.BROKEN_STATUS_ICON; break;
            }
            return iconPath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
