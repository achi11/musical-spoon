using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class DrawForm : Form
    {
        public DrawForm()
        {
            InitializeComponent();
        }

        
        public void DrawRectangles()
        {
            Pen red = new Pen(Color.Red);
            Graphics g = groupBox1.CreateGraphics();           
            var arr = new int[Int32.Parse(textBox1.Text)];
            FillArray(arr);
            int rectcount = arr.Length;
            int distance = 30;
            int recwidth = (groupBox1.Width - (rectcount - 1) * distance) / rectcount - 2;
            int firstcoordinate = 0;
            int secondcoordinate = 0;         
            for (int i = 0; i < arr.Length; i++)
            {
                secondcoordinate = groupBox1.Height - arr[i] - 5;
                g.DrawRectangle(red, new Rectangle(firstcoordinate, secondcoordinate, recwidth, arr[i]));
                firstcoordinate += recwidth + 30;
            }
        }

        private void FillArray(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 500);
            }
        }

        private void BtnDraw(object sender, EventArgs e)
        {
            DrawRectangles();
        }

        private void BtnClear(object sender, EventArgs e)
        {
            groupBox1.Invalidate();
        }
    }
}
