using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WPFSerialAssistant
{
    class IDUS
    {
        public string sql;
        public string ConnectionString = "Integrated Security=SSPI;Initial Catalog=fingerprintUser;Data Source=localhost";
        
        //public void update(string sql){
        //    SqlConnection conn=new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    try
        //    {
        //          sql = "update CrackInfo set repair=1 where [StartPoint X(°)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value + "'" +
        //                "and [StartPoint Y(°)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value + "'" +
        //                    //"and [CrackWidth(mm)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value + "'" +
        //                  "and [CrackDepth(mm)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value + "'" +
        //                    //"and [CrackAngle   (°)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value + "'" +
        //                    "and [CrackLength(mm)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value + "'";
        //                conn = new SqlConnection(ConnectionString);
        //                cmd = new SqlCommand(sql, conn);
        //                conn.Open();
        //                try
        //                {
        //                    cmd.ExecuteNonQuery();
        //                    conn.Close();
        //                    MessageBox.Show("数据更新成功");
        //                }
        //                catch (Exception E)
        //                {
        //                    MessageBox.Show("更新数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //                conn = new SqlConnection(ConnectionString);
        //                cmd = new SqlCommand();
        //                ds = new DataSet();
        //                sql = "SELECT * FROM  CrackInfo "; ;
        //                da = new SqlDataAdapter(sql, conn);
        //                da.Fill(ds, " CrackInfo");
        //                this.dataGridView1.DataSource = ds.Tables[" CrackInfo"].DefaultView;
        //            }

        //        }
        //    }
        //        sql = "select *from users where id='" + cardNum + "' and name='" + name + "'";
        //        conn = new SqlConnection(ConnectionString);


        //        DataSet ds;
        //        SqlDataAdapter da;
        //        ds = new DataSet();
        //        da = new SqlDataAdapter(sql, conn);
        //        da.Fill(ds, "user");
        //        if (ds.Tables["user"].Rows.Count == 0) {
        //            MessageBox.Show("用户名或者学号有误，请重新输入");
        //            skinWaterTextBox1.Text="";
        //            skinWaterTextBox2.Text="";

        //        }
        //        skinDataGridView1.DataSource = ds.Tables["user"];

        //    }
        //    catch (Exception E)
        //    {
        //        MessageBox.Show("查找数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    }
        //}
    }
}
