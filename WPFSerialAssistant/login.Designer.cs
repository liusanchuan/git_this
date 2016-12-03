namespace WPFSerialAssistant
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.用户列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.充值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消费查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.skinPictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 390);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Image = global::WPFSerialAssistant.Properties.Resources.deep_login_bg;
            this.skinPictureBox1.Location = new System.Drawing.Point(-12, 0);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(671, 410);
            this.skinPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.skinPictureBox1.TabIndex = 0;
            this.skinPictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户列表ToolStripMenuItem,
            this.添加用户ToolStripMenuItem,
            this.串口配置ToolStripMenuItem,
            this.充值ToolStripMenuItem,
            this.消费查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(672, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 用户列表ToolStripMenuItem
            // 
            this.用户列表ToolStripMenuItem.Image = global::WPFSerialAssistant.Properties.Resources._1186994;
            this.用户列表ToolStripMenuItem.Name = "用户列表ToolStripMenuItem";
            this.用户列表ToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.用户列表ToolStripMenuItem.Text = "用户列表";
            this.用户列表ToolStripMenuItem.Click += new System.EventHandler(this.用户列表ToolStripMenuItem_Click);
            // 
            // 添加用户ToolStripMenuItem
            // 
            this.添加用户ToolStripMenuItem.Image = global::WPFSerialAssistant.Properties.Resources._1186999;
            this.添加用户ToolStripMenuItem.Name = "添加用户ToolStripMenuItem";
            this.添加用户ToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.添加用户ToolStripMenuItem.Text = "添加用户";
            this.添加用户ToolStripMenuItem.Click += new System.EventHandler(this.添加用户ToolStripMenuItem_Click);
            // 
            // 串口配置ToolStripMenuItem
            // 
            this.串口配置ToolStripMenuItem.Image = global::WPFSerialAssistant.Properties.Resources._1187001;
            this.串口配置ToolStripMenuItem.Name = "串口配置ToolStripMenuItem";
            this.串口配置ToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.串口配置ToolStripMenuItem.Text = "串口配置";
            this.串口配置ToolStripMenuItem.Click += new System.EventHandler(this.串口配置ToolStripMenuItem_Click);
            // 
            // 充值ToolStripMenuItem
            // 
            this.充值ToolStripMenuItem.Image = global::WPFSerialAssistant.Properties.Resources._1187004;
            this.充值ToolStripMenuItem.Name = "充值ToolStripMenuItem";
            this.充值ToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.充值ToolStripMenuItem.Text = "充值";
            this.充值ToolStripMenuItem.Click += new System.EventHandler(this.充值ToolStripMenuItem_Click);
            // 
            // 消费查询ToolStripMenuItem
            // 
            this.消费查询ToolStripMenuItem.Image = global::WPFSerialAssistant.Properties.Resources._1187000;
            this.消费查询ToolStripMenuItem.Name = "消费查询ToolStripMenuItem";
            this.消费查询ToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.消费查询ToolStripMenuItem.Text = "消费查询";
            this.消费查询ToolStripMenuItem.Click += new System.EventHandler(this.消费查询ToolStripMenuItem_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(672, 442);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "login";
            this.Text = "指纹刷卡后台管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 串口配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 充值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 消费查询ToolStripMenuItem;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
    }
}