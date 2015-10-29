using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtoShark
{
    class DependBlock : Block
    {
        private String info;

        public DependBlock(String name, String info)
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

        public override string getInfoName()
        {
            return "info";
        }

        public override string getType()
        {
            return "dependent";
        }
        public override void insertData(XMLCreator xml, XmlElement parent)
        {
            xml.insertBlock(this, parent);
        }
    }
}