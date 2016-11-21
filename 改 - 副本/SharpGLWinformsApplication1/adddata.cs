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
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlTypes;

namespace SharpGLWinformsApplication1
{
    public partial class adddata : UserControl
    {


        //private string connStr = ConfigurationManager.ConnectionStrings["SharpGLWinformsApplication1.Properties.Settings.PlatformFlawBaseConnectionString"].ConnectionString;
        //private string connStr = "server=.;database=People;Integrated Security=SSPI;";
        private string ConnectionString = "server=.;database=PlatformFlawBase;Integrated Security=SSPI;";
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private string sql = null;
        private DataSet ds = null;
        private SqlDataAdapter da = null;
        public adddata()
        {
            InitializeComponent();
            conn = new SqlConnection(ConnectionString);
        }
        
        private void DataRearch_Load(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
                conn.Close();
            //ConnectionString = "server=.;database=CrackInfo;Integrated Security=SSPI;";
            ds = new DataSet();
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            sql = "SELECT * FROM data";
            da = new SqlDataAdapter(sql, conn);
        }


        
        private void Add_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择数据目录");
                return;
            }
             DataTable table = new DataTable();
            string[] ColumnsName={
                                     "Timestamp",
                                     "S1",
                                     "S2",
                                     "S3",
                                     "S4",
                                     "S5",
                                     "S6",
                                     "S7",
                                     "S8",
                                     "S9",
                                     "S10",
                                     "T1","T2","T3","T4","T5","T6","T7","T8","T9","T10"
                                 };
            for (int i = 0; i < ColumnsName.Length; i++)
            {
                table.Columns.Add(ColumnsName[i], typeof(SqlString));
            }
            //table.Columns.Add("Timestamp", typeof(SqlString));

            //table.Columns.Add("S1", typeof(SqlString));
            //table.Columns.Add("S2", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //table.Columns.Add("S3", typeof(SqlString));
            //DataRow row = table.NewRow();
            //row["id"] = 1;
            //row["name"] = "liutian";
            //row["age"] = 12;
            //row["birthday"] = "20150104";
            //table.Rows.Add(row);
            //dataGridView1.DataSource = table;

            string text = File.ReadAllText(textBox1.Text);
            string[] str1 = text.Split('\n');
            int str1_length = str1.Length;
            for (int i = 3; i < str1_length-2; i++)
            {
                string[] str1_child = str1[i].Split('\t');
                int a=str1_child.Length;
                DataRow row = table.NewRow();
                for (int j = 0; j < ColumnsName.Length; j++)
                {
                    String ac = ColumnsName[j];
                    row[ac]=str1_child[j];
                }
                table.Rows.Add(row);


                //row["id"] = str1_child[0];
                //row["name"] = str1_child[1];
                //row["age"] = str1_child[2];
                //row["birthday"] = str1_child[3];
                //table.Rows.Add(row);
            }
            dataGridView1.DataSource = table;
            string str = "server=.;database=PlatformFlawBase;Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(str); //创建连接对象
            con.Open(); //打开连接
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "dbo.SanChuan";
            bulkcopy.WriteToServer(table);
        
