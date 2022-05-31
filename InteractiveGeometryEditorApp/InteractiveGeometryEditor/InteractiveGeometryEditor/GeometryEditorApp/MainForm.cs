using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeometryLibrary;
using MathLibrary;
using Point = MathLibrary.Point;

namespace GeometryEditorApp
{
    public partial class MainForm : Form
    {
        private Graphics _pictureBoxGraphics = null;
        private Drawing _drawing = new Drawing(new Curve[0]);

        public MainForm()
        {
            InitializeComponent();
        }

        private Graphics GetPictureBoxGraphics()
        {
            if (_pictureBoxGraphics == null)
            {
                _pictureBoxGraphics = pictureBox.CreateGraphics();
                // Set the appropriate transform
                _pictureBoxGraphics.ScaleTransform(1f, -1f);
                _pictureBoxGraphics.TranslateTransform(0f, -pictureBox.Height);
            }

            return _pictureBoxGraphics;
        }

        private void toolStripButtonLine_Click(object sender, EventArgs e)
        {
            // Create Line object with test coordinates
            var line = new Line(new Point(), new Point(100d, 100d, 0d));

            // Add it to the drawing
            _drawing.AddCurve(line);

            // Draw it
            _drawing.Draw(GetPictureBoxGraphics());
        }

        private void toolStripButtonCircle_Click(object sender, EventArgs e)
        {
            // Create Line object with test coordinates
            var circle = new Circle(new Point(100d, 100d, 0d), Vector.ZDir, 50d);

            // Add it to the drawing
            _drawing.AddCurve(circle);

            // Draw it
            _drawing.Draw(GetPictureBoxGraphics());
        }

        private void toolStripButtonPolyline_Click(object sender, EventArgs e)
        {
            // Create Polyline object with test coordinates
            var polyline = new Polyline(new Point[]{new Point(), new Point(100d, 0d, 0d), new Point(100d, 100d, 0d), new Point(0d, 100d, 0d), new Point(),  });

            // Add it to the drawing
            _drawing.AddCurve(polyline);

            // Draw it
            _drawing.Draw(GetPictureBoxGraphics());
        }
    }
}
