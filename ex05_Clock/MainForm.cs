using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex05_Clock
{
    public partial class MainForm : Form
    {
        Graphics g; //Graphics 객체
        private bool aClock_Flag = false; //아날로그와 디지털 선택
        private Point Center; // 중심점
        private double radius; // 반지름
        private int hourHand; // 시침의 길이
        private int minHand;  // 분침의 길이
        private int secHand;  // 초침의 길이

        public MainForm()
        {
            InitializeComponent();
            this.Text = "FormClock";
            g = panel1.CreateGraphics();

            aClockSetting(); //아날로그 클럭세팅
            TimerSetting(); // 타이머 세팅

            this.아날로그.Click += new System.EventHandler(this.아날로그ToolStripMenuItem_Click);
            this.디지털.Click += new System.EventHandler(this.디지털ToolStripMenuItem_Click);
            this.종료.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
        }

        private void aClockSetting()
        {
            Center = new Point(panel1.Width / 2, panel1.Height / 2);
            radius = panel1.Height / 2;

            hourHand = (int)(radius * 0.45);
            minHand = (int)(radius * 0.55);
            secHand = (int)(radius * 0.65);
        }
        private void TimerSetting()
        {
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }


        private void 디지털ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aClock_Flag = false;
        }

        private void 아날로그ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            aClock_Flag = true;
            //DrawClockFace(); //시계판 그리기
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