            /*
            if (CheckAssessParameter())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Close();
                //ConnectionString = "Data Source=MS-20160121SCPS;Initial Catalog=PlatformFlawBase;"
                    //+ "Persist Security Info=True;User ID=sa;Password=zf19891014";
           
                sql = "insert into  LData(LaunchTime,AssessedValue,YesOrNo)  values('" + LTime.Value.Date.ToString("yyyy/MM/dd") + "'," +
                        "'" + AssessNumber.Text.Trim() + "'," + "'" + YesOrNo.Text.Trim() + "')";

                /*string fileName = textBox1.Text;
                try
                {
                    //创建内存临时数据表来存储从文本文件中读取出来的数据
                    using (DataTable table = new DataTable())
                    {
                        //使用StreamReader
                        using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
                        {
                            while (!sr.EndOfStream)
                            {
                                DataRow dr = table.NewRow();//创建数据行
                                string readStr = sr.ReadLine();//读取一行数据
                                if (readStr.StartsWith("1"))//去掉标题行
                                {
                                    //将读取的字符串按"制表符/t“和””“分割成数组
                                    string[] strs = readStr.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                                    //string Timestamp = strs[0];
                                    string S1 = strs[1];
                                    string S2 = strs[2];
                                    string S3 = strs[3];
                                    string S4 = strs[4];
                                    string S5 = strs[5];
                                    string S6 = strs[6];
                                    string S7 = strs[7];
                                    string S8 = strs[8];
                                    string S9 = strs[9];
                                    string S10 = strs[10];
                                    string T1 = strs[11];
                                    string T2 = strs[12];
                                    string T3 = strs[13];
                                    string T4 = strs[14];
                                    string T5 = strs[15];
                                    string T6 = strs[16];
                                    string T7 = strs[17];
                                    string T8 = strs[18];
                                    string T9 = strs[19];
                                    string T10 = strs[20];
                                    //往对应的 行中添加数据
                                    // dr["Timestamp"] = Timestamp;
                                    dr["S1"] = S1;
                                    dr["S2"] = S2;
                                    dr["S3"] = S3;
                                    dr["S4"] = S4;
                                    dr["S5"] = S5;
                                    dr["S6"] = S6;
                                    dr["S7"] = S7;
                                    dr["S8"] = S8;
                                    dr["S9"] = S9;
                                    dr["S10"] = S10;
                                    dr["T1"] = T1;
                                    dr["T2"] = T2;
                                    dr["T3"] = T3;
                                    dr["T4"] = T4;
                                    dr["T5"] = T5;
                                    dr["T6"] = T6;
                                    dr["T7"] = T7;
                                    dr["T8"] = T8;
                                    dr["T9"] = T9;
                                    dr["T10"] = T10;
                                    table.Rows.Add(dr);//将创建的数据行添加到table中
                                }
                            }
                        }
                        SqlBulkCopy bulkCopy = new SqlBulkCopy(connStr);
                        bulkCopy.DestinationTableName = "LData";//设置数据库中对象的表名
                        //设置数据表table和数据库中表的列对应关系
                        // bulkCopy.ColumnMappings.Add("Timestamp", "LaunchTime");
                        bulkCopy.ColumnMappings.Add("S1", "S1");
                        bulkCopy.ColumnMappings.Add("S2", "S2");
                        bulkCopy.ColumnMappings.Add("S3", "S3");
                        bulkCopy.ColumnMappings.Add("S4", "S4");
                        bulkCopy.ColumnMappings.Add("S5", "S5");
                        bulkCopy.ColumnMappings.Add("S6", "S6");
                        bulkCopy.ColumnMappings.Add("S7", "S7");
                        bulkCopy.ColumnMappings.Add("S8", "S8");
                        bulkCopy.ColumnMappings.Add("S9", "S9");
                        bulkCopy.ColumnMappings.Add("S10", "S10");
                        bulkCopy.ColumnMappings.Add("T1", "T1");
                        bulkCopy.ColumnMappings.Add("T2", "T2");
                        bulkCopy.ColumnMappings.Add("T3", "T3");
                        bulkCopy.ColumnMappings.Add("T4", "T4");
                        bulkCopy.ColumnMappings.Add("T5", "T5");
                        bulkCopy.ColumnMappings.Add("T6", "T6");
                        bulkCopy.ColumnMappings.Add("T7", "T7");
                        bulkCopy.ColumnMappings.Add("T8", "T8");
                        bulkCopy.ColumnMappings.Add("T9", "T9");
                        bulkCopy.ColumnMappings.Add("T10", "T10");
                        bulkCopy.WriteToServer(table);//将数据表table复制到数据库中
                        MessageBox.Show("共导入" + table.Rows.Count + "条数据:");

                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }*/
            /*
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();*/


