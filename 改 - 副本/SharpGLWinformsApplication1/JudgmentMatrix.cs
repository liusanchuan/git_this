using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;

using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System.Globalization;
using MathNet.Numerics.LinearAlgebra.Double;

namespace SharpGLWinformsApplication1
{
    public partial class JudgmentMatrix : Form
    {
        // 定义委托
        // public delegate void DataChangeHandler(string x); 一次可以传递一个string
        public delegate void DataChangeHandler(object sender, DataChangeEventArgs args);
        // 声明事件
        public event DataChangeHandler DataChange;

        // 调用事件函数
        public void OnDataChange(object sender, DataChangeEventArgs args)
        {
            if (DataChange != null)
            {
                DataChange(this, args);
            }
        }
        private HistoryList his = null;
        private string[] array = null;
        public JudgmentMatrix()
        {
            InitializeComponent();
            his = new HistoryList();
            InitTextBoxRemind();
        }
 

        //得到最大特征向量
        public double[] getMaxEigenValues(double[,] array,int x)
        {
            var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            formatProvider.TextInfo.ListSeparator = " ";
            var matrix = DenseMatrix.OfArray(array);
            var evd = matrix.Evd();
            //label1.Text = evd.EigenVectors.ToString("#0.00\t", formatProvider);
            //label2.Text = evd.EigenValues.ToString("N", formatProvider);
            var b = new Complex[x];
            double[] d = new double[3];
            for (int i = 0; i < x; i++)
            {
                var a = evd.EigenValues.AbsoluteMaximumIndex();
                b[i] = evd.EigenVectors[i, a];
                d[i] = b[i].Real;
                //var a0 = evd.EigenValues[0];
                //var a1 = evd.EigenValues[i];
                //label2.Text = evd.EigenValues[i][0].ToString();
                //Console.Write(a0);
            }

            //double d = b[0].Real;

            //string b = Convert.ToString(b[0]);
            //歸一化
            double sum = d.Sum();
            for (var z = 0; z < x; z++)
            {
                d[z] /= sum;
            }

            return d;

        }


        //同步
        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../Debug/Judgemartia.xml");
            foreach (XmlNode Sd in doc.DocumentElement.ChildNodes)
            {
                if (Sd.Name == "b12")
                    Sd.InnerText= textBoxB12.Text;
                if (Sd.Name == "b13")
                    Sd.InnerText= textBoxB13.Text ;
                if (Sd.Name == "b23")
                    Sd.InnerText= textBoxB23.Text;
                if (Sd.Name == "c12")
                    Sd.InnerText= textBoxc12.Text;
                if (Sd.Name == "c13")
                    Sd.InnerText= textBoxc13.Text;
                if (Sd.Name == "c23")
                    Sd.InnerText= textBoxc23.Text;
                if (Sd.Name == "d12")
                    Sd.InnerText= textBoxD12.Text;
                if (Sd.Name == "d13")
                    Sd.InnerText= textBoxD13.Text;
                if (Sd.Name == "d23")
                    Sd.InnerText= textBoxD23.Text;
                if (Sd.Name == "d45")
                    Sd.InnerText= textBoxd45.Text;
                if (Sd.Name == "d46")
                    Sd.InnerText= textBoxd46.Text ;
                if (Sd.Name == "d56")
                    Sd.InnerText= textBoxd56.Text ;
                if (Sd.Name == "c45")
                    Sd.InnerText= textBoxc45.Text ;
                if (Sd.Name == "d78")
                    Sd.InnerText = textBoxD78.Text;
            }
            doc.Save("../Debug/Judgemartia.xml");
            

            // 触发事件， 传递自定义参数
            OnDataChange(this, new DataChangeEventArgs(textBox10.Text, textBox41.Text, textBox42.Text, textBox43.Text, textBox44.Text, textBox45.Text, textBox46.Text, textBox47.Text, textBox48.Text, textBox49.Text));


