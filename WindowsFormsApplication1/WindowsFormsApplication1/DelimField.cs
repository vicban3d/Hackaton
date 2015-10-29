using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtoShark
{
    class DelimField :Field
    {
        private String delim;

        public DelimField(String name, String info, String description)
        {
            this.name = name;
            this.delim = info;
            this.description = description;
        }

        public override void drawData(GUI gui)
        {
            gui.drawData(this);
        }
         public override void insertData(XMLCreator xml, XmlElement parent)
        {
            xml.insertField(this, parent);
        }
        public String getDelim()
        {
            return delim;
        }

        public override string getInfo()
        {
           return getDelim();
        }

        public override string getInfoName()
        {
            return "delim";
        }

        public override List<Key> getKeys()
        {
            return null;
        }

        public override string getType()
        {
            return "delimited";
        }
    }
}
