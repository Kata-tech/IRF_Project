using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

using FinalVersion.Controllers;
using FinalVersion.Services;
using Timer = System.Timers.Timer;

namespace FinalVersion
{
    public partial class Form1 : Form
    {
        public static OrderController _controller = new OrderController();

       
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = _controller.OrderManager.Adats;

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 myfrom = new Form2();
           
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

        private void timer1_Tick(object sender, EventArgs e)
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

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            timer1.Stop();

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (timer1 != null)
            {
                timer1.Tick -= timer1_Tick;
            }
            
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
    }
}
