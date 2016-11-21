        using SharpGLWinformsApplication1.Properties;
using System;
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
    public partial class KuoZhanSuLv : UserControl
    {
        public KuoZhanSuLv()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            //double E = 212000, D_kth = 37.6, Kc = 1, KCmax = 1, KCmin = 0, D_KC, D_K, R;
            double E = Convert.ToDouble(textBox2_E.Text);
            double D_kth = Convert.ToDouble(textBox1_D_Kth.Text),
                Kc = Convert.ToDouble(textBox5_Kc.Text), 
                KCmax = Convert.ToDouble(textBox3_KC_max.Text),
                KCmin = Convert.ToDouble(textBox4_KC_min.Text),
                D_KC, D_K, R;
            
            R = KCmax / KCmin;
            double a0 , a1; //积分上下
            a0 = Convert.ToDouble(textBox1_a0.Text);
            a1=(1/Math.PI)*Math.Pow((Kc/(1.12*KCmax)),2);
            double H;  //步长
            double sum = 0;
            H = Math.Abs(a0 - a1) / 10000;
            D_KC = KCmax - KCmin;


            for (double i = 0; i < 10000; i++)
            {
                //double s1 =(double)Math.Pow((a0 + H * i+0.5*H), 2)*H;
                double a = a0 + H * (i + 0.5);
                D_K = D_KC * Math.Sqrt(Math.PI * a);
                double s1 = H * (Math.Pow(E, 2) / 48 * Math.Pow(D_K + D_kth, -0.5) * Math.Pow((1 / D_K - 1 / ((1 - R) * Kc)), 1.5));
                sum += s1;
            }
            label1.Text = Convert.ToString(sum/0.01)+"\n------说明-----\n:此结构还可\n承受"+Convert.ToString((int)sum)+"次冲击";

            XmlDocument doc = new XmlDocument();
            doc.Load(@"E:\program\测评\改 - 副本\SharpGLWinformsApplication1\Resources\historydata.xml");

            XmlElement root = doc.DocumentElement;

             root.SelectNodes("Dome")[0].SelectNodes("D_Kth")[0].InnerText=textBox1_D_Kth.Text;
             root.SelectNodes("Dome")[0].SelectNodes("E")[0].InnerText = textBox2_E.Text;
             root.SelectNodes("Dome")[0].SelectNodes("KC_max")[0].InnerText=textBox3_KC_max.Text;
            root.SelectNodes("Dome")[0].SelectNodes("KC_min")[0].InnerText=textBox4_KC_min.Text ;
            root.SelectNodes("Dome")[0].SelectNodes("a0")[0].InnerText=textBox1_a0.Text ;
            root.SelectNodes("Dome")[0].SelectNodes("Kc")[0].InnerText=textBox5_Kc.Text ;
            doc.Save(@"E:\program\测评\改 - 副本\SharpGLWinformsApplication1\Resources\historydata.xml");
        }

  

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_D_Kth_TextChanged(object sender, EventArgs e)
        {

        }

        private void LieWenKuoZhanSuLv_Load(object sender, EventArgs e)
        {

            //double E = Convert.ToDouble(textBox2_E.Text);
            //double D_kth = Convert.ToDouble(textBox1_D_Kth.Text),
            //    Kc = Convert.ToDouble(textBox5_Kc.Text),
            //    KCmax = Convert.ToDouble(textBox3_KC_max.Text),
            //    KCmin = Convert.ToDouble(textBox4_KC_min.Text),
            //    D_KC, D_K, R;

            //R = KCmax / KCmin;
            //double a0, a1; //积分上下
            //a0 = Convert.ToDouble(textBox1_a0.Text);
            XmlDocument doc = new XmlDocument();
            doc.Load(@"E:\program\测评\改 - 副本\SharpGLWinformsApplication1\Resources\historydata.xml");
            
            XmlElement root = doc.DocumentElement;
            textBox1_D_Kth.Text =root.SelectNodes("Dome")[0].SelectNodes("D_Kth")[0].InnerText;
            textBox2_E.Text = root.SelectNodes("Dome")[0].SelectNodes("E")[0].InnerText;
            textBox3_KC_max.Text = root.SelectNodes("Dome")[0].SelectNodes("KC_max")[0].InnerText;
            textBox4_KC_min.Text = root.SelectNodes("Dome")[0].SelectNodes("KC_min")[0].InnerText;
            textBox1_a0.Text = root.SelectNodes("Dome")[0].SelectNodes("a0")[0].InnerText;
            textBox5_Kc.Text = root.SelectNodes("Dome")[0].SelectNodes("Kc")[0].InnerText;

            label1.Text = root.InnerText;
            label1.Text = root.SelectNodes("Dome")[0].SelectNodes("D_Kth")[0].InnerText;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_E_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KC_max_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KC_min_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Kc_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_a0_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

