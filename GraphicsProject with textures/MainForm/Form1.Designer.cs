namespace MainForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.draw2DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.draw3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWithZBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWithTexturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frontImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightFromCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gouraudShadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxMainImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelZoom = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelRotation = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.shadowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelZoom.SuspendLayout();
            this.panelRotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(673, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openTextureToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open Model";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openTextureToolStripMenuItem
            // 
            this.openTextureToolStripMenuItem.Enabled = false;
            this.openTextureToolStripMenuItem.Name = "openTextureToolStripMenuItem";
            this.openTextureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openTextureToolStripMenuItem.Text = "Open Texture";
            this.openTextureToolStripMenuItem.Click += new System.EventHandler(this.openTextureToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.draw2DToolStripMenuItem,
            this.draw3DToolStripMenuItem,
            this.drawWithZBufferToolStripMenuItem,
            this.drawWithTexturesToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.runToolStripMenuItem.Enabled = false;
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // draw2DToolStripMenuItem
            // 
            this.draw2DToolStripMenuItem.Name = "draw2DToolStripMenuItem";
            this.draw2DToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.draw2DToolStripMenuItem.Text = "Draw Frame";
            this.draw2DToolStripMenuItem.Click += new System.EventHandler(this.draw2DToolStripMenuItem_Click);
            // 
            // draw3DToolStripMenuItem
            // 
            this.draw3DToolStripMenuItem.Name = "draw3DToolStripMenuItem";
            this.draw3DToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.draw3DToolStripMenuItem.Text = "Draw 3D";
            this.draw3DToolStripMenuItem.Click += new System.EventHandler(this.draw3DToolStripMenuItem_Click);
            // 
            // drawWithZBufferToolStripMenuItem
            // 
            this.drawWithZBufferToolStripMenuItem.Name = "drawWithZBufferToolStripMenuItem";
            this.drawWithZBufferToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.drawWithZBufferToolStripMenuItem.Text = "Draw with Z-Buffer";
            this.drawWithZBufferToolStripMenuItem.Click += new System.EventHandler(this.drawWithZBufferToolStripMenuItem_Click);
            // 
            // drawWithTexturesToolStripMenuItem
            // 
            this.drawWithTexturesToolStripMenuItem.Enabled = false;
            this.drawWithTexturesToolStripMenuItem.Name = "drawWithTexturesToolStripMenuItem";
            this.drawWithTexturesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.drawWithTexturesToolStripMenuItem.Text = "Draw with Textures";
            this.drawWithTexturesToolStripMenuItem.Click += new System.EventHandler(this.drawWithTexturesToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centerImageToolStripMenuItem,
            this.defaultScaleToolStripMenuItem,
            this.frontImageToolStripMenuItem,
            this.perspectiveToolStripMenuItem,
            this.shadowsToolStripMenuItem,
            this.lightFromCameraToolStripMenuItem,
            this.gouraudShadingToolStripMenuItem,
            this.toolStripSeparator1,
            this.rotationToolStripMenuItem,
            this.movingToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.settingsToolStripMenuItem.Enabled = false;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // centerImageToolStripMenuItem
            // 
            this.centerImageToolStripMenuItem.Name = "centerImageToolStripMenuItem";
            this.centerImageToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.centerImageToolStripMenuItem.Text = "Center Image";
            this.centerImageToolStripMenuItem.Click += new System.EventHandler(this.centerImageToolStripMenuItem_Click);
            // 
            // defaultScaleToolStripMenuItem
            // 
            this.defaultScaleToolStripMenuItem.Name = "defaultScaleToolStripMenuItem";
            this.defaultScaleToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.defaultScaleToolStripMenuItem.Text = "Default Scale";
            this.defaultScaleToolStripMenuItem.Click += new System.EventHandler(this.defaultScaleToolStripMenuItem_Click);
            // 
            // frontImageToolStripMenuItem
            // 
            this.frontImageToolStripMenuItem.Name = "frontImageToolStripMenuItem";
            this.frontImageToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.frontImageToolStripMenuItem.Text = "Front Image";
            this.frontImageToolStripMenuItem.Click += new System.EventHandler(this.frontImageToolStripMenuItem_Click);
            // 
            // lightFromCameraToolStripMenuItem
            // 
            this.lightFromCameraToolStripMenuItem.Checked = true;
            this.lightFromCameraToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lightFromCameraToolStripMenuItem.Name = "lightFromCameraToolStripMenuItem";
            this.lightFromCameraToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.lightFromCameraToolStripMenuItem.Text = "Light From Camera";
            this.lightFromCameraToolStripMenuItem.Click += new System.EventHandler(this.lightFromCameraToolStripMenuItem_Click);
            // 
            // gouraudShadingToolStripMenuItem
            // 
            this.gouraudShadingToolStripMenuItem.Enabled = false;
            this.gouraudShadingToolStripMenuItem.Name = "gouraudShadingToolStripMenuItem";
            this.gouraudShadingToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.gouraudShadingToolStripMenuItem.Text = "Gouraud shading";
            this.gouraudShadingToolStripMenuItem.Click += new System.EventHandler(this.gouraudShadingToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.Checked = true;
            this.rotationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.rotationToolStripMenuItem.Text = "Rotation";
            this.rotationToolStripMenuItem.Click += new System.EventHandler(this.rotationToolStripMenuItem_Click);
            // 
            // movingToolStripMenuItem
            // 
            this.movingToolStripMenuItem.Checked = true;
            this.movingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.movingToolStripMenuItem.Name = "movingToolStripMenuItem";
            this.movingToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.movingToolStripMenuItem.Text = "Moving";
            this.movingToolStripMenuItem.Click += new System.EventHandler(this.movingToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Checked = true;
            this.zoomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
            // 
            // pictureBoxMainImage
            // 
            this.pictureBoxMainImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBoxMainImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMainImage.Location = new System.Drawing.Point(0, 24);
            this.pictureBoxMainImage.Name = "pictureBoxMainImage";
            this.pictureBoxMainImage.Size = new System.Drawing.Size(673, 399);
            this.pictureBoxMainImage.TabIndex = 2;
            this.pictureBoxMainImage.TabStop = false;
            this.pictureBoxMainImage.SizeChanged += new System.EventHandler(this.pictureBoxMainImage_SizeChanged);
            this.pictureBoxMainImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMainImage_MouseDown);
            this.pictureBoxMainImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_mouseMove);
            this.pictureBoxMainImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMainImage_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelZoom);
            this.panel1.Controls.Add(this.panelRotation);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 44);
            this.panel1.TabIndex = 4;
            // 
            // panelZoom
            // 
            this.panelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelZoom.Controls.Add(this.button2);
            this.panelZoom.Controls.Add(this.button1);
            this.panelZoom.Location = new System.Drawing.Point(255, 0);
            this.panelZoom.Name = "panelZoom";
            this.panelZoom.Size = new System.Drawing.Size(76, 44);
            this.panelZoom.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(40, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 25);
            this.button2.TabIndex = 5;
            this.button2.Tag = "1";
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonZoom_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(14, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 25);
            this.button1.TabIndex = 4;
            this.button1.Tag = "-1";
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonZoom_Click);
            // 
            // panelRotation
            // 
            this.panelRotation.Controls.Add(this.trackBar1);
            this.panelRotation.Controls.Add(this.trackBar2);
            this.panelRotation.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRotation.Location = new System.Drawing.Point(298, 0);
            this.panelRotation.Name = "panelRotation";
            this.panelRotation.Size = new System.Drawing.Size(375, 44);
            this.panelRotation.TabIndex = 8;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.LargeChange = 45;
            this.trackBar1.Location = new System.Drawing.Point(213, 6);
            this.trackBar1.Maximum = 180;
            this.trackBar1.Minimum = -180;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(159, 45);
            this.trackBar1.SmallChange = 15;
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickFrequency = 15;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.Location = new System.Drawing.Point(39, 6);
            this.trackBar2.Maximum = 90;
            this.trackBar2.Minimum = -90;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(168, 45);
            this.trackBar2.TabIndex = 7;
            this.trackBar2.TickFrequency = 15;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // shadowsToolStripMenuItem
            // 
            this.shadowsToolStripMenuItem.Checked = true;
            this.shadowsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shadowsToolStripMenuItem.Name = "shadowsToolStripMenuItem";
            this.shadowsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.shadowsToolStripMenuItem.Text = "Shadows";
            this.shadowsToolStripMenuItem.Click += new System.EventHandler(this.shadowsToolStripMenuItem_Click);
            // 
            // perspectiveToolStripMenuItem
            // 
            this.perspectiveToolStripMenuItem.Name = "perspectiveToolStripMenuItem";
            this.perspectiveToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.perspectiveToolStripMenuItem.Text = "Perspective";
            this.perspectiveToolStripMenuItem.Click += new System.EventHandler(this.perspectiveToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 423);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxMainImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelZoom.ResumeLayout(false);
            this.panelRotation.ResumeLayout(false);
            this.panelRotation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxMainImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem draw2DToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.ToolStripMenuItem draw3DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
        private System.Windows.Forms.Panel panelRotation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem movingToolStripMenuItem;
        private System.Windows.Forms.Panel panelZoom;
        private System.Windows.Forms.ToolStripMenuItem defaultScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightFromCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frontImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawWithZBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawWithTexturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gouraudShadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shadowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perspectiveToolStripMenuItem;
    }
}

