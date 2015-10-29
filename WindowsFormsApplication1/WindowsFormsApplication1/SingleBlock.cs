using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtoShark
{
    class SingleBlock : Block
    {
        private String info;
        public SingleBlock(String name, String info)
        {
           this.name = name;
            this.info = info;
           this.data = new LinkedList<Data>();
        }

        public override void drawData(GUI gui)
        {
            gui.drawData(this);
        }

        public override string getInfo()
        {
            return info;
        }
        public override void insertData(XMLCreator xml, XmlElement parent)
        {
            xml.insertBlock(this, parent);
        }
        public override string getInfoName()
        {
            return "info";
        }

        public override string getType()
        {
            return "single";
        }
    }
}
