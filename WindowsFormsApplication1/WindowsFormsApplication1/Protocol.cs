﻿using System;
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

        public static List<String> getAttributes()
        {
            List<String> result = new List<string>();
            result.Add("name");
            result.Add("source");
            result.Add("description");
            return result;
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

        public Block createBlock(String name, String type)
        {
            Block newBlock;
            if (type.Equals("repeating")) newBlock = new RepeatingBlock(name);
            else if (type.Equals("single")) newBlock = new SingleBlock(name);
            else if (type.Equals("optional")) newBlock = new OptionalBlock(name);
            else return null;
            return newBlock;
        }

        public Block createField(String name, String type, String info)
        {
            Field newField;
            if (type.Equals("fixed")) newField = new FixedField(name, info);
            else if (type.Equals("delimited")) newField = new DelimField(name, info);
            else if (type.Equals("dependant")) newField = new DependField(name, info);
            else if (type.Equals("multi")) newField = new MultiField(name, info);
            else return null;
            return newField;
        }
    }
}
