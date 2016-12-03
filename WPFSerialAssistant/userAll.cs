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
    public partial class userAll : UserControl
    {
        public userAll()
        {
            InitializeComponent();
        }

        private void userAll_Load(object sender, EventArgs e)
        {
            //skinDataGridView1.DataSource
            string ConnectionString = "server=.;database=fingerprintUser;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string sql = "select *from users";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder sqlcommand = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            skinDataGridView1.DataSource = ds.Tables[0];

            //for (int XFJL = 0; XFJL < skinDataGridView1.Rows.Count; XFJL++)
            //{
            //    int id=Convert.ToInt32(skinDataGridView1.Rows[XFJL].Cells["id"].Value);
            //    for(int i=0;i<12;i++){
            //        Random r1=new Random(10);
            //        //sql = "insert into  users (id,fingerId,name,money) values('" + cardNum + "','" + 0 + "','" + name + "','" + money + "')";
            //        int lost=17*i/2;
            //        int cost = 15 - i;
            //        sql = "insert into cost values(" + id + "," + cost + ",'" + System.DateTime.Today.ToString("D")+"',"+lost+")";
            //        conn = new SqlConnection(ConnectionString);
            //        SqlCommand cmd = new SqlCommand(sql, conn);
            //        conn.Open();
            //        try
            //        {
            //            cmd.ExecuteNonQuery();
            //            conn.Close();
            //        }
            //        catch (Exception E)
            //        {
            //            MessageBox.Show("is:"+E);
            //        }
            //    }
            //}
            string[] str ={"编号",
                             "指纹编号",
                             "姓名",
                             "余额"
                         };
                for (int Bui = 0; Bui < skinDataGridView1.Columns.Count; Bui++)
                {
                    skinDataGridView1.Columns[Bui].SortMode = DataGridViewColumnSortMode.NotSortable;
                    //skinDataGridView1.Columns[Bui].FillWeight = 100 / skinDataGridView1.Columns.Count;
                    skinDataGridView1.Columns[Bui].HeaderText = str[Bui];
                }
        }

        private void skinDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = Convert.ToString(skinDataGridView1.CurrentRow.Cells["id"].Value);

            WPFSerialAssistant.login lo = new login();
            
            //OnDataChange(this, new DataChangeEventArgs(textBox10.Text, textBox41.Text, textBox42.Text, textBox43.Text, textBox44.Text, textBox45.Text, textBox46.Text, textBox47.Text, textBox48.Text, textBox49.Text));

        }
    }
}
