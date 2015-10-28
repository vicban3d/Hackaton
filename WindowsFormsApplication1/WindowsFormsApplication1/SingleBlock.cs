﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class SingleBlock : Block
    {
        public SingleBlock(String name)
        {
           this.name = name;
        }

        internal string getName()
        {
            return name;
        }

        internal List<Data> getChildren()
        {
            return null;
        }
    }
}