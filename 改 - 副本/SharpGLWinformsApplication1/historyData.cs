        using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

namespace SharpGLWinformsApplication1
{
    public partial class historyData : UserControl
    {
        public historyData()
        {
            InitializeComponent();
        }




        //private string ConnectionString = "server=.;database=PlatformFlawBase;Integrated Security=SSPI;";

        private string ConnectionString=null;
        
        private SqlConnection conn = null;
        //private SqlCommand cmd = null;
        private string sql = null;
        private DataSet ds = null;
        private SqlDataAdapter da = null;
        string[] titleName =
        {
            "加注/发射",
            "时间"
        };
  

        private void historyData_Load(object sender, EventArgs e)
        {

            ds = new DataSet();
            sqlConnection sqlstring = new sqlConnection();
            ConnectionString = sqlstring.getconn();
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            sql = "SELECT * FROM LData";
            // 创建数据适配器
            da = new SqlDataAdapter(sql, conn);
            // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            for (int Bui = 0; Bui < dataGridView1.Columns.Count; Bui++)
            {
                dataGridView1.Columns[Bui].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (Bui < 2)
                {
                    dataGridView1.Columns[Bui].HeaderCell.Value = titleName[Bui];
                }
            }
            conn.Close();
            RefreshDataGridView();

        }

        //查找数据
        private void button1_Click_1(object sender, EventArgs e)
        {
            dataSelect();
        }
        private void dataSelect(){
           //ConnectionString = "Data Source=MS-20160121SCPS;Initial Catalog=PlatformFlawBase;"
           //     + "Persist Security Info=True;User ID=sa;Password=zf19891014";
            try
            {
                ds = new DataSet();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                sql = "SELECT * FROM LData ";
                string condition = "";

                if (dateTimePicker1.Text != "" && dateTimePicker2.Text != "")
                {
                    condition = " LaunchTime BETWEEN " + "'" + dateTimePicker1.Value.Date.ToString("yyyy/MM/dd") + "'" + "AND" + "'" + dateTimePicker2.Value.Date.ToString("yyyy/MM/dd") + "'";
                }
              if (comboBox3.Text != ""&&comboBox3.Text!="全部")
              {
                  if (condition.Length > 0)
                  {
                      condition += " AND AddOrFly = " + "'" + comboBox3.Text + "'";
                  }
                  else
                  {
                      condition = " AddOrFly = " + "'" + comboBox3.Text + "'";
                  }
              }
 
                if (condition != "")
                    sql += " where " + condition;
                
                da = new SqlDataAdapter(sql, conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                conn.Close();
                
       
            }
            catch (Exception E)
            {
                MessageBox.Show("查找数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
        private void RefreshDataGridView(){
            string mystr = comboBox2.Text;
            if (mystr != "")
            {
                for (int i = 2; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].Visible = false;
                }


                for (int Cedian = 1; Cedian < 11; Cedian++)
                {
                    string str;
                    if (Cedian < 10)
                    {
                        str = "测点0" + Cedian;
                    }
                    else
                    {
                        str = "测点" + Cedian;
                    }

                    if (mystr == str)
                    {
                        dataGridView1.Columns[Cedian + 1].Visible = true;
                        dataGridView1.Columns[Cedian + 11].Visible = true;
                    }
                }
            }
            //chart1.Series.Clear();
            int seriesNum = 0;
            Double[][] series=new Double[2][];


            
            for (int i = 2; i < dataGridView1.ColumnCount; i++)
            {
                if (dataGridView1.Columns[i].Visible == true)
                {
                    series[seriesNum] = new Double[dataGridView1.Rows.Count];
                    int[] X = new int[dataGridView1.Rows.Count];
                    for (int F = 0; F < dataGridView1.Rows.Count; F++)
                    {
                            if (dataGridView1.Rows[F].Cells[i].Value == null)
                            {
                                continue;
                            }
                            series[seriesNum][F] = Convert.ToDouble(dataGridView1.Rows[F].Cells[i].Value);
                            X[F] = F;

                    }
                    chart1.ChartAreas[0].AxisX.Maximum = 30;
                    chart1.Series[seriesNum].Points.DataBindXY(X, series[seriesNum]);
                    seriesNum++;
                    if (seriesNum >1)
                    {
                        break;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSelect();
            RefreshDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {

            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请选择数据目录");
                    return;
                }
                try
                {
                    String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=" + textBox1.Text + ";" +
                    "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                    //实例化一个Oledbconnection类(实现了IDisposable,要using)
                    using (OleDbConnection ole_conn = new OleDbConnection(sConnectionString))
                    {
                        ole_conn.Open();
                        DataSet ds = new DataSet();
                        using (OleDbCommand ole_cmd = ole_conn.CreateCommand())
                        {
                            //类似SQL的查询语句这个[Sheet1$对应Excel文件中的一个工作表]
                            ole_cmd.CommandText = "select * from [Sheet1$]";
                            OleDbDataAdapter adapter = new OleDbDataAdapter(ole_cmd);

                            adapter.Fill(ds, "Sheet1");
                            dataGridView2.DataSource = ds.Tables[0].DefaultView;
                            sqlConnection sqlstring = new sqlConnection();
                            //string str = "server=.;database=PlatformFlawBase;Integrated Security=SSPI;";
                            string str = sqlstring.getconn();
                            SqlConnection con = new SqlConnection(str); //创建连接对象
                            con.Open(); //打开连接
                            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
                            bulkcopy.DestinationTableName = "dbo.LData";
                            bulkcopy.WriteToServer(ds.Tables[0]);
                            MessageBox.Show("添加信息成功！");
                        }
                    }
                    dataSelect();
                    RefreshDataGridView();
                }
                catch (Exception E)
                {
                    MessageBox.Show("添加未成功:" + E);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
                MessageBoxButtons messagebutton = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show("点击确认将会清空所有的信息", "请谨慎操作", messagebutton);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    SqlConnection sqlcon = new SqlConnection(ConnectionString);
                    sqlcon.Open();
                    string sqlstring = "truncate table LData";
                    SqlCommand sqlcom = sqlcon.CreateCommand();
                    sqlcom.CommandText = sqlstring;
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();

                }
                dataSelect();
                RefreshDataGridView();
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.FileName = Environment.SpecialFolder.MyComputer.ToString();
            FD.InitialDirectory = "C:";
            FD.Filter = "Excel file(*.xls;*.xlsx)|*.xls;*.xlsx";
            if (FD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = FD.FileName;
            }
        }

        private void Rwrite_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            FileFormat ff = new FileFormat();
            ff.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;

            int m;
            for (m = 2; m < dataGridView1.Columns.Count; m++)
            {
                dataGridView1.Columns[m].Visible = true;
            }

            ds = new DataSet();
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            sql = "SELECT * FROM LData";
            // 创建数据适配器
            da = new SqlDataAdapter(sql, conn);
            // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();

            /* int i, j;
             i = 0;
             j = 3;
             for (i = 0; i < dataGridView1.RowCount - 1; i++)
             {

                 for (j = 4; j < 23; j++)
                 {
                     if (j >= 3 && j <= 12)
                     {
                         string str = dataGridView1.Rows[i].Cells[j].Value.ToString();
                         if (str != "" && Convert.ToDouble(str) > 20)
                             dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                     }
                     if (j >= 13 && j <= 23)
                     {
                         string str = dataGridView1.Rows[i].Cells[j].Value.ToString();
                         if (str != "" && Convert.ToDouble(str) > 10)
                             dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Blue;
                     }
                 }
             }*/

        }
    
    }   
}