                /*string fileName = textBox1.Text;
                try
                {
                    //创建内存临时数据表来存储从文本文件中读取出来的数据
                    using (DataTable table = new DataTable())
                    {
                        //使用StreamReader
                        using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
                        {
                            while (!sr.EndOfStream)
                            {
                                DataRow dr = table.NewRow();//创建数据行
                                string readStr = sr.ReadLine();//读取一行数据
                                if (readStr.StartsWith("1"))//去掉标题行
                                {
                                    //将读取的字符串按"制表符/t“和””“分割成数组
                                    string[] strs = readStr.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                                    //string Timestamp = strs[0];
                                    string S1 = strs[1];
                                    string S2 = strs[2];
                                    string S3 = strs[3];
                                    string S4 = strs[4];
                                    string S5 = strs[5];
                                    string S6 = strs[6];
                                    string S7 = strs[7];
                                    string S8 = strs[8];
                                    string S9 = strs[9];
                                    string S10 = strs[10];
                                    string T1 = strs[11];
                                    string T2 = strs[12];
                                    string T3 = strs[13];
                                    string T4 = strs[14];
                                    string T5 = strs[15];
                                    string T6 = strs[16];
                                    string T7 = strs[17];
                                    string T8 = strs[18];
                                    string T9 = strs[19];
                                    string T10 = strs[20];
                                    //往对应的 行中添加数据
                                   // dr["Timestamp"] = Timestamp;
                                    dr["S1"] = S1;
                                    dr["S2"] = S2;
                                    dr["S3"] = S3;
                                    dr["S4"] = S4;
                                    dr["S5"] = S5;
                                    dr["S6"] = S6;
                                    dr["S7"] = S7;
                                    dr["S8"] = S8;
                                    dr["S9"] = S9;
                                    dr["S10"] = S10;
                                    dr["T1"] = T1;
                                    dr["T2"] = T2;
                                    dr["T3"] = T3;
                                    dr["T4"] = T4;
                                    dr["T5"] = T5;
                                    dr["T6"] = T6;
                                    dr["T7"] = T7;
                                    dr["T8"] = T8;
                                    dr["T9"] = T9;
                                    dr["T10"] = T10;
                                    table.Rows.Add(dr);//将创建的数据行添加到table中
                                }
                            }
                        }
                        SqlBulkCopy bulkCopy = new SqlBulkCopy(connStr);
                        bulkCopy.DestinationTableName = "LData";//设置数据库中对象的表名
                        //设置数据表table和数据库中表的列对应关系
                       // bulkCopy.ColumnMappings.Add("Timestamp", "LaunchTime");
                        bulkCopy.ColumnMappings.Add("S1", "S1");
                        bulkCopy.ColumnMappings.Add("S2", "S2");
                        bulkCopy.ColumnMappings.Add("S3", "S3");
                        bulkCopy.ColumnMappings.Add("S4", "S4");
                        bulkCopy.ColumnMappings.Add("S5", "S5");
                        bulkCopy.ColumnMappings.Add("S6", "S6");
                        bulkCopy.ColumnMappings.Add("S7", "S7");
                        bulkCopy.ColumnMappings.Add("S8", "S8");
                        bulkCopy.ColumnMappings.Add("S9", "S9");
                        bulkCopy.ColumnMappings.Add("S10", "S10");
                        bulkCopy.ColumnMappings.Add("T1", "T1");
                        bulkCopy.ColumnMappings.Add("T2", "T2");
                        bulkCopy.ColumnMappings.Add("T3", "T3");
                        bulkCopy.ColumnMappings.Add("T4", "T4");
                        bulkCopy.ColumnMappings.Add("T5", "T5");
                        bulkCopy.ColumnMappings.Add("T6", "T6");
                        bulkCopy.ColumnMappings.Add("T7", "T7");
                        bulkCopy.ColumnMappings.Add("T8", "T8");
                        bulkCopy.ColumnMappings.Add("T9", "T9");
                        bulkCopy.ColumnMappings.Add("T10", "T10");
                        bulkCopy.WriteToServer(table);//将数据表table复制到数据库中
                        MessageBox.Show("共导入" + table.Rows.Count + "条数据:");

                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }*/

                MessageBox.Show("添加信息成功！");
                //this.Close();
            
        }
        
       

        private bool CheckAssessParameter()
        {
            //if (LTime.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("请输入发射时间");
            //    return false;
            //}


            if (AssessNumber.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入评估值");
                return false;
            }
            else 
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(AssessNumber.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入评估值");
                    return false;

                }
                else   // 输入的是数字
                {

                    if (Convert.ToDecimal(AssessNumber.Text) > 1 || Convert.ToDecimal(AssessNumber.Text) < 0)
                    {
                        MessageBox.Show("请输入0到1之间的数字！");
                        return false;
                    }
                }
            {
            
            }
            }
            
            if (YesOrNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入是否发射");
                return false;
            }
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("请添加发射信息");
                return false;
            }
            return true;
        }

        private void Rwrite_Click(object sender, EventArgs e)
        {
            //LTime.Text = "";
            //AssessNumber.Text = "";
            //YesOrNo.SelectedItem = null;
         }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.FileName = Environment.SpecialFolder.MyComputer.ToString();
            FD.InitialDirectory = "C:";
            FD.Filter = "文本文件(*.txt)|*.txt";
            if (FD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = FD.FileName;
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBoxButtons messagebutton=MessageBoxButtons.YesNo;
            DialogResult result;
            result=MessageBox.Show("点击确认将会清空所有的信息","请谨慎操作",messagebutton);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection sqlcon = new SqlConnection(ConnectionString);
                sqlcon.Open();
                string sqlstring="truncate table SanChuan";
                SqlCommand sqlcom = sqlcon.CreateCommand();
                sqlcom.CommandText=sqlstring;
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();

            }
        }

        private void YesOrNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }









    }
}

