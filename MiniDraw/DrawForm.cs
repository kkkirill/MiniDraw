using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MiniDraw
{
    public partial class DrawForm : Form
    {
        private Point startCursorPoint, endCursorPoint;
        private Rectangle rectangle;

        private bool isPainting = false;
        private DrawingOptions drawingOptions;
        private LinesStorage figuresStorage;

        Graphics graphics;

        int counter;
        string lastFilename;

        public DrawForm()
        {
            InitializeComponent();
            counter = 0;
            drawingOptions = new DrawingOptions();
            figuresStorage = new LinesStorage();
            graphics = canvas.CreateGraphics(); 
        }

        private void reDrawContent(bool isClearRequired = false)
        {
            if (isClearRequired) graphics.Clear(canvas.BackColor);
            Pen pen = new Pen(Color.Black, 2);
            foreach (Line line in figuresStorage)
            {
                pen.DashStyle = line.dashStyle;
                pen.Color = line.color;
                pen.Width = line.width;
                line.Draw(graphics, pen);
            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figuresStorage.Clear();
            reDrawContent(true);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figuresStorage.RemoveLastLine();
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
                figuresStorage = (LinesStorage)bf.Deserialize(fileStream);
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
                bf.Serialize(fileStream, figuresStorage);
                fileStream.Close();
            }
        }
        private void offerResave(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(lastFilename, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStream, figuresStorage);
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
            if (drawingOptions.isFigure)
            {
                figuresStorage.AppendLine(new MyFigure(rectangle, drawingOptions.figureType, drawingOptions.pen.Color,
                    drawingOptions.pen.DashStyle, drawingOptions.pen.Width));
            }
            else
            {
                figuresStorage.AppendLine(new Line(startCursorPoint, endCursorPoint, drawingOptions.pen.Color,
                    drawingOptions.pen.DashStyle, drawingOptions.pen.Width)
                );
            }
        }

        private void drawDifferentFigures()
        {
            if (drawingOptions.isFigure)
            {
                rectangle = new Rectangle(Math.Min(startCursorPoint.X, endCursorPoint.X),
                                     Math.Min(startCursorPoint.Y, endCursorPoint.Y),
                                     Math.Abs(endCursorPoint.X - startCursorPoint.X),
                                     Math.Abs(endCursorPoint.Y - startCursorPoint.Y));
                switch (drawingOptions.figureType)
                {
                    case "Triangle":
                        Point[] points =
                        {
                            new Point(rectangle.Left, rectangle.Bottom),
                            new Point(rectangle.Right, rectangle.Bottom),
                            new Point(rectangle.X + rectangle.Width/2, Math.Min(rectangle.Top, rectangle.Bottom)),
                        };
                        graphics.DrawPolygon(drawingOptions.pen, points);
                        break;
                    case "Circle":
                        graphics.DrawEllipse(drawingOptions.pen, rectangle);
                        break;
                    case "Rectangle":
                        graphics.DrawRectangle(drawingOptions.pen, rectangle);
                        break;
                }
            }
            else
            {
                graphics.DrawLine(drawingOptions.pen, startCursorPoint, endCursorPoint);
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (isPainting)
                drawDifferentFigures();
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
