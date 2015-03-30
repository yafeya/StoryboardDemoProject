using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class GPIBLANINSTProvider : IMultiParentsINSTProvider
    {
        private IModelElementRepository mRepository;

        public GPIBLANINSTProvider(IModelElementRepository repository)
        {
            mRepository = repository;
        }

        #region IMultiParentsINSTProvider Members

        public IEnumerable<ModelInstrument> GetInstruments()
        {
            IEnumerable<ModelInstrument> insts = new ModelInstrument[] { };

            var gpibIntf = mRepository.GetElements().Where(e => e.Name == "GPIB").FirstOrDefault();
            var lanIntf = mRepository.GetElements().Where(e => e.Name == "LAN").FirstOrDefault();

            if (gpibIntf != null && lanIntf != null)
            {
                var inst = new ModelInstrument { Name = "GPIB/LAN Instrument1" };
                inst.AddParentID(gpibIntf.PersistentID);
                inst.AddParentID(lanIntf.PersistentID);
                insts = new ModelInstrument[] { inst };
            }

            return insts;
        }

        #endregion
    }
}
