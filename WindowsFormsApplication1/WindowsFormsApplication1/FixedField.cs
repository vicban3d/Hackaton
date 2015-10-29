using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtoShark
{
    class FixedField : Field
    {
        private String size;

        public FixedField(String name, String info, String description)
        {
            this.name = name;
            this.size = info;
            this.description = description;

        }
        public override void drawData(GUI gui)
        {
            gui.drawData(this);
        }

        public String getSize()
        {
            return size;
        }
        public override List<Key> getKeys()
        {
            return null;
        }

        public override string getType()
        {
            return "fixed";
        }

        public override string getInfo()
        {
            return getSize();
        }

        public override string getInfoName()
        {
            return "size";
        }
        public override void insertData(XMLCreator xml, XmlElement parent)
        {
            xml.insertField(this, parent);
        }
    }
}
