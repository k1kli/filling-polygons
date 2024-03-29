﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
        int n = 5;
        int m = 5;
        bool parametersRandomized = true;
        LightAnimator lightAnimator;

        Random r = new Random();
        LightParameters currentLightParameters;
        private int animated = 0;

        public EditorForm()
        {
            InitializeComponent();
            Shader shader = new PreciseShader();
            GlobalData globalData = new GlobalData(Color.White, new Vector3(0, 0, 10000));
            var normals = new ImageSampler(new Bitmap("..\\..\\data\\Normals.jpg"), drawingBox.Width, drawingBox.Height);
            normals.Transform(v => Vector3.Normalize(new Vector3(v.X * 2 - 1, -(v.Y * 2 - 1), v.Z)));
            scene = new Scene(new MemoryBitmap(drawingBox.Width, drawingBox.Height), shader, globalData)
            {
                MainTex = new ImageSampler(new Bitmap("..\\..\\data\\Image.jpg"), drawingBox.Width, drawingBox.Height),
                Normals = normals
            };
            CreateMesh();
        }

        private void DrawingBox_Paint(object sender, PaintEventArgs e)
        {
            if (lightAnimator != null)
            {
                scene.GlobalData.LightPosition = lightAnimator.NextPos();
            }
            scene.DrawMesh(mesh);
            e.Graphics.DrawImageUnscaled(scene.Bitmap.Bitmap, 0, 0);
            if (animated>0)
            {
                drawingBox.Invalidate();
            }
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
            mesh.TrianglesLightParameters = new LightParameters[n * m * 2];
            for (int y = 0; y <= n; y++)
            {
                for (int x = 0; x <= m; x++)
                {
                    mesh.Vertices[y * (m + 1) + x] = new Vector2(
                        scene.MinX + padding + gridHorizontalGap * x,
                        scene.MinY + padding + gridVerticalGap * y);
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
            deformer = new MeshDeformer(mesh);
            SetLightParameters();
        }
        public void SetLightParameters()
        {
            if (parametersRandomized)
            {
                RandomizeLightParameters();
            }
            else
            {
                SetConstantLightParameters();
            }
        }

        public void RandomizeLightParameters()
        {
            for (int i = 0; i < mesh.TrianglesLightParameters.Length; i++)
            {
                mesh.TrianglesLightParameters[i] = LightParameters.GetRandom(r);
            }
        }
        public void SetConstantLightParameters()
        {
            for (int i = 0; i < mesh.TrianglesLightParameters.Length; i++)
            {
                mesh.TrianglesLightParameters[i] = currentLightParameters;
            }
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
                    = new ImageSampler(new Bitmap(openFileDialog.FileName), drawingBox.Width, drawingBox.Height);
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
                ImageSampler isamp = new ImageSampler(new Bitmap(openFileDialog.FileName), drawingBox.Width, drawingBox.Height);
                isamp.Transform(v => Vector3.Normalize(new Vector3(v.X * 2 - 1, -(v.Y * 2 - 1), v.Z)));
                scene.Normals = isamp;
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

        private void DrawWireframeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.DrawWireframe = drawWireframeToolstripMenuItem.Checked = !drawWireframeToolstripMenuItem.Checked;
            drawingBox.Invalidate();
        }

        private void PreciseShaderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (preciseShaderRadioButton.Checked)
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
            if (deformer.MouseMove(scene.TransformToSceneCoords(new Vector2(e.X, e.Y))))
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
                scene.ResizeBitmap(new Vector2(drawingBox.Width, drawingBox.Height));
                drawingBox.Invalidate();
            }
        }

        private void RandomLightParametersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (randomLightParametersRadioButton.Checked)
            {
                parametersRandomized = true;
                SetLightParameters();
                drawingBox.Invalidate();
                kdLightParameterTrackBar.Enabled = false;
                ksLightParameterTrackBar.Enabled = false;
                mLightParameterTrackBar.Enabled = false;
            }
        }

        private void UpdateLightParameterTrackBars()
        {
            parametersRandomized = false;
            currentLightParameters = new LightParameters
            {
                Kd = kdLightParameterTrackBar.Value / 100f,
                Ks = ksLightParameterTrackBar.Value / 100f,
                M = mLightParameterTrackBar.Value
            };
            kdLightParameterTextBox.Text = currentLightParameters.Kd.ToString();
            ksLightParameterTextBox.Text = currentLightParameters.Ks.ToString();
            mLightParameterTextBox.Text = currentLightParameters.M.ToString();
            SetLightParameters();
            drawingBox.Invalidate();
        }

        private void ConstantLightParametersRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (constantLightParametersRadioButton.Checked)
            {
                kdLightParameterTrackBar.Enabled = true;
                ksLightParameterTrackBar.Enabled = true;
                mLightParameterTrackBar.Enabled = true;
                UpdateLightParameterTrackBars();
            }
        }

        private void LightParametersScroll(object sender, EventArgs e)
        {
            UpdateLightParameterTrackBars();
        }

        private void ConstantLightPosLabel_CheckedChanged(object sender, EventArgs e)
        {
            if (constantLightPosLabel.Checked)
            {
                lightAnimator = null;
                scene.GlobalData.LightPosition = new Vector3(0, 0, 10000);
                drawingBox.Invalidate();
            }
        }

        private void AnimateLightPosLabel_CheckedChanged(object sender, EventArgs e)
        {
            if (animateLightPosLabel.Checked)
            {
                lightAnimator = new LightAnimator(scene.Width / 2);
                lightAnimator.StartAnimation();
                animated++;
                drawingBox.Invalidate();
            }
            else
            {
                animated--;
            }
        }

        private void GridSizeConfirmButton_Click(object sender, EventArgs e)
        {
            if (
                int.TryParse(GridXTextBox.Text, out int width)
                && int.TryParse(GridYTextBox.Text, out int height))
            {
                n = height;
                m = width;
                CreateMesh();
                drawingBox.Invalidate();
            }
        }
        private (float a, float b, float c, float d) GetFunctionNormalParams()
        {
            float a;
            float b;
            float c;
            float d;
            if (!float.TryParse(AFuncNormalTextbox.Text, out a)) a = 1;
            if (!float.TryParse(BFuncNormalTextbox.Text, out b)) b = 1;
            if (!float.TryParse(CFuncNormalTextbox.Text, out c)) c = 1;
            if (!float.TryParse(DFuncNormalTextbox.Text, out d)) d = 1;
            return (a, b, c, d);
        }
        private void functionNormalsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(functionNormalsRadioButton.Checked)
            {
                var funcParams = GetFunctionNormalParams();
                scene.Normals = new FunctionNormalSampler(
                    funcParams.a,
                    funcParams.b,
                    funcParams.c,
                    funcParams.d
                    );
                animated++;
                drawingBox.Invalidate();
            }
            else
            {
                animated--;
            }
        }

        private void AFuncNormalTextbox_Leave(object sender, EventArgs e)
        {
            FunctionNormalSampler sampler = scene.Normals as FunctionNormalSampler;
            if (sampler == null) return;
            sampler.SetFunctionNormalParams(GetFunctionNormalParams());
        }
    }
}
