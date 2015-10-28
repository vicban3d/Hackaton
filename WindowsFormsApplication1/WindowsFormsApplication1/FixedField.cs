using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
