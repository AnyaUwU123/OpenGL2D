using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using GL = OpenTK.Graphics.GL;

namespace OpenGL2D
{
    public partial class Form1 : Form
    {
        private List<Shapes> shapes = new List<Shapes>();
        private OpenTK.GLControl gLControl;
        private ComboBox comboBoxShapes;
        private Button btnCreate, btnRotate, btnTranslate, btnScale, btnColor;
        private Label labelInfo;
        private Color selectedColor = Color.Black;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            InitializeOpenGL();
        }

        private void InitializeUI()
        {
            Panel panel = new Panel { Dock = DockStyle.Top, Height = 80 };
            Controls.Add(panel);

            comboBoxShapes = new ComboBox { Location = new Point(10, 10), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
            comboBoxShapes.Items.AddRange(new string[] { "Triangle", "Square", "Circle", "Rectangle", "Pentagon"});
            panel.Controls.Add(comboBoxShapes);

            btnCreate = new Button { Text = "Crear", Location = new Point(120, 10) };
            btnCreate.Click += BtnCreateShape_Click;
            panel.Controls.Add(btnCreate);

            btnRotate = new Button { Text = "Rotar", Location = new Point(180, 10) };
            btnRotate.Click += BtnRotate_Click;
            panel.Controls.Add(btnRotate);

            btnTranslate = new Button { Text = "Mover", Location = new Point(240, 10) };
            btnTranslate.Click += BtnTranslate_Click;
            panel.Controls.Add(btnTranslate);

            btnScale = new Button { Text = "Escalar", Location = new Point(300, 10) };
            btnScale.Click += BtnScale_Click;
            panel.Controls.Add(btnScale);

            btnColor = new Button { Text = "Seleccionar Color", Location = new Point(360, 10) };
            btnColor.Click += BtnColor_Click;
            panel.Controls.Add(btnColor);

            labelInfo = new Label
            {
                Text = "MARTÍNEZ SOTO KAREN: 19011585, RAMIREZ OLVERA HÉCTOR JESUS: 20011106. Tema 2. Graficación 2D",
                Location = new Point(10, 50),
                AutoSize = true,
                ForeColor = Color.Black,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            panel.Controls.Add(labelInfo);
        }

        private void InitializeOpenGL()
        {
            gLControl = new OpenTK.GLControl { Dock = DockStyle.Fill };
            Controls.Add(gLControl);
            gLControl.Paint += GlControl_Paint;
        }

        private void GlControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(OpenTK.Graphics.ClearBufferMask.ColorBufferBit);
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
            gLControl.SwapBuffers();
        }

        private void BtnCreateShape_Click(object sender, EventArgs e)
        {
            if (comboBoxShapes.SelectedItem == null)
                return;

            string shapeType = comboBoxShapes.SelectedItem.ToString();
            Shapes newShape = ShapeFactory.CreateShape(shapeType, new Color4(selectedColor.R / 255f, selectedColor.G / 255f, selectedColor.B / 255f, 1.0f));
            shapes.Add(newShape);
            gLControl.Invalidate();
        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Rotate(90);
            }
            gLControl.Invalidate();
        }

        private void BtnTranslate_Click(object sender, EventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Translate(0.1f, 0.1f);
            }
            gLControl.Invalidate();
        }

        private void BtnScale_Click(object sender, EventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Scale(1.2f);
            }
            gLControl.Invalidate();
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedColor = colorDialog.Color;
                    if (shapes.Count > 0)
                    {
                        Shapes lastShape = shapes[shapes.Count - 1];
                        lastShape.Color = new Color4(selectedColor.R / 255f, selectedColor.G / 255f, selectedColor.B / 255f, 1.0f);
                        gLControl.Invalidate();
                    }
                }
            }
        }
    }
}

