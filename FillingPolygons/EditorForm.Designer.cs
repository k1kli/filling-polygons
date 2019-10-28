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
            this.lightParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.mLightParameterTextBox = new System.Windows.Forms.TextBox();
            this.ksLightParameterTextBox = new System.Windows.Forms.TextBox();
            this.kdLightParameterTextBox = new System.Windows.Forms.TextBox();
            this.mLightParameterLabel = new System.Windows.Forms.Label();
            this.ksLightParameterLabel = new System.Windows.Forms.Label();
            this.kdLightParameterLabel = new System.Windows.Forms.Label();
            this.mLightParameterTrackBar = new System.Windows.Forms.TrackBar();
            this.ksLightParameterTrackBar = new System.Windows.Forms.TrackBar();
            this.kdLightParameterTrackBar = new System.Windows.Forms.TrackBar();
            this.constantLightParametersRadioButton = new System.Windows.Forms.RadioButton();
            this.randomLightParametersRadioButton = new System.Windows.Forms.RadioButton();
            this.chooseShaderGroupBox = new System.Windows.Forms.GroupBox();
            this.hybridShaderRadioButton = new System.Windows.Forms.RadioButton();
            this.vertexColorShaderRadioButton = new System.Windows.Forms.RadioButton();
            this.preciseShaderRadioButton = new System.Windows.Forms.RadioButton();
            this.lightGroupBox = new System.Windows.Forms.GroupBox();
            this.lightLocationLabel = new System.Windows.Forms.Label();
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
            this.constantLightPosLabel = new System.Windows.Forms.RadioButton();
            this.animateLightPosLabel = new System.Windows.Forms.RadioButton();
            this.editorLayoutPanel.SuspendLayout();
            this.ToolboxPanel.SuspendLayout();
            this.lightParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mLightParameterTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksLightParameterTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdLightParameterTrackBar)).BeginInit();
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
            this.editorLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.editorLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editorLayoutPanel.Controls.Add(this.ToolboxPanel, 0, 0);
            this.editorLayoutPanel.Controls.Add(this.drawAreaPanel, 1, 0);
            this.editorLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.editorLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.editorLayoutPanel.Name = "editorLayoutPanel";
            this.editorLayoutPanel.RowCount = 1;
            this.editorLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editorLayoutPanel.Size = new System.Drawing.Size(796, 628);
            this.editorLayoutPanel.TabIndex = 2;
            // 
            // ToolboxPanel
            // 
            this.ToolboxPanel.Controls.Add(this.lightParametersGroupBox);
            this.ToolboxPanel.Controls.Add(this.chooseShaderGroupBox);
            this.ToolboxPanel.Controls.Add(this.lightGroupBox);
            this.ToolboxPanel.Controls.Add(this.normalsSourceGroupBox);
            this.ToolboxPanel.Controls.Add(this.colorSourceGroupBox);
            this.ToolboxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolboxPanel.Location = new System.Drawing.Point(2, 2);
            this.ToolboxPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ToolboxPanel.Name = "ToolboxPanel";
            this.ToolboxPanel.Size = new System.Drawing.Size(232, 624);
            this.ToolboxPanel.TabIndex = 0;
            // 
            // lightParametersGroupBox
            // 
            this.lightParametersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lightParametersGroupBox.Controls.Add(this.mLightParameterTextBox);
            this.lightParametersGroupBox.Controls.Add(this.ksLightParameterTextBox);
            this.lightParametersGroupBox.Controls.Add(this.kdLightParameterTextBox);
            this.lightParametersGroupBox.Controls.Add(this.mLightParameterLabel);
            this.lightParametersGroupBox.Controls.Add(this.ksLightParameterLabel);
            this.lightParametersGroupBox.Controls.Add(this.kdLightParameterLabel);
            this.lightParametersGroupBox.Controls.Add(this.mLightParameterTrackBar);
            this.lightParametersGroupBox.Controls.Add(this.ksLightParameterTrackBar);
            this.lightParametersGroupBox.Controls.Add(this.kdLightParameterTrackBar);
            this.lightParametersGroupBox.Controls.Add(this.constantLightParametersRadioButton);
            this.lightParametersGroupBox.Controls.Add(this.randomLightParametersRadioButton);
            this.lightParametersGroupBox.Location = new System.Drawing.Point(7, 341);
            this.lightParametersGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.lightParametersGroupBox.Name = "lightParametersGroupBox";
            this.lightParametersGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.lightParametersGroupBox.Size = new System.Drawing.Size(223, 152);
            this.lightParametersGroupBox.TabIndex = 14;
            this.lightParametersGroupBox.TabStop = false;
            this.lightParametersGroupBox.Text = "Parametry Światła";
            // 
            // mLightParameterTextBox
            // 
            this.mLightParameterTextBox.Enabled = false;
            this.mLightParameterTextBox.Location = new System.Drawing.Point(194, 120);
            this.mLightParameterTextBox.Name = "mLightParameterTextBox";
            this.mLightParameterTextBox.Size = new System.Drawing.Size(24, 20);
            this.mLightParameterTextBox.TabIndex = 15;
            // 
            // ksLightParameterTextBox
            // 
            this.ksLightParameterTextBox.Enabled = false;
            this.ksLightParameterTextBox.Location = new System.Drawing.Point(194, 94);
            this.ksLightParameterTextBox.Name = "ksLightParameterTextBox";
            this.ksLightParameterTextBox.Size = new System.Drawing.Size(24, 20);
            this.ksLightParameterTextBox.TabIndex = 14;
            // 
            // kdLightParameterTextBox
            // 
            this.kdLightParameterTextBox.Enabled = false;
            this.kdLightParameterTextBox.Location = new System.Drawing.Point(195, 68);
            this.kdLightParameterTextBox.Name = "kdLightParameterTextBox";
            this.kdLightParameterTextBox.Size = new System.Drawing.Size(24, 20);
            this.kdLightParameterTextBox.TabIndex = 13;
            // 
            // mLightParameterLabel
            // 
            this.mLightParameterLabel.AutoSize = true;
            this.mLightParameterLabel.Location = new System.Drawing.Point(14, 119);
            this.mLightParameterLabel.Name = "mLightParameterLabel";
            this.mLightParameterLabel.Size = new System.Drawing.Size(15, 13);
            this.mLightParameterLabel.TabIndex = 12;
            this.mLightParameterLabel.Text = "m";
            // 
            // ksLightParameterLabel
            // 
            this.ksLightParameterLabel.AutoSize = true;
            this.ksLightParameterLabel.Location = new System.Drawing.Point(10, 93);
            this.ksLightParameterLabel.Name = "ksLightParameterLabel";
            this.ksLightParameterLabel.Size = new System.Drawing.Size(19, 13);
            this.ksLightParameterLabel.TabIndex = 11;
            this.ksLightParameterLabel.Text = "Ks";
            // 
            // kdLightParameterLabel
            // 
            this.kdLightParameterLabel.AutoSize = true;
            this.kdLightParameterLabel.Location = new System.Drawing.Point(9, 65);
            this.kdLightParameterLabel.Name = "kdLightParameterLabel";
            this.kdLightParameterLabel.Size = new System.Drawing.Size(20, 13);
            this.kdLightParameterLabel.TabIndex = 10;
            this.kdLightParameterLabel.Text = "Kd";
            // 
            // mLightParameterTrackBar
            // 
            this.mLightParameterTrackBar.Enabled = false;
            this.mLightParameterTrackBar.Location = new System.Drawing.Point(35, 119);
            this.mLightParameterTrackBar.Maximum = 100;
            this.mLightParameterTrackBar.Name = "mLightParameterTrackBar";
            this.mLightParameterTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mLightParameterTrackBar.Size = new System.Drawing.Size(154, 45);
            this.mLightParameterTrackBar.TabIndex = 9;
            this.mLightParameterTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mLightParameterTrackBar.Scroll += new System.EventHandler(this.LightParametersScroll);
            // 
            // ksLightParameterTrackBar
            // 
            this.ksLightParameterTrackBar.Enabled = false;
            this.ksLightParameterTrackBar.Location = new System.Drawing.Point(35, 93);
            this.ksLightParameterTrackBar.Maximum = 100;
            this.ksLightParameterTrackBar.Name = "ksLightParameterTrackBar";
            this.ksLightParameterTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ksLightParameterTrackBar.Size = new System.Drawing.Size(154, 45);
            this.ksLightParameterTrackBar.TabIndex = 8;
            this.ksLightParameterTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ksLightParameterTrackBar.Scroll += new System.EventHandler(this.LightParametersScroll);
            // 
            // kdLightParameterTrackBar
            // 
            this.kdLightParameterTrackBar.Enabled = false;
            this.kdLightParameterTrackBar.Location = new System.Drawing.Point(35, 68);
            this.kdLightParameterTrackBar.Maximum = 100;
            this.kdLightParameterTrackBar.Name = "kdLightParameterTrackBar";
            this.kdLightParameterTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kdLightParameterTrackBar.Size = new System.Drawing.Size(153, 45);
            this.kdLightParameterTrackBar.TabIndex = 7;
            this.kdLightParameterTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kdLightParameterTrackBar.Scroll += new System.EventHandler(this.LightParametersScroll);
            // 
            // constantLightParametersRadioButton
            // 
            this.constantLightParametersRadioButton.AutoSize = true;
            this.constantLightParametersRadioButton.Location = new System.Drawing.Point(4, 46);
            this.constantLightParametersRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.constantLightParametersRadioButton.Name = "constantLightParametersRadioButton";
            this.constantLightParametersRadioButton.Size = new System.Drawing.Size(51, 17);
            this.constantLightParametersRadioButton.TabIndex = 6;
            this.constantLightParametersRadioButton.TabStop = true;
            this.constantLightParametersRadioButton.Text = "Stałe";
            this.constantLightParametersRadioButton.UseVisualStyleBackColor = true;
            this.constantLightParametersRadioButton.CheckedChanged += new System.EventHandler(this.ConstantLightParametersRadioButton_CheckedChanged);
            // 
            // randomLightParametersRadioButton
            // 
            this.randomLightParametersRadioButton.AutoSize = true;
            this.randomLightParametersRadioButton.Checked = true;
            this.randomLightParametersRadioButton.Location = new System.Drawing.Point(4, 24);
            this.randomLightParametersRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.randomLightParametersRadioButton.Name = "randomLightParametersRadioButton";
            this.randomLightParametersRadioButton.Size = new System.Drawing.Size(155, 17);
            this.randomLightParametersRadioButton.TabIndex = 5;
            this.randomLightParametersRadioButton.TabStop = true;
            this.randomLightParametersRadioButton.Text = "Losowe dla każdego trójąta";
            this.randomLightParametersRadioButton.UseVisualStyleBackColor = true;
            this.randomLightParametersRadioButton.CheckedChanged += new System.EventHandler(this.RandomLightParametersRadioButton_CheckedChanged);
            // 
            // chooseShaderGroupBox
            // 
            this.chooseShaderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseShaderGroupBox.Controls.Add(this.hybridShaderRadioButton);
            this.chooseShaderGroupBox.Controls.Add(this.vertexColorShaderRadioButton);
            this.chooseShaderGroupBox.Controls.Add(this.preciseShaderRadioButton);
            this.chooseShaderGroupBox.Location = new System.Drawing.Point(7, 244);
            this.chooseShaderGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.chooseShaderGroupBox.Name = "chooseShaderGroupBox";
            this.chooseShaderGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.chooseShaderGroupBox.Size = new System.Drawing.Size(223, 93);
            this.chooseShaderGroupBox.TabIndex = 13;
            this.chooseShaderGroupBox.TabStop = false;
            this.chooseShaderGroupBox.Text = "Wyznaczanie koloru piksela";
            // 
            // hybridShaderRadioButton
            // 
            this.hybridShaderRadioButton.AutoSize = true;
            this.hybridShaderRadioButton.Location = new System.Drawing.Point(4, 68);
            this.hybridShaderRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.hybridShaderRadioButton.Name = "hybridShaderRadioButton";
            this.hybridShaderRadioButton.Size = new System.Drawing.Size(78, 17);
            this.hybridShaderRadioButton.TabIndex = 7;
            this.hybridShaderRadioButton.TabStop = true;
            this.hybridShaderRadioButton.Text = "Hybrydowo";
            this.hybridShaderRadioButton.UseVisualStyleBackColor = true;
            this.hybridShaderRadioButton.CheckedChanged += new System.EventHandler(this.HybridShaderRadioButton_CheckedChanged);
            // 
            // vertexColorShaderRadioButton
            // 
            this.vertexColorShaderRadioButton.AutoSize = true;
            this.vertexColorShaderRadioButton.Location = new System.Drawing.Point(4, 46);
            this.vertexColorShaderRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.vertexColorShaderRadioButton.Name = "vertexColorShaderRadioButton";
            this.vertexColorShaderRadioButton.Size = new System.Drawing.Size(135, 17);
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
            this.preciseShaderRadioButton.Location = new System.Drawing.Point(4, 24);
            this.preciseShaderRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.preciseShaderRadioButton.Name = "preciseShaderRadioButton";
            this.preciseShaderRadioButton.Size = new System.Drawing.Size(75, 17);
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
            this.lightGroupBox.Controls.Add(this.animateLightPosLabel);
            this.lightGroupBox.Controls.Add(this.constantLightPosLabel);
            this.lightGroupBox.Controls.Add(this.lightLocationLabel);
            this.lightGroupBox.Controls.Add(this.chooseLightColorButton);
            this.lightGroupBox.Location = new System.Drawing.Point(7, 155);
            this.lightGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.lightGroupBox.Name = "lightGroupBox";
            this.lightGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.lightGroupBox.Size = new System.Drawing.Size(223, 85);
            this.lightGroupBox.TabIndex = 5;
            this.lightGroupBox.TabStop = false;
            this.lightGroupBox.Text = "Światło";
            // 
            // lightLocationLabel
            // 
            this.lightLocationLabel.AutoSize = true;
            this.lightLocationLabel.Location = new System.Drawing.Point(4, 17);
            this.lightLocationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lightLocationLabel.Name = "lightLocationLabel";
            this.lightLocationLabel.Size = new System.Drawing.Size(82, 13);
            this.lightLocationLabel.TabIndex = 5;
            this.lightLocationLabel.Text = "Lokacja światła";
            // 
            // chooseLightColorButton
            // 
            this.chooseLightColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseLightColorButton.Location = new System.Drawing.Point(133, 17);
            this.chooseLightColorButton.Margin = new System.Windows.Forms.Padding(2);
            this.chooseLightColorButton.Name = "chooseLightColorButton";
            this.chooseLightColorButton.Size = new System.Drawing.Size(85, 37);
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
            this.normalsSourceGroupBox.Location = new System.Drawing.Point(7, 81);
            this.normalsSourceGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.normalsSourceGroupBox.Name = "normalsSourceGroupBox";
            this.normalsSourceGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.normalsSourceGroupBox.Size = new System.Drawing.Size(223, 69);
            this.normalsSourceGroupBox.TabIndex = 4;
            this.normalsSourceGroupBox.TabStop = false;
            this.normalsSourceGroupBox.Text = "Źródło wektora normalnego";
            // 
            // chooseNormalMapButton
            // 
            this.chooseNormalMapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseNormalMapButton.Enabled = false;
            this.chooseNormalMapButton.Location = new System.Drawing.Point(134, 41);
            this.chooseNormalMapButton.Margin = new System.Windows.Forms.Padding(2);
            this.chooseNormalMapButton.Name = "chooseNormalMapButton";
            this.chooseNormalMapButton.Size = new System.Drawing.Size(85, 19);
            this.chooseNormalMapButton.TabIndex = 4;
            this.chooseNormalMapButton.Text = "Wybierz";
            this.chooseNormalMapButton.UseVisualStyleBackColor = true;
            this.chooseNormalMapButton.Click += new System.EventHandler(this.ChooseNormalMapButton_Click);
            // 
            // staticNormalRadioButton
            // 
            this.staticNormalRadioButton.AutoSize = true;
            this.staticNormalRadioButton.Checked = true;
            this.staticNormalRadioButton.Location = new System.Drawing.Point(4, 19);
            this.staticNormalRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.staticNormalRadioButton.Name = "staticNormalRadioButton";
            this.staticNormalRadioButton.Size = new System.Drawing.Size(83, 17);
            this.staticNormalRadioButton.TabIndex = 1;
            this.staticNormalRadioButton.TabStop = true;
            this.staticNormalRadioButton.Text = "Stały [0,0,1]";
            this.staticNormalRadioButton.UseVisualStyleBackColor = true;
            this.staticNormalRadioButton.CheckedChanged += new System.EventHandler(this.StaticNormalRadioButton_CheckedChanged);
            // 
            // normalMapRadioButton
            // 
            this.normalMapRadioButton.AutoSize = true;
            this.normalMapRadioButton.Location = new System.Drawing.Point(4, 42);
            this.normalMapRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.normalMapRadioButton.Name = "normalMapRadioButton";
            this.normalMapRadioButton.Size = new System.Drawing.Size(99, 17);
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
            this.colorSourceGroupBox.Location = new System.Drawing.Point(7, 7);
            this.colorSourceGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.colorSourceGroupBox.Name = "colorSourceGroupBox";
            this.colorSourceGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.colorSourceGroupBox.Size = new System.Drawing.Size(223, 69);
            this.colorSourceGroupBox.TabIndex = 3;
            this.colorSourceGroupBox.TabStop = false;
            this.colorSourceGroupBox.Text = "Źródło koloru";
            // 
            // chooseImageButton
            // 
            this.chooseImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseImageButton.Location = new System.Drawing.Point(134, 41);
            this.chooseImageButton.Margin = new System.Windows.Forms.Padding(2);
            this.chooseImageButton.Name = "chooseImageButton";
            this.chooseImageButton.Size = new System.Drawing.Size(85, 19);
            this.chooseImageButton.TabIndex = 4;
            this.chooseImageButton.Text = "Wybierz";
            this.chooseImageButton.UseVisualStyleBackColor = true;
            this.chooseImageButton.Click += new System.EventHandler(this.ChooseImageButton_Click);
            // 
            // chooseColorButton
            // 
            this.chooseColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseColorButton.Enabled = false;
            this.chooseColorButton.Location = new System.Drawing.Point(134, 17);
            this.chooseColorButton.Margin = new System.Windows.Forms.Padding(2);
            this.chooseColorButton.Name = "chooseColorButton";
            this.chooseColorButton.Size = new System.Drawing.Size(85, 19);
            this.chooseColorButton.TabIndex = 3;
            this.chooseColorButton.Text = "Wybierz";
            this.chooseColorButton.UseVisualStyleBackColor = true;
            this.chooseColorButton.Click += new System.EventHandler(this.ChooseColorButton_Click);
            // 
            // staticColorRadioButton
            // 
            this.staticColorRadioButton.AutoSize = true;
            this.staticColorRadioButton.Location = new System.Drawing.Point(4, 19);
            this.staticColorRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.staticColorRadioButton.Name = "staticColorRadioButton";
            this.staticColorRadioButton.Size = new System.Drawing.Size(75, 17);
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
            this.colorFromImageRadioButton.Location = new System.Drawing.Point(4, 42);
            this.colorFromImageRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.colorFromImageRadioButton.Name = "colorFromImageRadioButton";
            this.colorFromImageRadioButton.Size = new System.Drawing.Size(53, 17);
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
            this.drawAreaPanel.Location = new System.Drawing.Point(238, 2);
            this.drawAreaPanel.Margin = new System.Windows.Forms.Padding(2);
            this.drawAreaPanel.Name = "drawAreaPanel";
            this.drawAreaPanel.Size = new System.Drawing.Size(556, 624);
            this.drawAreaPanel.TabIndex = 1;
            // 
            // drawingBox
            // 
            this.drawingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingBox.Location = new System.Drawing.Point(0, 0);
            this.drawingBox.Margin = new System.Windows.Forms.Padding(2);
            this.drawingBox.Name = "drawingBox";
            this.drawingBox.Size = new System.Drawing.Size(556, 624);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(796, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawWireframeToolstripMenuItem});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // drawWireframeToolstripMenuItem
            // 
            this.drawWireframeToolstripMenuItem.Checked = true;
            this.drawWireframeToolstripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawWireframeToolstripMenuItem.Name = "drawWireframeToolstripMenuItem";
            this.drawWireframeToolstripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.drawWireframeToolstripMenuItem.Text = "Rysuj szkielet";
            this.drawWireframeToolstripMenuItem.Click += new System.EventHandler(this.DrawWireframeToolStripMenuItem_Click);
            // 
            // constantLightPosLabel
            // 
            this.constantLightPosLabel.AutoSize = true;
            this.constantLightPosLabel.Location = new System.Drawing.Point(4, 36);
            this.constantLightPosLabel.Name = "constantLightPosLabel";
            this.constantLightPosLabel.Size = new System.Drawing.Size(51, 17);
            this.constantLightPosLabel.TabIndex = 6;
            this.constantLightPosLabel.TabStop = true;
            this.constantLightPosLabel.Text = "Stała";
            this.constantLightPosLabel.UseVisualStyleBackColor = true;
            this.constantLightPosLabel.CheckedChanged += new System.EventHandler(this.ConstantLightPosLabel_CheckedChanged);
            // 
            // animateLightPosLabel
            // 
            this.animateLightPosLabel.AutoSize = true;
            this.animateLightPosLabel.Location = new System.Drawing.Point(4, 59);
            this.animateLightPosLabel.Name = "animateLightPosLabel";
            this.animateLightPosLabel.Size = new System.Drawing.Size(171, 17);
            this.animateLightPosLabel.TabIndex = 7;
            this.animateLightPosLabel.TabStop = true;
            this.animateLightPosLabel.Text = "Punkt animowany po półsferze";
            this.animateLightPosLabel.UseVisualStyleBackColor = true;
            this.animateLightPosLabel.CheckedChanged += new System.EventHandler(this.AnimateLightPosLabel_CheckedChanged);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 652);
            this.Controls.Add(this.editorLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditorForm";
            this.Text = "EditorForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.ClientSizeChanged += new System.EventHandler(this.EditorForm_ClientSizeChanged);
            this.editorLayoutPanel.ResumeLayout(false);
            this.ToolboxPanel.ResumeLayout(false);
            this.lightParametersGroupBox.ResumeLayout(false);
            this.lightParametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mLightParameterTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksLightParameterTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdLightParameterTrackBar)).EndInit();
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
        private System.Windows.Forms.Label lightLocationLabel;
        private System.Windows.Forms.Button chooseLightColorButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawWireframeToolstripMenuItem;
        private System.Windows.Forms.GroupBox chooseShaderGroupBox;
        private System.Windows.Forms.RadioButton hybridShaderRadioButton;
        private System.Windows.Forms.RadioButton vertexColorShaderRadioButton;
        private System.Windows.Forms.RadioButton preciseShaderRadioButton;
        private System.Windows.Forms.GroupBox lightParametersGroupBox;
        private System.Windows.Forms.RadioButton constantLightParametersRadioButton;
        private System.Windows.Forms.RadioButton randomLightParametersRadioButton;
        private System.Windows.Forms.Label mLightParameterLabel;
        private System.Windows.Forms.Label ksLightParameterLabel;
        private System.Windows.Forms.Label kdLightParameterLabel;
        private System.Windows.Forms.TrackBar mLightParameterTrackBar;
        private System.Windows.Forms.TrackBar ksLightParameterTrackBar;
        private System.Windows.Forms.TrackBar kdLightParameterTrackBar;
        private System.Windows.Forms.TextBox mLightParameterTextBox;
        private System.Windows.Forms.TextBox ksLightParameterTextBox;
        private System.Windows.Forms.TextBox kdLightParameterTextBox;
        private System.Windows.Forms.RadioButton animateLightPosLabel;
        private System.Windows.Forms.RadioButton constantLightPosLabel;
    }
}