using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class Protocol
    {
        private String name;
        private String source;
        private String description; 
        private LinkedList<Data> data;
        
        public Protocol(String name, String source, String description)
        {
            this.name = name;
            this.source = source;
            this.description = description;
            this.data = new LinkedList<Data>();
        } 

        public String getName()
        {
            return name;
        }

        public String getSource()
        {
            return source;
        }

        public String getDescription()
        {
            return description;
        }

        public Block createBlock(String name, String type, String info)
        {
            Block newBlock;
            if (type.Equals("repeating")) newBlock = new RepeatingBlock(name, info);
            else if (type.Equals("single")) newBlock = new SingleBlock(name, info);
            else if (type.Equals("optional")) newBlock = new OptionalBlock(name, info);
            else if (type.Equals("dependent")) newBlock = new DependBlock(name, info);
            else return null;
            data.AddLast(newBlock);
            return newBlock;
        }

        public Field createField(String name, String type, String info, String description)
        {
            Field newField;
            if (type.Equals("fixed")) newField = new FixedField(name, info, description);
            else if (type.Equals("delimited")) newField = new DelimField(name, info, description);
            else if (type.Equals("dependent")) newField = new DependField(name, info, description);
            else if (type.Equals("multi")) newField = new MultiField(name, info, description);
            else return null;
            data.AddLast(newField);
            return newField;
        }

        public LinkedList<Data> getData()
        {
            return data;
        }
    }
}
