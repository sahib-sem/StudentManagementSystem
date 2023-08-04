namespace StudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to student management system");
            StudentManager<Student> mgt = new StudentManager<Student>("C:\\Users\\PC\\source\\repos\\StudentManagementSystem/students.json");

            while
                (true)
            {

                Console.WriteLine("what operation do you want to perform");
                Console.WriteLine("1.Add a student\n2.search for a student\n3.list all students\n4.exit");
                Console.Write("option: ");

                string option = Console.ReadLine();
                bool exit = false;

                switch(option)
                {
                    case ("1"):
                        Console.WriteLine("students Name\nName: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("students grade input one of A, B, C, D, F\nGrade: ");
                        StudentGrade Grade = (StudentGrade) Enum.Parse(typeof(StudentGrade), Console.ReadLine());
                        Console.WriteLine("the studnets age");
                        int Age = int.Parse(Console.ReadLine());

                        Student new_s = new Student(name, Grade, Age);
                        mgt.Add(new_s);
                        break;
                    case ("2"):
                        Console.WriteLine("write the students name\n Name: ");
                        string Name = Console.ReadLine();
                        mgt.search(Name);
                        break;
                    case ("3"):
                        mgt.listAll(mgt.LoadData());
                        break;
                    case ("4"):
                        exit = true;
                        break;

                }

                if (exit)
                {
                    break;
                }
            }
        }
    }
}