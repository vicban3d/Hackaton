using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class FixedField : Field
    {
        private String size;

        public FixedField(String name, String info)
        {
            this.name = name;
            this.size = info;
        }
    }
}
