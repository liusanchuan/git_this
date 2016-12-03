using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WPFSerialAssistant
{
    public partial class addUser : UserControl
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            string name = skinWaterTextBox1.Text;
            string sex = skinWaterTextBox2.Text;
            string cardNum = skinWaterTextBox3.Text;
            string money = skinWaterTextBox4.Text;
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
                sql = "select *from users where id='"+cardNum+"' or name='"+name+"'";
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                
                DataSet ds;
                SqlDataAdapter da;
                ds = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, " CrackInfo");
                if (ds.Tables[" CrackInfo"].Rows.Count > 0)
                {
                    MessageBox.Show("此用户名已注册");
                }
                else
                {
                    try
                    {
                        sql = "insert into  users (id,fingerId,name,money) values('" + cardNum + "','" + 0 + "','" + name + "','" + money + "')";
                        conn = new SqlConnection(ConnectionString);
                        cmd = new SqlCommand(sql, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("数据插入成功");
                        conn = new SqlConnection(ConnectionString);
                        cmd = new SqlCommand();
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("插入数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }


            }
            catch (Exception E)
            {
                MessageBox.Show("插入数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }
    }
}
