namespace CoursesTask6.Common
{
    using System;
    using Classes.Common.Printer;

    class Circle : IShape<Circle>
    {
        private readonly IPrinter _printer = new ConsolePrinter();

        public Point CenterPoint { get; set; }

        public double Radius { get; set; }

        public Circle() { }

        public Circle(Point centerPoint, double radius)
        {
            CenterPoint = centerPoint;
            Radius = radius;
        }

        public void ChangeSize(double coefficient)
        {
            Radius *= coefficient;
        }

        public void Draw()
        {
            _printer.Print(string.Format($"Center:({CenterPoint.X},{CenterPoint.Y}), radius: {Radius}\n"));
        }

        public Circle GetShapeContainsTwo(Circle first, Circle second)
        {
            double distanceBetweenCenters = Math.Sqrt(Math.Pow(first.CenterPoint.X - second.CenterPoint.X, 2) +
                Math.Pow(first.CenterPoint.Y - second.CenterPoint.Y, 2));
            CenterPoint = new Point(
                Math.Abs(first.CenterPoint.X + second.CenterPoint.X) / 2,
                Math.Abs(first.CenterPoint.Y + second.CenterPoint.Y) / 2);

            if (distanceBetweenCenters == 0)
            {
                return first.Radius > second.Radius ? first : second;
            }
            else
            {
                Radius = (distanceBetweenCenters / 2) + Math.Max(first.Radius, second.Radius);
                return this;
            }
        }

        public Circle GetShapesIntersection(Circle first, Circle second)
        {
            throw new NotImplementedException();
        }

        public void Move(double x, double y)
        {
            CenterPoint.X += x;
            CenterPoint.Y += y;
        }
    }
}
