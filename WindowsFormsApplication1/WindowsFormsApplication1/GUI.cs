using WindowsFormsApplication1;
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

namespace WindowsFormsApplication1
{
    public partial class GUI : Form
    {
        private static Size nodeSize = new Size(100, 20);
        private static Size nodeLabelSize = new Size(200, 20);
        
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

        private void fillProtocolList()
        {
            // Should read head XML file and fill in protocol names.
            cb_protocolsList.Items.Add("HTTP");
            cb_protocolsList.Items.Add("SMTP");
            cb_protocolsList.Items.Add("FTP");
            cb_protocolsList.Items.Add("SWF");
            cb_protocolsList.Sorted = true;
        }

        void drawData(Data data)
        {
        }

        void drawData(SingleBlock data)
        {
            Label dataLabel = new Label();
            dataLabel.BackColor = Color.White;
            dataLabel.BorderStyle = BorderStyle.Fixed3D;
            dataLabel.Text = data.getName();
            dataLabel.Size = nodeSize;
            dataLabel.Location = new Point(initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            p_view.Controls.Add(dataLabel);
            structureIndex++;
            if (data.getChildren() != null)
            {
                structureDepth++;
                foreach (Data child in data.getChildren())
                {
                    drawData(child);
                }
            }
        }
   

        void drawData(OptionalBlock data)
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
                    drawData(child);
                }
            }
        }


        void drawData(RepeatingBlock data)
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
                    drawData(child);
                }
            }
        }


        private void b_show_Click(object sender, EventArgs e)
        {
            p_view.Controls.Clear();
            if (cb_protocolsList.Text != "")
            {
                ///Protocol p = ...
                /// Data protocolData = p.getData();
                /// drawData(data);
                structureIndex = 1;
                structureDepth = 1;                
                l_protocolName.Text = cb_protocolsList.Text;
                SingleBlock fb = new SingleBlock("FixedBlock");
                OptionalBlock ob = new OptionalBlock("OptionalBlock");
                RepeatingBlock rb = new RepeatingBlock("RepeatingBlock");
                drawData(fb);
                drawData(ob);
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
            Label error = new Label();
            error.Text = "Select Protocol";
            error.Size = new Size(200, 20);            
            error.Location = new Point(p_view.Width / 2 - 50, p_view.Height / 2 - 100);
            p_view.Controls.Add(error);
        }
    }





}
