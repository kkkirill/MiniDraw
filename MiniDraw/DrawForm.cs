using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MiniDraw
{
    public partial class DrawForm : Form
    {
        private Point startCursorPoint, endCursorPoint;
        private bool isPainting = false;
        private DrawingOptions drawingOptions;
        private LinesStorage linesStorage;
        Graphics graphics;

        int counter;
        string lastFilename;

        public DrawForm()
        {
            InitializeComponent();
            counter = 0;
            drawingOptions = new DrawingOptions();
            linesStorage = new LinesStorage();
            graphics = canvas.CreateGraphics();
        }

        private void reDrawContent(bool isClearRequired = false)
        {
            if (isClearRequired) graphics.Clear(canvas.BackColor);
            Pen pen = new Pen(Color.Black, 2);
            foreach (Line line in linesStorage)
            {
                pen.DashStyle = line.dashStyle;
                pen.Color = line.color;
                pen.Width = line.width;
                graphics.DrawLine(pen, line.startPoint, line.endPoint);
            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linesStorage.Clear();
            reDrawContent(true);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linesStorage.RemoveLastLine();
            reDrawContent(true);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image file|*.drw";
            openFileDialog.Title = "Open File";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "") {
                lastFilename = openFileDialog.FileName;
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                linesStorage = (LinesStorage)bf.Deserialize(fileStream);
                fileStream.Close();
                reDrawContent(true);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (counter == 3)
            {
                saveToolStripMenuItem.Click -= saveToolStripMenuItem_Click;
                saveToolStripMenuItem.Click += offerResave;
                offerResave(sender, e);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image file|*.drw";
            saveFileDialog.Title = "Save File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                counter++;
                lastFilename = saveFileDialog.FileName;
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, linesStorage);
                fileStream.Close();
            }
        }
        private void offerResave(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(lastFilename, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStream, linesStorage);
            fileStream.Close();
            MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
            MessageBox.Show($"Saved to {lastFilename}", "Save Info", MessageBoxButtons.OK);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startCursorPoint = endCursorPoint = e.Location;
                isPainting = true;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPainting && e.Button == MouseButtons.Left)
            {
                endCursorPoint = e.Location;
                canvas.Refresh();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isPainting = false;
            linesStorage.AppendLine(new Line(startCursorPoint, endCursorPoint, drawingOptions.pen.Color, 
                drawingOptions.pen.DashStyle, drawingOptions.pen.Width)
            );
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (isPainting)
                graphics.DrawLine(drawingOptions.pen, startCursorPoint, endCursorPoint);
            reDrawContent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
            MessageBox.Show("Done by Kukhotskovolets Kirill", "About", MessageBoxButtons.OK);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void drawingOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingOptions.ShowDialog();
        }

    }
}
