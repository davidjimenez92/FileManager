using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using FileManager.Common.Layer;
using log4net;

namespace FileManager.DataAccess.Data
{
	public class TxtUtil
	{
        private readonly string path;

        public TxtUtil(string path)
        {
            this.path = path;
        }

        public void CreateFile()
        {
            if (!FileExists())
                using (File.Create(path)) ;
        }

        public bool FileExists()
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }

        public  Student AppendStudent(Student student)
        {
            if (!GetIds().Contains(student.Id))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine(student.Id + ", " + student.Name.Trim() + ", " +
                        student.Surname.Trim() + ", " + student.DateOfBirth.ToString("dd/MM/yyyy"));

                    return student;
                }
            }
            return null;
        }

        public List<int> GetIds()
        {
            string[] array = File.ReadAllLines(path);
            List<int> list = new List<int>();
            foreach (var line in array)
            {
                string[] values = line.Trim().Split(',');
                list.Add(int.Parse(values[0]));
            }
            return list;
        }

    }
}
