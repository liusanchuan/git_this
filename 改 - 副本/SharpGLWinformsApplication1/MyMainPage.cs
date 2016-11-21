using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpGLWinformsApplication1
{
    public partial class MyMainPage : Form
    {

        int[,] Position = new int[,]{
                {0,70},
                {130,-85},
                {-65,-150},
                {135,165},
                {0,0},
    {0,0},{0,0},{0,0}
            };
        int count=4;    //表示现在有多少列数据，当增加时，多一条裂纹数据
        int[] pencolor=new int[]{0,0,0,0,0,0,0,0};

        DataTable dt = new DataTable("Liewen");
        public MyMainPage()
        {
            InitializeComponent();
            
            dt.Columns.Add("ID");
            dt.Columns.Add("X(坐标)");
            dt.Columns.Add("Y(坐标)");
            dt.Columns.Add("已修复");
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] linX ={
                             new Point(0,250),
                             new Point(500,250)
                         };
            Point[] LinY ={
                             new Point(250,0),
                             new Point(250,500)
                         };
            Pen P = new Pen(Color.Red, 3);
            g.DrawLine(Pens.Red, linX[0], linX[1]);
            g.DrawLine(Pens.Red, LinY[0], LinY[1]);

            g.DrawLine(Pens.Red, new Point(500,250),new Point(490,240));
            g.DrawLine(Pens.Red, new Point(500,250),new Point(490,260));

            int zuobiao = 0;
            for (int x = 0; x < 50; x++)
            {

                g.DrawLine(Pens.Red, new Point(250, x* 10), new Point(255, x * 10));

                g.DrawLine(Pens.Red, new Point( x * 10,250), new Point(x * 10,245));


                if (zuobiao % 5 == 0)
                {
                    if (-x + 25 != 0)
                    {
                        g.DrawString(Convert.ToString(-x + 25), new Font("微软雅黑", 7), Brushes.Red, 225, x * 10 - 5);
                    }
                    g.DrawString(Convert.ToString(x- 25), new Font("微软雅黑", 7), Brushes.Red, x * 10 , 250);
                }
                zuobiao++;

            }
                //Rectangle ellipseRec=new Rectangle(-5,-5,5,5);

                //g.DrawEllipse(P, ellipseRec);
                //Random random=new Random();
                draw_4_circle(g);
        }
        private void draw_4_circle(Graphics g)
        {
            for (int i = 0; i < count; i++)
            {
                DrawCircle(g, Position[i, 0], Position[i, 1], Convert.ToString(i + 1), pencolor[i]);
            }
        }
        private void DrawCircle(Graphics g, int x, int y,string s,int pencolor)
        {
            x+=250;
            y=-y+250;
            g.TranslateTransform(x, y);
            Pen IPen = new Pen(Color.Blue, 3);
            if (pencolor == 0)
            {
                IPen.Color = Color.Blue;
                g.DrawEllipse(IPen, -20, -20, 20, 20);
                //pictureBox1.Refresh();
                g.DrawString(s, new Font("微软雅黑", 18), Brushes.Blue, 0, -20);

            }
            else
            {
                IPen.Color = Color.Red;

                g.DrawEllipse(IPen, -25, -25, 25, 25);
                //pictureBox1.Refresh();
                g.DrawString(s, new Font("微软雅黑", 18), Brushes.Red, 0, -20);
            }

            //pictureBox1.Refresh();
            g.ResetTransform();
        }

        private void MyMainPage_Load(object sender, EventArgs e)
        {

           int i = 0;
           for (; i <count;i++)
           {
               DataRow dr1 = dt.NewRow();
               dr1[0] = 1+i;
               dr1[1] = Position[i, 0];
               dr1[2] = Position[i, 1];
               dr1[3] = "否";
               dt.Rows.Add(dr1);
           }
           //for (int i = 0; i < 4; i++)
           //{

           //    dr1[0] = i+1;
           //    dr1[1] = Position[i, 0];
           //    dr1[2] = Position[i, 1];
           //    dt.Rows.Add(dr1);
           //}
           dataGridView2.DataSource = dt.DefaultView;
           //dataGridView2.ReadOnly = true;
           //dataGridView2.AllowUserToAddRows = true;
           //dataGridView2.AllowUserToResizeRows = false;
            //dataGridView2.Refresh();

            string str = "server=.;database=PlatformFlawBase;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(str);
            string sqlqury = "select S1,S2,S3 from SanChuan;";
            conn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sqlqury, conn);
            DataSet ds = new DataSet();   //dataset相当于临时的数据库，里面可以存放很多的table，
            sdr.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;    //默认存放于table【0】中
            //button1.Text = Convert.ToString(da[0]);     //显示类型转换，
            Double[] series1 = new Double[100];
            int[] X = new int[100];
            for (int F = 0; F < 100; F++)
            {
                DataRow da = ds.Tables[0].Rows[F];          //可以按照行row[0],列colum[0],第二列第一行colum[2][1]来取，所取得为一个datarow数组，然后再取此数组中的某一行            
                series1[F] = Convert.ToDouble(da[0]);

                X[F] = F;
            }
            //chart1.ChartAreas[0].AxisY.Minimum = 28.35;
            chart1.ChartAreas[0].AxisX.Maximum = 30;

            chart1.Series[0].Points.DataBindXY(X, series1);
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
        
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            object i=dataGridView2.CurrentCell.Value;
            object j = dataGridView2.CurrentRow.Cells["ID"].Value;  //获取当前行的ID值
            object S_F = dataGridView2.CurrentRow.Cells["已修复"].Value;
            if (Convert.ToString(S_F)=="否")
            {
                var result= MessageBox.Show("            是否此裂纹已修复：","修改" ,MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    dataGridView2.CurrentRow.Cells["已修复"].Value="是";
                }
            }
            label1.Text = Convert.ToString(j);
            int id = Convert.ToInt32(j)-1;
            for (int c = 0; c < count; c++)
            {
                if (c == id)
                {
                    pencolor[c] = 1;
                }
                else
                {
                    pencolor[c] = 0;
                }
            }
            pictureBox1.Refresh();
            //Label la=new Label();
            //la.Text=Convert.ToString(i);
            //la.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show("请输入X和Y");
            }
            else
            {
                count++;
                Position[count - 1, 0] = Convert.ToInt32(textBox1.Text);
                Position[count - 1, 1] = Convert.ToInt32(textBox2.Text);
            }
            pictureBox1.Refresh();


            //int i = 0;
            //for (; i < count; i++)
            //{
            //    DataRow dr1 = dt.NewRow();
            //    dr1[0] = 1 + i;
            //    dr1[1] = Position[i, 0];
            //    dr1[2] = Position[i, 1];
            //    dr1[3] = "否";
            //    dt.Rows.Add(dr1);
            //}
            
                DataRow dr1 = dt.NewRow();
                dr1[0] = count;
                dr1[1] = Position[count-1, 0];
                dr1[2] = Position[count-1, 1];
                dr1[3] = "否";
                dt.Rows.Add(dr1);
            
            dataGridView2.DataSource = dt.DefaultView;

            //dataGridView2.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

