using System;
using System.Collections.Generic;
using System.Xml;

namespace ProtoShark
{
    class XMLCreator
    {
        private XmlDocument doc;

        public void create(Protocol protocol)
        {
            string path = "C:\\Users\\gavrielg\\Desktop\\Tasks\\" + protocol.getName()+ ".xml";

         

            doc = new XmlDocument();



            XmlElement productNode = doc.CreateElement("protocol");
            productNode.SetAttribute("name", protocol.getName());
            productNode.SetAttribute("source", protocol.getSource());
            productNode.SetAttribute("description", protocol.getDescription());
            doc.AppendChild(productNode);
            LinkedList<Data> data = protocol.getData();
            foreach (Data node in data) { 
                node.insertData(this,productNode);
            }

             doc.Save(path);

        }
  
        public void insertBlock(Block block, XmlElement parent)
        {
            XmlElement blockNode =  doc.CreateElement("block");
            blockNode.SetAttribute("name", block.getName());
            blockNode.SetAttribute("type", block.getType());
            blockNode.SetAttribute(block.getInfoName(), block.getInfo());
            parent.AppendChild(blockNode);
            foreach(Data child in block.getChildren())
            {
                child.insertData(this,blockNode);
            }

        }

        public void insertField(Field field, XmlElement parent)
        {
            XmlElement fieldNode = doc.CreateElement("field");
            fieldNode.SetAttribute("name", field.getName());
            fieldNode.SetAttribute("type", field.getType());
            fieldNode.SetAttribute(field.getInfoName(), field.getInfo());
            fieldNode.SetAttribute("description", field.getDescription());
            parent.AppendChild(fieldNode);
            if (field.getType().Equals("multi"))
            {
                foreach (Key child in field.getKeys())
                {
                    insertKey(child, fieldNode);
                }
            }
        }

        private void insertKey(Key child, XmlElement parent)
        {
            XmlElement keyNode = doc.CreateElement("key");
            keyNode.SetAttribute("description", child.getDescription());
            keyNode.InnerText = child.getValue();
            parent.AppendChild(keyNode);
        }
    }
}