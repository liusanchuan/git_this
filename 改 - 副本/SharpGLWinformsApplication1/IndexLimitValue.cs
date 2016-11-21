using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace SharpGLWinformsApplication1
{
    public partial class IndexLimitValue : Form
    {
        private HistoryList his = null;
        private string[] array = null;
        public IndexLimitValue()
        {
            InitializeComponent();
            his = new HistoryList();
            InitTextBoxRemind();
        }
        void InitTextBoxRemind()
        {
            array = his.ReadLastHistory("../Debug/HistoryFile/ILV_LastHistory.txt");
            textBox1.Text = array[0];
            textBox2.Text = array[1];
            textBox3.Text = array[2];
            textBox4.Text = array[3];
            textBox5.Text = array[4];
            textBox6.Text = array[5];
            textBox7.Text = array[6];
            textBox8.Text = array[7];
            textBox9.Text = array[8];
        }

        public string TextBox11Text
        {
            set { this.textBox1.Text = value; }
            get { return this.textBox1.Text; }
        }
        public string TextBox12Text
        {
            set { this.textBox2.Text = value; }
            get { return this.textBox2.Text; }
        }
        public string TextBox13Text
        {
            set { this.textBox3.Text = value; }
            get { return this.textBox3.Text; }
        }
        public string TextBox14Text
        {
            set { this.textBox4.Text = value; }
            get { return this.textBox4.Text; }
        }
        public string TextBox15Text
        {
            set { this.textBox5.Text = value; }
            get { return this.textBox5.Text; }
        }
        public string TextBox16Text
        {
            set { this.textBox6.Text = value; }
            get { return this.textBox6.Text; }
        }
        public string TextBox17Text
        {
            set { this.textBox7.Text = value; }
            get { return this.textBox7.Text; }
        }
        public string TextBox18Text
        {
            set { this.textBox8.Text = value; }
            get { return this.textBox8.Text; }
        }
        public string TextBox19Text
        {
            set { this.textBox9.Text = value; }
            get { return this.textBox9.Text; }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (CheckAssessParameter())
        //    {
        //        FileStream fs = File.OpenWrite("../Debug/HistoryFile/ILV_LastHistory.txt");
        //        fs.SetLength(0);
        //        fs.Close();
        //        fs = null;
        //        his.ChangeLastHistory("../Debug/HistoryFile/ILV_LastHistory.txt", textBox1.Text.Trim());
        //        his.ChangeLastHistory("../Debug/HistoryFile/ILV_LastHistory.txt", textBox2.Text.Trim());
        //        his.ChangeLastHistory("../Debug/HistoryFile/ILV_LastHistory.txt", textBox3.Text.Trim());
        //        his.ChangeLastHistory("../Debug/HistoryFile/ILV_LastHistory.txt", textBox4.Text.Trim());
        //        his.ChangeLastHistory("../Debug/HistoryFile/ILV_LastHistory.txt", textBox5.Text.Trim());
        //        his.ChangeLastHistory("../Debug/HistoryFile/ILV_LastHistory.txt", textBox6.Text.Trim());
        //        his.ChangeLastHistory("../Debug/HistoryFile/ILV_LastHistory.txt", textBox7.Text.Trim());
        //        his.ChangeLastHistory("../Debug/HistoryFile/ILV_LastHistory.txt", textBox8.Text.Trim());
        //        his.ChangeLastHistory("../Debug/HistoryFile/ILV_LastHistory.txt", textBox9.Text.Trim());
        //        ReliabilityAssess Reliabilityassess = (ReliabilityAssess)this.Owner;
        //        Reliabilityassess.TextBox1Text = this.textBox1.Text;
        //        Reliabilityassess.TextBox2Text = this.textBox2.Text;
        //        Reliabilityassess.TextBox3Text = this.textBox3.Text;
        //        Reliabilityassess.TextBox4Text = this.textBox4.Text;
        //        Reliabilityassess.TextBox5Text = this.textBox5.Text;
        //        Reliabilityassess.TextBox6Text = this.textBox6.Text;
        //        Reliabilityassess.TextBox7Text = this.textBox7.Text;
        //        Reliabilityassess.TextBox8Text = this.textBox8.Text;
        //        Reliabilityassess.TextBox9Text = this.textBox9.Text;
        //        this.Close();
        //    }
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
       
        private bool CheckAssessParameter()
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入应力极限值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(textBox1.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入应力极限值");
                    return false;
                }
            }

            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入振动极限值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(textBox2.Text, pattern);   // 匹配正则表达式
                if (!m.Success )   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入振动极限值");
                    return false;
                }  
            }

            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入是否形变极限值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(textBox3.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入形变极限值");
                    return false;
                }
            }

            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("请添加裂纹极限值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(textBox4.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入裂纹极限值");
                    return false;
                }
            }

            if (textBox5.Text.Trim().Length == 0)
            {
                MessageBox.Show("请添加材料参数");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(textBox5.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入材料参数");
                    return false;
                }
            }

            if (textBox6.Text.Trim().Length == 0)
            {
                MessageBox.Show("请添加烧蚀量极限值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(textBox6.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入烧蚀量极限值");
                    return false;
                }
            }

            if (textBox7.Text.Trim().Length == 0)
            {
                MessageBox.Show("请添加传动阻力极限值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(textBox7.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确传动阻力极限值");
                    return false;
                }
            }

            if (textBox8.Text.Trim().Length == 0)
            {
                MessageBox.Show("请添加电机扭矩极限值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(textBox8.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入电机扭矩极限值");
                    return false;
                }
            }

            if (textBox8.Text.Trim().Length == 0)
            {
                MessageBox.Show("请添加制动力矩极限值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(textBox9.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入制动力矩极限值");
                    return false;
                }
            }
            return true;
        }
    }
}