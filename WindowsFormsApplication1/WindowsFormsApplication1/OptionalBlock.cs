using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class OptionalBlock : Block
    {
        private String condition;

        public OptionalBlock(String name, String info)
        {
            this.name = name;
            this.condition = info;
            this.data = new LinkedList<Data>();
        }

        public override void drawData(GUI gui)
        {
            gui.drawData(this);
        }

        public String getCondition()
        {
            return condition;
        }

        public override string getInfo()
        {
            return getCondition();
        }

        public override string getInfoName()
        {
            return "condition";
        }

        public override string getType()
        {
            return "optional";
        }
    }
}
