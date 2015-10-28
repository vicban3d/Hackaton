using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtoShark
{
    interface Data
    {
        void drawData(GUI gui);
        String getName();
        void insertData(XMLCreator xml, XmlElement parent);
    }
}
