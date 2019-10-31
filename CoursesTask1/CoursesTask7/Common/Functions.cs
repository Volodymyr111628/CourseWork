using System.Collections.Generic;

namespace CoursesTask7.Common
{
    public static class Functions
    {
        public static List<string> GetUniqueValues(string data)
        {
            List<string> uniqueCells = new List<string>();

            var values = data.Split('|');

            var dictionary = new Dictionary<string, int>();

            foreach (var value in values)
            {
                if (dictionary.ContainsKey(value))
                {
                    dictionary[value]++;
                }
                else
                {
                    dictionary.Add(value, 1);
                }
            }

            foreach (var item in dictionary)
            {
                if (item.Value == 1)
                {
                    uniqueCells.Add(item.Key);
                }
            }

            return uniqueCells;
        }
    }
}
