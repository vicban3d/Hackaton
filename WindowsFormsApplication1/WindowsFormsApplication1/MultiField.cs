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
    }
}
