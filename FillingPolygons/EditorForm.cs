using System;
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
                Sampler = new ImageSampler(new Bitmap("..\\..\\data\\Image.jpg"))
            };
            scene = new Scene(new MemoryBitmap(drawingBox.Width, drawingBox.Height), shader);
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
            float padding = scene.Width * 0.05f;
            float gridWidth = scene.Width - 2 * padding;
            float gridHeight = scene.Height - 2 * padding;
            float gridHorizontalGap = gridWidth / m;
            float gridVerticalGap = gridHeight / n;
            mesh.Vertices = new Vector2[(n + 1) * (m + 1)];
            mesh.UV = new Vector2[(n + 1) * (m + 1)];
            mesh.Triangles = new int[n * m * 2 * 3];
            for (int y = 0; y <= n; y++)
            {
                for (int x = 0; x <= m; x++)
                {
                    mesh.Vertices[y * (m + 1) + x] = new Vector2(padding + gridHorizontalGap * x, padding + gridVerticalGap * y);
                    mesh.UV[y * (m + 1) + x] = new Vector2(((float)x) / m, ((float)y) / n);
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
                scene.Shader.Sampler = new StaticColorSampler(colorDialog.Color);
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
                scene.Shader.Sampler
                    = new ImageSampler(new Bitmap(openFileDialog.FileName));
                drawingBox.Invalidate();
            }
        }
    }
}
