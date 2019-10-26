﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingLibrary;
using DrawingLibrary.Samplers;
using DrawingLibrary.Shaders;
using DrawingLibrary.Vectors;

namespace FillingPolygons
{
    public partial class EditorForm : Form
    {
        Scene scene;
        Mesh mesh;
        int n = 10;
        int m = 15;
        public EditorForm()
        {
            InitializeComponent();
            Shader shader = new VertexHybridShader
            {
                MainTex = new ImageSampler(new Bitmap("..\\..\\data\\Image.jpg"))
            };
            GlobalData globalData = new GlobalData(0.5, 0.5, Color.White, new Vector3(0, 0, 1).Normalized, 1);
            scene = new Scene(new MemoryBitmap(drawingBox.Width, drawingBox.Height), shader, globalData);
            CreateMesh();
        }

        private void DrawingBox_Paint(object sender, PaintEventArgs e)
        {
            scene.DrawMesh(mesh);
            e.Graphics.DrawImageUnscaled(scene.Bitmap.Bitmap, 0, 0);
        }

        private void CreateMesh()
        {
            mesh = new Mesh();
            double padding = scene.Width * 0.05;
            double gridWidth = scene.Width - 2 * padding;
            double gridHeight = scene.Height - 2 * padding;
            double gridHorizontalGap = gridWidth / m;
            double gridVerticalGap = gridHeight / n;
            mesh.Vertices = new Vector2[(n + 1) * (m + 1)];
            mesh.UV = new Vector2[(n + 1) * (m + 1)];
            mesh.Triangles = new int[n * m * 2 * 3];
            for (int y = 0; y <= n; y++)
            {
                for (int x = 0; x <= m; x++)
                {
                    mesh.Vertices[y * (m + 1) + x] = new Vector2(padding + gridHorizontalGap * x, padding + gridVerticalGap * y);
                    mesh.UV[y * (m + 1) + x] = new Vector2(((double)x) / m, ((double)y) / n);
                }
            }
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    mesh.Triangles[(y * m * 2 + x * 2) * 3] = y * (m + 1) + x;
                    mesh.Triangles[(y * m * 2 + x * 2) * 3 + 1] = y * (m + 1) + x + 1;
                    mesh.Triangles[(y * m * 2 + x * 2) * 3 + 2] = (y + 1) * (m + 1) + x;

                    mesh.Triangles[(y * m * 2 + x * 2) * 3 + 3] = y * (m + 1) + x + 1;
                    mesh.Triangles[(y * m * 2 + x * 2) * 3 + 4] = (y + 1) * (m + 1) + x + 1;
                    mesh.Triangles[(y * m * 2 + x * 2) * 3 + 5] = (y + 1) * (m + 1) + x;
                }
            }
        }

        private void EditorForm_ResizeEnd(object sender, EventArgs e)
        {
            scene.Bitmap.Resize(drawingBox.Width, drawingBox.Height);
            drawingBox.Invalidate();
        }

        private void StaticColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            chooseColorButton.Enabled = staticColorRadioButton.Checked;
        }

        private void ColorFromImageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            chooseImageButton.Enabled = colorFromImageRadioButton.Checked;
        }

        private void ChooseColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                scene.Shader.MainTex = new StaticColorSampler(colorDialog.Color);
                drawingBox.Invalidate();
            }

        }

        private void ChooseImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|" +
                "png files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                scene.Shader.MainTex
                    = new ImageSampler(new Bitmap(openFileDialog.FileName));
                drawingBox.Invalidate();
            }
        }

        private void StaticNormalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            scene.Shader.Normals = new StaticColorSampler(Color.Blue);
            drawingBox.Invalidate();
        }

        private void NormalMapRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            chooseNormalMapButton.Enabled = normalMapRadioButton.Checked;
        }

        private void ChooseNormalMapButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|" +
                "png files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                scene.Shader.Normals
                    = new ImageSampler(new Bitmap(openFileDialog.FileName));
                drawingBox.Invalidate();
            }
        }

        private void ChooseLightColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                scene.GlobalData.SetLightColor(colorDialog.Color);
                drawingBox.Invalidate();
            }
        }

        private void ConfirmToLightVectorButton_Click(object sender, EventArgs e)
        {
            if(double.TryParse(xToLightVectorTextBox.Text, out double x)
                && double.TryParse(yToLightVectorTextBox.Text, out double y)
                && double.TryParse(zToLightVectorTextBox.Text, out double z))
            {
                if(z > 0)
                {
                    scene.GlobalData.ToLightVersor = new Vector3(x, y, z).Normalized;
                    drawingBox.Invalidate();
                }
                else
                {
                    MessageBox.Show("Value of z must be positive");
                }
            }
            else
            {
                MessageBox.Show("Coordinates must be numbers");
            }
        }

        private void DrawWireframeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.DrawWireframe = drawWireframeToolstripMenuItem.Checked = !drawWireframeToolstripMenuItem.Checked;
            drawingBox.Invalidate();
        }
    }
}
