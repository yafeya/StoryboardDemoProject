using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryboardDemo
{
    public class USBElementProvider : IModelElementProvider
    {
        #region IModelElementProvider Members

        public IEnumerable<ModelElement> FindElements()
        {
            var elementList = new List<ModelElement>();
            var intf = new ModelInterface { Name = "USB" };
            var inst1 = new ModelInstrument { Name = "USBInstrument1" };
            var inst2 = new ModelInstrument { Name = "USBInstrument2" };
            var inst3 = new ModelInstrument { Name = "USBInstrument3" };
            var inst4 = new ModelInstrument { Name = "USBInstrument4" };
            var inst5 = new ModelInstrument { Name = "USBInstrument5" };

            inst1.AddParentID(intf.PersistentID);
            inst2.AddParentID(intf.PersistentID);
            inst3.AddParentID(intf.PersistentID);
            inst4.AddParentID(intf.PersistentID);
            inst5.AddParentID(intf.PersistentID);

            elementList.AddRange(new ModelElement[] { intf, inst1, inst2, inst3, inst4, inst5 });

            return elementList;
        }

        #endregion
    }
}
