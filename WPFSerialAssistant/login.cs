using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WPFSerialAssistant
{
    public partial class login : Form
    {
        public string sss;
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void costNote(string s)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //groupBox1.Container.
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 用户列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            userAll us = new userAll();
            
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(us);
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUser ad = new addUser();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(ad);
        }

        private void 消费查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XiaoFeiJiLu xfjl = new XiaoFeiJiLu();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(xfjl);
        }

        private void 串口配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WPFSerialAssistant.MainWindow mw = new MainWindow();
            mw.ShowDialog();
  
        }

        private void 充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            saveMoney sm = new saveMoney();
            groupBox1.Controls.Add(sm);
        }
    }
}
