using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SharpGLWinformsApplication1
{
    public partial class N_LiShuDu : Form
    {
        public string[] name ={
                                 "应力",
                                 "震动",
                                 "形变",
                                 "裂纹",
                                 "材料参数",
                                 "涂层烧蚀量",
                                 "传动阻力",
                                 "电机扭矩",
                                 "制动力矩",
                                 "液压及电控"

                             };
        public int Col = 0;//存储当前 按钮值
        public N_LiShuDu()
        {
            InitializeComponent();
        }
        
        public void ReadXmlToDataGrid()
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < name.Length; i++)
            {
                dt.Columns.Add(name[i]);
            }
            DataRow dt1 = dt.NewRow();
            DataRow dt2 = dt.NewRow();
            DataRow dt3 = dt.NewRow();
            DataRow dt4 = dt.NewRow();
            DataRow dt5 = dt.NewRow();
            DataRow dt6 = dt.NewRow();
            DataRow[] dtrow = { dt1, dt2, dt3, dt4, dt5, dt6 };
            string str = "../Debug/LiShuduBiao400.xml";
            if (XMLConnectionr.str == "800")
                str = "../Debug/LiShuduBiao800.xml";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(str);
            XmlNodeList nodeList = xmldoc.SelectSingleNode("NewXML").ChildNodes;//获取bookstore节点的所有子节点

            int x = 0;
            foreach (XmlNode Xn in nodeList)
            {
                XmlElement xe = (XmlElement)Xn;
                for (int B = 0; B < name.Length; B++)
                {
                    dtrow[x][B] = xe.GetAttribute(name[B]);
                }
                dt.Rows.Add(dtrow[x]);
                x++;

            }
            dataGridView1.DataSource = dt.DefaultView;
        }
        private void N_LiShuDu_Load(object sender, EventArgs e)
        {
            ReadXmlToDataGrid();
            appendValue(0);
        }

        private void appendValue(int Columns)
        {
            //ColorChange(Columns);
            groupBox1.Text ="更改-"+ name[Columns];

            T9.Text = dataGridView1.Rows[0].Cells[Columns].Value.ToString().Trim();
            T7.Text = dataGridView1.Rows[1].Cells[Columns].Value.ToString().Trim();
            T5.Text = dataGridView1.Rows[2].Cells[Columns].Value.ToString().Trim();
            T3.Text = dataGridView1.Rows[3].Cells[Columns].Value.ToString().Trim();
            T1.Text = dataGridView1.Rows[4].Cells[Columns].Value.ToString().Trim();
            T0.Text = dataGridView1.Rows[5].Cells[Columns].Value.ToString().Trim();
            T2.Text = T1.Text;
            T4.Text = T3.Text;
            T6.Text = T5.Text;
            T8.Text = T7.Text;
            
        }
        private void 应力值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Col = 0;
            appendValue(Col);
        }
        private void 震动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Col = 1;
            appendValue(Col);
        }
        private void 形变量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Col = 2;
            appendValue(Col);
        }

        private void 裂纹形位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Col = 3;
            appendValue(Col);
        }

        private void 材料参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Col = 4;
            appendValue(Col);
        }

        private void 涂层烧蚀量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Col = 5;
            appendValue(Col);
        }

        private void 传动阻力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Col = 6;
            appendValue(Col);
        }

        private void 电机扭矩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Col = 7;
            appendValue(Col);
        }

        private void 制动力矩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Col = 8;
            appendValue(Col);
        }

        private void 液压及电控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Col = 9;
            appendValue(Col);
        }

        public void SaveDataGridToXml(int Columns,int Mode)  //Mode分辨是重置(0)还是普通存储(1)
        {
            //定义负相关的参数对应的列
            int[] FuXiangGuan_Columns ={
                                            0,1,2,3,5,6
                                      };
            //定义初始化数组
            Double[] INIT_value = { 0, 12.5, 3 * 12.5, 5 * 12.5, 7 * 12.5, 8 * 12.5, };
            if (Mode == 1)
            { //普通存储模式
                foreach (int i in FuXiangGuan_Columns)
                {
                    if (Columns == i)//负相关
                    {
                        if (Convert.ToDouble(T9.Text) >= Convert.ToDouble(T7.Text) ||
                            Convert.ToDouble(T7.Text) >= Convert.ToDouble(T5.Text) ||
                            Convert.ToDouble(T5.Text) >= Convert.ToDouble(T3.Text) ||
                            Convert.ToDouble(T3.Text) >= Convert.ToDouble(T1.Text) ||
                            Convert.ToDouble(T1.Text) >= Convert.ToDouble(T0.Text)
                            )
                        {
                            MessageBox.Show("输入的数值不在允许范围内！请注意");
                            appendValue(Columns);
                            return;
                        }
                        break;
                    }
                    else//正相关
                    {
                        if (Convert.ToDouble(T9.Text) <= Convert.ToDouble(T7.Text) ||
                            Convert.ToDouble(T7.Text) <= Convert.ToDouble(T5.Text) ||
                            Convert.ToDouble(T5.Text) <= Convert.ToDouble(T3.Text) ||
                            Convert.ToDouble(T3.Text) <= Convert.ToDouble(T1.Text) ||
                            Convert.ToDouble(T1.Text) <= Convert.ToDouble(T0.Text)
                            )
                        {
                            MessageBox.Show("输入的数值不在允许范围内！请注意");
                            appendValue(Columns);
                            return;
                        }
                    }
                }
                dataGridView1.Rows[0].Cells[Columns].Value = T9.Text;
                dataGridView1.Rows[1].Cells[Columns].Value = T7.Text;
                dataGridView1.Rows[2].Cells[Columns].Value = T5.Text;
                dataGridView1.Rows[3].Cells[Columns].Value = T3.Text;
                dataGridView1.Rows[4].Cells[Columns].Value = T1.Text;
                dataGridView1.Rows[5].Cells[Columns].Value = T0.Text;
            }
            else if (Mode == 0)    //********重置*********
            {
                for (Columns = 0; Columns < 10; Columns++)
                {
                    bool ZorF=false;
                    foreach (int C in FuXiangGuan_Columns)
                    {
                        if(Columns == C){
                            ZorF=true;
                        }
                    }
                        if (ZorF==true)//负相关
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                dataGridView1.Rows[i].Cells[Columns].Value = INIT_value[i];
                            }
                        }
                        else
                        {
                            //正相关
                            for (int i = 0; i < 6; i++)
                            {
                                dataGridView1.Rows[i].Cells[Columns].Value = INIT_value[5 - i];
                            }
                        }
                    
                }
            }
            else
            {
                MessageBox.Show("存储模式有误");
                return;
            }

            string str = "../Debug/LiShuduBiao400.xml";
            if (XMLConnectionr.str == "800")
                str = "../Debug/LiShuduBiao800.xml";
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);
            XmlNode rowsNode= doc.CreateElement("NewXML");
            
            doc.AppendChild(rowsNode);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                XmlNode rowNode = doc.CreateElement("row");
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    XmlAttribute rowAttribute = doc.CreateAttribute(dataGridView1.Columns[j].HeaderText);
                    rowAttribute.Value = dataGridView1.Rows[i].Cells[j].Value.ToString().Trim();
                    rowNode.Attributes.Append(rowAttribute);
                    rowsNode.AppendChild(rowNode);
                }
            }
            doc.Save(str);
        }

        private void  ColorChange(int col){

            switch (col){
                case 0:
                    groupBox1.BackColor = 应力值ToolStripMenuItem.BackColor = Color.LightBlue;
                    break;
                case 1:
                    groupBox1.BackColor = 震动ToolStripMenuItem.BackColor = Color.LightCoral; 
                    break;
                case 2:
                    groupBox1.BackColor = 形变量ToolStripMenuItem.BackColor = Color.LightCyan;
                    break;
                case 3:
                    groupBox1.BackColor = 裂纹形位ToolStripMenuItem.BackColor = Color.LightGoldenrodYellow;
                    break;
                case 4:
                    groupBox1.BackColor = 材料参数ToolStripMenuItem.BackColor = Color.LightGray;
                    break;
                case 5:
                    groupBox1.BackColor = 涂层烧蚀量ToolStripMenuItem.BackColor = Color.LightGreen;
                    break;
                case 6:
                    groupBox1.BackColor = 传动阻力ToolStripMenuItem.BackColor = Color.LightPink;
                    break;
                case 7:
                    groupBox1.BackColor = 电机扭矩ToolStripMenuItem.BackColor = Color.LightSalmon;
                    break;
                case 8:
                    groupBox1.BackColor = 制动力矩ToolStripMenuItem.BackColor = Color.LightSeaGreen;
                    break;
                case 9:
                    groupBox1.BackColor = 液压及电控ToolStripMenuItem.BackColor = Color.LightYellow;
                    break;
            }


        }
        private void skinPictureBox9_Click(object sender, EventArgs e)
        {
            SaveDataGridToXml(Col,1);
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                SaveDataGridToXml(i, 0);
            }
            appendValue(Col);
        }

 
    }
}
