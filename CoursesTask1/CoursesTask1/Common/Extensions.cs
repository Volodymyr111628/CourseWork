using System;

namespace CoursesTask1.Common
{
    public static class Extensions
    {
        public static Array Sort(this Color color)
        {
            var enumValues = Enum.GetValues(typeof(Color));
            Array.Sort(enumValues);
            return enumValues;
        }
    }
}
