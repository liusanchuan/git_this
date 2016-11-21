using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System.Globalization;
using MathNet.Numerics.LinearAlgebra.Double;

namespace SharpGLWinformsApplication1
{
    public partial class NewJudgment : Form
    {
        public NewJudgment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u=new double[3,3]{{1,2,3},{4,5,6},{7,8,9}};
            
            var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            formatProvider.TextInfo.ListSeparator = " ";

            // Create square symmetric matrix
            var matrix = DenseMatrix.OfArray(new[,] { { 1.0, 2.0, 3.0 }, { 2.0, 1.0, 4.0 }, { 3.0, 4.0, 1.0 } });
            var evd = matrix.Evd();
            label1.Text = evd.EigenVectors.ToString("#0.00\t", formatProvider);
            label2.Text = evd.EigenValues.ToString("N", formatProvider);
            var b=new Complex[3];
            for (int i = 0; i < 3; i++)
            {
               var a = evd.EigenValues.AbsoluteMaximumIndex();
                b[i]=evd.EigenVectors[i,a];
                var a0 = evd.EigenValues[0];
                var a1 = evd.EigenValues[i];    
                //label2.Text = evd.EigenValues[i][0].ToString();
                //Console.Write(a0);
            }
            label2.Text = getMaxEigenValues(u).ToString();
        }
        public Complex[] getMaxEigenValues(double[,] array){
            var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            formatProvider.TextInfo.ListSeparator = " ";
            var matrix = DenseMatrix.OfArray(array);
            var evd = matrix.Evd();
            label1.Text = evd.EigenVectors.ToString("#0.00\t", formatProvider);
            label2.Text = evd.EigenValues.ToString("N", formatProvider);
            var b = new Complex[3];
            for (int i = 0; i < 3; i++)
            {
                var a = evd.EigenValues.AbsoluteMaximumIndex();
                b[i] = evd.EigenVectors[i, a];
                var a0 = evd.EigenValues[0];
                var a1 = evd.EigenValues[i];
                //label2.Text = evd.EigenValues[i][0].ToString();
                //Console.Write(a0);
            }
            return b;

        }


    }
}