            //FileStream fs = File.OpenWrite("../Debug/HistoryFile/JM_LastHistory.txt");
            //fs.SetLength(0);
            //fs.Close();
            //fs = null;
            //his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox10.Text.Trim());
            //his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox41.Text.Trim());
            //his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox42.Text.Trim());
            //his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox43.Text.Trim());
            //his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox44.Text.Trim());
            //his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox45.Text.Trim());
            //his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox46.Text.Trim());
            //his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox47.Text.Trim());
            //his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox48.Text.Trim());
            //his.ChangeLastHistory("../Debug/HistoryFile/JM_LastHistory.txt", textBox49.Text.Trim());
            //this.Close();
        }

        private void JudgmentMatrix_Load(object sender, EventArgs e)
        {
            calcul();
        }
        public void calcul(){
            //double[] B_array = new double[3];
            //double[] C_array = new double[5];
            //double[] D_array = new double[10];
            //double[] A_ceng = new double[3];
            //double[] B1_ceng = new double[3];
            //double[] C1_ceng = new double[3];
            //double[] C3_ceng = new double[3];
            //double[] C_ceng = new double[2];
            //double[] C1_ceng = new double[10];
            Dictionary<string,double> dic =new Dictionary<string,double>();



            XmlDocument doc = new XmlDocument();
            doc.Load("../Debug/Judgemartia.xml");


            foreach (XmlNode Sd in doc.DocumentElement.ChildNodes)
            {
                //XmlElement Sd = (XmlElement)single_data;


                //if (Sd.Name == "B1")
                //    B_array[0] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "B2")
                //    B_array[1] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "B3")
                //    B_array[2] = Convert.ToDouble(Sd.InnerText.Trim());


                //if (Sd.Name == "C1")
                //    C_array[0] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "C2")
                //    C_array[1] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "C3")
                //    C_array[2] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "C4")
                //    C_array[3] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "C5")
                //    C_array[4] = Convert.ToDouble(Sd.InnerText.Trim());

                //if (Sd.Name == "D1")
                //    D_array[0] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "D2")
                //    D_array[1] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "D2")
                //    D_array[2] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "D3")
                //    D_array[3] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "D4")
                //    D_array[4] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "D5")
                //    D_array[5] = Convert.ToDouble(Sd.InnerText.Trim());

                //if (Sd.Name == "D6")
                //    D_array[6] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "D7")
                //    D_array[7] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "D8")
                //    D_array[8] = Convert.ToDouble(Sd.InnerText.Trim());
                //if (Sd.Name == "D9")
                //    D_array[9] = Convert.ToDouble(Sd.InnerText.Trim());
                if (Sd.Name == "b12"){
                    textBoxB12.Text = Sd.InnerText.Trim();
                dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "b13"){
                    textBoxB13.Text = Sd.InnerText.Trim();
                dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "b23"){
                    textBoxB23.Text = Sd.InnerText.Trim();
            dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "c12"){
                    textBoxc12.Text = Sd.InnerText.Trim();
        dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "c13"){
                    textBoxc13.Text = Sd.InnerText.Trim();
    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "c23"){
                    textBoxc23.Text = Sd.InnerText.Trim();
dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d12"){
                    textBoxD12.Text = Sd.InnerText.Trim();
dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d13"){
                    textBoxD13.Text = Sd.InnerText.Trim();
dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d23"){
                    textBoxD23.Text = Sd.InnerText.Trim();
dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d45"){
                    textBoxd45.Text = Sd.InnerText.Trim();
dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d46"){
                    textBoxd46.Text = Sd.InnerText.Trim();
dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d56"){
                    textBoxd56.Text = Sd.InnerText.Trim();
dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "c45"){
                    textBoxc45.Text = Sd.InnerText.Trim();
dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d78"){
                    textBoxD78.Text = Sd.InnerText.Trim();
dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
              



                   



            }
            //double[,] B = new double[3, 3]{{1,B_array[0]/B_array[1],B_array[0]/B_array[2]},
            //                            {B_array[1]/B_array[0],1,B_array[1]/B_array[2]},
            //                            {B_array[2]/B_array[0],B_array[2]/B_array[1],1}};
            //double[,] C123 = new double[3, 3]{{1,C_array[0]/C_array[1],C_array[0]/C_array[2]},
            //                            {C_array[1]/C_array[0],1,C_array[1]/C_array[2]},
            //                            {C_array[2]/C_array[0],C_array[2]/C_array[1],1}};
            //double[,] C45 = new double[2, 2]{
            //                                    {1,C_array[3]/C_array[4]},
            //                                    {C_array[4]/C_array[3],1}
            //};
            //double[,] D123 = new double[3, 3]{{1,D_array[0]/D_array[1],D_array[0]/D_array[2]},
            //                            {D_array[1]/D_array[0],1,D_array[1]/D_array[2]},
            //                            {D_array[2]/D_array[0],D_array[2]/D_array[1],1}};
            //double[,] D567 = new double[3, 3]{{1,D_array[4]/D_array[5],D_array[4]/D_array[6]},
            //                            {D_array[5]/D_array[4],1,D_array[5]/D_array[6]},
            //                            {D_array[6]/D_array[4],D_array[6]/D_array[5],1}};
            //double[,] D89 = new double[2, 2]{
            //                                    {1,D_array[7]/D_array[8]},
            //                                    {D_array[8]/D_array[7],1}
            //};


                    double[,] B = new double[3, 3]{{1,dic["b12"],dic["b13"]},
                                        {1/dic["b12"],1,dic["b23"]},
                                        {1/dic["b13"],1/dic["b23"],1}};
            double[,] C123 = new double[3, 3]{{1,dic["c12"],dic["c13"]},
                                        {1/dic["c12"],1,dic["c23"]},
                                        {1/dic["c13"],1/dic["c23"],1}};
            double[,] C45 = new double[2, 2]{
                                                {1,dic["c45"]},
                                                {1/dic["c45"],1}
            };
            double[,] D123 = new double[3, 3]{{1,dic["d12"],dic["d13"]},
                                        {1/dic["d12"],1,dic["d23"]},
                                        {1/dic["d13"],1/dic["d23"],1}};
            double[,] D567 = new double[3, 3]{{1,dic["d45"],dic["d46"]},
                                        {1/dic["d45"],1,dic["d56"]},
                                        {1/dic["d46"],1/dic["d56"],1}};
            double[,] D89 = new double[2, 2]{{1,dic["d78"]},
                                                {1/dic["d78"],1}};
            var Qz_B = getMaxEigenValues(B, 3);//B1層權重
            var Qz_c123 = getMaxEigenValues(C123, 3);
            var Qz_C45 = getMaxEigenValues(C45, 2);
            var Qz_D123 = getMaxEigenValues(D123, 3);
            var Qz_D567 = getMaxEigenValues(D567, 3);
            var Qz_D89 = getMaxEigenValues(D89, 2);
            double[] Final_D = new double[10];
            for (var i = 0; i < 3; i++)
            {
                Final_D[i] = Qz_B[0] * Qz_c123[0] * Qz_D123[i];
                Final_D[i + 4] = Qz_B[0] * Qz_c123[2] * Qz_D567[i];
            }
            Final_D[3] = Qz_B[0] * Qz_c123[1];
            Final_D[7] = Qz_B[1] * Qz_C45[0] * Qz_D89[0];
            Final_D[8] = Qz_B[1] * Qz_C45[0] * Qz_D89[1];
            Final_D[9] = Qz_B[1] * Qz_C45[1];

            textBox10.Text = Final_D[0].ToString("N4");
            textBox41.Text = Final_D[1].ToString("N4");
            textBox42.Text = Final_D[2].ToString("N4");
            textBox43.Text = Final_D[3].ToString("N4");
            textBox44.Text = Final_D[4].ToString("N4");
            textBox45.Text = Final_D[5].ToString("N4");
            textBox46.Text = Final_D[6].ToString("N4");
            textBox47.Text = Final_D[7].ToString("N4");
            textBox48.Text = Final_D[8].ToString("N4");
            textBox49.Text = Final_D[9].ToString("N4");
            textBox50.Text = Qz_B[2].ToString("N4");
        }
        private void button1_Click(object sender, EventArgs e)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("../Debug/Judgemartia.xml");
            foreach (XmlNode Sd in doc.DocumentElement.ChildNodes)
            {
                if (Sd.Name == "b12")
                    Sd.InnerText = textBoxB12.Text;
                if (Sd.Name == "b13")
                    Sd.InnerText = textBoxB13.Text;
                if (Sd.Name == "b23")
                    Sd.InnerText = textBoxB23.Text;
                if (Sd.Name == "c12")
                    Sd.InnerText = textBoxc12.Text;
                if (Sd.Name == "c13")
                    Sd.InnerText = textBoxc13.Text;
                if (Sd.Name == "c23")
                    Sd.InnerText = textBoxc23.Text;
                if (Sd.Name == "d12")
                    Sd.InnerText = textBoxD12.Text;
                if (Sd.Name == "d13")
                    Sd.InnerText = textBoxD13.Text;
                if (Sd.Name == "d23")
                    Sd.InnerText = textBoxD23.Text;
                if (Sd.Name == "d45")
                    Sd.InnerText = textBoxd45.Text;
                if (Sd.Name == "d46")
                    Sd.InnerText = textBoxd46.Text;
                if (Sd.Name == "d56")
                    Sd.InnerText = textBoxd56.Text;
                if (Sd.Name == "c45")
                    Sd.InnerText = textBoxc45.Text;
                if (Sd.Name == "d78")
                    Sd.InnerText = textBoxD78.Text;
            }
            doc.Save("../Debug/Judgemartia.xml");
            calcul();
            //double[] B_array=new double[3];
            //double[] C_array = new double[5];
            //double[] D_array = new double[10];

            //XmlDocument doc=new XmlDocument();
            //doc.Load("../Debug/Judgemartia.xml");
       

            //foreach (XmlNode Sd in doc.DocumentElement.ChildNodes)
            //{
            //    //XmlElement Sd = (XmlElement)single_data;

              
            //    if (Sd.Name == "B1") 
            //        B_array[0]=Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "B2")
            //        B_array[1] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "B3")
            //        B_array[2] = Convert.ToDouble(Sd.InnerText.Trim());


            //    if (Sd.Name == "C1")
            //        C_array[0] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "C2")
            //        C_array[1] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "C3")
            //        C_array[2] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "C4")
            //        C_array[3] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "C5")
            //        C_array[4] = Convert.ToDouble(Sd.InnerText.Trim());

            //    if (Sd.Name == "D1")
            //        D_array[0] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "D2")
            //        D_array[1] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "D2")
            //        D_array[2] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "D3")
            //        D_array[3] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "D4")
            //        D_array[4] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "D5")
            //        D_array[5] = Convert.ToDouble(Sd.InnerText.Trim());

            //    if (Sd.Name == "D6")
            //        D_array[6] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "D7")
            //        D_array[7] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "D8")
            //        D_array[8] = Convert.ToDouble(Sd.InnerText.Trim());
            //    if (Sd.Name == "D9")
            //        D_array[9] = Convert.ToDouble(Sd.InnerText.Trim());

                

            //}
            //double[,] B=new double[3,3]{{1,B_array[0]/B_array[1],B_array[0]/B_array[2]},
            //                            {B_array[1]/B_array[0],1,B_array[1]/B_array[2]},
            //                            {B_array[2]/B_array[0],B_array[2]/B_array[1],1}};
            //double[,] C123 = new double[3, 3]{{1,C_array[0]/C_array[1],C_array[0]/C_array[2]},
            //                            {C_array[1]/C_array[0],1,C_array[1]/C_array[2]},
            //                            {C_array[2]/C_array[0],C_array[2]/C_array[1],1}};
            //double[,] C45 = new double[2, 2]{
            //                                    {1,C_array[3]/C_array[4]},
            //                                    {C_array[4]/C_array[3],1}
            //};
            //double[,] D123 = new double[3, 3]{{1,D_array[0]/D_array[1],D_array[0]/D_array[2]},
            //                            {D_array[1]/D_array[0],1,D_array[1]/D_array[2]},
            //                            {D_array[2]/D_array[0],D_array[2]/D_array[1],1}};
            //double[,] D567 = new double[3, 3]{{1,D_array[4]/D_array[5],D_array[4]/D_array[6]},
            //                            {D_array[5]/D_array[4],1,D_array[5]/D_array[6]},
            //                            {D_array[6]/D_array[4],D_array[6]/D_array[5],1}};
            //double[,] D89 = new double[2, 2]{
            //                                    {1,D_array[7]/D_array[8]},
            //                                    {D_array[8]/D_array[7],1}
            //};

            //var Qz_B=getMaxEigenValues(B, 3);//B1層權重
            //var Qz_c123=getMaxEigenValues(C123, 3);
            //var Qz_C45=getMaxEigenValues(C45, 2);
            //var Qz_D123=getMaxEigenValues(D123, 3);
            //var Qz_D567=getMaxEigenValues(D567, 3);
            //var Qz_D89=getMaxEigenValues(D89,2);
            //double[] Final_D = new double[10];
            //for (var i = 0; i < 3; i++)
            //{
            //    Final_D[i] = Qz_B[0] * Qz_c123[0] * Qz_D123[i];
            //    Final_D[i + 4] = Qz_B[0] * Qz_c123[2] * Qz_D567[i];
            //}
            //Final_D[3] = Qz_B[0] * Qz_c123[1];
            //Final_D[7] = Qz_B[1] * Qz_C45[0] * Qz_D89[0];
            //Final_D[8] = Qz_B[1] * Qz_C45[0] * Qz_D89[1];
            //Final_D[9] = Qz_B[1] * Qz_C45[1] ;

            //textBox10.Text = Final_D[0].ToString("N4");
            //textBox41.Text = Final_D[1].ToString("N4");
            //textBox42.Text = Final_D[2].ToString("N4");
            //textBox43.Text = Final_D[3].ToString("N4");
            //textBox44.Text = Final_D[4].ToString("N4");
            //textBox45.Text = Final_D[5].ToString("N4");
            //textBox46.Text = Final_D[6].ToString("N4");
            //textBox47.Text = Final_D[7].ToString("N4");
            //textBox48.Text = Final_D[8].ToString("N4");
            //textBox49.Text = Final_D[9].ToString("N4");
            //textBox50.Text = Qz_B[2].ToString("N4");
        //    string str="";
        //    double summary=0;
        //    for(var o=0;o<10;o++){
        //        summary += Final_D[o];
        //        str=str+ Final_D[o].ToString()+"-";
        //}
        //    summary += Qz_B[2];
        //        textBox10.Text =summary.ToString()+":"+str; //B_array.ToString() + C_array.ToString() + D_array.ToString();

        }

