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
        MeshDeformer deformer;
        int n = 10;
        int m = 15;
        public EditorForm()
        {
            InitializeComponent();
            Shader shader = new PreciseShader();
            GlobalData globalData = new GlobalData(0.5, 0.5, Color.White, new Vector3(0, 0, 10000), 1);
            scene = new Scene(new MemoryBitmap(drawingBox.Width, drawingBox.Height), shader, globalData);
            scene.MainTex = new ImageSampler(new Bitmap("..\\..\\data\\Image.jpg"));
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
                    mesh.Vertices[y * (m + 1) + x] = new Vector2(
                        scene.MinX + padding + gridHorizontalGap * x,
                        scene.MinY + padding + gridVerticalGap * y);
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
            deformer = new MeshDeformer(mesh);
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
                scene.MainTex = new StaticColorSampler(colorDialog.Color);
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
                scene.MainTex
                    = new ImageSampler(new Bitmap(openFileDialog.FileName));
                drawingBox.Invalidate();
            }
        }

        private void StaticNormalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            scene.Normals = new StaticColorSampler(Color.Blue);
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
                ImageSampler isamp = new ImageSampler(new Bitmap(openFileDialog.FileName));
                isamp.Transform(v => new Vector3(v.X * 2 - 1, v.Y * 2 - 1, v.Z).Normalized);
                scene.Normals= isamp;
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
                    scene.GlobalData.LightPosition = new Vector3(x, y, z).Normalized;
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

        private void PreciseShaderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(preciseShaderRadioButton.Checked)
            {
                scene.Shader = new PreciseShader();
                drawingBox.Invalidate();
            }
        }

        private void VertexColorShaderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (vertexColorShaderRadioButton.Checked)
            {
                scene.Shader = new VertexColorShader();
                drawingBox.Invalidate();
            }
        }

        private void HybridShaderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (hybridShaderRadioButton.Checked)
            {
                scene.Shader = new HybridShader();
                drawingBox.Invalidate();
            }
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            
        }

        private void DrawingBox_MouseDown(object sender, MouseEventArgs e)
        {
            deformer.MouseDown(scene.TransformToSceneCoords(new Vector2(e.X, e.Y)));
        }

        private void DrawingBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(deformer.MouseMove(scene.TransformToSceneCoords(new Vector2(e.X, e.Y))))
            {
                drawingBox.Invalidate();
            }
        }

        private void DrawingBox_MouseUp(object sender, MouseEventArgs e)
        {
            deformer.MouseUp();
        }

        private void DrawingBox_MouseLeave(object sender, EventArgs e)
        {
            deformer.MouseUp();
        }

        private void EditorForm_ClientSizeChanged(object sender, EventArgs e)
        {

            if (scene != null)
            {
                scene.Bitmap.Resize(drawingBox.Width, drawingBox.Height);
                drawingBox.Invalidate();
            }
        }
    }
}
