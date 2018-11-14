using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
namespace aeRobot
{
    public partial class Form1 : Form
    {

        SerialPort port;
        public Form1()
        {
            InitializeComponent();
            //串口初始化
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            if (port == null)
            {
                //COM1为Arduino使用的串口号，需根据实际情况调整
                 port = new SerialPort("COM1", 9600);
                port.Open();
            }
        }
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
            }
        }
        private void PortWrite(string message)
        {
            if (port != null && port.IsOpen)
            {
                port.Write(message);
            }
        }
        #region 改变textbox中的值并发送运动指令
        double d = 4.999999;
        double v = 0.999999;
        private void J1UP_Click(object sender, EventArgs e)
        {
            if(double.Parse(J1BOX.Text)+d<170)
            { 
            J1BOX.Text = Convert.ToString(double.Parse(J1BOX.Text) + d);
            PortWrite(J1BOX.Text + ",1s");
            }
            else
            {
                MessageBox.Show("j1的范围超出范围(-170~170)，请重新设置");               
            }
        }
        private void J1DOWN_Click(object sender, EventArgs e)
        {
            if (double.Parse(J1BOX.Text)-d>-170 )
            {
                J1BOX.Text = Convert.ToString(double.Parse(J1BOX.Text) - d);
                PortWrite(J1BOX.Text + ",1s");
            }
            else
            {
                MessageBox.Show("j1的范围超出范围(-170~170)，请重新设置");            
            }
        }
        private void J2UP_Click(object sender, EventArgs e)
        {
            if (double.Parse(J2BOX.Text) +d< 135)
            {
                J2BOX.Text = Convert.ToString(double.Parse(J2BOX.Text) + d);
                PortWrite(J2BOX.Text + ",2s");
            }
            else
            {
                MessageBox.Show("j2的范围超出范围(-100~-135)，请重新设置");              
            }  
        }
        private void J2DOWN_Click(object sender, EventArgs e)
        {          
            if (double.Parse(J2BOX.Text)-d >-100)
            {
                J2BOX.Text = Convert.ToString(double.Parse(J2BOX.Text) - d);
                PortWrite(J2BOX.Text + ",2s");
            }
            else
            {
                MessageBox.Show("j2的范围超出范围(-100~-135)，请重新设置");               
            }
        }
        private void J3UP_Click(object sender, EventArgs e)
        {
            if (double.Parse(J3BOX.Text)+d<156)
            {
                J3BOX.Text = Convert.ToString(double.Parse(J3BOX.Text) + d);
                PortWrite(J3BOX.Text + ",3s");
            }
            else
            {
                MessageBox.Show("j3的范围超出范围(-120~156)，请重新设置");          
            }           
        }
        private void J3DOWN_Click(object sender, EventArgs e)
        {
            if (double.Parse(J3BOX.Text)-d >-120)
            {
                J3BOX.Text = Convert.ToString(double.Parse(J3BOX.Text) - d);
                PortWrite(J3BOX.Text + ",3s");
            }
            else
            {
                MessageBox.Show("j3的范围超出范围(-120~156)，请重新设置");     
            }           
        }
        private void J4UP_Click(object sender, EventArgs e)
        {
            if (double.Parse(J4BOX.Text)+d<200)
            {
                J4BOX.Text = Convert.ToString(double.Parse(J4BOX.Text) + d);
                PortWrite(J4BOX.Text + ",4s");
            }
            else
            {
                MessageBox.Show("j4的范围超出范围(-200~200)，请重新设置");
            }          
        }
        private void J4DOWN_Click(object sender, EventArgs e)
        {
            if (double.Parse(J4BOX.Text)-d >-200)
            {
                J4BOX.Text = Convert.ToString(double.Parse(J4BOX.Text) - d);
                PortWrite(J4BOX.Text + ",4s");
            }
            else
            {
                MessageBox.Show("j4的范围超出范围(-200~200)，请重新设置");
            }
        }
        private void J5UP_Click(object sender, EventArgs e)
        {
            if (double.Parse(J5BOX.Text)+d <135)
            {
                J5BOX.Text = Convert.ToString(double.Parse(J5BOX.Text) + d);
                PortWrite(J5BOX.Text + ",5s");
            }
            else 
            {
                MessageBox.Show("j5的范围超出范围(-135~135)，请重新设置");
            }           
        }
        private void J5DOWN_Click(object sender, EventArgs e)
        {
            if (double.Parse(J5BOX.Text)-d >-135)
            {
                J5BOX.Text = Convert.ToString(double.Parse(J5BOX.Text) - d);
                PortWrite(J5BOX.Text + ",5s");
            }
            else 
            {
                MessageBox.Show("j5的范围超出范围(-135~135)，请重新设置");
            }           
        }
        private void J6UP_Click(object sender, EventArgs e)
        {
            if (double.Parse(J6BOX.Text)+d<360)
            {
            J6BOX.Text = Convert.ToString(double.Parse(J6BOX.Text) + d);
            PortWrite(J6BOX.Text + ",6s");
            }
            else
            {
                MessageBox.Show("j6的范围超出范围(-360~360)，请重新设置");
            }
        }
        private void J6DOWN_Click(object sender, EventArgs e)
        {
            if(double.Parse(J6BOX.Text)-d>-360)
            { 
            J6BOX.Text = Convert.ToString(double.Parse(J6BOX.Text) - d);
            PortWrite(J6BOX.Text + ",6s");
            }
            else
            {
                MessageBox.Show("j6的范围超出范围(-360~360)，请重新设置");
            }
        }
        private void vup_Click(object sender, EventArgs e)
        {
            if(double.Parse(vs.Text) + v<100)
            { 
            vs.Text = Convert.ToString(double.Parse(vs.Text) + v);
            PortWrite(vs.Text + ",vs");
            }
            else
            {
                MessageBox.Show("速度的范围超出范围(0~100)，请重新设置");
            }
        }
        private void vdown_Click(object sender, EventArgs e)
        {
            if(double.Parse(vs.Text)-v>0)
            { 
            vs.Text = Convert.ToString(double.Parse(vs.Text) - v);
            PortWrite(vs.Text + ",vs");
            }
            else
            {
                MessageBox.Show("速度的范围超出范围(0~100)，请重新设置");
            }
        }
        #endregion
        #region 开始运动指令与停止并复位运动指令
        private void pause_Click(object sender, EventArgs e)
        {
            PortWrite("tops");
            J1BOX.Text = "0.000000";
            J2BOX.Text = "0.000000";
            J3BOX.Text = "0.000000";
            J4BOX.Text = "0.000000";
            J5BOX.Text = "0.000000";
            J6BOX.Text = "0.000000";
            vs.Text = "5.000000";
        }
        #endregion
        private void SetOk_Click(object sender, EventArgs e)
        {
           if(double.Parse(J1BOX.Text)>-170 && double.Parse(J1BOX.Text) < 170&& double.Parse(J2BOX.Text)>-100&& double.Parse(J2BOX.Text)<135&& double.Parse(J3BOX.Text)>-120&& double.Parse(J3BOX.Text)<156&& double.Parse(J4BOX.Text)>-200&& double.Parse(J4BOX.Text)<200&& double.Parse(J5BOX.Text)>-135&& double.Parse(J5BOX.Text)< 135&&double.Parse(J6BOX.Text)>-360&& double.Parse(J6BOX.Text)<360&& double.Parse(vs.Text)>0&& double.Parse(vs.Text)<100)
            { 
            PortWrite(J1BOX.Text + "|"+ J2BOX.Text+"|"+ J3BOX.Text + "|" + J4BOX.Text + "|" + J5BOX.Text + "|" + J6BOX.Text + "|" + vs.Text + "|k" );
            }
            else
            {
                MessageBox.Show("设置超出了范围");
            }
        }
        private void self_input_Click(object sender, EventArgs e)
        {
            PortWrite("ets");
        }
    }
}
