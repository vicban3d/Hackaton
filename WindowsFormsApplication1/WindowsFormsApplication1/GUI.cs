﻿using System;
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

        private bool editMode = false;
        private bool createMode = false;
        private static Size nodeSize = new Size(180, 20);
        private static Size nodeLabelSize = new Size(200, 20);
        private static String PROTOCOLS_FILE_PATH = "\\\\docman\\docman\\ProtoShark";

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
        private void b_save_Click(object sender, EventArgs e)
        {
            protocol = new Protocol(tb_title.Text, tb_source.Text, tb_description.Text);
            p_newprotocol.Hide();
            p_newlayers.Show();
            l_protocolName.Text = protocol.getName();
            l_protocolDesc.Text = protocol.getDescription();
            p_add_new_data.Hide();
        }

        private void b_add_data_Click(object sender, EventArgs e)
        {
            p_add_new_data.Show();
            structureDepth = Int32.Parse(((Button)(sender)).Tag + "");
        }

        private void t_data_majorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string majorTypeSelected = t_data_majorType.Text;
            if (majorTypeSelected == "Field")
            {
             this.t_data_minorType.Items.Clear();

             this.t_data_minorType.Items.AddRange(new object[] {
            "Delimited",
            "Fixed",
            "Multi" ,
             "dependent"});
             this.t_data_minorType.Sorted = true;
             this.l_data_desc.Text = "Description";
             this.t_data_desc.Show();
            }

            else if (majorTypeSelected == "Block")
            {
                this.t_data_minorType.Items.Clear();
                this.t_data_minorType.Items.AddRange(new object[] {
                "Repeating",
                "Single",
                "Optional"});
                this.t_data_minorType.Sorted = true;
                this.l_data_desc.Text = "";
                this.t_data_desc.Hide();
            }

        }
        private void label5_Click(object sender, EventArgs e)
        {

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


            if (majorType == "Block")
            {
                dataStack = new Stack();

                Data newBlock = protocol.createBlock(name, minorType, info);
                b_add_data.Hide();
                newBlock.drawData(this);
                Button plus = new Button();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
                plus.BackgroundImage = Image.FromFile("C:\\Users\\victorb\\Documents\\GitHubVisualStudio\\Hackaton\\WindowsFormsApplication1\\WindowsFormsApplication1\\plus.png");
                plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                plus.Location = new Point(initialLeft + structureDepth * nodeSize.Width / 4 + nodeSize.Width, initialHeight + (structureIndex - 1) * nodeSize.Height);
                plus.Name = "b_add_data";
                plus.Size = new System.Drawing.Size(20, 20);
                plus.TabIndex = 0;
                plus.Tag = (structureDepth + 1).ToString();
                plus.UseVisualStyleBackColor = true;
                plus.Click += new System.EventHandler(this.b_add_data_Click);
                p_newlayers.Controls.Add(plus);

            }
            else if(majorType == "Field")
            {
                string description = t_data_desc.Text;
                Data newField = protocol.createField(name, minorType, info, description);
                Console.WriteLine(newField.getName());
                b_add_data.Hide();
                newField.drawData(this);
                Button key = new Button();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
                key.BackgroundImage = Image.FromFile("C:\\Users\\victorb\\Documents\\GitHubVisualStudio\\Hackaton\\WindowsFormsApplication1\\WindowsFormsApplication1\\key.png");
                key.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                key.Location = new Point(initialLeft + structureDepth * nodeSize.Width / 3 + nodeSize.Width, initialHeight + structureIndex * nodeSize.Height);
                key.Name = "b_add_data";
                key.Size = new System.Drawing.Size(20, 20);
                key.TabIndex = 0;
                key.Tag = (structureDepth + 1).ToString();
                key.UseVisualStyleBackColor = true;
                key.Click += new System.EventHandler(this.b_add_data_Click);
                p_newlayers.Controls.Add(key);

            }
            
            p_add_new_data.Hide();
        }
    }





}
