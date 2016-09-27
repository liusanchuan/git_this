using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Text;


namespace sqlLearn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label1.Text = "Please input the name of database";

            }else{
                try
                {
                    string ConStr = "server=.;database=" + textBox1.Text.Trim() + ";Integrated Security=SSPI;";
                    SqlConnection conn = new SqlConnection(ConStr);
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        label1.Text = "well connection";
                        conn.Close();
                    }
                }
                catch
                {
                    label1.Text = "fail connection";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"E:\program\测评\改 - 副本\my.txt";
            using (FileStream fs = File.Create(path))
            {
                AddText(fs,"12\t32\n");
                AddText(fs, "34\t45\n");
                AddText(fs, "56\t67\n");
            }
        }
        private static void AddText(FileStream fs, string value)
        {

            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText(@"E:\program\测评\改 - 副本\my.txt");
            string []str1 = text.Split('\n');
            string []str11 = str1[0].Split('\t');
            label2.Text = str11[0];
            label3.Text = str11[1];

            string []str12 = str1[1].Split('\t');
            label4.Text = str12[0];
            label5.Text = str12[1];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            //{
                string str = "server=.;database=People;Integrated Security=SSPI;";

                SqlConnection con = new SqlConnection(str); //创建连接对象
                con.Open(); //打开连接
                

                string strsql = "select * from Person"; // 编写SQL语句
                SqlCommand cmd = new SqlCommand(strsql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                int id = rd.GetOrdinal("ID");
                while (rd.Read())
                {
                    label6.Text="a";
                    label6.Text = label6.Text+rd[id].ToString();
                }
                //SqlDataAdapter da = new SqlDataAdapter(strsql, con); //创建适配器
                //SqlCommandBuilder build = new SqlCommandBuilder(da); //构造SQL语句
                //DataSet ds = new DataSet(); // 创建数据集
                //da.Fill(ds, "datatable"); //填充数据集
                //DataTable tb = ds.Tables["datatable"]; //创建表
                //tb.PrimaryKey = new DataColumn[] { tb.Columns["id"] }; //创建表的主键
                //DataRow row = ds.Tables["datatable"].NewRow(); //创建DataRow
                //row["title"] = "使用DataSet插入新行"; //赋值新列
                //row["id"] = "15";
                //ds.Tables["datatable"].Rows.Add(row);
                //da.Update(ds, "datatable"); 

            //    SqlConnection conn = new SqlConnection(ConStr);
            //    conn.Open();
            //    string sql3 = "update Person set age=age+10 where name='liutian'";
            //    SqlCommand cmd = new SqlCommand(sql3,conn);
            //    label6.Text += cmd.ExecuteReader();
            //if (con.State == ConnectionState.Open)
            //{
            //    label1.Text = "well connection";
            //    con.Close();

            //}
            //}
            //catch
            //{
            //    label1.Text = "fail connection";
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(SqlString));

            table.Columns.Add("name", typeof(SqlString));
            table.Columns.Add("age", typeof(SqlString));
            table.Columns.Add("birthday", typeof(SqlString));
            //DataRow row = table.NewRow();
            //row["id"] = "1";
            //row["name"] = "liutian";
            //row["age"] = "12";
            //row["birthday"] = "20150104";
            //table.Rows.Add(row);
            //dataGridView1.DataSource = table;

            string text = File.ReadAllText(@"E:\阿.txt");
            string[] str1 = text.Split('\n');
            int str1_length = str1.Length;
            for (int i = 0; i < str1_length; i++)
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                Byte[] encodedBytes = utf8.GetBytes(";");
                String decodedString = utf8.GetString(encodedBytes);
                char FenHao = decodedString[0];
            
                string[] str1_child = str1[i].Split(new char[]{'\t'});
                DataRow row = table.NewRow();
                string sstr1_child = str1_child[0];
                row["id"] = sstr1_child;
                row["name"] = sstr1_child=str1_child[1];
                row["age"] =sstr1_child= str1_child[2];
                row["birthday"] =sstr1_child= str1_child[3];
                table.Rows.Add(row);
            }
            dataGridView1.DataSource = table;
            string str = "server=.;database=People;Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(str); //创建连接对象
            con.Open(); //打开连接
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "dbo.pe";
            bulkcopy.WriteToServer(table);
        }

        //public static string get_uft8(string unicodeString)
        //{
        //    //UTF8Encoding utf8 = new UTF8Encoding();
        //    //Byte[] encodedBytes = utf8.GetBytes(unicodeString);
        //    //String decodedString = utf8.GetString(encodedBytes);
        //    //return decodedString;
        //    UTF8Encoding utf8 = new UTF8Encoding();
        //    Byte[] encodedBytes = utf8.GetBytes(";");
        //    String decodedString = utf8.GetString(encodedBytes);
        //    char FenHao = decodedString[0];
        //}
        private void button6_Click(object sender, EventArgs e)
        {
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

            string text = File.ReadAllText(@"E:\program\测评\Sensors.20160612182433.txt");
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
        }


    }
}
