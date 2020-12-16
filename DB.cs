using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Day8_HW
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=task7");

        private MySqlConnection GetConnection()
        {
            return connection;
        }

        private void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public List<string> GetAllStudents()
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT StudentFullName FROM `students`", GetConnection());
            var allStudents = new List<string>();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                allStudents.Add(reader[0].ToString());
            }
            reader.Close();
            CloseConnection();
            return allStudents;
        }

        public List<string> GetInfo(string studentFullName)
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(
                $"SELECT CourseName, Rating FROM students a JOIN rating b ON (a.StudentID = b.StudentID) JOIN courses c ON (c.CourseID = b.CourseID) WHERE (StudentFullName = '{studentFullName}')",
                GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();
            var information = new List<string>();
            if (reader != null)
            {
                System.Console.WriteLine($"Student {studentFullName}");
                while (reader.Read())
                {
                    information.Add($"On {reader[0]} have Rating = {reader[1]}");
                }
            }
            else information.Add($"Student {studentFullName} not found!");
            CloseConnection();
            return information;
        }

        public void DeleteStudent(string studentFullName)
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM students WHERE StudentFullName = '{studentFullName}'",GetConnection());
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
