using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
