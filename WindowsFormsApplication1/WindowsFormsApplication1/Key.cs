using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class Key
    {
        private String description;
        private String value;
        public Key(String description, String value)
        {
            this.description = description;
            this.value = value;
        }

        public String getDescription()
        {
            return description;
        }

        public String getValue()
        {
            return value;
        }

    }
}
