using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDraw
{
    [Serializable]
    class MyFigure : Line
    {
        public Rectangle rectangle;
        public Point[] points;
        public string figureType;

        public MyFigure(Rectangle rectangle, string figureType, Color? color = null, DashStyle? dashStyle = null, float? width = null) : 
            base(rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Top, color, dashStyle, width)
        {
            this.rectangle = rectangle;
            this.figureType = figureType;
            points = new Point[] {
                new Point(rectangle.Left, rectangle.Bottom),
                new Point(rectangle.Right, rectangle.Bottom),
                new Point(rectangle.X + rectangle.Width/2, Math.Min(rectangle.Top, rectangle.Bottom)),
            };
        }

        public override void Draw(Graphics graphics, Pen pen)
        {
            switch (figureType)
            {
                case "Triangle":
                    graphics.DrawPolygon(pen, points);
                    break;
                case "Rectangle":
                    graphics.DrawRectangle(pen, rectangle);
                    break;
                case "Circle":
                    graphics.DrawEllipse(pen, rectangle);
                    break;
                default:
                    break;
            }
        }
    }
}
