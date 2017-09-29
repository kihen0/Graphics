using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace MainForm
{
    public partial class Form1 : Form
    {
        DrawingMode mode = DrawingMode.clear;
        Bitmap bm;
        float k = 1;
        DrawingObject model;
        Point dPoint = new Point(0, 0);
        Point prev;
        bool moving = false;
        bool spining = false;
        bool isSpiningEnabled = true;
        bool isMovingEnabled = true;
        bool isZoomEnabled = true;

        string textureName;

        public Form1()
        {
            InitializeComponent();
            pictureBoxMainImage.MouseWheel += PictureBoxMainImage_MouseWheel;
        }

        void Drawing()
        {
            if (mode == DrawingMode.clear || pictureBoxMainImage.Width == 0 || pictureBoxMainImage.Height == 0)
                return;

            bm = new Bitmap(pictureBoxMainImage.Width, pictureBoxMainImage.Height - panel1.Size.Height - 2);
            var g = Graphics.FromImage(bm);
            switch (mode)
            {
                case DrawingMode.clear:
                    break;
                case DrawingMode.draw2D:
                    model.Draw2D(bm.Width, bm.Height, g, k);
                    break;
                case DrawingMode.draw3D:
                    model.Draw3D(bm.Width, bm.Height, g, bm, k, lightFromCameraToolStripMenuItem.Checked, false);
                    break;
                case DrawingMode.drawWithBuff:
                    model.Draw3D(bm.Width, bm.Height, g, bm, k, lightFromCameraToolStripMenuItem.Checked, true);
                    break;
                case DrawingMode.drawWithTextures:
                    model.DrawWithTextures(bm.Width, bm.Height, bm, k,textureName,gouraudShadingToolStripMenuItem.Checked,lightFromCameraToolStripMenuItem.Checked);
                    break;
            }
            pictureBoxMainImage.Image = bm;

        }

        void Clear()
        {
            mode = DrawingMode.clear;
            bm = new Bitmap(pictureBoxMainImage.Width, pictureBoxMainImage.Height - 30);
            pictureBoxMainImage.Image = bm;
        }

        void ChangeMode(DrawingMode mode)
        {
            this.mode = mode;
            Drawing();
        }

        void Zoom(int dz)
        {
            if (mode != DrawingMode.clear)
            {
                k *= (float)Math.Pow(Math.Pow(2, 1.0 / 3), dz);
                Drawing();
            }
        }

        private void pictureBoxMainImage_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    prev = e.Location;
                    spining = true;
                    break;
                case MouseButtons.Middle:
                    prev = e.Location;
                    moving = true;
                    break;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();            
            if (openFD.ShowDialog()==DialogResult.OK)
            {                
                Logic.FileExecutor file = new FileExecutor(openFD.FileName);
                var data= file.ReadFile();
                model = new DrawingObject(data);
                if (data.VT.Length != 0)
                    openTextureToolStripMenuItem.Enabled = true;
                if (data.VN.Length!= 0)
                    gouraudShadingToolStripMenuItem.Enabled = true;

                label1.Text = "file loaded, " + data.Vertices.Length + " V,    "+ data.VT.Length 
                    + " VT,    " + data.VN.Length + " VN,    " + data.Faces.Length + " Faces";
                runToolStripMenuItem.Enabled = settingsToolStripMenuItem.Enabled = true;              
            }
            Clear();
        }               

        private void draw2DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode(DrawingMode.draw2D);
        }

        private void draw3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode(DrawingMode.draw3D);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pictureBoxMainImage_SizeChanged(object sender, EventArgs e)
        {            
            Drawing();                                   
        }
    
        private void buttonZoom_Click(object sender, EventArgs e)
        {
            Zoom(Convert.ToInt16(((Control)sender).Tag));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            model.beta = trackBar2.Value;
            model.alpha = trackBar1.Value;
            Drawing();
            
        }

        private void Form1_mouseMove(object sender, MouseEventArgs e)
        {
            Text = e.X + " " + e.Y;
            if (isSpiningEnabled&&spining&&(prev.X-e.X>6||prev.Y-e.Y>6||e.X-prev.X>6||e.Y-prev.Y>6))
            {
                var dx = e.X - prev.X;
                var dy = e.Y - prev.Y;
                if (trackBar1.Value > trackBar1.Minimum - dx && trackBar1.Value + dx < trackBar1.Maximum)
                    trackBar1.Value += e.X - prev.X;
                else
                    if (dx > 0)
                        trackBar1.Value += trackBar1.Minimum*2 + dx;
                else
                    trackBar1.Value += trackBar1.Maximum*2 + dx;
                if(trackBar2.Value > trackBar2.Minimum-dy && trackBar2.Value+dy < trackBar2.Maximum)
                trackBar2.Value += e.Y - prev.Y;
                trackBar1_Scroll(2, null);
                prev = e.Location;
            }
            if (moving&&isMovingEnabled)
            {                
                model.Move((e.X - prev.X)/k, (e.Y - prev.Y)/k);
                prev = e.Location;
                Drawing();
               
            }
        }

        private void pictureBoxMainImage_MouseUp(object sender, MouseEventArgs e)
        {
            moving=spining = false;
        }

        private void PictureBoxMainImage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (isZoomEnabled)            
                Zoom(e.Delta / 120);            
        }
        
        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool b = ((ToolStripMenuItem)sender).Checked;
            ((ToolStripMenuItem)sender).Checked = !b;
            isSpiningEnabled = !b;
            panelRotation.Visible = !b;
        }

        private void movingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool b = ((ToolStripMenuItem)sender).Checked;
            ((ToolStripMenuItem)sender).Checked = !b;
            isMovingEnabled = !b;            
        }

        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.CenterImage();
            Drawing();
        }

        private void defaultScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k = 1;
            Drawing();
        }

        private void lightFromCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool b = ((ToolStripMenuItem)sender).Checked;
            ((ToolStripMenuItem)sender).Checked = !b;
            Drawing();
        }

        private void frontImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.alpha = model.beta = 0;
            trackBar1.Value = trackBar2.Value = 0;
            Drawing();
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool b = ((ToolStripMenuItem)sender).Checked;
            ((ToolStripMenuItem)sender).Checked = !b;
            panelZoom.Visible = !b;
            isZoomEnabled = !b;
        }

        private void drawWithZBufferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode(DrawingMode.drawWithBuff);
        }

        private void drawWithTexturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode(DrawingMode.drawWithTextures);
        }

        private void openTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if(opf.ShowDialog()==DialogResult.OK)
            {
                textureName = opf.FileName;
                drawWithTexturesToolStripMenuItem.Enabled = true;
            }            
        }

        private void gouraudShadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gouraudShadingToolStripMenuItem.Checked = !gouraudShadingToolStripMenuItem.Checked;
            Drawing();
        }

        private void shadowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shadowsToolStripMenuItem.Checked = !shadowsToolStripMenuItem.Checked;
            model.IsNeedShadows = shadowsToolStripMenuItem.Checked;
            Drawing();
        }

        private void perspectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            perspectiveToolStripMenuItem.Checked = !perspectiveToolStripMenuItem.Checked;
            model.IsWithPerspective = perspectiveToolStripMenuItem.Checked;
            Drawing();
        }
    }
}
