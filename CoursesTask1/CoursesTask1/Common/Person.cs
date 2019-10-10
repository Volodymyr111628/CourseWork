
namespace CoursesTask1.Common
{
    public struct Person
    {
        public int age;
        public string name;
        public string surname;

        public Person(int age, string name, string surname)
        {
            this.age = age;
            this.name = name;
            this.surname = surname;
        }

        public string ReturnString(int n)
        {
            if (n < age)
            {
                return string.Format("{0} {1} older than {2} \n", name, surname, n);
            }
            else if (n > age)
            {
                return string.Format("{0} {1} younger than {2} \n", name, surname, n);
            }
            else
            {
                return string.Format("{0} {1} is {2} \n", name, surname, n);
            }
        }
    }
}
