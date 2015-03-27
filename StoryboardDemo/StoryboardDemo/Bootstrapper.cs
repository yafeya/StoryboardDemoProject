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
            var shell = new MainWindow();
            return shell;
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            InitializeRepository();
            var model = new MainModel(Container);

        }

        protected override IUnityContainer CreateContainer()
        {
            var container = base.CreateContainer();
            container.RegisterType<IModelElementRepository, ModelElementRepository>();
            return container;
        }

        private void InitializeRepository()
        {
            var modelElementRepository = Container.Resolve<IModelElementRepository>();
            modelElementRepository.FillData();
        }
    }
}
