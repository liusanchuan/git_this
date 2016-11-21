namespace SharpGLWinformsApplication1
{
    partial class DataAdd
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
            //
            // openFileDialog1
            //
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "launch";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "请选择文件";
            // 
            //button4
            //
            this.button4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(414, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
        }
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AssessData = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AssessNumber = new System.Windows.Forms.TextBox();
            this.LaunchParameter = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.YesOrNo = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.Rwrite = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.LaunchParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // AssessData
            // 
            this.AssessData.AutoSize = true;
            this.AssessData.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AssessData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AssessData.Location = new System.Drawing.Point(29, 70);
            this.AssessData.Name = "AssessData";
            this.AssessData.Size = new System.Drawing.Size(72, 16);
            this.AssessData.TabIndex = 1;
            this.AssessData.Text = "评估值：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(29, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "是否发射：";
            // 
            // AssessNumber
            // 
            this.AssessNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AssessNumber.Location = new System.Drawing.Point(123, 66);
            this.AssessNumber.Name = "AssessNumber";
            this.AssessNumber.Size = new System.Drawing.Size(96, 26);
            this.AssessNumber.TabIndex = 1;
            // 
            // LaunchParameter
            // 
            this.LaunchParameter.Controls.Add(this.dataGridView1);
            this.LaunchParameter.Controls.Add(this.textBox1);
            this.LaunchParameter.Controls.Add(this.YesOrNo);
            this.LaunchParameter.Controls.Add(this.label1);
            this.LaunchParameter.Controls.Add(this.button4);
            this.LaunchParameter.Controls.Add(this.AssessData);
            this.LaunchParameter.Controls.Add(this.label4);
            this.LaunchParameter.Controls.Add(this.AssessNumber);
            this.LaunchParameter.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LaunchParameter.Location = new System.Drawing.Point(12, 15);
            this.LaunchParameter.Name = "LaunchParameter";
            this.LaunchParameter.Size = new System.Drawing.Size(442, 195);
            this.LaunchParameter.TabIndex = 3;
            this.LaunchParameter.TabStop = false;
            this.LaunchParameter.Text = "发射参数";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(225, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(211, 115);
            this.dataGridView1.TabIndex = 22;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1.Location = new System.Drawing.Point(123, 145);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(226, 26);
            this.textBox1.TabIndex = 21;
            // 
            // YesOrNo
            // 
            this.YesOrNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YesOrNo.Font = new System.Drawing.Font("宋体", 12F);
            this.YesOrNo.FormattingEnabled = true;
            this.YesOrNo.Items.AddRange(new object[] {
            "是",
            "否"});
            this.YesOrNo.Location = new System.Drawing.Point(123, 106);
            this.YesOrNo.Name = "YesOrNo";
            this.YesOrNo.Size = new System.Drawing.Size(96, 24);
            this.YesOrNo.TabIndex = 20;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(355, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 26);
            this.button4.TabIndex = 17;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(28, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "发射信息：";
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Add.Location = new System.Drawing.Point(104, 226);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 34);
            this.Add.TabIndex = 4;
            this.Add.Text = "添加";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Rwrite
            // 
            this.Rwrite.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rwrite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Rwrite.Location = new System.Drawing.Point(286, 226);
            this.Rwrite.Name = "Rwrite";
            this.Rwrite.Size = new System.Drawing.Size(75, 34);
            this.Rwrite.TabIndex = 5;
            this.Rwrite.Text = "重置";
            this.Rwrite.UseVisualStyleBackColor = true;
            this.Rwrite.Click += new System.EventHandler(this.Rwrite_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(12, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "清空数据库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(834, 622);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Rwrite);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.LaunchParameter);
            this.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Name = "DataAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加数据";
            this.Load += new System.EventHandler(this.DataAdd_Load);
            this.LaunchParameter.ResumeLayout(false);
            this.LaunchParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label AssessData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AssessNumber;
        private System.Windows.Forms.GroupBox LaunchParameter;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Rwrite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox YesOrNo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}