        public string TextBox01Text
        {
            set { this.textBox10.Text = value; }
            get { return this.textBox10.Text; }
        }
        public string TextBox02Text
        {
            set { this.textBox41.Text = value; }
            get { return this.textBox41.Text; }
        }
        public string TextBox03Text
        {
            set { this.textBox42.Text = value; }
            get { return this.textBox42.Text; }
        }
        public string TextBox04Text
        {
            set { this.textBox43.Text = value; }
            get { return this.textBox43.Text; }
        }
        public string TextBox05Text
        {
            set { this.textBox44.Text = value; }
            get { return this.textBox44.Text; }
        }
        public string TextBox06Text
        {
            set { this.textBox45.Text = value; }
            get { return this.textBox45.Text; }
        }
        public string TextBox07Text
        {
            set { this.textBox46.Text = value; }
            get { return this.textBox46.Text; }
        }
        public string TextBox08Text
        {
            set { this.textBox47.Text = value; }
            get { return this.textBox47.Text; }
        }
        public string TextBox09Text
        {
            set { this.textBox48.Text = value; }
            get { return this.textBox48.Text; }
        }
        public string TextBox10Text
        {
            set { this.textBox49.Text = value; }
            get { return this.textBox49.Text; }
        }
        public string TextBox11Text
        {
            set { this.textBox50.Text = value; }
            get { return this.textBox50.Text; }
        }

