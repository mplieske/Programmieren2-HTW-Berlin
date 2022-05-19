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

namespace GeometryEditorApp
{
    public partial class MainForm : Form
    {
        private Drawing _drawing = new Drawing(new Curve[0]);

        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // FIXME: Hard coded for now. Only testing.
            MathLibrary.Point startPoint = new MathLibrary.Point(15, 15);
            MathLibrary.Point endPoint = new MathLibrary.Point(30, 30);
            Line line = new Line(startPoint, endPoint);
            _drawing.AddCurve(line);
            PictureBox pictureBox = (PictureBox)this.Controls["pictureBox1"]; // FIXME: Duplication
            _drawing.Draw(pictureBox.CreateGraphics());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MathLibrary.Point point = new MathLibrary.Point(55, 22.5);
            MathLibrary.Vector vector = new MathLibrary.Vector(7.5, 0, 0);
            GeometryLibrary.Circle circle = new Circle(point, vector, 7.5);

            _drawing.AddCurve(circle);
            PictureBox pictureBox = (PictureBox)this.Controls["pictureBox1"]; // FIXME: Duplication
            _drawing.Draw(pictureBox.CreateGraphics());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            List<MathLibrary.Point> points = new List<MathLibrary.Point>();
            points.Add(new MathLibrary.Point(15, 50));
            points.Add(new MathLibrary.Point(15, 70));
            points.Add(new MathLibrary.Point(30, 70));
            points.Add(new MathLibrary.Point(15, 50));
            GeometryLibrary.Polyline polyline = new Polyline(points.ToArray());
            _drawing.AddCurve(polyline);
            PictureBox pictureBox = (PictureBox)this.Controls["pictureBox1"]; // FIXME: Duplication
            _drawing.Draw(pictureBox.CreateGraphics());
        }
    }
}
