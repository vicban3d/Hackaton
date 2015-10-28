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
            if (info == "")
            {
                info = "unspecified";
            }
            this.numOfRepetition = info;
            this.name = name;
            this.data = new LinkedList<Data>();
        }
        public override void drawData(GUI gui)
        {
            gui.drawData(this);
        }

        public override string getInfo()
        {
            return getNumOfRepetitions();
        }

        public override string getInfoName()
        {
            return "numOfRepetition";
        }

        public String getNumOfRepetitions()
        {
            return numOfRepetition;
        }

        public override string getType()
        {
           return "repeating";
        }
    }
}
