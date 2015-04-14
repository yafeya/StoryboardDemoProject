using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace StoryboardDemo
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            InitializeRepository();
            RefreshStatus();
            var model = new MainModel(Container);
            var shell = new MainWindow();
            var mainViewModel = new MainViewModel(model);
            shell.DataContext = mainViewModel;
            return shell;
        }

        private void RefreshStatus()
        {
            Container.RefreshAddresses();
            Container.RefreshInstruments();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            var mainView = (MainWindow)Shell;
            mainView.Show();
        }

        protected override IUnityContainer CreateContainer()
        {
            var container = base.CreateContainer();
            container.RegisterType<IModelElementRepository, ModelElementRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<AddressStatusPolicy, BrokenFileAddressStatusPolicy>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAddressStatusManager, AddressStatusManager>(new ContainerControlledLifetimeManager());
            return container;
        }

        private void InitializeRepository()
        {
            var modelElementRepository = Container.Resolve<IModelElementRepository>();
            modelElementRepository.FillData();
        }
    }
}
