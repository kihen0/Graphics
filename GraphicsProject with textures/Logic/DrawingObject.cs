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
        static PointF Sum(PointF a,PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }
        static PointF Minus(PointF a, PointF b)
        {
            return new PointF(a.X - b.X, a.Y - b.Y);
        }
        static PointF Multiply(float k,PointF p)
        {
            return new PointF(k * p.X, k * p.Y);
        }
        Random rnd = new Random();
        public bool IsNeedShadows
        { get; set; }
        public bool IsWithPerspective { get; set; }
        float x=0, y=0;
        DataArrays data;        
        public int alpha = 0;
        public int beta = 0;
        float[,] ZBuffer;
        delegate Color ForZBuffering(float x, float y);

        public DrawingObject(DataArrays data)
        {
            IsNeedShadows = true;
            this.data = data;         
        }       
        public void DrawNew(int width, int height, Graphics g, Bitmap bm, float koef, bool isLightFromCamera, bool buffer, bool isNeedTexture, bool isFrame, bool isGourand, string textureName)
        {
            var matrixArr = SelectFromDataAndRotate();
            /*if (IsWithPerspective)
                matrixArr = Perspectie(matrixArr);*/
            var ps = Projection(matrixArr = Move(matrixArr, width, height, koef,IsWithPerspective));
            var vecs = NormaleVector(matrixArr);
            InitializeZBuffer(width, height);
            PointF[] textureCoord = null;
            Vector3D[] nVectors = null;
            Bitmap texture = null;
            if (isNeedTexture)
            {
                texture = FileExecutor.TextureOpen(textureName);
            }
            for (int i = 0; i < ps.Length; i++)
            {
                Vector3D lightVector;
                if (isFrame)
                {
                    g.DrawPolygon(Pens.Black, ps[i]);
                    continue;
                }
                if (isNeedTexture)
                    textureCoord = data.Faces[i].Select(x => (data.VT[x.Item2 - 1])).ToArray();
                if (isGourand)
                    nVectors = data.Faces[i].Select(x => (data.VN[x.Item3 - 1])).Select(x => new Vector3D(x.Item1, x.Item2, x.Item3)).ToArray();
                float cosA = CosAngle(vecs[i], lightVector = new Vector3D(0, 0, -1));
                if (cosA >= 0)
                {
                    PointF ab, ac, tAB, tAC;
                    ab = ac = tAB = tAC = new PointF(0, 0);
                    float c = 0;

                    if (isNeedTexture || isGourand)
                    {
                        ab = Minus(ps[i][1], ps[i][0]);
                        ac = Minus(ps[i][2], ps[i][0]);
                        c = ab.X * ac.Y - ac.X * ab.Y;
                        if (isNeedTexture)
                        {
                            tAB = Minus(textureCoord[1], textureCoord[0]);
                            tAC = Minus(textureCoord[2], textureCoord[0]);
                        }
                    }
                    var trig = VcosVsinCosSin();
                    if (!isLightFromCamera && IsNeedShadows)
                    {
                        cosA = CosAngle(vecs[i], lightVector = new Vector3D(-trig[3] * trig[0], trig[1], -trig[2] * trig[0]));
                    }
                    cosA = (float)(-Math.Abs(Math.Acos(cosA)) / Math.PI + 1) * 0.7f + 0.3f;
                    Color color;
                    if (!IsNeedShadows)
                        color = RandomColor(new int[] { 204, 184, 132 });
                    else
                        color = Color.FromArgb(Convert.ToInt32(204 * cosA), Convert.ToInt32(184 * cosA), Convert.ToInt32(132 * cosA));
                    ForZBuffering drawingDelegate = new ForZBuffering((x, y) =>
                      {
                          if (isNeedTexture || isGourand)
                          {
                              float u, v;
                              PointF pa = Minus(ps[i][0], new PointF(x, y));
                              u = (ac.X * pa.Y - pa.X * ac.Y) / c;
                              v = (pa.X * ab.Y - ab.X * pa.Y) / c;
                              if (isNeedTexture)
                              {
                                  PointF coord = Sum(textureCoord[0], Sum(Multiply(u, tAB), Multiply(v, tAC)));
                                  color = texture.GetPixel(Convert.ToInt16(coord.X * texture.Width) % texture.Width, Convert.ToInt16((1 - coord.Y % 1) * texture.Height) % texture.Height);
                              }
                              else
                                  color = Color.FromArgb(204, 184, 132);
                              if (IsNeedShadows)
                              {
                                  if (isGourand)
                                  {
                                      lightVector = isLightFromCamera ? new Vector3D(-trig[3] * trig[0], trig[1], trig[2] * trig[0]) : new Vector3D(0, 0, 1);
                                      var normVec = (nVectors[0] * (1 - u - v) + nVectors[1] * u + nVectors[2] * v);
                                      cosA = (normVec * lightVector) / (normVec.Abs() * lightVector.Abs());
                                      cosA = (float)(-Math.Abs(Math.Acos(cosA)) / Math.PI + 1) * 0.7f + 0.3f;
                                  }
                              }
                              else
                                  cosA = 1;

                              color = Color.FromArgb(Convert.ToInt16(color.R * cosA), Convert.ToInt16(color.G * cosA), Convert.ToInt16(color.B * cosA));
                          }
                          return color;
                      });
                    if (buffer)
                        if(ps[i].Length==3)
                            ZBuffering(VectorsFromMatrix(matrixArr[i].data), width, height, bm,drawingDelegate);
                        else
                        {
                            var polygon = VectorsFromMatrix(matrixArr[i].data);
                            ZBuffering(new Vector3D[] { polygon[0], polygon[1], polygon[2] }, width, height, bm, drawingDelegate);
                            ZBuffering(new Vector3D[] { polygon[0], polygon[3], polygon[2] }, width, height, bm, drawingDelegate);
                        }
                    else
                        g.FillPolygon(new SolidBrush(color), ps[i]);
                }
            }
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
               
        float[] VcosVsinCosSin()
        {
            float[] res = new float[4];
            res[0] = (float)Math.Cos(Math.PI * beta / 180);
            res[1] = (float)Math.Sin(Math.PI * beta / 180);
            res[2] = (float)Math.Cos(Math.PI * alpha / 180);
            res[3] = (float)Math.Sin(Math.PI * alpha / 180);
            return res;
        }
        void InitializeZBuffer(int width, int height)
        {
            ZBuffer = new float[height, width];
            for (int i = 0; i < ZBuffer.GetLength(0); i++)
            {
                for (int j = 0; j < ZBuffer.GetLength(1); j++)
                {
                    ZBuffer[i, j] = float.MinValue;
                }
            }
        }
        void ZBuffering(Vector3D[] polygon,int width,int height,Bitmap bm,ForZBuffering colorDelegate)
        {            
            var maxX = (int)polygon.Max(p => p.x);
            var maxY = (int)polygon.Max(p => p.y);
            var minX = (int)polygon.Min(p => p.x);
            var minY = (int)polygon.Min(p => p.y);                        
            var v1 = polygon[1] - polygon[0];
            var v2 = polygon[2] - polygon[0];
            var ABC = new float[3];
            ABC[0] = v1.y * v2.z - v1.z * v2.y;
            ABC[1] = v2.x * v1.z - v1.x * v2.z;
            ABC[2] = v1.x * v2.y - v1.y * v2.x;
            var zKoef = (ABC[0] * polygon[2].x + ABC[1] * polygon[2].y + ABC[2] * polygon[2].z) / ABC[2];
            for (int i = minX; i <= maxX; i++)
            {
                for (int j = minY; j <= maxY; j++)
                {
                    if (!(i < 0 || j < 0 || i >= width || j >= height))
                    {
                        var p = new PointF(i, j);
                        if (PointInTriangle(p, new PointF(polygon[0].x,polygon[0].y), new PointF(polygon[1].x, polygon[1].y), new PointF(polygon[2].x, polygon[2].y)))
                        {
                            float z = zKoef - (ABC[0] * i + ABC[1] * j) / ABC[2];
                            if (z >= ZBuffer[j, i])
                            {
                                ZBuffer[j, i] = z;
                                bm.SetPixel(i, j, colorDelegate(i,j));                               
                            }                            
                        }
                    }
                }
            }
        }
        MathExt.Matrix[] SelectFromDataAndRotate()
        {
            var trig = VcosVsinCosSin();
           
            List<MathExt.Matrix> matrixLis = new List<MathExt.Matrix>();
            foreach (var polygon in data.Faces)
            {
                var P = polygon.Select(t =>
                       new Tuple<double, double, double>(data.Vertices[t.Item1 - 1].Item1, data.Vertices[t.Item1 - 1].Item2, data.Vertices[t.Item1 - 1].Item3)).ToArray();
                var pointsMatrix = new MathExt.Matrix(ArrayConcat(P));
                pointsMatrix = pointsMatrix.MultiplyLeft(new double[,] { { trig[2], 0, trig[3], 0 }, { 0, 1, 0, 0 }, { -trig[3], 0, trig[2], 0 }, { 0, 0, 0, 1 } });
                pointsMatrix = pointsMatrix.MultiplyLeft(new double[,] { { 1, 0, 0, 0 }, { 0, trig[0], -trig[1], 0 }, { 0, trig[1], trig[0], 0 }, { 0, 0, 0, 1 } });
                pointsMatrix = pointsMatrix.Project();
                matrixLis.Add(pointsMatrix);
            }
            return matrixLis.ToArray();
        }
        MathExt.Matrix[] Move(MathExt.Matrix[] mArr,int width, int height, float koef,bool isNeedPerspective)
        {
            float maxR = (float)data.Vertices.Select(tup =>
               Math.Sqrt(tup.Item1 * tup.Item1 + tup.Item2 * tup.Item2)).Max();
            int min = (width > height) ? height : width;
            float k = min * 0.5f / maxR * 0.9f * koef;
            /*float dx = x * koef + width * 0.5f,
                  dy = y * koef + height * 0.5f;*/
            float maxY = mArr.Max(matr => VectorsFromMatrix(matr.data).Max(vect => vect.y)),
                minY = mArr.Min(matr => VectorsFromMatrix(matr.data).Min(vect => vect.y));
            float dySpecial = (maxY + minY) * 0.5f;
            for (int i = 0; i < mArr.Length; i++)
            {
                var pointsMatrix = mArr[i];
                pointsMatrix = pointsMatrix.Resize(1).MultiplyLeft(new double[,]
                { { 1, 0, 0,0 }, { 0, 1, 0, -dySpecial }, {0,0,1,0 }, {0,0,0,1 }}).Resize(-1);
                pointsMatrix = pointsMatrix.MultiplyLeft(new double[,] { { 1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 } });
                pointsMatrix = pointsMatrix.MultiplyByNumber(k);
                pointsMatrix = pointsMatrix.Resize(1).MultiplyLeft(new double[,]
                { { 1, 0, 0, x * koef }, { 0, 1, 0, y * koef }, {0,0,1,0 }, {0,0,0,1 }}).Resize(-1);
                mArr[i] = pointsMatrix;
            }
            float maxZCoord = 0;
            if(isNeedPerspective)
            {
                maxZCoord = mArr.Max(matr => VectorsFromMatrix(matr.data).Max(vect =>vect.Abs()));
            }
            for (int i = 0; i < mArr.Length; i++)
            {
                var pointsMatrix = mArr[i];
                if (isNeedPerspective)
                    pointsMatrix = pointsMatrix.Resize(1).MultiplyLeft((new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, -1/(maxZCoord*5), 1 } })).Project();
                pointsMatrix = pointsMatrix.Resize(1).MultiplyLeft(new double[,]
                { { 1, 0, 0, width*0.5f }, { 0, 1, 0, height*0.5f }, {0,0,1,0 }, {0,0,0,1 }}).Resize(-1);
                mArr[i] = pointsMatrix;           
            }
            return mArr;
        }       
        Vector3D[] NormaleVector(MathExt.Matrix[] matr)
        {            
            var vectors = new Vector3D[matr.Length];
            int i = 0;
            foreach (var md in matr)
            {
                var m = md.data;
                var vecs = new double[,] { { m[0,1]-m[0,0],m[1,1]-m[1,0],m[2,1]-m[2,0]},
                    { m[0,2]-m[0,0],m[1,2]-m[1,0],m[2,2]-m[2,0]}};
                var NVect = new Vector3D(new float[3] { (float)(vecs[0, 1] * vecs[1, 2] - vecs[1, 1] * vecs[0, 2]),
                    (float)(vecs[1, 0] * vecs[0, 2] - vecs[0,0 ] * vecs[1, 2]),
                    (float)(vecs[0, 0] * vecs[1, 1] - vecs[1, 0] * vecs[0, 1])});
                vectors[i++] = NVect;
            }
            return vectors;
        }
        Color RandomColor(int[] RGB)
        {
            double col = 0.8 + 0.2 * rnd.NextDouble();
            return Color.FromArgb(Convert.ToInt32(RGB[0] * col), Convert.ToInt32(RGB[1] * col), Convert.ToInt32(RGB[2] * col));
        } 
        float CosAngle(Vector3D surface,Vector3D lightVector)
        {
            return surface * lightVector / Math.Abs(surface.Abs() * lightVector.Abs());
        }
        PointF[][] Projection(MathExt.Matrix[] matrixArr)
        {
            return matrixArr.Select(m =>
            {
                PointF[] ps = new PointF[m.data.GetLength(1)];
                
                for (int i = 0; i < m.data.GetLength(1); i++)
                {
                    ps[i] = new PointF((float)m.data[0, i],(float) m.data[1, i]);
                }
                return ps;
            }).ToArray();
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

        double[,] ArrayConcat(Tuple<double,double,double>[] arrays)
        {
            double[,] result = new double[4, arrays.Length];
            for (int i = 0; i < arrays.Length; i++)
            {
                result[0, i] = arrays[i].Item1;
                result[1, i] = arrays[i].Item2;
                result[2, i] = arrays[i].Item3;
                result[3, i] = 1;
            }
            return result;
        }
        Vector3D[] VectorsFromMatrix(double[,] matrix)
        {
            Vector3D[] res = new Vector3D[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res[i] = new Vector3D((float)matrix[0, i], (float)matrix[1, i], (float)matrix[2, i]);
            }
            return res;
        }
    }
}
