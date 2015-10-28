using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace WindowsFormsApplication1
{
    class XMLParser
    {
        public void func()
        {
            // Attributes of nodes
            String[] protocolAttributes = new String[] { "name" , "source"}; //TODO: change to Protocol.attributes
            String[] blockAttributes = new String[] { "a" };
            String[] fieldAttributes = new String[] { "a" };
            String[] keyAttributes = new String[] { "a" };

            // parse protocol attributes
            String path = "C:\\Users\\noaav\\Desktop\\protocol.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            XmlNodeList protocolNode = xmlDoc.DocumentElement.SelectNodes("/protocol");
            foreach (XmlNode node in protocolNode)
            {
                foreach (String attName in protocolAttributes)
                {
                    if(node.Attributes[attName] != null)
                    Console.WriteLine(node.Attributes[attName].Value);
                }

            }

            XmlNodeList blockNodes = xmlDoc.DocumentElement.SelectNodes("/protocol/block");
      //      foreach (XmlNode blockNode in blockNodes)
      //      {
       //         blockNode.Attributes;
          //  }

        }


    }
}
        
    

