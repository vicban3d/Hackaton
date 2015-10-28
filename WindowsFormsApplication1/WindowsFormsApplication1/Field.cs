using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{


    abstract class Field : Data
    {
        protected String name;
        protected String description;
        public abstract void drawData(GUI gui);
        public String getName()
        {
            return name;
        }
    }
}
