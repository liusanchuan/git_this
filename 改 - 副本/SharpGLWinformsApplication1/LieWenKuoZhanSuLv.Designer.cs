namespace SharpGLWinformsApplication1
{
    partial class LieWenKuoZhanSuLv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LieWenKuoZhanSuLv));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1_D_Kth = new System.Windows.Forms.TextBox();
            this.textBox2_E = new System.Windows.Forms.TextBox();
            this.textBox3_KC_max = new System.Windows.Forms.TextBox();
            this.textBox4_KC_min = new System.Windows.Forms.TextBox();
            this.textBox5_Kc = new System.Windows.Forms.TextBox();
            this.textBox1_a0 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gold;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(594, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = ":";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(507, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "生成结果";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.Location = new System.Drawing.Point(740, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1_D_Kth
            // 
            this.textBox1_D_Kth.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox1_D_Kth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1_D_Kth.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1_D_Kth.Location = new System.Drawing.Point(646, 85);
            this.textBox1_D_Kth.Name = "textBox1_D_Kth";
            this.textBox1_D_Kth.Size = new System.Drawing.Size(100, 30);
            this.textBox1_D_Kth.TabIndex = 4;
            this.textBox1_D_Kth.Text = "37.6";
            this.textBox1_D_Kth.TextChanged += new System.EventHandler(this.textBox1_D_Kth_TextChanged);
            // 
            // textBox2_E
            // 
            this.textBox2_E.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox2_E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2_E.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2_E.Location = new System.Drawing.Point(646, 127);
            this.textBox2_E.Name = "textBox2_E";
            this.textBox2_E.Size = new System.Drawing.Size(100, 30);
            this.textBox2_E.TabIndex = 5;
            this.textBox2_E.Text = "69.6";
            this.textBox2_E.TextChanged += new System.EventHandler(this.textBox2_E_TextChanged);
            // 
            // textBox3_KC_max
            // 
            this.textBox3_KC_max.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox3_KC_max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3_KC_max.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3_KC_max.Location = new System.Drawing.Point(646, 169);
            this.textBox3_KC_max.Name = "textBox3_KC_max";
            this.textBox3_KC_max.Size = new System.Drawing.Size(100, 30);
            this.textBox3_KC_max.TabIndex = 6;
            this.textBox3_KC_max.Text = "500";
            this.textBox3_KC_max.TextChanged += new System.EventHandler(this.textBox3_KC_max_TextChanged);
            // 
            // textBox4_KC_min
            // 
            this.textBox4_KC_min.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox4_KC_min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4_KC_min.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4_KC_min.Location = new System.Drawing.Point(646, 211);
            this.textBox4_KC_min.Name = "textBox4_KC_min";
            this.textBox4_KC_min.Size = new System.Drawing.Size(100, 30);
            this.textBox4_KC_min.TabIndex = 7;
            this.textBox4_KC_min.Text = "200";
            this.textBox4_KC_min.TextChanged += new System.EventHandler(this.textBox4_KC_min_TextChanged);
            // 
            // textBox5_Kc
            // 
            this.textBox5_Kc.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox5_Kc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5_Kc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox5_Kc.Location = new System.Drawing.Point(646, 254);
            this.textBox5_Kc.Name = "textBox5_Kc";
            this.textBox5_Kc.Size = new System.Drawing.Size(100, 30);
            this.textBox5_Kc.TabIndex = 8;
            this.textBox5_Kc.Text = "33";
            this.textBox5_Kc.TextChanged += new System.EventHandler(this.textBox5_Kc_TextChanged);
            // 
            // textBox1_a0
            // 
            this.textBox1_a0.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox1_a0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1_a0.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1_a0.Location = new System.Drawing.Point(646, 296);
            this.textBox1_a0.Name = "textBox1_a0";
            this.textBox1_a0.Size = new System.Drawing.Size(100, 30);
            this.textBox1_a0.TabIndex = 9;
            this.textBox1_a0.Text = "5";
            this.textBox1_a0.TextChanged += new System.EventHandler(this.textBox1_a0_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 460);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LieWenKuoZhanSuLv
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 460);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1_a0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5_Kc);
            this.Controls.Add(this.textBox4_KC_min);
            this.Controls.Add(this.textBox3_KC_max);
            this.Controls.Add(this.textBox2_E);
            this.Controls.Add(this.textBox1_D_Kth);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LieWenKuoZhanSuLv";
            this.Text = "LieWenKuoZhanSuLv";
            this.Load += new System.EventHandler(this.LieWenKuoZhanSuLv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1_D_Kth;
        private System.Windows.Forms.TextBox textBox2_E;
        private System.Windows.Forms.TextBox textBox3_KC_max;
        private System.Windows.Forms.TextBox textBox4_KC_min;
        private System.Windows.Forms.TextBox textBox5_Kc;
        private System.Windows.Forms.TextBox textBox1_a0;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}