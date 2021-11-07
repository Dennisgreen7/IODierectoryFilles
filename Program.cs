using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;



namespace IO
{
    class Program
    {
        static void Biggest3aFilles(string dPath)
        {
            //Quest2
            DirectoryInfo di = new DirectoryInfo(dPath);
            FileInfo[] myFiles = di.GetFiles();
            var sort = (from fille in myFiles
                        orderby fille.Length descending
                        select fille).Take(3).ToList();
            for (int i = 0; i < sort.Count; i++)
            {
                Console.WriteLine(sort[i].Name + " " + sort[i].LastWriteTime);
            }
        }

        //Quest5
        private static string CreateCSVTextFile<T>(List<T> data, string seperator = ",")
        {
            var properties = typeof(T).GetProperties();
            var result = new StringBuilder();
             
            foreach (var row in data)
            {
                var values = properties.Select(p => p.GetValue(row, null));
                var line = string.Join(seperator, values);
                result.AppendLine(line);
            }

            return result.ToString();
        }
        //Quest6
        public static void ReadCSV(string path)
        {
            if (File.Exists(path))
            {
                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] columns = line.Split(',');
                    foreach (string column in columns)
                    {
                        Console.WriteLine(column);
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
        }
        static void Main(string[] args)
        {
            //Quest1
            //One1Way
            DirectoryInfo di = new DirectoryInfo(@"C:\");
            DirectoryInfo[] diArr = di.GetDirectories();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(diArr[i].Name);
            }

            //2Way 
            int count = 0;
            foreach (var d in System.IO.Directory.GetDirectories(@"C:\"))
            {
                Console.WriteLine(new DirectoryInfo(d).Name);
                count++;
                if (count == 10)
                {
                    break;
                }
            }
            //Biggest3aFilles(@"C:\");

            //Quest3
            List<Student> studentsList = new List<Student>() { new Student("Dennis", "Greenberg"), new Student("Cristiano", "Ronaldo") };
            var jsonList = JsonSerializer.Serialize(studentsList);

            //Quest4
            using (StreamWriter sw = new StreamWriter(@"C:\Dot.Net\C# Advanced\Shior13\text1.csv", false))
            {
                string appended;
                foreach (var student in studentsList)
                {
                    appended = string.Format("{0,-10}{0,-10}", student.FirstName, student.LastName);
                    sw.WriteLine(appended);
                }
            }
            //Quest5
            string str = CreateCSVTextFile(studentsList);
            File.WriteAllText(@"C:\Dot.Net\C# Advanced\Shior13\text.csv",str);

            //Quest6
            ReadCSV(@"C:\Dot.Net\C# Advanced\Shior13\text.csv");

            Console.ReadLine();
        }

    }
}