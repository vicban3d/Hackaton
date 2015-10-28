using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class GUI : Form
    {
        private static Size nodeSize = new Size(100, 20);
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

        void drawData()
        {
            l_protocolName.Text = cb_protocolsList.Text;
            Label l = new Label();            
            l.BackColor = Color.White;
            l.BorderStyle = BorderStyle.Fixed3D;            
            l.Text = "some field";
            l.Size = nodeSize;
            l.Location = new Point(initialLeft + structureDepth * nodeSize.Width/3, initialHeight + structureIndex * nodeSize.Height);
            p_view.Controls.Add(l);
            structureIndex++;
            structureDepth++;
        }


        private void b_show_Click(object sender, EventArgs e)
        {
            drawData();
        }
    }

   



}