        void InitTextBoxRemind()
        {
            calcul();

            //array = his.ReadLastHistory("../Debug/HistoryFile/JM_LastHistory.txt");
            //textBox10.Text = array[0];
            //textBox41.Text = array[1];
            //textBox42.Text = array[2];
            //textBox43.Text = array[3];
            //textBox44.Text = array[4];
            //textBox45.Text = array[5];
            //textBox46.Text = array[6];
            //textBox47.Text = array[7];
            //textBox48.Text = array[8];
            //textBox49.Text = array[9];
            //array = his.ReadLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt");
            //textBoxB12.Text = array[0];
            //textBoxB13.Text = array[1];
            //textBoxB23.Text = array[2];
            //textBoxc12.Text = array[3];
            //textBoxc13.Text = array[4];
            //textBoxc23.Text = array[5];
            //textBoxD12.Text = array[6];
            //textBoxd45.Text = array[7];
            //textBoxd46.Text = array[8];
            //textBoxd56.Text = array[9];
            //textBoxc45.Text = array[10];
            //textBoxD78.Text = array[11];
        }

        //private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //{

        //    if (e.Action == TreeViewAction.ByMouse)
        //    {
        //        if (e.Node.Name == "节点1")
        //        {
        //            tabControl1.SelectedTab = tabPage1;
        //        }
        //        else if (e.Node.Name == "节点2")
        //        {
        //            tabControl1.SelectedTab = tabPage2;
        //        }
        //        else if (e.Node.Name == "节点3")
        //        {
        //            tabControl1.SelectedTab = tabPage3;
        //        }
        //        else if (e.Node.Name == "节点4")
        //        {
        //            tabControl1.SelectedTab = tabPage4;
        //        }
        //        else if (e.Node.Name == "节点5")
        //        {
        //            tabControl1.SelectedTab = tabPage5;
        //        }
        //        else if (e.Node.Name == "节点6")
        //        {
        //            tabControl1.SelectedTab = tabPage6;
        //        }
        //    }

