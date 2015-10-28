using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class RepeatingBlock : Block
    {
        public RepeatingBlock(String name)
        {
            this.name = name;
            this.data = new LinkedList<Data>();
        }
    }
}
