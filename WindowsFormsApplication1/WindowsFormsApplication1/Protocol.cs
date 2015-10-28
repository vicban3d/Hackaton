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

        public Data createBlock(String name, String type)
        {
            Data newBlock;
            if (type.Equals("repeating")) newBlock = new RepeatingBlock(name);
            if (type.Equals("fixed")) newBlock = new FixedBlock(name);
            if (type.Equals("optional")) newBlock = new OptionalBlock(name);
            return newBlock;
        }

    }
}
