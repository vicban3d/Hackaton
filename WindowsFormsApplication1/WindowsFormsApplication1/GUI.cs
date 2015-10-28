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

        private bool editMode = false;
        private bool createMode = false;
        private static Size nodeSize = new Size(200, 20);
        private static Size nodeLabelSize = new Size(200, 20);
        private static String PROTOCOLS_FILE_PATH = "\\\\docman\\docman\\ProtoShark";

        private static int initialHeight = 0;
        private static int initialLeft = 0;


        private int structureIndex;
        private int structureDepth;


        public GUI()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            structureIndex = 1;
            structureDepth = 1;
            fillProtocolList();

            p_view.AutoScroll = true;

            tb_desc.BackColor = Color.White;
            tb_desc.BorderStyle = BorderStyle.FixedSingle;
            tb_desc.AutoSize = false;
            tb_desc.Size = new Size(520, 720);
            tb_desc.Location = new Point(730, 55);
            tb_desc.ScrollBars = ScrollBars.Vertical;
            tb_desc.ReadOnly = true;
            tb_desc.WordWrap = true;

            b_save.Hide();





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
            string keys = "";
            foreach (Key key in data.getKeys())
            {
                keys += key.getValue() + "\r\n" + key.getDescription() + "\r\n\r\n";
            }
            keys = "\r\n\r\nMay be equal to one of the following values:\r\n" + keys;
            createLabel(data.getName(), data.getDescription() + keys);
        }

        internal void drawData(DelimField data)
        {
            createLabel(data.getName() + " : " + data.getDelim(), data.getDescription() + "\r\n\r\nThe value of this field ends with \'" + data.getDelim() + "\'.\r\n");
        }

        public void drawData(FixedField data)
        {
            createLabel(data.getName() + " (" + data.getSize() + ")", data.getDescription() + "\r\n\r\nThe size of this field is " + data.getSize() + " bytes.\r\n");
        }
        public void drawData(DependField data)
        {
            createLabel(data.getName() + " (" + data.getInfo() + ")", data.getDescription() + "\r\n\r\nThis field may or may not appear depending on " + data.getInfo() + " field.\r\n");
        }

        private void createLabel(String content, String description)
        {
            TextBox dataLabel = new TextBox();
            dataLabel.BackColor = Color.White;
            dataLabel.BorderStyle = BorderStyle.Fixed3D;
            dataLabel.AutoSize = false;
            if (!createMode) { 
            dataLabel.Text = content;
            } 
            else
            {
                dataLabel.Text = "";
            }
            dataLabel.Size = nodeSize;
            dataLabel.Location = new Point(initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            dataLabel.ReadOnly = !editMode;

            dataLabel.Click += (x, y) => clickHandler(description);
            
            p_view.Controls.Add(dataLabel);
            
        }

        

        private void clickHandler(String description)
        {
            tb_desc.Text = description;
        }

        private void editHandler(String name, String info, String description)
        {
            MessageBox.Show(name + " " + info + " " + description);
        }

       

        private void resetView()
        {
            p_view.Controls.Clear();
            structureIndex = 1;
            structureDepth = 1;
            tb_desc.Text = "";
            Label error = new Label();
            error.Text = "Select Protocol";
            error.Size = new Size(200, 20);
            error.Location = new Point(p_view.Width / 2 - 50, p_view.Height / 2 - 100);
            p_view.Controls.Add(error);
        }

        private void b_show_Click(object sender, EventArgs e)
        {
            editMode = false;
            createMode = false;
            b_save.Hide();
            p_view.Controls.Clear();
            structureIndex = 1;
            structureDepth = 1;
            tb_desc.Text = "";
            if (cb_protocolsList.Items.Contains(cb_protocolsList.Text))
            {
                String filepath = PROTOCOLS_FILE_PATH + "\\" + cb_protocolsList.Text + ".xml";
                Protocol p = Facade.getProtocolFromXML(filepath);
                link_source.Text = p.getSource();
                LinkedList<Data> protocolData = p.getData();
                drawData(protocolData);
                l_protocolName.Text = cb_protocolsList.Text;
            }
            else
            {
                resetView();
            }
        }

        private void b_edit_Click(object sender, EventArgs e)
        {
            editMode = true;
            createMode = false;
            b_save.Show();
            p_view.Controls.Clear();
            structureIndex = 1;
            structureDepth = 1;
            tb_desc.Text = "";
            if (cb_protocolsList.Items.Contains(cb_protocolsList.Text))
            {
                String filepath = PROTOCOLS_FILE_PATH + "\\" + cb_protocolsList.Text + ".xml";
                Protocol p = Facade.getProtocolFromXML(filepath);
                link_source.Text = p.getSource();
                LinkedList<Data> protocolData = p.getData();
                drawData(protocolData);
                l_protocolName.Text = cb_protocolsList.Text;
            }
            else
            {
                resetView();
            }
        }

        private void b_create_Click(object sender, EventArgs e)
        {
            editMode = true;
            createMode = true;
            b_save.Show();
            p_view.Controls.Clear();
            structureIndex = 1;
            structureDepth = 1;
            tb_desc.Text = "";
            if (cb_protocolsList.Items.Contains(cb_protocolsList.Text))
            {
                String filepath = PROTOCOLS_FILE_PATH + "\\" + cb_protocolsList.Text + ".xml";
                Protocol p = Facade.getProtocolFromXML(filepath);
                link_source.Text = p.getSource();
                LinkedList<Data> protocolData = p.getData();
                drawData(protocolData);
                l_protocolName.Text = "Create New Protocol";
            }
            else
            {
                resetView();
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {

        }
    }





}
