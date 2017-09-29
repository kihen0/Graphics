using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTriangleFill
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    

        float TriangleSquare(PointF[] ar)
        {
            return Math.Abs((ar[0].X - ar[2].X) * (ar[1].Y - ar[2].Y) - (ar[1].X - ar[2].X) * (ar[0].Y - ar[2].Y)) / 2;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            var g = CreateGraphics();
            var ps = new PointF[3] { new PointF(448, 64), new PointF(448, 176), new PointF(366, 176) };
            var maxX = (int)ps.Max(x => x.X);
            var maxY = (int)ps.Max(p => p.Y);
            var minX = (int)ps.Min(p => p.X);
            var minY = (int)ps.Min(p => p.Y);
            var square = TriangleSquare(ps);

            for (int i = minX; i < maxX; i++)
            {
                for (int j = minY; j < maxY; j++)
                {
                    var p = new PointF(i, j);
                    if (PointInTriangle(new PointF(i,j),ps[0],ps[1],ps[2]))
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), i, j, 1, 1);
                    }
                }
            }
        }
        float sign(PointF p1, PointF p2, PointF p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        bool PointInTriangle(PointF pt, PointF v1, PointF v2, PointF v3)
        {
            bool b1, b2, b3;

            b1 = sign(pt, v1, v2) < 0.0f;
            b2 = sign(pt, v2, v3) < 0.0f;
            b3 = sign(pt, v3, v1) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }
    }
}
