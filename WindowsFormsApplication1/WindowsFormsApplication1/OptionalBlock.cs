using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class OptionalBlock : Block
    {
        public OptionalBlock(String name)
        {
            this.name = name;
        }

        internal IEnumerable<Data> getChildren()
        {
            return null;
        }

        internal string getCondition()
        {
            return "CONDITION";
        }

        internal string getName()
        {
            return name;
        }
    }
}
