using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace StoryboardDemo
{
    public class BrokenFileAddressStatusPolicy : AddressStatusPolicy
    {
        private const string BROKENADDRESS_FILENAME = "MockData/BrokenAddresses.xml";
        private List<string> mBrokenAddressList = new List<string>();

        public BrokenFileAddressStatusPolicy()
        {
            InitializeBrokenList();
        }

        public override WorkStatus GetStatus(Address address)
        {
            var status = mBrokenAddressList.Contains(address.AddressValue) ? WorkStatus.Broken : WorkStatus.Good;
            return status;
        }

        private void InitializeBrokenList()
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BROKENADDRESS_FILENAME);
            if (File.Exists(fileName))
            {
                using (Stream stream = new FileStream(fileName, FileMode.Open))
                {
                    var document = XDocument.Load(stream);
                    var addresses = document.Element("addresses").Elements("address").Select(element => element.Attribute("value").Value);
                    mBrokenAddressList.AddRange(addresses);
                }
            }
        }
    }
}
