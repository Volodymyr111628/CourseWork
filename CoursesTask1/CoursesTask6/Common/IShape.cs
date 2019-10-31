using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesTask6.Common
{
    public interface IShape<T>
    {
        void Draw();

        T GetShapeContainsTwo(T first, T second);

        T GetShapesIntersection(T first, T second);

        void ChangeSize(double coefficient);

        void Move(double x, double y);

        T GetShape();
    }
}
