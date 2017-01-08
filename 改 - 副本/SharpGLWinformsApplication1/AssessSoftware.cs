﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SharpGLWinformsApplication1
{
    public partial class AssessSoftware : Form
    {
        
        public AssessSoftware()
        {
            InitializeComponent();
           
        }

        public int check()
        {
            int response_num = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load("userInfo.xml");
            XmlNodeList all_user = doc.SelectSingleNode("userInfo").ChildNodes;
            foreach (XmlNode Seted_user in all_user)
            {
                XmlNode user_name = Seted_user.SelectSingleNode("user_name");
                if (textBox1.Text == user_name.InnerText)
                {
                    XmlNode user_password = Seted_user.SelectSingleNode("password");
                    if (user_password.InnerText == textBox2.Text)
                    {
                        response_num = 3;   //登录成功
                    }
                    else
                    {
                        response_num = 2;   //密码错误
                    }
                }
                else
                {
                    response_num = 1;       //无此用户
                }
            }
            return response_num;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int response_num = check();
            if (response_num == 3)
            {




                Main_Form Zhujiemian = new Main_Form();
                Zhujiemian.ShowDialog();
                Zhujiemian.Dispose();
                
            }
            else if (response_num == 2)
            {
                MessageBox.Show("密码错误");
            }
            else if (response_num == 1)
            {
                MessageBox.Show("此用户名未注册");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {
            int Num = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load("userInfo.xml");

            int response_num = check();
            //if (response_num == 3)
            //{
            //    MessageBox.Show("登录成功");
            //}
            //else if (response_num == 2)
            //{
            //    MessageBox.Show("密码错误");
            //}
            //else if (response_num == 1)
            //{
            //    MessageBox.Show("此用户名未注册");
            //}
            if (response_num == 1)
            {
                XmlNode bookstore = doc.SelectSingleNode("userInfo");
                XmlElement user = doc.CreateElement("user");
                user.SetAttribute("ID", Convert.ToString(Num++));
                XmlElement user_name = doc.CreateElement("user_name");
                user_name.InnerText = textBox1.Text;
                XmlElement user_password = doc.CreateElement("password");
                user_password.InnerText = textBox2.Text;
                user.AppendChild(user_name);
                user.AppendChild(user_password);
                bookstore.AppendChild(user);
                doc.Save("userInfo.xml");
                MessageBox.Show("注册成功");
            }
            else
            {
                MessageBox.Show("此用户名已被占用");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Main_Form main = new Main_Form();
            main.Show();
        }
    }
}
