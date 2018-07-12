using System;
using System.Collections;
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

        List<Rectangle> reclist = new List<Rectangle>();
        List<Color> colorlist = new List<Color>();
        System.Drawing.SolidBrush fill;
        public void DrawRectangles()
        {
            Random random = new Random();
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
                Color color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                fill = new System.Drawing.SolidBrush(color);
                secondcoordinate = groupBox1.Height - arr[i] - 5;
                var rect = new Rectangle(firstcoordinate, secondcoordinate, recwidth, arr[i]);
                g.FillRectangle(fill, rect);
                firstcoordinate += recwidth + 30;
                if (reclist.Count < Int32.Parse(textBox1.Text))
                {
                    reclist.Add(rect);
                    colorlist.Add(color);
                }
                else
                {
                    reclist[i] = rect;
                    colorlist[i] = color;
                }
            }
        }
        public void SwapRectangle()
        {
            Graphics g = groupBox1.CreateGraphics();
            int a = Int32.Parse(textBox2.Text);
            int b = Int32.Parse(textBox3.Text);
            if (reclist[a].Height < reclist[b].Height)
            {
                var c = new Rectangle(reclist[a].X, reclist[a].Y, reclist[a].Width, reclist[a].Height);
                reclist[a] = new Rectangle(reclist[a].X, reclist[b].Y, reclist[a].Width, reclist[b].Height);
                reclist[b] = new Rectangle(reclist[b].X, c.Y, reclist[b].Width, c.Height);
                var k = colorlist[a];
                colorlist[a] = colorlist[b];
                colorlist[b] = k;
            }
            for (int i = 0; i < reclist.Count; i++)
            {
                fill = new System.Drawing.SolidBrush(colorlist[i]);
                g.FillRectangle(fill, reclist[i]);
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
            groupBox1.Refresh();
            DrawRectangles();
        }

        private void BtnClear(object sender, EventArgs e)
        {
            groupBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Refresh();
            SwapRectangle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox2.Text = rnd.Next(Int32.Parse(textBox1.Text)).ToString();
            textBox3.Text = rnd.Next(Int32.Parse(textBox1.Text)).ToString();
        }
    }
}
