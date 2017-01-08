using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpGLWinformsApplication1
{
    public partial class Main_Form : Form
    {
        public realiable realiable = new realiable();
        public Main_Form()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //e.Graphics.Clear(this.BackColor);

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 可靠性评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realiable.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(realiable);
        }

        private void 裂纹快速评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Liewenpinggu Liewenpinggu = new Liewenpinggu();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(Liewenpinggu);
        }

        private void 历史数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyData hd = new historyData();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(hd);
        }

        private void 扩展速率评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KuoZhanSuLv kuzhan = new KuoZhanSuLv();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(kuzhan);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void skinMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void skinLine1_Click(object sender, EventArgs e)
        {

        }

        private void 添加数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adddata add = new adddata();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(add);
        }
    }
}
