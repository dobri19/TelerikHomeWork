using System;

namespace Problem01School
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var class01 = new ClassInSchool("FMI Best Class");

            var student01 = new Student("Janet", "Florofilova", 234);
            var student02 = new Student("Zombie", "Tronov", 23);
            var student03 = new Student("Carlos", "Santana", 44, "Student is too smart!");

            var teacher01 = new Teacher("Zoro", "Banderov");
            var teacher02 = new Teacher("Portos", "Aramisov");

            var discip01 = new Discipline("History", 2, 20);
            var discip02 = new Discipline("Geography", 4, 10);

            teacher01.DisciplineEnseigne.Add(discip01);
            teacher02.DisciplineEnseigne.Add(discip02);

            class01.AddStudent(student01);
            class01.AddStudent(student02);
            class01.AddStudent(student03);

            class01.AddTeacher(teacher01);
            class01.AddTeacher(teacher02);

            Console.WriteLine(class01.ToString());

            class01.RemoveStudent(student03);
            class01.RemoveTeacher(teacher02);

            Console.WriteLine(class01.ToString());
        }
    }
}
