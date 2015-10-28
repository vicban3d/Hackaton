﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    class RepeatingBlock : Block
    {

        private string repetitions;

        public RepeatingBlock(String name)
        {
            this.name = name;
            repetitions = "REPETITIONS_DEFAULT";
        }

        internal string getName()
        {
            return name;
        }

        internal string getNumOfRepetitions()
        {
            return repetitions;
        }

        internal List<Data> getChildren()
        {
            return null;
        }
    }
}