        //}


        private void textBox2_TextChanged(object sender, EventArgs e)   //B12
        {
            check_Num(this.textBoxB12, this.textBox4);
        }
        //b13
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxB13, this.textBox7);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxB23, this.textBox8);
        }



        
        //private void button_Click(object sender, EventArgs e)

        //{

      
        //    FileStream fs = File.OpenWrite("../Debug/HistoryFile/JM1_LastHistory.txt");
        //    fs.SetLength(0);
        //    fs.Close();
        //    fs = null;
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxB12.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxB13.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxB23.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxc12.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxc13.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxc23.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxD12.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxd45.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxd46.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxd56.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxc45.Text.Trim());
        //    his.ChangeLastHistory("../Debug/HistoryFile/JM1_LastHistory.txt", textBoxc78.Text.Trim());
        //    if (!CheckMatrix())
        //        return;
        //    //计算A层判断矩阵
        //    double[][] a = new double[3][];
        //    a[0] = new double[] { 1, double.Parse(textBoxB12.Text.Trim()), double.Parse(textBoxB13.Text.Trim()) };
        //    a[1] = new double[] { double.Parse(textBox4.Text.Trim()), 1, double.Parse(textBoxB23.Text.Trim()) };
        //    a[2] = new double[] { double.Parse(textBox7.Text.Trim()), double.Parse(textBox8.Text.Trim()), 1 };

        //    double[] q = normalize(a);//求特征向量
        //    textBox10.Text = Convert.ToDouble(q[2]).ToString("0.000");

        //    //计算B1层判断矩阵
        //    double[][] b = new double[3][];
        //    b[0] = new double[] { 1, double.Parse(textBoxc12.Text.Trim()), double.Parse(textBoxc13.Text.Trim()) };
        //    b[1] = new double[] { double.Parse(textBox14.Text.Trim()), 1, double.Parse(textBoxc23.Text.Trim()) };
        //    b[2] = new double[] { double.Parse(textBox18.Text.Trim()), double.Parse(textBox19.Text.Trim()), 1 };

        //    double[] w = normalize(b);//求特征向量
        //    textBox43.Text = Convert.ToDouble(q[0] * w[1]).ToString("0.000");

        //    //计算C1层判断矩阵
        //    double[][] c = new double[2][];
        //    c[0] = new double[] { 1, double.Parse(textBoxD12.Text.Trim()) };
        //    c[1] = new double[] { double.Parse(textBox22.Text.Trim()), 1 };
        //    double[] r = normal(c);//求特征向量
        //    textBox41.Text = Convert.ToDouble(q[0] * w[0] * r[0]).ToString("0.000");
        //    textBox42.Text = Convert.ToDouble(q[0] * w[0] * r[1]).ToString("0.000");

        //    //计算C3层判断矩阵
        //    double[][] d = new double[3][];
        //    d[0] = new double[] { 1, double.Parse(textBoxd45.Text.Trim()), double.Parse(textBoxd46.Text.Trim()) };
        //    d[1] = new double[] { double.Parse(textBox27.Text.Trim()), 1, double.Parse(textBoxd56.Text.Trim()) };
        //    d[2] = new double[] { double.Parse(textBox31.Text.Trim()), double.Parse(textBox32.Text.Trim()), 1 };
        //    double[] t = normalize(d);//求特征向量
        //    textBox44.Text = Convert.ToDouble(q[0] * w[2] * t[0]).ToString("0.000");
        //    textBox45.Text = Convert.ToDouble(q[0] * w[2] * t[1]).ToString("0.000");
        //    textBox46.Text = Convert.ToDouble(q[0] * w[2] * t[2]).ToString("0.000");

        //    //计算B2层判断矩阵
        //    double[][] f = new double[2][];
        //    f[0] = new double[] { 1, double.Parse(textBoxc45.Text.Trim()) };
        //    f[1] = new double[] { double.Parse(textBox34.Text.Trim()), 1 };
        //    double[] y = normal(f);//求特征向量
        //    textBox49.Text = Convert.ToDouble(q[1] * y[1]).ToString("0.000");

        //    //计算C4层判断矩阵
        //    double[][] g = new double[2][];
        //    g[0] = new double[] { 1, double.Parse(textBoxc45.Text.Trim()) };
        //    g[1] = new double[] { double.Parse(textBox34.Text.Trim()), 1 };
        //    double[] u = normal(g);//求特征向量
        //    textBox47.Text = Convert.ToDouble(q[1] * y[0] * u[0]).ToString("0.000");
        //    textBox48.Text = Convert.ToDouble(q[1] * y[0] * u[1]).ToString("0.000");
           

        //}

        private bool CheckMatrix()
        {
            if (textBoxB12.Text.Trim().Length == 0 || textBoxB13.Text.Trim().Length == 0 || textBoxB23.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查A层判断矩阵");
                return false;
            }
            if (textBoxc12.Text.Trim().Length == 0 || textBoxc13.Text.Trim().Length == 0 || textBoxc23.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查B1层判断矩阵");
                return false;
            }
            if (textBoxD12.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查C1层判断矩阵");
                return false;
            }
            if (textBoxd45.Text.Trim().Length == 0 || textBoxd46.Text.Trim().Length == 0 || textBoxd56.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查C3层判断矩阵");
                return false;
            }
            if (textBoxc45.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查B2层判断矩阵");
                return false;
            }
            if (textBoxD78.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查C4层判断矩阵");
                return false;
            }
            return true;
        }

        private double[] normalize(double[][] m)
        {

            int row = m.Length;
            int column = m[2].Length;
            double[] Sum_column = new double[column];
            double[] w = new double[row];

            for (int i = 0; i < column; i++)
            {
                Sum_column[i] = 0;
                for (int j = 0; j < row; j++)
                {
                    Sum_column[i] += m[j][i];
                }
            }
            //进行归一化,计算特征向量W

            for (int i = 0; i < row; i++)
            {
                w[i] = 0;
                for (int j = 0; j < column; j++)
                {
                    w[i] += m[i][j] / Sum_column[j];
                }
                w[i] /= row;
            }
            return w;
        }
        private double[] normal(double[][] n)
        {

            int row = n.Length;
            int column = n[1].Length;
            double[] Sum_column = new double[column];
            double[] w = new double[row];

            for (int i = 0; i < column; i++)
            {
                Sum_column[i] = 0;
                for (int j = 0; j < row; j++)
                {
                    Sum_column[i] += n[j][i];
                }
            }
            //进行归一化,计算特征向量W

            for (int i = 0; i < row; i++)
            {
                w[i] = 0;
                for (int j = 0; j < column; j++)
                {
                    w[i] += n[i][j] / Sum_column[j];
                }
                w[i] /= row;
            }
            return w;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxc12, this.textBox14);
        }



        private void textBox13_TextChanged_1(object sender, EventArgs e)
        {
            check_Num(this.textBoxc13, this.textBox18);
        }



        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxc23, this.textBox19);
        }



        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxD12, this.textBox22);
        }
        private void textBoxD13_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxD13, this.textBox52);

        }
       
        //矩阵textbox限制输入  
        private void check_Num(TextBox inputText, TextBox outputText)
        {
            string pattern = @"^[0-9]*$";
            string param1 = null;
            Match m = Regex.Match(inputText.Text, pattern);   // 匹配正则表达式
            if (!m.Success || string.IsNullOrEmpty(inputText.Text))   // 输入的不是数字
            {
                inputText.Text = "1";   // textBox内容不变

                // 将光标定位到文本框的最后
                inputText.SelectionStart = inputText.Text.Length;
            }
            else   // 输入的是数字
            {

                if (Convert.ToDecimal(inputText.Text) >= 1 && Convert.ToDecimal(inputText.Text) <= 9 )
                {
                    param1 = inputText.Text;   // 将现在textBox的值保存下来
                    outputText.Text = (1.0 / Convert.ToDouble(inputText.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("请输入1到9之间的整数！");
                    inputText.Text = "";
                }
            }
        }
        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxd45, this.textBox27);
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxd46, this.textBox31);
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxd56, this.textBox32);
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxc45, this.textBox34);
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxD78, this.textBox38);
        }

        



        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxD23_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxD23, this.textBox53);
        }







    }

    /// <summary>
    /// 自定义事件参数类型，根据需要可设定多种参数便于传递
    /// </summary>
    public class DataChangeEventArgs : EventArgs
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; } 
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; }
        public string G { get; set; }
        public string I { get; set; }
        public string J { get; set; }
        public string H { get; set; }
      
        public DataChangeEventArgs(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10)
        {
            A = s1;
            B = s2;
            C = s3;
            D = s4;
            E = s5;
            F = s6;
            G = s7;
            H = s8;
            I = s9;
            J = s10;

        }
    }

}
