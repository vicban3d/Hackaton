using System;

namespace ProtoShark
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.t_data_majorType = new System.Windows.Forms.ComboBox();
            this.p_menu = new System.Windows.Forms.Panel();
            this.b_create = new System.Windows.Forms.Button();
            this.b_show = new System.Windows.Forms.Button();
            this.l_protocols = new System.Windows.Forms.Label();
            this.cb_protocolsList = new System.Windows.Forms.ComboBox();
            this.p_view = new System.Windows.Forms.Panel();
            this.l_notes = new System.Windows.Forms.Label();
            this.link_source = new System.Windows.Forms.LinkLabel();
            this.l_protocolName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_desc = new System.Windows.Forms.TextBox();
            this.p_create = new System.Windows.Forms.Panel();
            this.p_newlayers = new System.Windows.Forms.Panel();
            this.b_add_data = new System.Windows.Forms.Button();
            this.p_newprotocol = new System.Windows.Forms.Panel();
            this.tb_title = new System.Windows.Forms.TextBox();
            this.l_description = new System.Windows.Forms.Label();
            this.tb_source = new System.Windows.Forms.TextBox();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.l_title = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.l_source = new System.Windows.Forms.Label();
            this.l_protocolDesc = new System.Windows.Forms.Label();
            this.p_add_new_data = new System.Windows.Forms.Panel();
            this.b_add_data_filled = new System.Windows.Forms.Button();
            this.t_data_info = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.l_data_desc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.t_data_minorType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_data_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.t_data_desc = new System.Windows.Forms.TextBox();
            this.tv_data_tree = new System.Windows.Forms.TreeView();
            this.p_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.p_create.SuspendLayout();
            this.p_newlayers.SuspendLayout();
            this.p_newprotocol.SuspendLayout();
            this.p_add_new_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // t_data_majorType
            // 
            this.t_data_majorType.FormattingEnabled = true;
            this.t_data_majorType.Items.AddRange(new object[] {
            "Block",
            "Field"});
            this.t_data_majorType.Location = new System.Drawing.Point(69, 32);
            this.t_data_majorType.Name = "t_data_majorType";
            this.t_data_majorType.Size = new System.Drawing.Size(162, 21);
            this.t_data_majorType.TabIndex = 10;
            this.t_data_majorType.SelectedIndexChanged += new System.EventHandler(this.t_data_majorType_SelectedIndexChanged);
            // 
            // p_menu
            // 
            this.p_menu.Controls.Add(this.b_create);
            this.p_menu.Controls.Add(this.b_show);
            this.p_menu.Controls.Add(this.l_protocols);
            this.p_menu.Controls.Add(this.cb_protocolsList);
            this.p_menu.Location = new System.Drawing.Point(9, 56);
            this.p_menu.Name = "p_menu";
            this.p_menu.Size = new System.Drawing.Size(166, 117);
            this.p_menu.TabIndex = 0;
            // 
            // b_create
            // 
            this.b_create.Location = new System.Drawing.Point(64, 82);
            this.b_create.Name = "b_create";
            this.b_create.Size = new System.Drawing.Size(98, 30);
            this.b_create.TabIndex = 4;
            this.b_create.Text = "Create >>";
            this.b_create.UseVisualStyleBackColor = true;
            this.b_create.Click += new System.EventHandler(this.b_create_Click);
            // 
            // b_show
            // 
            this.b_show.Location = new System.Drawing.Point(64, 46);
            this.b_show.Name = "b_show";
            this.b_show.Size = new System.Drawing.Size(99, 30);
            this.b_show.TabIndex = 2;
            this.b_show.Text = "Show >>";
            this.b_show.UseVisualStyleBackColor = true;
            this.b_show.Click += new System.EventHandler(this.b_show_Click);
            // 
            // l_protocols
            // 
            this.l_protocols.AutoSize = true;
            this.l_protocols.Location = new System.Drawing.Point(3, 3);
            this.l_protocols.Name = "l_protocols";
            this.l_protocols.Size = new System.Drawing.Size(49, 13);
            this.l_protocols.TabIndex = 1;
            this.l_protocols.Text = "Protocol:";
            // 
            // cb_protocolsList
            // 
            this.cb_protocolsList.FormattingEnabled = true;
            this.cb_protocolsList.Location = new System.Drawing.Point(3, 19);
            this.cb_protocolsList.Name = "cb_protocolsList";
            this.cb_protocolsList.Size = new System.Drawing.Size(160, 21);
            this.cb_protocolsList.TabIndex = 0;
            // 
            // p_view
            // 
            this.p_view.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_view.Location = new System.Drawing.Point(184, 54);
            this.p_view.Name = "p_view";
            this.p_view.Size = new System.Drawing.Size(539, 720);
            this.p_view.TabIndex = 1;
            // 
            // l_notes
            // 
            this.l_notes.AutoSize = true;
            this.l_notes.Location = new System.Drawing.Point(730, 38);
            this.l_notes.Name = "l_notes";
            this.l_notes.Size = new System.Drawing.Size(38, 13);
            this.l_notes.TabIndex = 3;
            this.l_notes.Text = "Notes:";
            // 
            // link_source
            // 
            this.link_source.AutoSize = true;
            this.link_source.Location = new System.Drawing.Point(185, 38);
            this.link_source.Name = "link_source";
            this.link_source.Size = new System.Drawing.Size(0, 13);
            this.link_source.TabIndex = 1;
            // 
            // l_protocolName
            // 
            this.l_protocolName.AutoSize = true;
            this.l_protocolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_protocolName.Location = new System.Drawing.Point(184, 15);
            this.l_protocolName.Name = "l_protocolName";
            this.l_protocolName.Size = new System.Drawing.Size(0, 20);
            this.l_protocolName.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1141, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(1040, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "ProtoShark";
            // 
            // tb_desc
            // 
            this.tb_desc.Location = new System.Drawing.Point(730, 54);
            this.tb_desc.Multiline = true;
            this.tb_desc.Name = "tb_desc";
            this.tb_desc.Size = new System.Drawing.Size(513, 720);
            this.tb_desc.TabIndex = 6;
            // 
            // p_create
            // 
            this.p_create.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_create.Controls.Add(this.p_newlayers);
            this.p_create.Controls.Add(this.p_newprotocol);
            this.p_create.Location = new System.Drawing.Point(184, 54);
            this.p_create.Name = "p_create";
            this.p_create.Size = new System.Drawing.Size(539, 720);
            this.p_create.TabIndex = 2;
            // 
            // p_newlayers
            // 
            this.p_newlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_newlayers.Controls.Add(this.tv_data_tree);
            this.p_newlayers.Controls.Add(this.b_add_data);
            this.p_newlayers.Location = new System.Drawing.Point(4, 4);
            this.p_newlayers.Name = "p_newlayers";
            this.p_newlayers.Size = new System.Drawing.Size(530, 711);
            this.p_newlayers.TabIndex = 9;
            // 
            // b_add_data
            // 
            this.b_add_data.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("b_add_data.BackgroundImage")));
            this.b_add_data.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_add_data.Location = new System.Drawing.Point(4, 5);
            this.b_add_data.Name = "b_add_data";
            this.b_add_data.Size = new System.Drawing.Size(41, 39);
            this.b_add_data.TabIndex = 0;
            this.b_add_data.Tag = "1";
            this.b_add_data.UseVisualStyleBackColor = true;
            this.b_add_data.Click += new System.EventHandler(this.b_add_data_Click);
            // 
            // p_newprotocol
            // 
            this.p_newprotocol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_newprotocol.Controls.Add(this.tb_title);
            this.p_newprotocol.Controls.Add(this.l_description);
            this.p_newprotocol.Controls.Add(this.tb_source);
            this.p_newprotocol.Controls.Add(this.tb_description);
            this.p_newprotocol.Controls.Add(this.l_title);
            this.p_newprotocol.Controls.Add(this.b_save);
            this.p_newprotocol.Controls.Add(this.l_source);
            this.p_newprotocol.Location = new System.Drawing.Point(4, 4);
            this.p_newprotocol.Name = "p_newprotocol";
            this.p_newprotocol.Size = new System.Drawing.Size(530, 164);
            this.p_newprotocol.TabIndex = 8;
            // 
            // tb_title
            // 
            this.tb_title.Location = new System.Drawing.Point(7, 21);
            this.tb_title.Name = "tb_title";
            this.tb_title.Size = new System.Drawing.Size(520, 20);
            this.tb_title.TabIndex = 0;
            // 
            // l_description
            // 
            this.l_description.AutoSize = true;
            this.l_description.Location = new System.Drawing.Point(4, 85);
            this.l_description.Name = "l_description";
            this.l_description.Size = new System.Drawing.Size(60, 13);
            this.l_description.TabIndex = 7;
            this.l_description.Text = "Description";
            // 
            // tb_source
            // 
            this.tb_source.Location = new System.Drawing.Point(7, 62);
            this.tb_source.Name = "tb_source";
            this.tb_source.Size = new System.Drawing.Size(520, 20);
            this.tb_source.TabIndex = 1;
            // 
            // tb_description
            // 
            this.tb_description.Location = new System.Drawing.Point(7, 102);
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(520, 20);
            this.tb_description.TabIndex = 6;
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Location = new System.Drawing.Point(4, 5);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(27, 13);
            this.l_title.TabIndex = 2;
            this.l_title.Text = "Title";
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(436, 128);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(91, 30);
            this.b_save.TabIndex = 5;
            this.b_save.Text = "Create";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // l_source
            // 
            this.l_source.AutoSize = true;
            this.l_source.Location = new System.Drawing.Point(4, 45);
            this.l_source.Name = "l_source";
            this.l_source.Size = new System.Drawing.Size(41, 13);
            this.l_source.TabIndex = 3;
            this.l_source.Text = "Source";
            // 
            // l_protocolDesc
            // 
            this.l_protocolDesc.Location = new System.Drawing.Point(315, 15);
            this.l_protocolDesc.Name = "l_protocolDesc";
            this.l_protocolDesc.Size = new System.Drawing.Size(408, 36);
            this.l_protocolDesc.TabIndex = 7;
            // 
            // p_add_new_data
            // 
            this.p_add_new_data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_add_new_data.Controls.Add(this.b_add_data_filled);
            this.p_add_new_data.Controls.Add(this.t_data_info);
            this.p_add_new_data.Controls.Add(this.label6);
            this.p_add_new_data.Controls.Add(this.l_data_desc);
            this.p_add_new_data.Controls.Add(this.label4);
            this.p_add_new_data.Controls.Add(this.t_data_minorType);
            this.p_add_new_data.Controls.Add(this.label3);
            this.p_add_new_data.Controls.Add(this.t_data_majorType);
            this.p_add_new_data.Controls.Add(this.t_data_name);
            this.p_add_new_data.Controls.Add(this.label2);
            this.p_add_new_data.Controls.Add(this.t_data_desc);
            this.p_add_new_data.Location = new System.Drawing.Point(730, 55);
            this.p_add_new_data.Name = "p_add_new_data";
            this.p_add_new_data.Size = new System.Drawing.Size(503, 148);
            this.p_add_new_data.TabIndex = 1;
            // 
            // b_add_data_filled
            // 
            this.b_add_data_filled.Location = new System.Drawing.Point(6, 113);
            this.b_add_data_filled.Name = "b_add_data_filled";
            this.b_add_data_filled.Size = new System.Drawing.Size(98, 30);
            this.b_add_data_filled.TabIndex = 5;
            this.b_add_data_filled.Text = "<< Add";
            this.b_add_data_filled.UseVisualStyleBackColor = true;
            this.b_add_data_filled.Click += new System.EventHandler(this.b_add_data_filled_Click);
            // 
            // t_data_info
            // 
            this.t_data_info.Location = new System.Drawing.Point(69, 87);
            this.t_data_info.Name = "t_data_info";
            this.t_data_info.Size = new System.Drawing.Size(162, 20);
            this.t_data_info.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Info";
            // 
            // l_data_desc
            // 
            this.l_data_desc.AutoSize = true;
            this.l_data_desc.Location = new System.Drawing.Point(241, 8);
            this.l_data_desc.Name = "l_data_desc";
            this.l_data_desc.Size = new System.Drawing.Size(0, 13);
            this.l_data_desc.TabIndex = 15;
            this.l_data_desc.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Minor Type";
            // 
            // t_data_minorType
            // 
            this.t_data_minorType.FormattingEnabled = true;
            this.t_data_minorType.Location = new System.Drawing.Point(69, 59);
            this.t_data_minorType.Name = "t_data_minorType";
            this.t_data_minorType.Size = new System.Drawing.Size(162, 21);
            this.t_data_minorType.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Major Type";
            // 
            // t_data_name
            // 
            this.t_data_name.Location = new System.Drawing.Point(69, 5);
            this.t_data_name.Name = "t_data_name";
            this.t_data_name.Size = new System.Drawing.Size(162, 20);
            this.t_data_name.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name";
            // 
            // t_data_desc
            // 
            this.t_data_desc.Location = new System.Drawing.Point(238, 24);
            this.t_data_desc.Multiline = true;
            this.t_data_desc.Name = "t_data_desc";
            this.t_data_desc.Size = new System.Drawing.Size(259, 83);
            this.t_data_desc.TabIndex = 18;
            // 
            // tv_data_tree
            // 
            this.tv_data_tree.Location = new System.Drawing.Point(-1, -1);
            this.tv_data_tree.Name = "tv_data_tree";
            this.tv_data_tree.Size = new System.Drawing.Size(528, 577);
            this.tv_data_tree.TabIndex = 1;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1255, 786);
            this.Controls.Add(this.p_add_new_data);
            this.Controls.Add(this.l_protocolDesc);
            this.Controls.Add(this.p_create);
            this.Controls.Add(this.tb_desc);
            this.Controls.Add(this.link_source);
            this.Controls.Add(this.l_protocolName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.l_notes);
            this.Controls.Add(this.p_view);
            this.Controls.Add(this.p_menu);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProtoShark";
            this.p_menu.ResumeLayout(false);
            this.p_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.p_create.ResumeLayout(false);
            this.p_newlayers.ResumeLayout(false);
            this.p_newprotocol.ResumeLayout(false);
            this.p_newprotocol.PerformLayout();
            this.p_add_new_data.ResumeLayout(false);
            this.p_add_new_data.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_menu;
        private System.Windows.Forms.Button b_show;
        private System.Windows.Forms.Label l_protocols;
        private System.Windows.Forms.ComboBox cb_protocolsList;
        private System.Windows.Forms.Panel p_view;
        private System.Windows.Forms.LinkLabel link_source;
        private System.Windows.Forms.Label l_protocolName;
        private System.Windows.Forms.Label l_notes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_desc;
        private System.Windows.Forms.Button b_create;
        private System.Windows.Forms.Panel p_create;
        private System.Windows.Forms.Label l_source;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.TextBox tb_source;
        private System.Windows.Forms.TextBox tb_title;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Label l_protocolDesc;
        private System.Windows.Forms.Label l_description;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.Panel p_newprotocol;
        private System.Windows.Forms.Panel p_newlayers;
        private System.Windows.Forms.Button b_add_data;
        private System.Windows.Forms.Panel p_add_new_data;
        private System.Windows.Forms.TextBox t_data_info;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l_data_desc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox t_data_minorType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_add_data_filled;
        private System.Windows.Forms.TextBox t_data_desc;
        private System.Windows.Forms.TextBox t_data_name;
        private System.Windows.Forms.ComboBox t_data_majorType;
        private System.Windows.Forms.TreeView tv_data_tree;
    }
}

