using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class MainViewModel : ModelViewModel<MainModel>
    {
        private ObservableCollection<ModelInstrumentViewModel> _flatInstruments = new ObservableCollection<ModelInstrumentViewModel>();
        private ObservableCollection<ModelInterfaceViewModel> _umberallaInterfaces = new ObservableCollection<ModelInterfaceViewModel>();

        public MainViewModel(MainModel model)
            : base(model)
        {
            Initialize();
        }

        public ObservableCollection<ModelInstrumentViewModel> FlatInstruments
        {
            get { return _flatInstruments; }
        }
        public ObservableCollection<ModelInterfaceViewModel> UmberallaInterfaces
        {
            get { return _umberallaInterfaces; }
        }

        private void Initialize()
        {
            //ToDo: Initialize the data.
        }
    }
}
