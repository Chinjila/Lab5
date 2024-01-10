using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace _05_DebuggingAndExceptionHandling_01_Starter
{
    public class Program
    {
        struct course
        {
            public string courseName;
            public int creditHours;
            public int gradePoints;
        };
        public static async Task Main(string[] args)
        {
            Console.WriteLine("05 -> Debugging And Exception Handling");
            bool tryAgain=false;
            do
            {
                course[] courseList;
                try
                {
                    courseList = PopulateTranscript();
                    double GPA = GetGPA(courseList);
                    Console.WriteLine("Your GPA is currently: " + GPA);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Can't parse the input, use a valid number!-{fe.Message}");
                }
                finally
                {
                    Console.Write("Try again? (Y/any other key):  ");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        tryAgain = true;
                    }
                    else
                    {
                        Console.Clear();
                        tryAgain = false;
                    };
                   
                }
            } while (tryAgain);

        }

        private static course[] PopulateTranscript()
        {
            course[] courseList = new course[2];

            for (int counter = 0; counter < courseList.Length; counter++)
            {
                course newCourse = new course();
                Console.WriteLine("Enter a course name");
                newCourse.courseName = Console.ReadLine();

                Console.WriteLine("Enter the credit hours for this course");
                newCourse.creditHours = Int32.Parse(Console.ReadLine()); //fix 1

                Console.WriteLine("Enter your grade points for this course");
                newCourse.gradePoints = Convert.ToInt32(Console.ReadLine());//fix 2

                courseList[counter] = newCourse;
            }

            return courseList;
        }

        private static double GetGPA(course[] courseList)
        {
            double result = 0.0;
            double totalCredHours = 0;
            double totalGradePoints = 0;

            foreach (course currentCourse in courseList)
            {
                totalCredHours += currentCourse.creditHours;
                totalGradePoints += currentCourse.gradePoints;
            }

            result = totalGradePoints / totalCredHours;

            return result;
        }
    }
}
