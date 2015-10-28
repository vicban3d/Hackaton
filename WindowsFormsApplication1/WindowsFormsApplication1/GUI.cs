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
        public GUI()
        {
            InitializeComponent();
        }

        void drawData()
        {
            Label l = new Label();
            l.Text = "some field";
            l.Size = new System.Drawing.Size(166, 83);
            p_view.Controls.Add(l);

        }

        private void b_show_Click(object sender, EventArgs e)
        {
            drawData();
        }
    }

   



}
