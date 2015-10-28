using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public String getInfo()
        {
            return info;
        }
    }
}
