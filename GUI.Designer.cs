namespace WindowsFormsApplication1
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
            this.p_menu = new System.Windows.Forms.Panel();
            this.b_show = new System.Windows.Forms.Button();
            this.l_protocols = new System.Windows.Forms.Label();
            this.cb_protocolsList = new System.Windows.Forms.ComboBox();
            this.p_view = new System.Windows.Forms.Panel();
            this.link_source = new System.Windows.Forms.LinkLabel();
            this.l_protocolName = new System.Windows.Forms.Label();
            this.p_menu.SuspendLayout();
            this.p_view.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_menu
            // 
            this.p_menu.Controls.Add(this.b_show);
            this.p_menu.Controls.Add(this.l_protocols);
            this.p_menu.Controls.Add(this.cb_protocolsList);
            this.p_menu.Location = new System.Drawing.Point(12, 12);
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
            this.p_view.Controls.Add(this.link_source);
            this.p_view.Controls.Add(this.l_protocolName);
            this.p_view.Location = new System.Drawing.Point(184, 12);
            this.p_view.Name = "p_view";
            this.p_view.Size = new System.Drawing.Size(801, 564);
            this.p_view.TabIndex = 1;
            // 
            // link_source
            // 
            this.link_source.AutoSize = true;
            this.link_source.Location = new System.Drawing.Point(5, 27);
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
            this.l_protocolName.Location = new System.Drawing.Point(4, 4);
            this.l_protocolName.Name = "l_protocolName";
            this.l_protocolName.Size = new System.Drawing.Size(126, 20);
            this.l_protocolName.TabIndex = 0;
            this.l_protocolName.Text = "Protocol Name";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 588);
            this.Controls.Add(this.p_view);
            this.Controls.Add(this.p_menu);
            this.Name = "GUI";
            this.Text = "ProtoShark";
            this.p_menu.ResumeLayout(false);
            this.p_menu.PerformLayout();
            this.p_view.ResumeLayout(false);
            this.p_view.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_menu;
        private System.Windows.Forms.Button b_show;
        private System.Windows.Forms.Label l_protocols;
        private System.Windows.Forms.ComboBox cb_protocolsList;
        private System.Windows.Forms.Panel p_view;
        private System.Windows.Forms.LinkLabel link_source;
        private System.Windows.Forms.Label l_protocolName;
    }
}

