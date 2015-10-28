using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class OptionalBlock : Block
    {
        private string name;
        private string condition;
        public OptionalBlock(String name)
        {
            this.name = name;
            this.condition = "Optional Condition";
        }

        internal string getName()
        {
            return name;
        }

        internal List<Data> getChildren()
        {
            return null;
        }

        internal string getCondition()
        {
            return condition;

        }
    }
}
