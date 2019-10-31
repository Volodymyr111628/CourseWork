
namespace CoursesTask1.Common
{
    public struct Rectangle : ISize, ICoordinates
    {

        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
        
        public double Perimeter()
        {
            return (Width + Height) * 2;
        }
    }
}