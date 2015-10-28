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
        private static Size nodeSize = new Size(200, 20);
        private static Size nodeLabelSize = new Size(200, 20);
        private static String PROTOCOLS_FILE_PATH = "\\\\docman\\docman\\ProtoShark";
        
        private static int initialHeight = 20;
        private static int initialLeft = 20;


        private int structureIndex;
        private int structureDepth;


        public GUI()
        {
            InitializeComponent();
            structureIndex = 1;
            structureDepth = 1;
            fillProtocolList();

            p_view.AutoScroll = true;
            
            l_desc.BackColor = Color.White;
            l_desc.BorderStyle = BorderStyle.FixedSingle;
            l_desc.AutoSize = false;
            l_desc.Size = new Size(250, 520);
            l_desc.Location = new Point(730, 55);


            resetView();



        }

        private void drawData(LinkedList<Data> data)
        {
            if (data != null)
            {
                structureDepth++;
                foreach (Data child in data)
                {
                    structureIndex++;
                    child.drawData(this);
                }
                structureIndex++;

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
            createLabel(data.getName(), "A block that appears only once.");
            drawData(data.getChildren());
            structureDepth--;
        }


        public void drawData(OptionalBlock data)
        {
            createLabel(data.getName(), "A block that may or may not appear depending on the condition.");
            Label conditionLabel = new Label();                       
            conditionLabel.Text = " -? " + data.getCondition();
            conditionLabel.Size = nodeLabelSize;
            conditionLabel.Location = new Point(nodeSize.Width + initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            p_view.Controls.Add(conditionLabel);
            drawData(data.getChildren());
            structureDepth--;
        }


        public void drawData(RepeatingBlock data)
        {
            createLabel(data.getName(), "A block that appears repeatedly.");            
            Label conditionLabel = new Label();
            conditionLabel.Text = "  x " + data.getNumOfRepetitions();
            conditionLabel.Size = nodeLabelSize;
            conditionLabel.Location = new Point(nodeSize.Width + initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            p_view.Controls.Add(conditionLabel);
            drawData(data.getChildren());
            structureDepth--;
        }

        public void drawData(MultiField data)
        {
     
        }
        public void drawData(FixedField data)
        {
            createLabel(data.getName() + " (" + data.getSize() + ")", data.getDescription());
        }
        public void drawData(DependField data)
        {
            createLabel(data.getName() + " (" + data.getInfo() + ")", data.getDescription());
        }

        private void createLabel(String content, string description)
        {
            Label dataLabel = new Label();
            dataLabel.BackColor = Color.White;
            dataLabel.BorderStyle = BorderStyle.Fixed3D;
            dataLabel.AutoSize = false;
            dataLabel.Text = content;
            dataLabel.Size = nodeSize;
            dataLabel.Location = new Point(initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);

            dataLabel.Click += (x, y) => clickHandler(description);

            p_view.Controls.Add(dataLabel);
        }

        private void clickHandler(string description)
        {
            l_desc.Text = description;
        }

        private void b_show_Click(object sender, EventArgs e)
        {
            p_view.Controls.Clear();
            structureIndex = 1;
            structureDepth = 1;
            l_desc.Text = "";
            if (cb_protocolsList.Items.Contains(cb_protocolsList.Text))
            {
                String filepath = PROTOCOLS_FILE_PATH + "\\" + cb_protocolsList.Text + ".xml";
                // Protocol p = Facade.getProtocolFromXML(filepath);
                // link_source.Text = p.getSource();
                // LinkedList<Data> protocolData = p.getData();
                // drawData(protocolData);               
                 l_protocolName.Text = cb_protocolsList.Text;

                FixedField ff = new FixedField("FixedField", "4", "This field is fixed with size 4 bytes.");
                DependField df = new DependField("DependField", "FixedField == 0", "This field only exists if FiexedField is 0");
                SingleBlock sb = new SingleBlock("Fields", "BlaBla");
                RepeatingBlock rb = new RepeatingBlock("RepeatingBlock", "10");
                sb.addField("FixedField", "fixed", "4", "This field is fixed with size 4 bytes.");
                sb.addField("DependField", "dependant", "FixedField == 0", "This field only exists if FiexedField is 0");                
                rb.addField("FixedField", "fixed", "4", "This field is fixed with size 4 bytes.");
                rb.addField("DependField", "dependant", "FixedField == 0", "This field only exists if FiexedField is 0");
                drawData(sb);
                drawData(rb);
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
            l_desc.Text = "";
            Label error = new Label();
            error.Text = "Select Protocol";
            error.Size = new Size(200, 20);            
            error.Location = new Point(p_view.Width / 2 - 50, p_view.Height / 2 - 100);
            p_view.Controls.Add(error);
        }
    }





}
