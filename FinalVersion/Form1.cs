using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalVersion.Controllers;
using FinalVersion.Services;

namespace FinalVersion
{
    public partial class Form1 : Form
    {
        private OrderController _controller = new OrderController();
        public Form1()
        {
            InitializeComponent();

        }

       
        


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 myfrom = new Form2();
            myfrom.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.Register(
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    int.Parse(textBox4.Text),
                    int.Parse(textBox5.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }

        private Point lastPos;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MousePosition != lastPos)
            {
                MouseHasntMoved();
                timer1.Stop();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            lastPos = MousePosition;
        }

        public void MouseHasntMoved()
        {
            //Do something
        }
    }
}
