using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using SldWorks; //COM Reference: SldWorks 2012 Type Library.
//using SwConst;　//COM Reference: SolidWorks 2012 Constant type library.
namespace SharpGLWinformsApplication1
{
    public partial class RealTimeMonitoring : Form
    {
        private List<RealTimeMonitoringModel> DataModel = null;
        private RealTimeMonitoringModel StartModel = null;
        private List<string> filelist = null;
        public RealTimeMonitoring()
        {
            InitializeComponent();
            
        }
              
        //private void Timer_Click(object sender, EventArgs e)
        //{
        //    SharpGLForm shishijiankong = new SharpGLForm();
        //    shishijiankong.ShowDialog();
        //    shishijiankong.Dispose();
        //}

       private void button1_Click(object sender, EventArgs e)
        {
            //int IErrors = 0;
            //int IWarnings = 0;
            //SldWorks.SldWorks swApp = new SldWorks.SldWorks();
            //swApp.OpenDoc6(System.AppDomain.CurrentDomain.BaseDirectory + "火箭发射塔三维模型.SLDPRT", (int)SwConst.swDocumentTypes_e.swDocPART, (int)SwConst.swOpenDocOptions_e.swOpenDocOptions_Silent, null, ref IErrors, ref IWarnings);
            //swApp.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (filelist == null || filelist.Count == 0) //检测是否有文件可读
            {
                filelist = FileOperate.ScanFile(); //扫描文件夹 获取待读文件列表
                if (filelist == null || filelist.Count == 0)
                    return;
            }
            string filename = filelist.First(); //取第一个文件
            while (DataModel == null || DataModel.Count == 0)//未读文件
            {
                DataModel = FileOperate.ReadFile(filename); //读文件
                //FileOperate.MoveDelFile(filename); //将已读文件移走
                if (DataModel == null || DataModel.Count == 0) //没有读到数据
                {
                    filelist.Remove(filename);
                    if (filelist == null || filelist.Count == 0) //检测是否有文件可读
                    {
                        return;
                    }
                    filename = filelist.First(); //取第一个文件
                    //return;
                }
            }
            if (StartModel == null)//如果显示数据为空，即才开始进去 没数据
            {
                StartModel = DataModel.First();//显示文件数据的第一个点
            }
            else//如果不是空，显示下一个点
            {
                var date = FileOperate.GetRealTimeMonitoringModel(DataModel, StartModel, 1000, 1);
                if (date == null || date.Count == 0)
                {
                    DataModel = null;
                    StartModel = null;
                    filelist.Remove(filename);
                    return;
                }
                StartModel = date.First();

            }
            
            //bool flag = false;
            if (Convert.ToDouble(StartModel.Stress1) >= 17.5)
            {
                textBox1.ForeColor = Color.Red;
                //flag = true;
            }
            else
            {
                textBox1.ForeColor = Color.Black;
            }
            if (Convert.ToDouble(StartModel.Temperature1) >= 25.3)
            {
                textBox2.ForeColor = Color.Red;
                //flag = true;
            }
            else
            {
                textBox2.ForeColor = Color.Black;
            }
             if (Convert.ToDouble(StartModel.Stress2) >= 15.5)
            {
                textBox3.ForeColor = Color.Red;
                //flag = true;
            }
            else
            {
                textBox3.ForeColor = Color.Black;
            }
             if (Convert.ToDouble(StartModel.Temperature2) >= -4)
             {
                 textBox4.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox4.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress3) >= 17.5)
             {
                 textBox5.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox5.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature3) >= -4)
             {
                 textBox6.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox6.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress4) >= 17.5)
             {
                 textBox7.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox7.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature4) >= -4)
             {
                 textBox8.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox8.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress5) >= 17.5)
             {
                 textBox9.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox9.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature5) >= -4)
             {
                 textBox10.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox10.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress6) >= 17.5)
             {
                 textBox11.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox11.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature6) >= -4)
             {
                 textBox12.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox12.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress7) >= 17.5)
             {
                 textBox13.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox13.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature7) >= -4)
             {
                 textBox14.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox14.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress8) >= 17.5)
             {
                 textBox15.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox15.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature8) >= -4)
             {
                 textBox16.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox16.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress9) >= 17.5)
             {
                 textBox17.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox17.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature9) >= -4)
             {
                 textBox18.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox18.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress10) >= 17.5)
             {
                 textBox19.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox19.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature10) >= -4)
             {
                 textBox20.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox20.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress11) >= 17.5)
             {
                 textBox21.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox21.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature11) >= -4)
             {
                 textBox22.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox22.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress12) >= 17.5)
             {
                 textBox23.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox23.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature12) >= -4)
             {
                 textBox24.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox24.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress13) >= 17.5)
             {
                 textBox25.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox25.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature13) >= -4)
             {
                 textBox26.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox26.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress14) >= 17.5)
             {
                 textBox27.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox27.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature14) >= -4)
             {
                 textBox28.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox28.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress15) >= 17.5)
             {
                 textBox29.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox29.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature15) >= -4)
             {
                 textBox30.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox30.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress16) >= 17.5)
             {
                 textBox31.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox31.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature16) >= -4)
             {
                 textBox32.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox32.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature17) >= -4)
             {
                 textBox33.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox33.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress17) >= 17.5)
             {
                 textBox34.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox34.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress18) >= 17.5)
             {
                 textBox35.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox35.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress19) >= 17.5)
             {
                 textBox36.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox36.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature18) >= -4)
             {
                 textBox37.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox37.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress20) >= 17.5)
             {
                 textBox38.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox38.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress21) >= 17.5)
             {
                 textBox39.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox39.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress22) >= 17.5)
             {
                 textBox40.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox40.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature19) >= -4)
             {
                 textBox41.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox41.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress23) >= 17.5)
             {
                 textBox42.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox42.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress24) >= 17.5)
             {
                 textBox43.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox43.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress25) >= 17.5)
             {
                 textBox44.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox44.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Temperature20) >= -4)
             {
                 textBox45.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox45.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress26) >= 17.5)
             {
                 textBox46.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox46.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress27) >= 17.5)
             {
                 textBox47.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox47.ForeColor = Color.Black;
             }
             if (Convert.ToDouble(StartModel.Stress28) >= 17.5)
             {
                 textBox48.ForeColor = Color.Red;
                 //flag = true;
             }
             else
             {
                 textBox48.ForeColor = Color.Black;
             }
            
            textBox1.Text = StartModel.Stress1;
            textBox2.Text = StartModel.Temperature1;
            textBox3.Text = StartModel.Stress2;
            textBox4.Text = StartModel.Temperature2;
            textBox5.Text = StartModel.Stress3;
            textBox6.Text = StartModel.Temperature3;
            textBox7.Text = StartModel.Stress4;
            textBox8.Text = StartModel.Temperature4;
            textBox9.Text = StartModel.Stress5;
            textBox10.Text = StartModel.Temperature5;
            textBox11.Text = StartModel.Stress6;
            textBox12.Text = StartModel.Temperature6;
            textBox13.Text = StartModel.Stress7;
            textBox14.Text = StartModel.Temperature7;
            textBox15.Text = StartModel.Stress8;
            textBox16.Text = StartModel.Temperature8;
            textBox17.Text = StartModel.Stress9;
            textBox18.Text = StartModel.Temperature9;
            textBox19.Text = StartModel.Stress10;
            textBox20.Text = StartModel.Temperature10;
            textBox21.Text = StartModel.Stress11;
            textBox22.Text = StartModel.Temperature11;
            textBox23.Text = StartModel.Stress12;
            textBox24.Text = StartModel.Temperature12;
            textBox25.Text = StartModel.Stress13;
            textBox26.Text = StartModel.Temperature13;
            textBox27.Text = StartModel.Stress14;
            textBox28.Text = StartModel.Temperature14;
            textBox29.Text = StartModel.Stress15;
            textBox30.Text = StartModel.Temperature15;
            textBox31.Text = StartModel.Stress16;
            textBox32.Text = StartModel.Temperature16;
            textBox33.Text = StartModel.Temperature17;
            textBox34.Text = StartModel.Stress17;
            textBox35.Text = StartModel.Stress18;
            textBox36.Text = StartModel.Stress19;
            textBox37.Text = StartModel.Temperature18;
            textBox38.Text = StartModel.Stress20;
            textBox39.Text = StartModel.Stress21;
            textBox40.Text = StartModel.Stress22;
            textBox41.Text = StartModel.Temperature19;
            textBox42.Text = StartModel.Stress23;
            textBox43.Text = StartModel.Stress24;
            textBox44.Text = StartModel.Stress25;
            textBox45.Text = StartModel.Temperature20;
            textBox46.Text = StartModel.Stress26;
            textBox47.Text = StartModel.Stress27;
            textBox48.Text = StartModel.Stress28;
            /*if (flag)
            {
               FileOperate.SaveFile(StartModel);
            }*/
        }

        private void RealTimeMonitoring_Load(object sender, EventArgs e)
        {
            timer1.Start();//加载RealTimeMonitoring窗口启动计时器
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
           
        }

                
    }
}
