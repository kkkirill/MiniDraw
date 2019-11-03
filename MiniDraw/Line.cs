using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MiniDraw
{
    [Serializable]
    class Line
    {
        public Point startPoint;
        public Point endPoint;
        public Color color;
        public DashStyle dashStyle;
        public float width;


        public Line(int startX, int startY, int endX, int endY, Color? color = null, DashStyle? dashStyle = null, float? width = null)
        {
            
            this.startPoint = new Point(startX, startY);
            this.endPoint = new Point(endX, endY);
            this.color = color ?? Color.Black;
            this.dashStyle = dashStyle ?? DashStyle.Solid;
            this.width = width ?? 2;
        }

        public Line(Point startPoint, Point endPoint, Color? color = null, DashStyle? dashStyle = null, float? width = null)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.color = color ?? Color.Black;
            this.dashStyle = dashStyle ?? DashStyle.Solid;
            this.width = width ?? 2;
        }

        public virtual void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, startPoint, endPoint);
        }
    }
}
