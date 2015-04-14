using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;

namespace StoryboardDemo
{
    public class MainViewModel : ModelViewModel<MainModel>
    {
        private IUnityContainer mContainer;
        private ObservableCollection<ModelInstrumentViewModel> mFlatInstruments = new ObservableCollection<ModelInstrumentViewModel>();
        private ObservableCollection<ModelInterfaceViewModel> mUmbrellaInterfaces = new ObservableCollection<ModelInterfaceViewModel>();
        private ModelInstrumentViewModel mSelectedInstrument = null;
        private ICommand mRescanCommand;

        public MainViewModel(MainModel model)
            : base(model)
        {
            Initialize();
            mContainer = model.Container;
        }

        public ObservableCollection<ModelInstrumentViewModel> FlatInstruments
        {
            get { return mFlatInstruments; }
        }
        public ObservableCollection<ModelInterfaceViewModel> UmbrellaInterfaces
        {
            get { return mUmbrellaInterfaces; }
        }
        public ModelInstrumentViewModel SelectedInstrument
        {
            get { return mSelectedInstrument; }
            set
            {
                mSelectedInstrument = value;
                OnPropertyChanged("SelectedInstrument");
            }
        }
        public ICommand RescanCommand
        {
            get
            {
                if (mRescanCommand == null)
                {
                    mRescanCommand = new DelegateCommand(() =>
                    {
                        BeginRefresh();
                        Action handler = () =>
                        {
                            var statusManager = mContainer.Resolve<IAddressStatusManager>();
                            var addressList = new List<Address>();
                            foreach (var instrument in mFlatInstruments)
                            {
                                var addresses = instrument.Addresses.Select(a => a.GetAddressModel());
                                addressList.AddRange(addresses);
                            }
                            statusManager.RefreshStatus(addressList);
                            mContainer.RefreshInstruments();
                            Thread.Sleep(2500);
                        };
                        Action<IAsyncResult> callbackHandler = r => EndRefresh();
                        var callback = new AsyncCallback(callbackHandler);
                        handler.BeginInvoke(callback, null);
                    });
                }
                return mRescanCommand;
            }
        }

        private void BeginRefresh()
        {
            foreach (var instrument in FlatInstruments)
            {
                instrument.BeginRefresh();
            }
        }

        private void EndRefresh()
        {
            foreach (var instrument in FlatInstruments)
            {
                instrument.EndRefresh();
            }
        }

        private void Initialize()
        {
            //ToDo: Initialize the data.
            var instruments = mModel.GetModelElements().Where(e => e is ModelInstrument).Select(e => new ModelInstrumentViewModel((ModelInstrument)e)).OrderBy(e => e.Name);
            foreach (var instrument in instruments)
            {
                FlatInstruments.Add(instrument);
            }

            var interfaces = mModel.GetModelElements().Where(e => e is ModelInterface).Select(e =>
            {
                var interfaceViewModel = new ModelInterfaceViewModel((ModelInterface)e);
                var children = FlatInstruments.Where(i => i.GetParentIDs().Contains(e.PersistentID));
                foreach (var child in children)
                {
                    interfaceViewModel.Children.Add(child);
                }
                return interfaceViewModel;
            });
            foreach (var intf in interfaces)
            {
                UmbrellaInterfaces.Add(intf);
                intf.PropertyChanged += intf_PropertyChanged;
            }
        }

        void intf_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedInstrument")
            {
                var intfViewModel = sender as ModelInterfaceViewModel;
                if (intfViewModel != null)
                {
                    SelectedInstrument = intfViewModel.SelectedInstrument;
                }
            }
        }
    }
}
