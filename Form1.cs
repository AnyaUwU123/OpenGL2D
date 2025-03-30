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
        private Button btnCreate, btnRotate, btnTranslate, btnScale, btnSelectColor;
        private ListBox listBoxShapes;
        private Label labelInfo;
        private Color4 selectedColor = new Color4(1.0f, 1.0f, 1.0f, 1.0f); // Color inicial (blanco)

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            InitializeOpenGL();
        }

        private void InitializeUI()
        {
            Panel panel = new Panel { Dock = DockStyle.Top, Height = 100 };
            Controls.Add(panel);

            comboBoxShapes = new ComboBox { Location = new Point(10, 10), Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
            comboBoxShapes.Items.AddRange(new string[] { "Triangle", "Square", "Circle", "Rectangle", "Pentagon" });
            panel.Controls.Add(comboBoxShapes);

            btnSelectColor = new Button { Text = "Seleccionar Color", Location = new Point(140, 10) };
            btnSelectColor.Click += BtnSelectColor_Click;
            panel.Controls.Add(btnSelectColor);

            btnCreate = new Button { Text = "Crear", Location = new Point(260, 10) };
            btnCreate.Click += BtnCreateShape_Click;
            panel.Controls.Add(btnCreate);

            btnRotate = new Button { Text = "Rotar", Location = new Point(320, 10) };
            btnRotate.Click += BtnRotate_Click;
            panel.Controls.Add(btnRotate);

            btnTranslate = new Button { Text = "Mover", Location = new Point(380, 10) };
            btnTranslate.Click += BtnTranslate_Click;
            panel.Controls.Add(btnTranslate);

            btnScale = new Button { Text = "Escalar", Location = new Point(440, 10) };
            btnScale.Click += BtnScale_Click;
            panel.Controls.Add(btnScale);


            // Etiqueta con nombres y tema
            labelInfo = new Label
            {
                Text = "MARTÍNEZ SOTO KAREN: 19011585, RAMIREZ OLVERA HÉCTOR JESUS: 20011106. Tema 2. Graficación 2D",
                Location = new Point(10, 70),
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

        private void BtnSelectColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color color = colorDialog.Color;
                    selectedColor = new Color4(color.R / 255f, color.G / 255f, color.B / 255f, 1.0f);
                }
            }
        }

        private void BtnCreateShape_Click(object sender, EventArgs e)
        {
            if (comboBoxShapes.SelectedItem == null)
                return;

            string shapeType = comboBoxShapes.SelectedItem.ToString();
            Shapes newShape = ShapeFactory.CreateShape(shapeType, selectedColor);
            shapes.Add(newShape);
            gLControl.Invalidate();
        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            if (listBoxShapes.SelectedIndex == -1) return;

            shapes[listBoxShapes.SelectedIndex].Rotate(90);
            gLControl.Invalidate();
        }

        private void BtnTranslate_Click(object sender, EventArgs e)
        {
            if (listBoxShapes.SelectedIndex == -1) return;

            shapes[listBoxShapes.SelectedIndex].Translate(0.1f, 0.1f);
            gLControl.Invalidate();
        }

        private void BtnScale_Click(object sender, EventArgs e)
        {
            if (listBoxShapes.SelectedIndex == -1) return;

            shapes[listBoxShapes.SelectedIndex].Scale(1.2f);
            gLControl.Invalidate();
        }
    }
}
