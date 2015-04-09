using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public abstract class EnumItemViewModel : BaseViewModel
    {
        private string mText = string.Empty;
        private string mIcon = string.Empty;

        public string Text
        {
            get { return mText; }
            set
            {
                if (mText != value)
                {
                    mText = value;
                    OnPropertyChanged("Text");
                }
            }
        }
        public string Icon
        {
            get { return mIcon; }
            set
            {
                if (mIcon != value)
                {
                    mIcon = value;
                    OnPropertyChanged("Icon");
                }
            }
        }

        public abstract object GetItem();
    }

    public class EnumItemViewModel<TEnum> : EnumItemViewModel where TEnum : struct
    {
        private TEnum mItem = default(TEnum);

        public TEnum Item
        {
            get { return mItem; }
            set
            {
                mItem = value;
                OnPropertyChanged("EnumItem");
            }
        }

        public override object GetItem()
        {
            return Item;
        }
    }

    public class EnumViewModel
    {
        private ObservableCollection<EnumItemViewModel> mItems = new ObservableCollection<EnumItemViewModel>();

        public EnumViewModel(IEnumerable<EnumItemViewModel> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        public ObservableCollection<EnumItemViewModel> Items
        {
            get { return mItems; }
        }
    }
}
