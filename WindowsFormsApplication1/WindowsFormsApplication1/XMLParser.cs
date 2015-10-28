using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace ProtoShark
{
    class XMLParser
    {
        public void parse()
        {

            // parse protocol attributes
            String path = "\\\\docman\\docman\\ProtoShark\\HTTP.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);


            XmlNodeList protocolNode = xmlDoc.DocumentElement.SelectNodes("/protocol");

            // parsing protocol attributes
            if (protocolNode != null)
            {
                string protoName = null, protoSource = null, protoDescription = null;
                foreach (XmlNode node in protocolNode)
                {

                    if (node.Attributes["name"] != null)
                    {
                        protoName = node.Attributes["name"].Value;
                    }
                    if (node.Attributes["source"] != null)
                    {
                        protoSource = node.Attributes["source"].Value;
                    }
                    if (node.Attributes["description"] != null)
                    {
                        protoDescription = node.Attributes["description"].Value;
                    }

                }

                //creating new protocol instance
                Protocol protocol = new Protocol(protoName, protoSource, protoDescription);

                //getting all the blo
                XmlNodeList nodes = xmlDoc.DocumentElement.SelectNodes("/protocol/block|/protocol/field");

                //going over all the nodes and creating their instances
                foreach (XmlNode node in nodes)
                {
                    if (node.Name == "block")
                    {
                        String[] attr = getBlockAttr(node);
                        String name = attr[0];
                        String type = attr[1];
                        String info = attr[2];

                        Block block = protocol.createBlock(name, type, info);
                        innerBlocks(block, node.ChildNodes);
                    }
                    else if (node.Name == "field")
                    {
                        String[] attr = getFieldAttr(node);
                        String name = attr[0];
                        String type = attr[1];
                        String info = attr[2];
                        String description = attr[3];

                        Field field = protocol.createField(name, type, info, description);
                        if (node.ChildNodes != null)
                        {
                            innerFields(field, node.ChildNodes);
                        }
                    }
                }

            }

        }


        //adding keys to specfic field
        public void innerFields(Field field, XmlNodeList keys)
        {
            foreach (XmlNode key in keys)
            {
                ((MultiField)field).addKey(key.Attributes[0].Value, key.Value);
            }

        }


        //going through the children of the blockNode and creates recursively the right structure
        public void innerBlocks(Block blockNode, XmlNodeList children)
        {
            foreach (XmlNode child in children)
            {
                if (child.Name == "block")
                {
                    String[] attr = getBlockAttr(child);
                    String name = attr[0];
                    String type = attr[1];
                    String info = attr[2];

                    Block block = blockNode.addBlock(name, type, info);
                    innerBlocks(block, child.ChildNodes);
                }
                else if (child.Name == "field")
                {
                    String[] attr = getFieldAttr(child);
                    String name = attr[0];
                    String type = attr[1];
                    String info = attr[2];
                    String description = attr[3];
                    Field field = blockNode.addField(name, type, info, description);
                    innerFields(field, child.ChildNodes);

                }
            }
        }

        //parsing attributes of block and returning them in array
        public String[] getBlockAttr(XmlNode blockNode)
        {
            String[] attr = new String[3];
            attr[0] = blockNode.Attributes[0].Value;
            attr[1] = blockNode.Attributes[1].Value;
            attr[2] = blockNode.Attributes[2].Value;

            return attr;
        }

        //parsing attributes of field and returning them in array
        public String[] getFieldAttr(XmlNode fieldNode)
        {
            String[] attr = new String[4];
            attr[0] = fieldNode.Attributes[0].Value;
            attr[1] = fieldNode.Attributes[1].Value;
            if (fieldNode.Attributes[2] != null)
            {
                attr[2] = fieldNode.Attributes[2].Value;
            }
            if (fieldNode.Attributes[3] != null)
            {
                attr[3] = fieldNode.Attributes[3].Value;
            }

            return attr;
        }

    }
}



