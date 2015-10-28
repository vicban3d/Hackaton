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
            Block newBlock;
            if (type.Equals("repeating")) newBlock = new RepeatingBlock(name, info);
            else if (type.Equals("single")) newBlock = new SingleBlock(name, info);
            else if (type.Equals("optional")) newBlock = new OptionalBlock(name, info);
            else return null;
            data.AddLast(newBlock);
            return newBlock;
        }

        public Field addField(String name, String type, String info, String description)
        {
            Field newField;
            if (type.Equals("fixed")) newField = new FixedField(name, info, description);
            else if (type.Equals("delimited")) newField = new DelimField(name, info, description);
            else if (type.Equals("dependant")) newField = new DependField(name, info, description);
            else if (type.Equals("multi")) newField = new MultiField(name, info, description);
            else return null;
            data.AddLast(newField);
            return newField;
        }
    }
}
