
namespace CoursesTask1.Common
{
    public interface ISize
    {
        double Width { get; set; }
        double Height { get; set; }

        double Perimeter();
    }
}
