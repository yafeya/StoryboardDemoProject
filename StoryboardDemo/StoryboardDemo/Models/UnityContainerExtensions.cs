using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace StoryboardDemo
{
    public static class UnityContainerExtensions
    {
        public static void RefreshInstruments(this IUnityContainer container)
        {
            var modelElementRepository = container.Resolve<IModelElementRepository>();
            var elements = modelElementRepository.GetElements();
            var instruments = elements.Where(e => e is ModelInstrument).Select(i => i as ModelInstrument);
            foreach (var instrument in instruments)
            {
                instrument.RefreshStatus();
            }
        }

        public static void RefreshAddresses(this IUnityContainer container)
        {
            var modelElementRepository = container.Resolve<IModelElementRepository>();
            var elements = modelElementRepository.GetElements();
            var addresses = elements.Where(e => e is ModelInstrument).Select(i => i as ModelInstrument).SelectMany(instrument => instrument.Addresses);
            var statusManager = container.Resolve<IAddressStatusManager>();
            statusManager.RefreshStatus(addresses);
        }
    }
}
