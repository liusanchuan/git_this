﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace SharpGLWinformsApplication1
{

    class xmlConnection
    {
        public static string str = "../Debug/userInfo.xml";
    }
    class GuanLiYuan
    {
        public static bool ma = false;
    }
    class CanShuBianhuaZhi
    {
        public static Double[] Cal = new Double[20];
        public static Double[] x = new Double[20];
    }
    class XMLConnectionr
    {
        public static string str = "400";
    }
    class sqlConnection
    {
        public string str = "server=.;database=PlatformFlawBase;Integrated Security=SSPI;";
        public string getconn()
        {
            string ConnectionString = str;
            return ConnectionString;
        }

        public string[] Read_SQL_Data(string tableName)
        {
            string[] readdata=null;
            try
            {
                DataSet ds = new DataSet();
                sqlConnection sc = new sqlConnection();

                SqlConnection conn = new SqlConnection(sc.str);
                conn.Open();
                string sql = "SELECT * FROM  "+tableName;
                // 创建数据适配器
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                da.Fill(ds);
                int i = 0;
                readdata = new string[ds.Tables[0].Columns.Count];
                for (i = 0; i < ds.Tables[0].Columns.Count;i++)
                    readdata[i] = ds.Tables[0].Rows[0][i].ToString().Trim();
                
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("--:"+e);
            }
            return readdata;
        }
        public void Save_SQL_Data(string[] SaveData,string tableName)
        {
            try
            {

                string sql = "insert into  "+tableName+"  values('";
                for (int i = 0; i < SaveData.Length; i++)
                {
                    sql += SaveData[i].Trim() + "'";
                    if (i != SaveData.Length-1)
                    {
                        sql += ",'";
                    }
                    else
                    {
                        sql += ")";
                    }
                }

                sqlConnection sc = new sqlConnection();

                SqlConnection conn = new SqlConnection(sc.str);
                SqlCommand cmd = new SqlCommand("delete from " + tableName, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("--:" + e);
            }
        }
    }
}
