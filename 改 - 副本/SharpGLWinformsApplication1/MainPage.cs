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
    public partial class MainPage : Form
    {
        public  LieWenKuoZhanSuLv mynewform;
           public  FlawAssess Liewenpinggu;
            public  ReliabilityAssess Reliabilityassess;
           public  DataRearch Datasearch ;
           public DataAdd dataadd;
        public void  CloseALL(){
            mynewform.Close();
            Liewenpinggu.Close();
            Reliabilityassess.Close();
            Datasearch.Close();
            dataadd.Close();
        }
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void 实时状态检测_Click(object sender, EventArgs e)
        {
            RealTimeMonitoring Realtimemonitoring = new RealTimeMonitoring();
            Realtimemonitoring.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReliabilityAssess Reliabilityassess = new ReliabilityAssess();
            Reliabilityassess.MdiParent = this;
            Reliabilityassess.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FlawAssess Liewenpinggu = new FlawAssess();
            Liewenpinggu.MdiParent = this;
            Liewenpinggu.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRearch Datasearch = new DataRearch();
            Datasearch.MdiParent = this;
            Datasearch.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataAdd Rearchresult = new DataAdd();
            Rearchresult.MdiParent = this;
            Rearchresult.Show(); 
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            mynewform = new LieWenKuoZhanSuLv();
            Liewenpinggu = new FlawAssess();
            Reliabilityassess = new ReliabilityAssess();
            Datasearch = new DataRearch();
            dataadd = new DataAdd();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MyMainPage myform = new MyMainPage();

            myform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mynewform.MdiParent = this;
            mynewform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LiShuHanShu form = new LiShuHanShu();
            form.MdiParent = this;
            form.ShowDialog();
        }

        private void 可靠性评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reliabilityassess.MdiParent = this;
            //CloseALL();
            Reliabilityassess.Show(); 
        }

        private void 裂纹快速评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Liewenpinggu.MdiParent = this;
            //CloseALL();

            Liewenpinggu.Show(); 
        }

        private void 历史数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datasearch.MdiParent = this;
            //CloseALL();

            Datasearch.Show();
        }

        private void 新增数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataadd.MdiParent = this;
            //CloseALL();

            dataadd.Show();
        }
    }
}
