using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex06_MouseClickPaintCircle
{
    public partial class Form1 : Form
    {
        Point[] ptCircle;
        //int nCount;

        public Form1()
        {
            //nCount = 0;
            InitializeComponent();
            ptCircle = new Point[2];
            ptCircle[0].X = 0;
            ptCircle[0].Y = 0;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            g.DrawEllipse(Pens.White, ptCircle[0].X - 10, ptCircle[0].Y - 10, 20, 20);
            
            
            ptCircle[0].X = e.X;
            ptCircle[0].Y = e.Y;
            g.DrawEllipse(Pens.Black, e.X - 10, e.Y - 10, 20, 20);
            //nCount++;
            g.Dispose();
        }
    }
}
