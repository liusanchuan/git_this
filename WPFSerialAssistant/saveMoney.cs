using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WPFSerialAssistant
{
    public partial class saveMoney : UserControl
    {
        private double lastMoney = 0;
        public saveMoney()
        {
            InitializeComponent();
        }

        //更新
        private void skinButton2_Click(object sender, EventArgs e)
        {

            string name = skinWaterTextBox1.Text;
            string cardNum = skinWaterTextBox2.Text;
            if (skinWaterTextBox3.Text.Trim() == "")
            {
                return;
            }
            double saveMoney = Convert.ToDouble(skinWaterTextBox3.Text.Trim())+lastMoney;
            
            string sql;
            string ConnectionString = "Integrated Security=SSPI;Initial Catalog=fingerprintUser;Data Source=localhost";

            SqlConnection conn;
            SqlCommand cmd;
            try
            {
                //sql = "insert into  users  values('" + Convert.ToDouble(textBox1.Text.Trim()).ToString() + "'," +
                //    "'" + Convert.ToDouble(textBox15.Text.Trim()).ToString() + "'," +
                //    //"'" + Convert.ToDouble(textBox2.Text.Trim()).ToString() + "'," +
                //   "'" + Convert.ToDouble(textBox3.Text.Trim()).ToString() + "'," +
                //    //"'" + Convert.ToDouble(textBox14.Text.Trim()).ToString() + "'," +
                //   "'" + Convert.ToDouble(textBox16.Text.Trim()).ToString() + "',0)";
                sql = "update users set money=" + saveMoney+ " where name='" + name + "'and id='" + cardNum+"'";

                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("数据--更新成功");

            }
            catch (Exception E)
            {
                MessageBox.Show("更新数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            search();
        }


        //查找：
        private void skinButton1_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            string name = skinWaterTextBox1.Text;
            string cardNum = skinWaterTextBox2.Text;
            string sql;
            string ConnectionString = "Integrated Security=SSPI;Initial Catalog=fingerprintUser;Data Source=localhost";
            SqlCommand cmd;
            SqlConnection conn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand();
                sql = "select *from users where id='" + cardNum + "' and name='" + name + "'";
                conn = new SqlConnection(ConnectionString);
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "user");
                string[] str ={"编号",
                             "指纹编号",
                             "姓名",
                             "余额"
                         };

                if (ds.Tables["user"].Rows.Count == 0)
                {
                    MessageBox.Show("用户名或者学号有误，请重新输入");
                    skinWaterTextBox1.Text = "";
                    skinWaterTextBox2.Text = "";
                    return;

                }
                skinDataGridView1.DataSource = ds.Tables["user"];
                for (int Bui = 0; Bui < skinDataGridView1.Columns.Count; Bui++)
                {
                    skinDataGridView1.Columns[Bui].SortMode = DataGridViewColumnSortMode.NotSortable;
                    skinDataGridView1.Columns[Bui].HeaderText = str[Bui];
                    skinDataGridView1.Columns[Bui].FillWeight=100/skinDataGridView1.Columns.Count;

                }
                lastMoney =Convert.ToDouble(skinDataGridView1.Rows[0].Cells["money"].Value);

            }
            catch (Exception E)
            {
                MessageBox.Show("查找数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

           

            //try
            //{
            //    //sql = "insert into  users  values('" + Convert.ToDouble(textBox1.Text.Trim()).ToString() + "'," +
            //    //    "'" + Convert.ToDouble(textBox15.Text.Trim()).ToString() + "'," +
            //    //    //"'" + Convert.ToDouble(textBox2.Text.Trim()).ToString() + "'," +
            //    //   "'" + Convert.ToDouble(textBox3.Text.Trim()).ToString() + "'," +
            //    //    //"'" + Convert.ToDouble(textBox14.Text.Trim()).ToString() + "'," +
            //    //   "'" + Convert.ToDouble(textBox16.Text.Trim()).ToString() + "',0)";
            //    //sql = "select *from users where id='" + cardNum + "' and name='" + name + "'";
            //    sql = "select *from users where id='" + cardNum + "' and name='" + name + "'";

            //    conn = new SqlConnection(ConnectionString);


            //    DataSet ds;
            //    SqlDataAdapter da;
            //    ds = new DataSet();
            //    da = new SqlDataAdapter(sql, conn);
            //    da.Fill(ds, "user");
            //    if (ds.Tables["user"].Rows.Count == 0)
            //    {
            //        MessageBox.Show("用户名或者学号有误，请重新输入");
            //        skinWaterTextBox1.Text = "";
            //        skinWaterTextBox2.Text = "";

            //    }
            //    //ds.Tables["user"].Rows[0]
            //    skinDataGridView1.DataSource = ds.Tables["user"];

            //}catch (Exception E)
            //{
            //    MessageBox.Show("查找数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}

        }


    }
}
