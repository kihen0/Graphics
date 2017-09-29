using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Logic
{
    public class FileExecutor
    {
        string fileName;
        public FileExecutor()
        {

        }
        public FileExecutor(string fileName)
        {
            this.fileName = fileName;
        }
        void ListPush(string s, List<Tuple<double,double,double>> list)
        {
            try
            {                
                var sa = s.Replace('.', ',').Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                if(sa.Length<4)
                    list.Add(new Tuple<double, double, double>(
                    (double)Convert.ToDouble(sa[1]), (double)Convert.ToDouble(sa[2]), 0));
                else
                    list.Add(new Tuple<double, double, double>(
                    (double)Convert.ToDouble(sa[1]), (double)Convert.ToDouble(sa[2]), (double)Convert.ToDouble(sa[3])));
            }
            catch
            {

            }
        }
        public DataArrays ReadFile()
        {
            DataArrays data;
            var vertices = new List<Tuple<double, double, double>>();
            var vtList = new List<Tuple<double, double,double>>();
            var vnList = new List<Tuple<double, double, double>>();
            var faceList = new List<Tuple<int, int, int>[]>();
            using (StreamReader reader =new StreamReader(fileName))
            {                
                string s;
                while ((s=reader.ReadLine()) != null)
                {                   
                    if (s.ToLower().Length!=0)
                    {
                        if(s[0]=='v')
                        {                            
                            if (s[1]=='t')
                            {
                                ListPush(s, vtList);
                            }
                            else if (s[1]=='n')
                            {
                                ListPush(s, vnList);
                            }
                            else if(s[1]==' ')                            
                                ListPush(s, vertices);                            
                        }
                        else if(s[0]=='f')
                        {                            
                            var linksList = new List<Tuple<int, int, int>>();           
                            var sa = s.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 1; i < sa.Length; i++)
                            {
                                int v = -1, vt = -1, vn = -1;
                                try
                                {
                                    var elems = sa[i].Split('/');
                                    v = int.Parse(elems[0]);
                                    if (elems.Length >1&&elems[1]!="")                                    
                                        vt = int.Parse(elems[1]);
                                    
                                    if (elems.Length==3)                                    
                                        vn= int.Parse(elems[2]);
                                                                        
                                }                               
                                finally
                                {
                                    linksList.Add(new Tuple<int, int, int>(v, vt, vn));
                                } 
                            }
                            faceList.Add(linksList.ToArray());
                        }
                    }
                }
            }
            data = new DataArrays(vertices.ToArray(),vtList.Min(x=>x.Item2)>=0? vtList.Select(x => new PointF(Math.Abs((float)x.Item1), (float)x.Item2)).ToArray()
                : vtList.Select(x=>new PointF(Math.Abs((float)x.Item1),((float)x.Item2)-1)).ToArray()
                ,vnList.ToArray(),faceList.ToArray());                
            return data;
        }
        public static Bitmap TextureOpen(string pathPlusName)
        {
            return new Bitmap(Image.FromFile(pathPlusName));
        }
    }
}
