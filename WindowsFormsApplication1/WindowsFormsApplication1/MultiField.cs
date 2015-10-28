using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class MultiField : Field
    {
        private String info;
        protected List<Key> keys;

        public MultiField(String name, String info)
        {
            this.name = name;
            this.info = info;
            this.keys = new List<Key>();
        }
    }
}
