using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class FixedBlock : Block
    {

        private string name;
        private List<Data> children;

        public FixedBlock(String name)
        {
            this.name = name;
            children = null;
        }

        public string getName()
        {
            return name;
        }

        public List<Data> getChildren()
        {
            return children;
        }
    }
}
