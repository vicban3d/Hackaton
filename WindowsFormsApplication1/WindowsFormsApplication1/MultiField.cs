using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class MultiField : Field
    {
        private String info;
        protected List<Key> keys;

        public MultiField(String name, String info, String description)
        {
            this.name = name;
            this.info = info;
            this.description = description; 
            this.keys = new List<Key>();
        }

        public override void drawData(GUI gui)
        {
            gui.drawData(this);
        }
        
        public void addKey(String name, String value)
        {
            keys.Add(new Key(name, value));
        }

        public override List<Key> getKeys()
        {
            return keys;
        }

        public override string getType()
        {
            return "multi";
        }

        public override string getInfo()
        {
            return info;
        }

        public override string getInfoName()
        {
            return "info";
        }
    }
}
