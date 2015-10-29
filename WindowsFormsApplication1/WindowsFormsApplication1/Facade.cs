using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtoShark
{
    static class Facade
    {
        public static Protocol getProtocolFromXML(String path)
        {
            XMLParser parser = new XMLParser();
            return parser.parse(path);
        }
        private static void createXML(Protocol prot)
        {
            XMLCreator creator = new XMLCreator();
            creator.create(prot);
        }

        public static void createProtocol(TreeView tree)
        {
            TreeNodeCollection treeCol = tree.Nodes;
            Protocol prot = new Protocol(treeCol[0].Text, treeCol[0].ImageKey, treeCol[0].SelectedImageKey);
            Block data = null;
            foreach (TreeNode t in treeCol[0].Nodes)
            {
                if (t.Name.Equals("Block"))
                {
                    data = prot.createBlock(t.Text, t.ImageKey, t.SelectedImageKey);
                    createProtocol(t.Nodes, data);
                }
                else
                {
                    if(t.Name.Equals("multi"))
                    { 
                    Field f = prot.createField(t.Text, t.Name,  "", t.SelectedImageKey);
                    string[] values = t.ImageKey.Split(';');
                    foreach(string s in values)
                        {
                            string[] pair = s.Split(':');
                            ((MultiField)f).addKey(pair[0], pair[1]);
                        }
                   } else prot.createField(t.Text, t.Name, t.ImageKey, t.SelectedImageKey);
                }
            }
            createXML(prot);
        }

        private static void createProtocol(TreeNodeCollection tree, Block data)
        {
            Block temp = null;
            foreach (TreeNode t in tree)
            {
                if (t.Name.Equals("Block"))
                {
                    temp = data.addBlock(t.Text, t.ImageKey, t.SelectedImageKey);
                    createProtocol(t.Nodes, temp);
                }
                else
                {
                    if (t.Name.Equals("multi"))
                    {
                        Field f = data.addField(t.Text, t.Name, "", t.SelectedImageKey);
                        string[] values = t.ImageKey.Split(';');
                        foreach (string s in values)
                        {
                            string[] pair = s.Split(':');
                            ((MultiField)f).addKey(pair[0], pair[1]);
                        }
                    }
                    else data.addField(t.Text, t.Name, t.ImageKey, t.SelectedImageKey);
                }
            }
        }
    }
}
