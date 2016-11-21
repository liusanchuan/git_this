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
    public partial class FlawAssess : Form
    {
        private string ConnectionString = "Integrated Security=SSPI;Initial Catalog=PlatformFlawBase;Data Source=localhost";
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private string sql = null;
        private DataSet ds = null;
        private SqlDataAdapter da = null;
        //  private SqlCommandBuilder builder = null;


        public FlawAssess()
        {
            InitializeComponent();
            // 创建一个连接
            conn = new SqlConnection(ConnectionString);
        }
        /**
       * 此方法为将数据库火箭发射平台裂纹库中的裂纹特征表的数据查询出来并放入DataSet中 
      **/
        private void Form1_Load_1(object sender, EventArgs e)
        {
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
            ds.Tables[0].Columns[0].ColumnName= "ID";
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
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
        }

        //计算临界裂纹长度
        private void button2_Click(object sender, EventArgs e)
        {

            textBox7.Text = (Math.Pow(Convert.ToDouble(textBox4.Text) /
                Convert.ToDouble(textBox5.Text) / Convert.ToDouble(textBox6.Text), 2.0) / Math.PI).ToString("f3");

        }
        //计算裂纹长度比值
        private void button5_Click(object sender, EventArgs e)
        {

            if (Convert.ToDouble(textBox7.Text) > 0)
            {
                textBox9.Text = (Convert.ToDouble(textBox8.Text) / Convert.ToDouble(textBox7.Text)).ToString("f3");
                if (Convert.ToDouble(textBox9.Text) >= 1.0)
                {
                    MessageBox.Show("裂纹比值大于1，表面裂纹危险!请尽快处理！");
                }
                else
                {
                    MessageBox.Show("裂纹比值小于1，请根据实际情况处理！");
                }
            }
            else
            {
                MessageBox.Show("分母‘临界裂纹长度’必须为正值！");
            }

        }
        //计算裂纹扩展速率
        private void button10_Click(object sender, EventArgs e)
        {
            textBox12.Text = (Convert.ToDouble(textBox10.Text) *Math.Pow(Convert.ToDouble(textBox13.Text), Convert.ToDouble(textBox11.Text))).ToString("f3");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
