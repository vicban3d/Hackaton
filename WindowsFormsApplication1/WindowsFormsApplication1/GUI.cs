using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProtoShark;
using System.IO;

namespace ProtoShark
{
    partial class GUI : Form
    {
        private static Size nodeSize = new Size(100, 20);
        private static Size nodeLabelSize = new Size(200, 20);
        private static String PROTOCOLS_FILE_PATH = "\\\\docman\\docman\\ProtoShark";
        
        private static int initialHeight = 50;
        private static int initialLeft = 50;


        private int structureIndex;
        private int structureDepth;


        public GUI()
        {
            InitializeComponent();
            structureIndex = 1;
            structureDepth = 1;
            fillProtocolList();

            p_view.AutoScroll = true;

            resetView();
        }

        private void drawData(LinkedList<Data> data)
        {
            if (data != null)
            {
                structureDepth++;
                foreach (Data child in data)
                {
                    child.drawData(this);
                }
            }
        }

        private void fillProtocolList()
        {
            // Should read head XML file and fill in protocol names.
            DirectoryInfo dir = Directory.CreateDirectory(PROTOCOLS_FILE_PATH);
            foreach (FileInfo file in dir.EnumerateFiles())
            {
                cb_protocolsList.Items.Add(file.Name.Split('.')[0]);
            }
        }


       public void drawData(SingleBlock data)
        {
            Label dataLabel = new Label();
            dataLabel.BackColor = Color.White;
            dataLabel.BorderStyle = BorderStyle.Fixed3D;
            dataLabel.Text = data.getName();
            dataLabel.Size = nodeSize;
            dataLabel.Location = new Point(initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            p_view.Controls.Add(dataLabel);
            structureIndex++;           
            drawData(data.getChildren());
        }


        public void drawData(OptionalBlock data)
        {
            Label dataLabel = new Label();
            dataLabel.BackColor = Color.White;
            dataLabel.BorderStyle = BorderStyle.Fixed3D;
            dataLabel.Text = data.getName();
            dataLabel.Size = nodeSize;
            dataLabel.Location = new Point(initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            p_view.Controls.Add(dataLabel);

            Label conditionLabel = new Label();                       
            conditionLabel.Text = " -? " + data.getCondition();
            conditionLabel.Size = nodeLabelSize;
            conditionLabel.Location = new Point(nodeSize.Width + initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            p_view.Controls.Add(conditionLabel);

            structureIndex++;

            if (data.getChildren() != null)
            {
                structureDepth++;
                foreach (Data child in data.getChildren())
                {
                    child.drawData(this);
                }
            }
        }


        public void drawData(RepeatingBlock data)
        {
            Label dataLabel = new Label();
            dataLabel.BackColor = Color.White;
            dataLabel.BorderStyle = BorderStyle.Fixed3D;
            dataLabel.Text = data.getName();
            dataLabel.Size = nodeSize;
            dataLabel.Location = new Point(initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            p_view.Controls.Add(dataLabel);

            Label conditionLabel = new Label();
            conditionLabel.Text = " -X " + data.getNumOfRepetitions();
            conditionLabel.Size = nodeLabelSize;
            conditionLabel.Location = new Point(nodeSize.Width + initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            p_view.Controls.Add(conditionLabel);

            structureIndex++;

            if (data.getChildren() != null)
            {
                structureDepth++;
                foreach (Data child in data.getChildren())
                {
                    child.drawData(this);
                }
            }
        }

        public void drawData(MultiField data)
        {
     
        }
        public void drawData(FixedField data)
        {

        }
        public void drawData(DependField data)
        {

        }

        private void b_show_Click(object sender, EventArgs e)
        {
            p_view.Controls.Clear();
            if (cb_protocolsList.Text != "")
            {
                String filepath = PROTOCOLS_FILE_PATH + "\\" + cb_protocolsList.Text + ".xml";
               // Protocol p = Facade.getProtocolFromXML(filepath);
               // link_source.Text = p.getSource();
               // LinkedList<Data> protocolData = p.getData();
               // drawData(protocolData);               
               // l_protocolName.Text = cb_protocolsList.Text;
            }
            else
            {
                resetView();
            }
        }

        private void resetView()
        {
            p_view.Controls.Clear();
            structureIndex = 1;
            structureDepth = 1;
            Label error = new Label();
            error.Text = "Select Protocol";
            error.Size = new Size(200, 20);            
            error.Location = new Point(p_view.Width / 2 - 50, p_view.Height / 2 - 100);
            p_view.Controls.Add(error);
        }
    }





}
