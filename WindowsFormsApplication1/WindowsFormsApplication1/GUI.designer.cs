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

        internal void drawData(DelimField delimField)
        {
            throw new NotImplementedException();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.p_menu = new System.Windows.Forms.Panel();
            this.b_show = new System.Windows.Forms.Button();
            this.l_protocols = new System.Windows.Forms.Label();
            this.cb_protocolsList = new System.Windows.Forms.ComboBox();
            this.p_view = new System.Windows.Forms.Panel();
            this.l_notes = new System.Windows.Forms.Label();
            this.p_properties = new System.Windows.Forms.Panel();
            this.link_source = new System.Windows.Forms.LinkLabel();
            this.l_protocolName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.p_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // p_menu
            // 
            this.p_menu.Controls.Add(this.b_show);
            this.p_menu.Controls.Add(this.l_protocols);
            this.p_menu.Controls.Add(this.cb_protocolsList);
            this.p_menu.Location = new System.Drawing.Point(9, 56);
            this.p_menu.Name = "p_menu";
            this.p_menu.Size = new System.Drawing.Size(166, 83);
            this.p_menu.TabIndex = 0;
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
            this.p_view.Size = new System.Drawing.Size(539, 522);
            this.p_view.TabIndex = 1;
            // 
            // l_notes
            // 
            this.l_notes.AutoSize = true;
            this.l_notes.Location = new System.Drawing.Point(726, 39);
            this.l_notes.Name = "l_notes";
            this.l_notes.Size = new System.Drawing.Size(38, 13);
            this.l_notes.TabIndex = 3;
            this.l_notes.Text = "Notes:";
            // 
            // p_properties
            // 
            this.p_properties.BackColor = System.Drawing.Color.White;
            this.p_properties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_properties.Location = new System.Drawing.Point(729, 54);
            this.p_properties.Name = "p_properties";
            this.p_properties.Size = new System.Drawing.Size(256, 522);
            this.p_properties.TabIndex = 2;
            // 
            // link_source
            // 
            this.link_source.AutoSize = true;
            this.link_source.Location = new System.Drawing.Point(185, 38);
            this.link_source.Name = "link_source";
            this.link_source.Size = new System.Drawing.Size(41, 13);
            this.link_source.TabIndex = 1;
            this.link_source.TabStop = true;
            this.link_source.Text = "Source";
            // 
            // l_protocolName
            // 
            this.l_protocolName.AutoSize = true;
            this.l_protocolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_protocolName.Location = new System.Drawing.Point(184, 15);
            this.l_protocolName.Name = "l_protocolName";
            this.l_protocolName.Size = new System.Drawing.Size(126, 20);
            this.l_protocolName.TabIndex = 0;
            this.l_protocolName.Text = "Protocol Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(883, 2);
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
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(782, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "ProtoShark";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 588);
            this.Controls.Add(this.link_source);
            this.Controls.Add(this.l_protocolName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.l_notes);
            this.Controls.Add(this.p_view);
            this.Controls.Add(this.p_properties);
            this.Controls.Add(this.p_menu);
            this.Name = "GUI";
            this.Text = "ProtoShark";
            this.p_menu.ResumeLayout(false);
            this.p_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Panel p_properties;
        private System.Windows.Forms.Label l_notes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

