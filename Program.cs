using System;

namespace Day8_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DB();
            //List students
            var students = db.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            //Get info 
            var information = db.GetInfo("Cecil");
            foreach (var info in information)
            {
                Console.WriteLine(info);
            }
            //Delete student
            //db.DeleteStudent("Cecil");
        }
    }
}
