using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    static class Facade
    {
        public static Protocol getProtocolFromXML(String path)
        {
            XMLParser parser = new XMLParser();
            return parser.parse(path);
        }
        public static void createXML(Protocol prot)
        {
            XMLCreator creator = new XMLCreator();
            creator.create(prot);
        }
    }
}
