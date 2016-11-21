        using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace SharpGLWinformsApplication1
{
    public partial class Liewenpinggu : UserControl
    {
        int[,] Position = new int[100, 100];
    //            {0,70},
    //            {130,-85},
    //            {-65,-150},
    //            {135,165},
    //            {0,0},
    //{0,0},{0,0},{0,0}
            //};
        int CountT=4;    //表示现在有多少列数据，当增加时，多一条裂纹数据
        int[] pencolor=new int[100];

        DataTable dt = new DataTable("Liewen");

        private string ConnectionString = "Integrated Security=SSPI;Initial Catalog=PlatformFlawBase;Data Source=localhost";
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private string sql = null;
        private DataSet ds = null;
        private SqlDataAdapter da = null;
        //  private SqlCommandBuilder builder = null;


        public Liewenpinggu()
        {
            InitializeComponent();
            // 创建一个连接
            conn = new SqlConnection(ConnectionString);
        }
        /**
       * 此方法为将数据库火箭发射平台裂纹库中的裂纹特征表的数据查询出来并放入DataSet中 
      **/
        private void Liewenpinggu_Load(object sender, EventArgs e)
        {
                        dt.Columns.Add("ID");
            dt.Columns.Add("X(坐标)");
            dt.Columns.Add("Y(坐标)");
            dt.Columns.Add("已修复");
            if (conn.State != ConnectionState.Open)
                conn.Close();
            //ConnectionString = "Data Source=MS-20160121SCPS;Initial Catalog=PlatformFlawBase;"
            //    + "Persist Security Info=True;User ID=sa;Password=zf19891014";
            ds = new DataSet();
            
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            sql = "SELECT * FROM  CrackInfo";
            // 创建数据适配器
            da = new SqlDataAdapter(sql, conn);
            // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
            da.Fill(ds);
            //ds.Tables[0].Columns[0].ColumnName= "ID";
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            for(int number=0;number<dataGridView1.Rows.Count;number++){
                Position[number, 0] = Convert.ToInt32(dataGridView1.Rows[number].Cells[0].Value);
                Position[number, 1] = Convert.ToInt32(dataGridView1.Rows[number].Cells[1].Value);
            }
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
            conn.Close();
        }
 

       

        //多条件查询 CrackInfo中信息
        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
                conn.Close();
            //ConnectionString = "Data Source=MS-20160121SCPS;Initial Catalog=PlatformFlawBase;"
            //    + "Persist Security Info=True;User ID=sa;Password=zf19891014";
            try
            {
                ds = new DataSet();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                sql = "SELECT * FROM  CrackInfo ";
                string condition = "";
                if (textBox1.Text.Trim() != "")
                    condition = " [StartPoint X(°)] BETWEEN " + Convert.ToDouble(textBox1.Text) + "-5 AND " + Convert.ToDouble(textBox1.Text) + "+5";
                if (textBox15.Text.Trim() != "")
                {
                    if (condition.Length > 0)
                    {
                        condition += "AND [StartPoint Y(°)] BETWEEN " + Convert.ToDouble(textBox15.Text) + "-5 AND " + Convert.ToDouble(textBox15.Text) + "+5";

                    }
                    else
                    {
                        condition = " [StartPoint Y(°)] BETWEEN " + Convert.ToDouble(textBox15.Text) + "-5 AND " + Convert.ToDouble(textBox15.Text) + "+5";
                    }
                }
                if (textBox2.Text.Trim() != "")
                {
                    if (condition.Length > 0)
                    {
                        condition += "AND [CrackWidth(mm)] BETWEEN " + Convert.ToDouble(textBox2.Text) + "-5 AND " + Convert.ToDouble(textBox2.Text) + "+5";
                    }
                    else
                    {
                        condition = " [CrackWidth(mm)] BETWEEN " + Convert.ToDouble(textBox2.Text) + "-5 AND " + Convert.ToDouble(textBox2.Text) + "+5";
                    }

                }
                if (textBox3.Text.Trim() != "")
                {
                    if (condition.Length > 0)
                    {
                        condition += "AND [CrackDepth(mm)] BETWEEN " + Convert.ToDouble(textBox3.Text) + "-5 AND " + Convert.ToDouble(textBox3.Text) + "+5";
                    }
                    else
                    {
                        condition = " [CrackDepth(mm)] BETWEEN " + Convert.ToDouble(textBox3.Text) + "-5 AND " + Convert.ToDouble(textBox3.Text) + "+5";
                    }
                }
                if (textBox14.Text.Trim() != "")
                {
                    if (condition.Length > 0)
                    {
                        condition += "AND [CrackAngle   (°)] BETWEEN " + Convert.ToDouble(textBox14.Text) + "-5 AND " + Convert.ToDouble(textBox14.Text) + "+5";
                    }
                    else
                    {
                        condition = " [CrackAngle   (°)] BETWEEN " + Convert.ToDouble(textBox14.Text) + "-5 AND " + Convert.ToDouble(textBox14.Text) + "+5";
                    }
                }
                if (condition != "")
                    sql += " where " + condition;
                da = new SqlDataAdapter(sql, conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                int R = dataGridView1.Rows.Count - 1;
                conn.Close();
                if (R == 0)
                {
                    MessageBox.Show("相似裂纹数据查找无效！" ); 
                }
                else
                {
                    MessageBox.Show("已找到相似裂纹" + R + "条！");
                }           
                this.button3.Visible = true;
            }
            catch (Exception E)
            {
                MessageBox.Show("查找数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            pictureBox1.Refresh();
        }

        //插入裂纹数据
        private void button7_Click(object sender, EventArgs e)
        {
            var count = 0;
            if (conn.State != ConnectionState.Open)
                conn.Close();
            //ConnectionString = "Data Source=MS-20160121SCPS;Initial Catalog=PlatformFlawBase;"
            //    + "Persist Security Info=True;User ID=sa;Password=zf19891014";
            foreach (DataGridViewRow v in dataGridView1.Rows)
            {
                if (v.Cells[0].Value != null && v.Cells[1].Value != null && v.Cells[2].Value != null && v.Cells[3].Value != null && v.Cells[4].Value != null && v.Cells[5].Value != null)
                {
                            if (v.Cells[0].Value.ToString().Equals(textBox1.Text.Trim())
                                && v.Cells[1].Value.ToString().Equals(textBox15.Text.Trim())
                                && v.Cells[2].Value.ToString().Equals(textBox2.Text.Trim())
                                && v.Cells[3].Value.ToString().Equals(textBox3.Text.Trim())
                                && v.Cells[4].Value.ToString().Equals(textBox14.Text.Trim())
                                && v.Cells[5].Value.ToString().Equals(textBox16.Text.Trim()))
                                count++;
                        }
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("已存在相同数据");
                        return;
                    }
              
            

            try
            {

                sql = "insert into  CrackInfo  values('" + Convert.ToDouble(textBox1.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(textBox15.Text.Trim()).ToString() + "'," +
                   "'" + Convert.ToDouble(textBox2.Text.Trim()).ToString() + "'," +
                   "'" + Convert.ToDouble(textBox3.Text.Trim()).ToString() + "'," +
                   "'" + Convert.ToDouble(textBox14.Text.Trim()).ToString() + "'," +
                   "'" + Convert.ToDouble(textBox16.Text.Trim()).ToString() + "')";
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("数据插入成功");
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand();
                ds = new DataSet();
                sql = "SELECT * FROM  CrackInfo "; ;
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, " CrackInfo");
                this.dataGridView1.DataSource = ds.Tables[" CrackInfo"].DefaultView;


            }
            catch (Exception E)
            {
                MessageBox.Show("插入数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            pictureBox1.Refresh();

        }
        //删除裂纹数据
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();

                string sql = "delete from  CrackInfo where [StartPoint X(°)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value + "'" +
                    "and [StartPoint Y(°)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value + "'" +
                     "and [CrackWidth(mm)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value + "'" +
                      "and [CrackDepth(mm)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value + "'" +
                       "and [CrackAngle   (°)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value + "'" +
                        "and [CrackLength(mm)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value + "'";
                //cmd.Connection = conn;

                cmd = new SqlCommand(sql, conn);
                // cmd.CommandText = "delete from  CrackInfo where 裂纹长度='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value + "' and 裂纹宽度='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value+ "'";

                cmd.ExecuteNonQuery();
                //  conn.Close();
                MessageBox.Show("数据删除成功");
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand();
                ds = new DataSet();
                sql = "SELECT * FROM  CrackInfo "; ;
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, " CrackInfo");
                this.dataGridView1.DataSource = ds.Tables[" CrackInfo"].DefaultView;


            }
            catch (Exception E)
            {
                MessageBox.Show("删除数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
            pictureBox1.Refresh();
        }

 

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();
            ds = new DataSet();
            sql = "SELECT * FROM  CrackInfo "; ;
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, " CrackInfo");
            this.dataGridView1.DataSource = ds.Tables[" CrackInfo"].DefaultView;
            this.button3.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            //                object i=dataGridView1.CurrentCell.Value;
            //object j = dataGridView2.CurrentRow.Cells["ID"].Value;  //获取当前行的ID值
            //object S_F = dataGridView2.CurrentRow.Cells["已修复"].Value;
            //if (Convert.ToString(S_F)=="否")
            //{
            //    var result= MessageBox.Show("            是否此裂纹已修复：","修改" ,MessageBoxButtons.YesNo);
            //    if (DialogResult.Yes == result)
            //    {
            //        dataGridView2.CurrentRow.Cells["已修复"].Value="是";
            //    }
            //}
            //label1.Text = Convert.ToString(j);
            //int id = Convert.ToInt32(j)-1;
            for (int c = 0; c < dataGridView1.Rows.Count; c++)
            {
                if (c == i)
                {
                    pencolor[c] = 1;
                }
                else
                {
                    pencolor[c] = 0;
                }
            }
            pictureBox1.Refresh();
        }
    }
}


