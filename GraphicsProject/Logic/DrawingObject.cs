using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Logic
{
    public class DrawingObject
    {
        float x=0, y=0;
        DataArrays data;        
        public int alpha = 0;
        public int beta = 0;        
        KeyValuePair<PointF[],Color>[] polygonArr;
        public DrawingObject(DataArrays data)
        {
            this.data = data;
            polygonArr = new KeyValuePair<PointF[], Color>[data.Faces.Length];
        }       
        public void Draw2D(int width, int height, Graphics g, float koef)
        {
            double vCos= (float)Math.Cos(Math.PI * beta / 180),
                vSin= (float)Math.Sin(Math.PI * beta / 180);
            float cos = (float)Math.Cos(Math.PI * alpha / 180),
                sin = (float)Math.Sin(Math.PI * alpha / 180);
            float maxR = (float)data.Vertices.Select(tup =>
                Math.Sqrt(tup.Item1 * tup.Item1 + tup.Item2 * tup.Item2)).Max();
            int min = (width > height) ? height : width;
            float k = min * 0.5f / maxR * 0.9f * koef;
            int i = 0;
            foreach (var polygon in data.Faces)
            {
                var P = polygon.Select(t =>
                    new Tuple<double, double, double>(data.Vertices[t.Item1 - 1].Item1, data.Vertices[t.Item1 - 1].Item2, data.Vertices[t.Item1 - 1].Item3)).ToArray();
                var ps = P.Select(t => new PointF(
                      (float)(t.Item1 * cos - t.Item3 * sin) * k + x * koef + width * 0.5f,
                       (float)((-t.Item2 * vCos - (t.Item3 * cos + t.Item1 * sin) * vSin) * k + y * koef + height * 0.5f))).ToArray();
                polygonArr[i++] = new KeyValuePair<PointF[], Color>(ps, Color.FromArgb(0,0,0));
                g.DrawPolygon(Pens.Black, ps);

            }
        }

        

        public void Draw3D(int width, int height, Graphics g, float koef,bool isLightFromCamera)
        {
            polygonArr = new KeyValuePair<PointF[], Color>[data.Faces.Length];                   
            double vCos= (float)Math.Cos(Math.PI * beta / 180),
                vSin= (float)Math.Sin(Math.PI * beta / 180);
            float cos = (float)Math.Cos(Math.PI * alpha / 180),
                sin = (float)Math.Sin(Math.PI * alpha / 180);
            float maxR = (float)data.Vertices.Select(tup =>
                Math.Sqrt(tup.Item1 * tup.Item1 + tup.Item2 * tup.Item2)).Max();
            int min = (width > height) ? height : width;
            float k = min * 0.5f / maxR * 0.9f * koef;
            int i = 0;                      
            foreach (var polygon in data.Faces)
            {
                var P = polygon.Select(t =>
                    new Tuple<double, double, double>(data.Vertices[t.Item1 - 1].Item1, data.Vertices[t.Item1 - 1].Item2, data.Vertices[t.Item1 - 1].Item3)).ToArray();

                double[,] vecs = new double[2, 3] { { P[1].Item1-P[0].Item1, P[1].Item2 - P[0].Item2, P[1].Item3 - P[0].Item3 },
                    { P[2].Item1-P[0].Item1, P[2].Item2 - P[0].Item2, P[2].Item3 - P[0].Item3 } };
                var NVect = new double[3] { vecs[0, 1] * vecs[1, 2] - vecs[1, 1] * vecs[0, 2],
                    vecs[1, 0] * vecs[0, 2] - vecs[0,0 ] * vecs[1, 2],
                    vecs[0, 0] * vecs[1, 1] - vecs[1, 0] * vecs[0, 1] };

                double VecMultiplyBackFaceCulling = NVect[0] * sin*vCos - NVect[1] * vSin + NVect[2] * cos*vCos;                
                double CosAlphaBFC = VecMultiplyBackFaceCulling / Math.Sqrt(NVect[0] * NVect[0] + NVect[1] * NVect[1] + NVect[2] * NVect[2]);
                double VecMultiplyLight, CosAlphaLight;
                if (isLightFromCamera)
                {
                    CosAlphaLight = CosAlphaBFC;
                }
                else
                {
                    VecMultiplyLight = NVect[2];
                    CosAlphaLight = VecMultiplyLight / Math.Sqrt(NVect[0] * NVect[0] + NVect[1] * NVect[1] + NVect[2] * NVect[2]);
                }
                //if (CosAlphaBFC >= 0)
                {
                    CosAlphaLight = -Math.Abs(Math.Acos(CosAlphaLight))/Math.PI+1;//optional

                    var PointsMatrix =new  MathExt.Matrix( ArrayConcat(P));
                    PointsMatrix=PointsMatrix.MultiplyByNumber(k);
                    PointsMatrix=PointsMatrix.Multiply(new double[,] { { cos, 0, sin }, { 0, 1, 0 }, { -sin, 0, cos } });
                    /*var ps = P.Select(t => new PointF(
                      (float)(t.Item1 * cos - t.Item3 * sin) * k+x*koef +  width * 0.5f,
                       (float)((-t.Item2*vCos-( t.Item3 * cos + t.Item1 * sin)*vSin)* k+y*koef+ height * 0.5f))).ToArray();*/
                    var ps = PolygonFromMatrix(PointsMatrix.data).Select(p => new PointF(p.X + x * koef + width * 0.5f, -p.Y + y * koef + height * 0.5f)).ToArray();                        
                    var colorRGB = Convert.ToInt32(150 * CosAlphaBFC*CosAlphaBFC)+40;                   
                    var color = Color.FromArgb(Convert.ToInt32(204 * CosAlphaLight), Convert.ToInt32(184 * CosAlphaLight), Convert.ToInt32(132 * CosAlphaLight));
                    //g.FillPolygon(new SolidBrush(color), ps);
                    polygonArr[i] = new KeyValuePair<PointF[], Color>(ps, color);
                    g.DrawPolygon(Pens.Black, ps);
                }               
            }
        }              
        double[,] ArrayConcat(Tuple<double,double,double>[] arrays)
        {
            double[,] result = new double[3, arrays.Length];
            for (int i = 0; i < arrays.Length; i++)
            {
                result[0, i] = arrays[i].Item1;
                result[1, i] = arrays[i].Item2;
                result[2, i] = arrays[i].Item3;
            }
            return result;
        }
        PointF[] PolygonFromMatrix(double[,] matrix)
        {
            PointF[] res = new PointF[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res[i] = new PointF((float)matrix[0, i], (float)matrix[1, i]);
            }
            return res;
        }
        public void Move(float x,float y)
        {
            this.x += x;
            this.y += y;            
        }
        public void CenterImage()
        {
            x = y = 0;
        }
    }
}
