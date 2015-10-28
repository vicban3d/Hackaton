using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class Block : Data
    {
        protected String name;
        protected String type;
        protected LinkedList<Data> data;

        public static List<String> getAttributes()
        {
            List<String> result = new List<string>();
            result.Add("name");
            result.Add("type");
            return result;
        }

        public 
    }
}
