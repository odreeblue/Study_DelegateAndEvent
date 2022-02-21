using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex05_Clock
{
    partial class MainForm
    {
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DateTime c = DateTime.Now; // 현재시간
            Font font = new Font("맑은고딕", 12, FontStyle.Bold);
            Font font1 = new Font("맑은고딕", 32, FontStyle.Bold | FontStyle.Italic);
            Brush brush = Brushes.SkyBlue;
            Brush brush1 = Brushes.SteelBlue;

            panel1.Refresh();

            if (aClock_Flag == false) // 디지털 시계
            {
                string date = DateTime.Today.ToString("D");
                string time = string.Format("{0:D2}:{1:D2}:{2:D2}", c.Hour, c.Minute, c.Second);

                g.DrawString(date, font, brush, new Point(2, 50));
                g.DrawString(time, font1, brush1, new Point(0, 84));
            }
            else // 아날로그 시계
            {
                DrawClockFace(); //시계판 그리기

                // 시침, 분침, 초침의 각도(단위: 라디안)
                double radHr = (c.Hour % 12 + c.Minute / 60.0) * 30 * Math.PI / 180;
                double radMin = (c.Minute + c.Second / 60.0) * 6 * Math.PI / 180;
                double radSec = (c.Second) * 6 * Math.PI / 180;

                DrawHands(radHr, radMin, radSec); // 바늘 그리기
            }
        }
        private void DrawClockFace()
        {
            Pen pen = new Pen(Brushes.LightSteelBlue, 30);
            g.DrawEllipse(pen, Center.X - 85, Center.Y - 85, 170, 170);
        }
        private void DrawHands(double radHr, double radMin, double radSec)
        {
            // 시침
            DrawLine((int)(hourHand * Math.Sin(radHr)), (int)(-hourHand * Math.Cos(radHr)),
                0, 0, Brushes.RoyalBlue, 8, Center.X, Center.Y);
            // 분침
            DrawLine((int)(minHand * Math.Sin(radMin)), (int)(-minHand * Math.Cos(radMin)),
                0, 0, Brushes.SkyBlue, 6, Center.X, Center.Y);
            // 초침
            DrawLine((int)(secHand * Math.Sin(radSec)), (int)(-secHand * Math.Cos(radSec)),
                0, 0, Brushes.OrangeRed, 3, Center.X, Center.Y);

            // 배꼽
            int coreSize = 16;
            Rectangle r = new Rectangle(Center.X - coreSize / 2, Center.Y - coreSize / 2, coreSize, coreSize);
            g.FillEllipse(Brushes.Gold, r);
            Pen p = new Pen(Brushes.DarkRed, 3);
            g.DrawEllipse(p, r);
        }

        private void DrawLine(int x1, int y1, int x2, int y2, Brush color, int thick, int Cx, int Cy)
        {
            Pen pen = new Pen(color, thick);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.DrawLine(pen, x1 + Cx, y1 + Cy, x2 + Cx, y2 + Cy);
        }
    }
}
