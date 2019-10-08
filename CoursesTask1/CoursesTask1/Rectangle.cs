using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesTask1
{
    struct Rectangle : ISize, ICoordinates
    {
        public double X { get; set; }
        public double Y { get; set; }
        
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double _X,double _Y,double _Width,double _Height)
        {
            X = _X;
            Y = _Y;
            Width = _Width;
            Height = _Height;
        }

        public double Perimeter()
        {
            return (Width + Height) * 2;
        }
    }
}
