using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class RepeatingBlock : Block
    {
        private String numOfRepetition;
        public RepeatingBlock(String name, String info)
        {
            this.numOfRepetition = info;
            this.name = name;
            this.data = new LinkedList<Data>();
        }
        public override void drawData(GUI gui)
        {
            gui.drawData(this);
        }

        public String getNumOfRepetitions()
        {
            return numOfRepetition;
        }
    }
}
