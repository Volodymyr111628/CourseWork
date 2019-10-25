using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesTask6.Common
{
    public class Rectangle
    {

        public Rectangle() { }

        public Rectangle(Point bottomLeftPoint, Point topLeftPoint, Point topRightPoint, Point bottomRightPoint)
        {
            BottomLeftPoint = bottomLeftPoint;
            TopLeftPoint = topLeftPoint;
            TopRightPoint = topRightPoint;
            BottomRightPoint = bottomRightPoint;

            Width = BottomLeftPoint.X - BottomRightPoint.X;
            Height = BottomLeftPoint.Y - TopLeftPoint.Y;
        }

        public Point BottomLeftPoint { get; set; }

        public Point TopLeftPoint { get; set; }

        public Point TopRightPoint { get; set; }

        public Point BottomRightPoint { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public void MoveRectangle(double x, double y)
        {
            BottomLeftPoint = new Point(BottomLeftPoint.X + x, BottomLeftPoint.Y + y);
            TopLeftPoint = new Point(TopLeftPoint.X + x, TopLeftPoint.Y + y);
            TopRightPoint = new Point(TopRightPoint.X + x, TopRightPoint.Y + y);
            BottomRightPoint = new Point(BottomRightPoint.X + x, BottomRightPoint.Y + y);
        }

        public void ChangeSize(int coefficient)
        {
            Width *= coefficient;
            Height *= coefficient;

            TopLeftPoint = new Point(BottomLeftPoint.X, BottomLeftPoint.Y + Height);
            BottomRightPoint = new Point(BottomRightPoint.X + Width, BottomRightPoint.Y);
            TopRightPoint = new Point(BottomLeftPoint.X + Width, BottomLeftPoint.Y + Height);
        }

        public Rectangle BuildRectangleIncludesTwo(Rectangle firstRectangle,Rectangle secondReactangle)
        {
            BottomLeftPoint = new Point(Math.Min(firstRectangle.BottomLeftPoint.X, secondReactangle.BottomLeftPoint.X),
                Math.Min(firstRectangle.BottomLeftPoint.Y, secondReactangle.BottomLeftPoint.Y));

            TopRightPoint= new Point(Math.Max(firstRectangle.TopRightPoint.X, secondReactangle.TopRightPoint.X),
                Math.Max(firstRectangle.TopRightPoint.Y, secondReactangle.TopRightPoint.Y));

            TopLeftPoint = new Point(BottomLeftPoint.X, TopRightPoint.Y);

            BottomRightPoint = new Point(BottomLeftPoint.Y, TopRightPoint.X);

            Width = BottomLeftPoint.X - BottomRightPoint.X;
            Height = BottomLeftPoint.Y - TopLeftPoint.Y;

            return this;
        }

        public Rectangle BuildRectangleIntersectionOfTwo(Rectangle firstRectangle,Rectangle secondReactangle)
        {
            

            return this;
        }

    }
}
