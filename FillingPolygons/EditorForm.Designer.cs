namespace FillingPolygons
{
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.editorLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ToolboxPanel = new System.Windows.Forms.Panel();
            this.chooseShaderGroupBox = new System.Windows.Forms.GroupBox();
            this.hybridShaderRadioButton = new System.Windows.Forms.RadioButton();
            this.vertexColorShaderRadioButton = new System.Windows.Forms.RadioButton();
            this.preciseShaderRadioButton = new System.Windows.Forms.RadioButton();
            this.lightGroupBox = new System.Windows.Forms.GroupBox();
            this.confirmToLightVectorButton = new System.Windows.Forms.Button();
            this.zToLightVectorTextBox = new System.Windows.Forms.TextBox();
            this.yToLightVectorTextBox = new System.Windows.Forms.TextBox();
            this.xToLightVectorTextBox = new System.Windows.Forms.TextBox();
            this.toLightVectorZLabel = new System.Windows.Forms.Label();
            this.toLightVectorYLabel = new System.Windows.Forms.Label();
            this.toLightVectorXLabel = new System.Windows.Forms.Label();
            this.toLightVectorLabel = new System.Windows.Forms.Label();
            this.chooseLightColorButton = new System.Windows.Forms.Button();
            this.normalsSourceGroupBox = new System.Windows.Forms.GroupBox();
            this.chooseNormalMapButton = new System.Windows.Forms.Button();
            this.staticNormalRadioButton = new System.Windows.Forms.RadioButton();
            this.normalMapRadioButton = new System.Windows.Forms.RadioButton();
            this.colorSourceGroupBox = new System.Windows.Forms.GroupBox();
            this.chooseImageButton = new System.Windows.Forms.Button();
            this.chooseColorButton = new System.Windows.Forms.Button();
            this.staticColorRadioButton = new System.Windows.Forms.RadioButton();
            this.colorFromImageRadioButton = new System.Windows.Forms.RadioButton();
            this.drawAreaPanel = new System.Windows.Forms.Panel();
            this.drawingBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWireframeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorLayoutPanel.SuspendLayout();
            this.ToolboxPanel.SuspendLayout();
            this.chooseShaderGroupBox.SuspendLayout();
            this.lightGroupBox.SuspendLayout();
            this.normalsSourceGroupBox.SuspendLayout();
            this.colorSourceGroupBox.SuspendLayout();
            this.drawAreaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editorLayoutPanel
            // 
            this.editorLayoutPanel.ColumnCount = 2;
            this.editorLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.editorLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editorLayoutPanel.Controls.Add(this.ToolboxPanel, 0, 0);
            this.editorLayoutPanel.Controls.Add(this.drawAreaPanel, 1, 0);
            this.editorLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this.editorLayoutPanel.Name = "editorLayoutPanel";
            this.editorLayoutPanel.RowCount = 1;
            this.editorLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editorLayoutPanel.Size = new System.Drawing.Size(1062, 658);
            this.editorLayoutPanel.TabIndex = 2;
            // 
            // ToolboxPanel
            // 
            this.ToolboxPanel.Controls.Add(this.chooseShaderGroupBox);
            this.ToolboxPanel.Controls.Add(this.lightGroupBox);
            this.ToolboxPanel.Controls.Add(this.normalsSourceGroupBox);
            this.ToolboxPanel.Controls.Add(this.colorSourceGroupBox);
            this.ToolboxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolboxPanel.Location = new System.Drawing.Point(3, 3);
            this.ToolboxPanel.Name = "ToolboxPanel";
            this.ToolboxPanel.Size = new System.Drawing.Size(312, 652);
            this.ToolboxPanel.TabIndex = 0;
            // 
            // chooseShaderGroupBox
            // 
            this.chooseShaderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseShaderGroupBox.Controls.Add(this.hybridShaderRadioButton);
            this.chooseShaderGroupBox.Controls.Add(this.vertexColorShaderRadioButton);
            this.chooseShaderGroupBox.Controls.Add(this.preciseShaderRadioButton);
            this.chooseShaderGroupBox.Location = new System.Drawing.Point(9, 335);
            this.chooseShaderGroupBox.Name = "chooseShaderGroupBox";
            this.chooseShaderGroupBox.Size = new System.Drawing.Size(300, 114);
            this.chooseShaderGroupBox.TabIndex = 13;
            this.chooseShaderGroupBox.TabStop = false;
            this.chooseShaderGroupBox.Text = "Wyznaczanie koloru piksela";
            // 
            // hybridShaderRadioButton
            // 
            this.hybridShaderRadioButton.AutoSize = true;
            this.hybridShaderRadioButton.Location = new System.Drawing.Point(6, 84);
            this.hybridShaderRadioButton.Name = "hybridShaderRadioButton";
            this.hybridShaderRadioButton.Size = new System.Drawing.Size(99, 21);
            this.hybridShaderRadioButton.TabIndex = 7;
            this.hybridShaderRadioButton.TabStop = true;
            this.hybridShaderRadioButton.Text = "Hybrydowo";
            this.hybridShaderRadioButton.UseVisualStyleBackColor = true;
            this.hybridShaderRadioButton.CheckedChanged += new System.EventHandler(this.HybridShaderRadioButton_CheckedChanged);
            // 
            // vertexColorShaderRadioButton
            // 
            this.vertexColorShaderRadioButton.AutoSize = true;
            this.vertexColorShaderRadioButton.Location = new System.Drawing.Point(6, 57);
            this.vertexColorShaderRadioButton.Name = "vertexColorShaderRadioButton";
            this.vertexColorShaderRadioButton.Size = new System.Drawing.Size(168, 21);
            this.vertexColorShaderRadioButton.TabIndex = 6;
            this.vertexColorShaderRadioButton.TabStop = true;
            this.vertexColorShaderRadioButton.Text = "Tylko w wierzchołkach";
            this.vertexColorShaderRadioButton.UseVisualStyleBackColor = true;
            this.vertexColorShaderRadioButton.CheckedChanged += new System.EventHandler(this.VertexColorShaderRadioButton_CheckedChanged);
            // 
            // preciseShaderRadioButton
            // 
            this.preciseShaderRadioButton.AutoSize = true;
            this.preciseShaderRadioButton.Checked = true;
            this.preciseShaderRadioButton.Location = new System.Drawing.Point(6, 30);
            this.preciseShaderRadioButton.Name = "preciseShaderRadioButton";
            this.preciseShaderRadioButton.Size = new System.Drawing.Size(92, 21);
            this.preciseShaderRadioButton.TabIndex = 5;
            this.preciseShaderRadioButton.TabStop = true;
            this.preciseShaderRadioButton.Text = "Dokładnie";
            this.preciseShaderRadioButton.UseVisualStyleBackColor = true;
            this.preciseShaderRadioButton.CheckedChanged += new System.EventHandler(this.PreciseShaderRadioButton_CheckedChanged);
            // 
            // lightGroupBox
            // 
            this.lightGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lightGroupBox.Controls.Add(this.confirmToLightVectorButton);
            this.lightGroupBox.Controls.Add(this.zToLightVectorTextBox);
            this.lightGroupBox.Controls.Add(this.yToLightVectorTextBox);
            this.lightGroupBox.Controls.Add(this.xToLightVectorTextBox);
            this.lightGroupBox.Controls.Add(this.toLightVectorZLabel);
            this.lightGroupBox.Controls.Add(this.toLightVectorYLabel);
            this.lightGroupBox.Controls.Add(this.toLightVectorXLabel);
            this.lightGroupBox.Controls.Add(this.toLightVectorLabel);
            this.lightGroupBox.Controls.Add(this.chooseLightColorButton);
            this.lightGroupBox.Location = new System.Drawing.Point(9, 191);
            this.lightGroupBox.Name = "lightGroupBox";
            this.lightGroupBox.Size = new System.Drawing.Size(300, 138);
            this.lightGroupBox.TabIndex = 5;
            this.lightGroupBox.TabStop = false;
            this.lightGroupBox.Text = "Światło";
            // 
            // confirmToLightVectorButton
            // 
            this.confirmToLightVectorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmToLightVectorButton.Location = new System.Drawing.Point(181, 79);
            this.confirmToLightVectorButton.Name = "confirmToLightVectorButton";
            this.confirmToLightVectorButton.Size = new System.Drawing.Size(113, 46);
            this.confirmToLightVectorButton.TabIndex = 12;
            this.confirmToLightVectorButton.Text = "Zatwierdź wektor";
            this.confirmToLightVectorButton.UseVisualStyleBackColor = true;
            this.confirmToLightVectorButton.Click += new System.EventHandler(this.ConfirmToLightVectorButton_Click);
            // 
            // zToLightVectorTextBox
            // 
            this.zToLightVectorTextBox.Location = new System.Drawing.Point(29, 103);
            this.zToLightVectorTextBox.Name = "zToLightVectorTextBox";
            this.zToLightVectorTextBox.Size = new System.Drawing.Size(140, 22);
            this.zToLightVectorTextBox.TabIndex = 11;
            this.zToLightVectorTextBox.Text = "1";
            // 
            // yToLightVectorTextBox
            // 
            this.yToLightVectorTextBox.Location = new System.Drawing.Point(29, 76);
            this.yToLightVectorTextBox.Name = "yToLightVectorTextBox";
            this.yToLightVectorTextBox.Size = new System.Drawing.Size(140, 22);
            this.yToLightVectorTextBox.TabIndex = 10;
            this.yToLightVectorTextBox.Text = "0";
            // 
            // xToLightVectorTextBox
            // 
            this.xToLightVectorTextBox.Location = new System.Drawing.Point(29, 50);
            this.xToLightVectorTextBox.Name = "xToLightVectorTextBox";
            this.xToLightVectorTextBox.Size = new System.Drawing.Size(140, 22);
            this.xToLightVectorTextBox.TabIndex = 9;
            this.xToLightVectorTextBox.Text = "0";
            // 
            // toLightVectorZLabel
            // 
            this.toLightVectorZLabel.AutoSize = true;
            this.toLightVectorZLabel.Location = new System.Drawing.Point(6, 103);
            this.toLightVectorZLabel.Name = "toLightVectorZLabel";
            this.toLightVectorZLabel.Size = new System.Drawing.Size(17, 17);
            this.toLightVectorZLabel.TabIndex = 8;
            this.toLightVectorZLabel.Text = "Z";
            // 
            // toLightVectorYLabel
            // 
            this.toLightVectorYLabel.AutoSize = true;
            this.toLightVectorYLabel.Location = new System.Drawing.Point(6, 76);
            this.toLightVectorYLabel.Name = "toLightVectorYLabel";
            this.toLightVectorYLabel.Size = new System.Drawing.Size(17, 17);
            this.toLightVectorYLabel.TabIndex = 7;
            this.toLightVectorYLabel.Text = "Y";
            // 
            // toLightVectorXLabel
            // 
            this.toLightVectorXLabel.AutoSize = true;
            this.toLightVectorXLabel.Location = new System.Drawing.Point(6, 50);
            this.toLightVectorXLabel.Name = "toLightVectorXLabel";
            this.toLightVectorXLabel.Size = new System.Drawing.Size(17, 17);
            this.toLightVectorXLabel.TabIndex = 6;
            this.toLightVectorXLabel.Text = "X";
            // 
            // toLightVectorLabel
            // 
            this.toLightVectorLabel.AutoSize = true;
            this.toLightVectorLabel.Location = new System.Drawing.Point(6, 21);
            this.toLightVectorLabel.Name = "toLightVectorLabel";
            this.toLightVectorLabel.Size = new System.Drawing.Size(119, 17);
            this.toLightVectorLabel.TabIndex = 5;
            this.toLightVectorLabel.Text = "Wektor do światła";
            // 
            // chooseLightColorButton
            // 
            this.chooseLightColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseLightColorButton.Location = new System.Drawing.Point(181, 21);
            this.chooseLightColorButton.Name = "chooseLightColorButton";
            this.chooseLightColorButton.Size = new System.Drawing.Size(113, 46);
            this.chooseLightColorButton.TabIndex = 4;
            this.chooseLightColorButton.Text = "Wybierz kolor";
            this.chooseLightColorButton.UseVisualStyleBackColor = true;
            this.chooseLightColorButton.Click += new System.EventHandler(this.ChooseLightColorButton_Click);
            // 
            // normalsSourceGroupBox
            // 
            this.normalsSourceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.normalsSourceGroupBox.Controls.Add(this.chooseNormalMapButton);
            this.normalsSourceGroupBox.Controls.Add(this.staticNormalRadioButton);
            this.normalsSourceGroupBox.Controls.Add(this.normalMapRadioButton);
            this.normalsSourceGroupBox.Location = new System.Drawing.Point(9, 100);
            this.normalsSourceGroupBox.Name = "normalsSourceGroupBox";
            this.normalsSourceGroupBox.Size = new System.Drawing.Size(300, 85);
            this.normalsSourceGroupBox.TabIndex = 4;
            this.normalsSourceGroupBox.TabStop = false;
            this.normalsSourceGroupBox.Text = "Źródło wektora normalnego";
            // 
            // chooseNormalMapButton
            // 
            this.chooseNormalMapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseNormalMapButton.Enabled = false;
            this.chooseNormalMapButton.Location = new System.Drawing.Point(181, 51);
            this.chooseNormalMapButton.Name = "chooseNormalMapButton";
            this.chooseNormalMapButton.Size = new System.Drawing.Size(113, 23);
            this.chooseNormalMapButton.TabIndex = 4;
            this.chooseNormalMapButton.Text = "Wybierz";
            this.chooseNormalMapButton.UseVisualStyleBackColor = true;
            this.chooseNormalMapButton.Click += new System.EventHandler(this.ChooseNormalMapButton_Click);
            // 
            // staticNormalRadioButton
            // 
            this.staticNormalRadioButton.AutoSize = true;
            this.staticNormalRadioButton.Checked = true;
            this.staticNormalRadioButton.Location = new System.Drawing.Point(6, 23);
            this.staticNormalRadioButton.Name = "staticNormalRadioButton";
            this.staticNormalRadioButton.Size = new System.Drawing.Size(104, 21);
            this.staticNormalRadioButton.TabIndex = 1;
            this.staticNormalRadioButton.TabStop = true;
            this.staticNormalRadioButton.Text = "Stały [0,0,1]";
            this.staticNormalRadioButton.UseVisualStyleBackColor = true;
            this.staticNormalRadioButton.CheckedChanged += new System.EventHandler(this.StaticNormalRadioButton_CheckedChanged);
            // 
            // normalMapRadioButton
            // 
            this.normalMapRadioButton.AutoSize = true;
            this.normalMapRadioButton.Location = new System.Drawing.Point(6, 52);
            this.normalMapRadioButton.Name = "normalMapRadioButton";
            this.normalMapRadioButton.Size = new System.Drawing.Size(129, 21);
            this.normalMapRadioButton.TabIndex = 2;
            this.normalMapRadioButton.TabStop = true;
            this.normalMapRadioButton.Text = "Tekstura (RGB)";
            this.normalMapRadioButton.UseVisualStyleBackColor = true;
            this.normalMapRadioButton.CheckedChanged += new System.EventHandler(this.NormalMapRadioButton_CheckedChanged);
            // 
            // colorSourceGroupBox
            // 
            this.colorSourceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSourceGroupBox.Controls.Add(this.chooseImageButton);
            this.colorSourceGroupBox.Controls.Add(this.chooseColorButton);
            this.colorSourceGroupBox.Controls.Add(this.staticColorRadioButton);
            this.colorSourceGroupBox.Controls.Add(this.colorFromImageRadioButton);
            this.colorSourceGroupBox.Location = new System.Drawing.Point(9, 9);
            this.colorSourceGroupBox.Name = "colorSourceGroupBox";
            this.colorSourceGroupBox.Size = new System.Drawing.Size(300, 85);
            this.colorSourceGroupBox.TabIndex = 3;
            this.colorSourceGroupBox.TabStop = false;
            this.colorSourceGroupBox.Text = "Źródło koloru";
            // 
            // chooseImageButton
            // 
            this.chooseImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseImageButton.Location = new System.Drawing.Point(181, 50);
            this.chooseImageButton.Name = "chooseImageButton";
            this.chooseImageButton.Size = new System.Drawing.Size(113, 23);
            this.chooseImageButton.TabIndex = 4;
            this.chooseImageButton.Text = "Wybierz";
            this.chooseImageButton.UseVisualStyleBackColor = true;
            this.chooseImageButton.Click += new System.EventHandler(this.ChooseImageButton_Click);
            // 
            // chooseColorButton
            // 
            this.chooseColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseColorButton.Enabled = false;
            this.chooseColorButton.Location = new System.Drawing.Point(181, 21);
            this.chooseColorButton.Name = "chooseColorButton";
            this.chooseColorButton.Size = new System.Drawing.Size(113, 23);
            this.chooseColorButton.TabIndex = 3;
            this.chooseColorButton.Text = "Wybierz";
            this.chooseColorButton.UseVisualStyleBackColor = true;
            this.chooseColorButton.Click += new System.EventHandler(this.ChooseColorButton_Click);
            // 
            // staticColorRadioButton
            // 
            this.staticColorRadioButton.AutoSize = true;
            this.staticColorRadioButton.Location = new System.Drawing.Point(6, 23);
            this.staticColorRadioButton.Name = "staticColorRadioButton";
            this.staticColorRadioButton.Size = new System.Drawing.Size(95, 21);
            this.staticColorRadioButton.TabIndex = 1;
            this.staticColorRadioButton.TabStop = true;
            this.staticColorRadioButton.Text = "Kolor stały";
            this.staticColorRadioButton.UseVisualStyleBackColor = true;
            this.staticColorRadioButton.CheckedChanged += new System.EventHandler(this.StaticColorRadioButton_CheckedChanged);
            // 
            // colorFromImageRadioButton
            // 
            this.colorFromImageRadioButton.AutoSize = true;
            this.colorFromImageRadioButton.Checked = true;
            this.colorFromImageRadioButton.Location = new System.Drawing.Point(6, 52);
            this.colorFromImageRadioButton.Name = "colorFromImageRadioButton";
            this.colorFromImageRadioButton.Size = new System.Drawing.Size(68, 21);
            this.colorFromImageRadioButton.TabIndex = 2;
            this.colorFromImageRadioButton.TabStop = true;
            this.colorFromImageRadioButton.Text = "Obraz";
            this.colorFromImageRadioButton.UseVisualStyleBackColor = true;
            this.colorFromImageRadioButton.CheckedChanged += new System.EventHandler(this.ColorFromImageRadioButton_CheckedChanged);
            // 
            // drawAreaPanel
            // 
            this.drawAreaPanel.Controls.Add(this.drawingBox);
            this.drawAreaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawAreaPanel.Location = new System.Drawing.Point(321, 3);
            this.drawAreaPanel.Name = "drawAreaPanel";
            this.drawAreaPanel.Size = new System.Drawing.Size(738, 652);
            this.drawAreaPanel.TabIndex = 1;
            // 
            // drawingBox
            // 
            this.drawingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingBox.Location = new System.Drawing.Point(0, 0);
            this.drawingBox.Name = "drawingBox";
            this.drawingBox.Size = new System.Drawing.Size(738, 652);
            this.drawingBox.TabIndex = 0;
            this.drawingBox.TabStop = false;
            this.drawingBox.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingBox_Paint);
            this.drawingBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingBox_MouseDown);
            this.drawingBox.MouseLeave += new System.EventHandler(this.DrawingBox_MouseLeave);
            this.drawingBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingBox_MouseMove);
            this.drawingBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingBox_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.widokToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawWireframeToolstripMenuItem});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // drawWireframeToolstripMenuItem
            // 
            this.drawWireframeToolstripMenuItem.Checked = true;
            this.drawWireframeToolstripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawWireframeToolstripMenuItem.Name = "drawWireframeToolstripMenuItem";
            this.drawWireframeToolstripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.drawWireframeToolstripMenuItem.Text = "Rysuj szkielet";
            this.drawWireframeToolstripMenuItem.Click += new System.EventHandler(this.DrawWireframeToolStripMenuItem_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 686);
            this.Controls.Add(this.editorLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "EditorForm";
            this.Text = "EditorForm";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.ClientSizeChanged += new System.EventHandler(this.EditorForm_ClientSizeChanged);
            this.editorLayoutPanel.ResumeLayout(false);
            this.ToolboxPanel.ResumeLayout(false);
            this.chooseShaderGroupBox.ResumeLayout(false);
            this.chooseShaderGroupBox.PerformLayout();
            this.lightGroupBox.ResumeLayout(false);
            this.lightGroupBox.PerformLayout();
            this.normalsSourceGroupBox.ResumeLayout(false);
            this.normalsSourceGroupBox.PerformLayout();
            this.colorSourceGroupBox.ResumeLayout(false);
            this.colorSourceGroupBox.PerformLayout();
            this.drawAreaPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel editorLayoutPanel;
        private System.Windows.Forms.Panel ToolboxPanel;
        private System.Windows.Forms.Panel drawAreaPanel;
        private System.Windows.Forms.PictureBox drawingBox;
        private System.Windows.Forms.GroupBox colorSourceGroupBox;
        private System.Windows.Forms.RadioButton staticColorRadioButton;
        private System.Windows.Forms.RadioButton colorFromImageRadioButton;
        private System.Windows.Forms.Button chooseImageButton;
        private System.Windows.Forms.Button chooseColorButton;
        private System.Windows.Forms.GroupBox normalsSourceGroupBox;
        private System.Windows.Forms.Button chooseNormalMapButton;
        private System.Windows.Forms.RadioButton staticNormalRadioButton;
        private System.Windows.Forms.RadioButton normalMapRadioButton;
        private System.Windows.Forms.GroupBox lightGroupBox;
        private System.Windows.Forms.Button confirmToLightVectorButton;
        private System.Windows.Forms.TextBox zToLightVectorTextBox;
        private System.Windows.Forms.TextBox yToLightVectorTextBox;
        private System.Windows.Forms.TextBox xToLightVectorTextBox;
        private System.Windows.Forms.Label toLightVectorZLabel;
        private System.Windows.Forms.Label toLightVectorYLabel;
        private System.Windows.Forms.Label toLightVectorXLabel;
        private System.Windows.Forms.Label toLightVectorLabel;
        private System.Windows.Forms.Button chooseLightColorButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawWireframeToolstripMenuItem;
        private System.Windows.Forms.GroupBox chooseShaderGroupBox;
        private System.Windows.Forms.RadioButton hybridShaderRadioButton;
        private System.Windows.Forms.RadioButton vertexColorShaderRadioButton;
        private System.Windows.Forms.RadioButton preciseShaderRadioButton;
    }
}