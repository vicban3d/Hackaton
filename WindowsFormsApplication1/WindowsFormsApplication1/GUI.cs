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
using System.Collections;

namespace ProtoShark
{
    partial class GUI : Form
    {
        private TreeView tv;
        private bool editMode = false;
        private bool createMode = false;
        private static Size nodeSize = new Size(180, 20);
        private static Size nodeLabelSize = new Size(200, 20);
        private static String PROTOCOLS_FILE_PATH = "C:\\Users\\gavrielg\\Desktop\\Tasks";

        private static int initialHeight = -20;
        private static int initialLeft = -100;
        private Stack dataStack;

        private int structureIndex;
        private int structureDepth;

        private Protocol protocol;

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

            p_create.Hide();
            p_newlayers.Hide();
            p_add_new_data.Hide();
            p_keys.Hide();






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
                    structureIndex++;
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
            createLabel(data.getName(), "A block that appears only once.");
            structureDepth++;
            foreach (Data child in data.getChildren())
            {
                structureIndex++;
                child.drawData(this);
            }
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
            structureDepth++;
            foreach (Data child in data.getChildren())
            {
                structureIndex++;
                child.drawData(this);
            }
            structureDepth--;
        }


        public void drawData(RepeatingBlock data)
        {
            createLabel(data.getName(), "A block that appears repeatedly.");
            Label conditionLabel = new Label();
            conditionLabel.Text = "  x " + data.getNumOfRepetitions();
            conditionLabel.Size = nodeLabelSize;
            conditionLabel.Location = new Point(nodeSize.Width + initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            conditionLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            p_view.Controls.Add(conditionLabel);
            structureDepth++;
            foreach (Data child in data.getChildren())
            {
                structureIndex++;
                child.drawData(this);
            }
            structureDepth--;
        }

        public void drawData(DependBlock data)
        {
            createLabel(data.getName() + " (" + data.getInfoName() + ")", data.getInfo() + "\r\n\r\nThis field may or may not appear depending on " + data.getInfoName() + " field.\r\n");
            structureDepth++;
            foreach (Data child in data.getChildren())
            {
                structureIndex++;
                child.drawData(this);
            }
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
            Label dataLabel = new Label();
            dataLabel.BackColor = Color.White;
            dataLabel.BorderStyle = BorderStyle.FixedSingle;
            dataLabel.AutoSize = false;
            dataLabel.Font = new Font("Arial", 10, FontStyle.Bold);

            dataLabel.Text = content;


            dataLabel.Size = nodeSize;
            dataLabel.Location = new Point(initialLeft + structureDepth * nodeSize.Width / 3, initialHeight + structureIndex * nodeSize.Height);
            dataLabel.Click += (x, y) => clickHandler(description);
            if (!createMode)
            {
                p_view.Controls.Add(dataLabel);
            }
            else
            {
                p_newlayers.Controls.Add(dataLabel);
            }

        }



        private void clickHandler(String description)
        {
            tb_desc.Text = description;
            tb_desc.Focus();
            tb_desc.DeselectAll();
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
            createMode = false;
            p_view.Controls.Clear();
            structureIndex = 1;
            structureDepth = 1;
            tb_desc.Text = "";
            p_view.Show();
            p_create.Hide();
            p_newprotocol.Hide();
            p_newlayers.Hide();
            p_add_new_data.Hide();
            if (cb_protocolsList.Items.Contains(cb_protocolsList.Text))
            {
                String filepath = PROTOCOLS_FILE_PATH + "\\" + cb_protocolsList.Text + ".xml";
                protocol = Facade.getProtocolFromXML(filepath);
                link_source.Text = "Source";
                LinkedList<Data> protocolData = protocol.getData();
                drawData(protocolData);
                l_protocolName.Text = cb_protocolsList.Text;
                l_protocolDesc.Text = protocol.getDescription();
            }
            else
            {
                resetView();
            }
        }

        private void b_create_Click(object sender, EventArgs e)
        {
            createMode = true;
            p_view.Controls.Clear();
            structureIndex = 1;
            structureDepth = 1;
            tb_desc.Text = "";
            l_protocolName.Text = "Create New Protocol";
            l_protocolDesc.Text = "";
            link_source.Text = "";
            p_view.Hide();
            p_create.Show();
            p_newprotocol.Show();
            p_add_new_data.Hide();
        }

        private void treeFocusHandler()
        {
            tv.SelectedNode.BackColor = Color.Red;
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            protocol = new Protocol(tb_title.Text, tb_source.Text, tb_description.Text);

            tv = new TreeView();
            tv.Size = p_newlayers.Size;
            tv.Location = p_newlayers.Location;
            tv.HideSelection = false;
            tv.Nodes.Add("Block", protocol.getName(), protocol.getSource(), protocol.getDescription());
            tv.SelectedNode = tv.Nodes[0];
            tv.BackColor = SystemColors.ActiveCaption;
            tv.BorderStyle = BorderStyle.Fixed3D;
            p_newlayers.Controls.Add(tv);


            p_newprotocol.Hide();
            p_newlayers.Show();
            l_protocolName.Text = protocol.getName();
            l_protocolDesc.Text = protocol.getDescription();
            p_add_new_data.Show();
        }

        private void t_data_majorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string majorTypeSelected = t_data_majorType.Text;
            if (majorTypeSelected == "Field")
            {
                this.t_data_minorType.Items.Clear();

                this.t_data_minorType.Items.AddRange(new object[] {
            "delimited",
            "fixed",
            "multi" ,
             "dependent"});
                this.t_data_minorType.Sorted = true;
                this.l_data_desc.Text = "Description";
                this.t_data_desc.Show();
            }

            else if (majorTypeSelected == "Block")
            {
                this.t_data_minorType.Items.Clear();
                this.t_data_minorType.Items.AddRange(new object[] {
                "repeating",
                "single",
                "optional"});
                this.t_data_minorType.Sorted = true;
                this.l_data_desc.Text = "";
                this.t_data_desc.Hide();
            }

        }
 
