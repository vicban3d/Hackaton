using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    abstract class Block : Data
    {
        protected String name;
        protected LinkedList<Data> data;

        public abstract void drawData(GUI gui);
        public String getName()
        {
            return name;
        }
        public LinkedList<Data> getChildren()
        {
            return data;
        }
        
        public Block addBlock(String name, String type, String info) {
            return null;
        }

        public Field addField(String name, String type, String info, String description)
        {
            return null;
        }
    }
}
