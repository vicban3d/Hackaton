using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class DependField : Field
    {
        private String info;

        public DependField(String name, String info, String description)
        {
            this.name = name;
            this.info = info;
            this.description = description;

        }
        public override void drawData(GUI gui)
        {
            gui.drawData(this);
        }
    }
}
