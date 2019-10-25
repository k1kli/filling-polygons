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
            this.colorSourceGroupBox = new System.Windows.Forms.GroupBox();
            this.chooseImageButton = new System.Windows.Forms.Button();
            this.chooseColorButton = new System.Windows.Forms.Button();
            this.staticColorRadioButton = new System.Windows.Forms.RadioButton();
            this.colorFromImageRadioButton = new System.Windows.Forms.RadioButton();
            this.drawAreaPanel = new System.Windows.Forms.Panel();
            this.drawingBox = new System.Windows.Forms.PictureBox();
            this.editorLayoutPanel.SuspendLayout();
            this.ToolboxPanel.SuspendLayout();
            this.colorSourceGroupBox.SuspendLayout();
            this.drawAreaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // editorLayoutPanel
            // 
            this.editorLayoutPanel.ColumnCount = 2;
            this.editorLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.editorLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.editorLayoutPanel.Controls.Add(this.ToolboxPanel, 0, 0);
            this.editorLayoutPanel.Controls.Add(this.drawAreaPanel, 1, 0);
            this.editorLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.editorLayoutPanel.Name = "editorLayoutPanel";
            this.editorLayoutPanel.RowCount = 1;
            this.editorLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editorLayoutPanel.Size = new System.Drawing.Size(1062, 686);
            this.editorLayoutPanel.TabIndex = 2;
            // 
            // ToolboxPanel
            // 
            this.ToolboxPanel.Controls.Add(this.colorSourceGroupBox);
            this.ToolboxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolboxPanel.Location = new System.Drawing.Point(3, 3);
            this.ToolboxPanel.Name = "ToolboxPanel";
            this.ToolboxPanel.Size = new System.Drawing.Size(312, 680);
            this.ToolboxPanel.TabIndex = 0;
            // 
            // colorSourceGroupBox
            // 
            this.colorSourceGroupBox.Controls.Add(this.chooseImageButton);
            this.colorSourceGroupBox.Controls.Add(this.chooseColorButton);
            this.colorSourceGroupBox.Controls.Add(this.staticColorRadioButton);
            this.colorSourceGroupBox.Controls.Add(this.colorFromImageRadioButton);
            this.colorSourceGroupBox.Location = new System.Drawing.Point(9, 9);
            this.colorSourceGroupBox.Name = "colorSourceGroupBox";
            this.colorSourceGroupBox.Size = new System.Drawing.Size(300, 154);
            this.colorSourceGroupBox.TabIndex = 3;
            this.colorSourceGroupBox.TabStop = false;
            this.colorSourceGroupBox.Text = "Źródło koloru";
            // 
            // chooseImageButton
            // 
            this.chooseImageButton.Enabled = false;
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
            this.drawAreaPanel.Size = new System.Drawing.Size(738, 680);
            this.drawAreaPanel.TabIndex = 1;
            // 
            // drawingBox
            // 
            this.drawingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingBox.Location = new System.Drawing.Point(0, 0);
            this.drawingBox.Name = "drawingBox";
            this.drawingBox.Size = new System.Drawing.Size(738, 680);
            this.drawingBox.TabIndex = 0;
            this.drawingBox.TabStop = false;
            this.drawingBox.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingBox_Paint);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 686);
            this.Controls.Add(this.editorLayoutPanel);
            this.Name = "EditorForm";
            this.Text = "EditorForm";
            this.ResizeEnd += new System.EventHandler(this.EditorForm_ResizeEnd);
            this.editorLayoutPanel.ResumeLayout(false);
            this.ToolboxPanel.ResumeLayout(false);
            this.colorSourceGroupBox.ResumeLayout(false);
            this.colorSourceGroupBox.PerformLayout();
            this.drawAreaPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingBox)).EndInit();
            this.ResumeLayout(false);

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
    }
}