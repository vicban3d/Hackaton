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

        public String getDescription()
        {
            return description;
        }
        public abstract String getType();
        public abstract String getInfo();
        public abstract String getInfoName();
        abstract public List<Key> getKeys();

    }
}
