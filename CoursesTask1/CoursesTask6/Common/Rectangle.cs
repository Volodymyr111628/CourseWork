using System;
using Classes.Common.Printer;

namespace CoursesTask6.Common
{
    public class Rectangle : IShape<Rectangle>
    {

        private readonly IPrinter _printer = new ConsolePrinter();

        public Rectangle() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="bottomLeftPoint">Bottom left point</param>
        /// <param name="topRightPoint">Top right point</param>
        public Rectangle(Point bottomLeftPoint, Point topRightPoint)
        {
            BottomLeftPoint = bottomLeftPoint;
            TopRightPoint = topRightPoint;
        }

        public Point BottomLeftPoint { get; set; }

        public Point TopRightPoint { get; set; }
        
        public void Move(double x, double y)
        {
            BottomLeftPoint = new Point(BottomLeftPoint.X + x, BottomLeftPoint.Y + y);
            TopRightPoint = new Point(TopRightPoint.X + x, TopRightPoint.Y + y);
        }

        public void ChangeSize(double coefficient)
        {
            double width = (TopRightPoint.X - BottomLeftPoint.X) * coefficient;
            double height = (TopRightPoint.Y - BottomLeftPoint.Y) * coefficient;

            TopRightPoint = new Point(BottomLeftPoint.X + width, BottomLeftPoint.Y + height);
        }

        public Rectangle GetShapeContainsTwo(Rectangle firstRectangle, Rectangle secondReactangle)
        {
            BottomLeftPoint = new Point(
                Math.Min(firstRectangle.BottomLeftPoint.X, secondReactangle.BottomLeftPoint.X),
                Math.Min(firstRectangle.BottomLeftPoint.Y, secondReactangle.BottomLeftPoint.Y));

            TopRightPoint = new Point(
                Math.Max(firstRectangle.TopRightPoint.X, secondReactangle.TopRightPoint.X),
                Math.Max(firstRectangle.TopRightPoint.Y, secondReactangle.TopRightPoint.Y));

            return this;
        }

        public Rectangle GetShapesIntersection(Rectangle firstRectangle, Rectangle secondReactangle)
        {
            BottomLeftPoint = new Point(
                Math.Max(firstRectangle.BottomLeftPoint.X, secondReactangle.BottomLeftPoint.X),
                Math.Max(firstRectangle.BottomLeftPoint.Y, secondReactangle.BottomLeftPoint.Y));

            TopRightPoint = new Point(
                Math.Min(firstRectangle.TopRightPoint.X, secondReactangle.TopRightPoint.X),
                Math.Min(firstRectangle.TopRightPoint.Y, secondReactangle.TopRightPoint.Y));

            if (BottomLeftPoint.X - TopRightPoint.X >= 0 || BottomLeftPoint.Y - TopRightPoint.Y >= 0)
            {
                _printer.Print("Rectangles dont intersect \n");
                return null;
            }
            else
            {
                return this;
            }
        }

        public void Draw()
        {
            _printer.Print(string.Format($"Bottom left point coordinates: ({BottomLeftPoint.X},{BottomLeftPoint.Y}) "
                + $"Top right point coordinates: ({TopRightPoint.X},{TopRightPoint.Y}) \n"));
        }

        public Rectangle GetShape()
        {
            return this;
        }
    }
}
