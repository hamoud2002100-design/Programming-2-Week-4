using System.ComponentModel.DataAnnotations;

namespace Assignment1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        void Start()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("John", 1, 95.5));
            students.Add(new Student("Jane", 2, 88.0));
            students.Add(new Student("Alice", 3, 76.3));

            DisplayAllStudents(students);
        }
       public void DisplayAllStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}







