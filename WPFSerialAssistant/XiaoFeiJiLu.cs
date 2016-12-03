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
    public partial class XiaoFeiJiLu : UserControl
    {
        public XiaoFeiJiLu()
        {
            InitializeComponent();
        }

        private void XiaoFeiJiLu_Load(object sender, EventArgs e)
        {
            string ConnectionString = "server=.;database=fingerprintUser;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string sql = "select *from cost";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder sqlcommand = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            skinDataGridView1.DataSource = ds.Tables[0];
            string[] str ={"学号",
                             "消费金额",
                             "日期",
                             "余额"
                         };
            for (int Bui = 0; Bui < skinDataGridView1.Columns.Count; Bui++)
            {
                skinDataGridView1.Columns[Bui].SortMode = DataGridViewColumnSortMode.NotSortable;
                skinDataGridView1.Columns[Bui].HeaderText = str[Bui];
            }

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (skinWaterTextBox2.Text != "")
            {
                string id = skinWaterTextBox2.Text;
                string ConnectionString = "server=.;database=fingerprintUser;Integrated Security=SSPI;";
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                string sql = "select *from cost where id='" + id + "'";
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    SqlCommandBuilder sqlcommand = new SqlCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    skinDataGridView1.DataSource = ds.Tables[0];
                    for (int Bui = 0; Bui < skinDataGridView1.Columns.Count; Bui++)
                    {
                        skinDataGridView1.Columns[Bui].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(" " + E);
                }
            }
            else
            {
                MessageBox.Show("请输入学号ID！");
            }
        }
    }
}
