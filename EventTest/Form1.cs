using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;//Graphics 클래스가 있는 네임스페이스
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//Form클래스가 있는 네임스페이스

namespace EventTest
{
    //public delegate void PaintEventHandler(object objsender, EventArgs e);
    //public delegate void PaintEventHandler(object objsender, PaintEventArgs pea);
    //public delegate void usrPaintEventHandler(object sender, PaintEventArgs e);
    public partial class Form1 : Form
    {
        public int x1, x2, y1, y2;

       

        public Form1()
        {
            InitializeComponent();
            x1 = 10; x2 = 20; y1 = 10; y2 = 20;
        }
        private void MyPaintHandler(object objSender, PaintEventArgs pea)
        {
            
        }

        private void ClickForm(object sender, MouseEventArgs pea)
        {
            Graphics g = CreateGraphics();
            
            g.DrawLine(Pens.Black, x1, y1, x2, y2);
            x1 += 10; x2 += 10; y1 += 10; y2 += 10;
            g.Dispose();
        }
    }
}
