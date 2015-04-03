using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class LANElementProvider : IModelElementProvider
    {
        #region IModelElementProvider Members

        public IEnumerable<ModelElement> FindElements()
        {
            var elementList = new List<ModelElement>();
            var intf = new ModelInterface { Name = "LAN" };
            var inst1 = new ModelInstrument { Name = "LANInstrument1", Addresses = new[] { new Address("TCPIP0::INSTR1") } };
            var inst2 = new ModelInstrument { Name = "LANInstrument2", Addresses = new[] { new Address("TCPIP0::INSTR2") } };
            var inst3 = new ModelInstrument { Name = "LANInstrument3", Addresses = new[] { new Address("TCPIP0::INSTR3") } };
            var inst4 = new ModelInstrument { Name = "LANInstrument4", Addresses = new[] { new Address("TCPIP0::INSTR4") } };

            inst1.AddParentID(intf.PersistentID);
            inst2.AddParentID(intf.PersistentID);
            inst3.AddParentID(intf.PersistentID);
            inst4.AddParentID(intf.PersistentID);

            elementList.AddRange(new ModelElement[] { intf, inst1, inst2, inst3, inst4 });

            return elementList;
        }

        #endregion
    }
}
