﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoShark
{
    static class Facade
    {
        public static Protocol getProtocolFromXML(String path)
        {
            XMLCreator parser = new XMLCreator();
            return parser.parse(path);
        }
    }
}
