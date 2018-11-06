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
       //private string  PortRead()
       // {
       //     if (port != null && port.IsOpen)
       //     {
       //        byte[] rec = new byte[1024 * 1024];
       //        int r = port.Read(rec, 0, rec.Length);
       //        return   System.Text.Encoding.Default.GetString(rec);  
       //     }
       //     else
       //     {
       //         return "读取失败！";
       //     } 
       // }
        private void Add(int number)
        {
            switch (number)
            {
                case 1: PortWrite("1ups"); break;
                case 2: PortWrite("2ups"); break;
                case 3: PortWrite("3ups"); break;
                case 4: PortWrite("4ups"); break;
                case 5: PortWrite("5ups"); break;
                case 6: PortWrite("6ups"); break;
                case 7:PortWrite("vus");break;
                default: PortWrite("ps"); break;
            }

        }
        private void Sub(int number)
        {
            switch (number)
            {
                case 1: PortWrite("1ds"); break;
                case 2: PortWrite("2ds"); break;
                case 3: PortWrite("3ds"); break;
                case 4: PortWrite("4ds"); break;
                case 5: PortWrite("5ds"); break;
                case 6: PortWrite("6ds"); break;
                case 7:PortWrite("vds");break;
                default: PortWrite("ps"); break;
            }
        }

        #region 运动
        double d = 5;
        double v = 2;
        private void J1UP_Click(object sender, EventArgs e)
        {
            double j1box= (double.Parse(J1BOX.Text) + d);
            J1BOX.Text = Convert.ToString(j1box)+".0000000";
            Add(1);
            
        }     
        private void J1DOWN_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J1BOX.Text) - d);
            J1BOX.Text = Convert.ToString(jbox) + ".0000000";
            Sub(1);
        }
        private void J2UP_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J2BOX.Text) + d);
            J2BOX.Text = Convert.ToString(jbox) + ".0000000";
            Add(2);
        }
        private void J2DOWN_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J2BOX.Text) - d);
            J2BOX.Text = Convert.ToString(jbox) + ".0000000";
            Sub(2);
        }
        private void J3UP_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J3BOX.Text) +d);
            J3BOX.Text = Convert.ToString(jbox) + ".0000000";
            Add(3);
        }
        private void J3DOWN_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J3BOX.Text) -d);
            J3BOX.Text = Convert.ToString(jbox) + ".0000000";
            Sub(3);
        }
        private void J4UP_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J4BOX.Text) + d);
            J4BOX.Text = Convert.ToString(jbox) + ".0000000";
            Add(4);
        }
        private void J4DOWN_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J4BOX.Text) -d);
            J4BOX.Text = Convert.ToString(jbox) + ".0000000";
            Sub(4);
        }
        private void J5UP_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J5BOX.Text) + d);
            J5BOX.Text = Convert.ToString(jbox) + ".0000000";
            Add(5);
        }
        private void J5DOWN_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J5BOX.Text) - d);
            J5BOX.Text = Convert.ToString(jbox) + ".0000000";
            Sub(5);
        }
        private void J6UP_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J6BOX.Text) + d);
            J6BOX.Text = Convert.ToString(jbox) + ".0000000";
            Add(6);
        }

        private void J6DOWN_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(J6BOX.Text) + d);
            J6BOX.Text = Convert.ToString(jbox) + ".0000000";
            Sub(6);
        }

        private void vup_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(vs.Text) + v);
            vs.Text = Convert.ToString(jbox) + ".0000000";
            Add(7);
        }

        private void vdown_Click(object sender, EventArgs e)
        {
            double jbox = (double.Parse(vs.Text) - v);
            vs.Text = Convert.ToString(jbox) + ".0000000";
            Sub(7);
        }

        private void pause_Click(object  sender, EventArgs e)
        {
            PortWrite("ps");
            J1BOX.Text = "0.000000";
            J2BOX.Text = "0.000000";
            J3BOX.Text = "0.000000";
            J4BOX.Text = "0.000000";
            J5BOX.Text = "0.000000";
            J6BOX.Text = "0.000000";
            vs.Text = "5.000000";
        }
        #endregion

    }
}