        private void b_add_data_filled_Click(object sender, EventArgs e)
        {
            string name = t_data_name.Text;
            t_data_name.Text = "";
            string majorType = t_data_majorType.Text;
            t_data_majorType.Text = "";
            string minorType = t_data_minorType.Text.ToLower();
            t_data_minorType.Text = "";
            string info = t_data_info.Text;
            t_data_info.Text = "";
            string desc = t_data_desc.Text;
            t_data_desc.Text = "";


            if (tv.SelectedNode.Name == "Block")
            {
                if (majorType == "Block")
                {
                    tv.SelectedNode.Nodes.Add(majorType, name, minorType, info);
                }
                else if (majorType == "Field")
                {
                    tv.SelectedNode.Nodes.Add(minorType, name, info, desc);

                }
            }
            else
            {
                MessageBox.Show("Cannot append to selected field.");
            }
        }

        private void t_data_minorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string minorTypeSelected = t_data_minorType.Text;
            if (minorTypeSelected == "multi")
            {
                p_keys.Show();
                b_add_data_filled.Hide();
            }
            else
            {
                p_keys.Hide();
                b_add_data_filled.Show();
            }
        }

        private void b_add_with_keys_Click(object sender, EventArgs e)
        {
            if (tv.SelectedNode.Name == "Block")
            {
                string keys = "";
                foreach (DataGridViewRow row in keys_table.Rows)
                {
                    keys += row.Cells[0].Value + ":" + row.Cells[1].Value + ";";
                }

                string name = t_data_name.Text;
                t_data_name.Text = "";
                string majorType = t_data_majorType.Text;
                t_data_majorType.Text = "";
                string minorType = t_data_minorType.Text.ToLower();
                t_data_minorType.Text = "";
                string info = t_data_info.Text;
                t_data_info.Text = "";
                string desc = t_data_desc.Text;
                t_data_desc.Text = "";

                tv.SelectedNode.Nodes.Add(minorType, name, keys, desc);

                keys_table.Columns.Clear();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Facade.createProtocol(tv);
        }
    }





}
