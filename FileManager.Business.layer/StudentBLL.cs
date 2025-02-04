﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileManager.Common.Layer;
using FileManager.DataAccess.Data;

namespace FileManager.Business.layer
{
    public class StudentBLL
    {
        public string SaveStudent(string name, EnumTypes type, Student student)
        {
            student.Guid = Guid.NewGuid();
            IAbstractFactory factory = FactoryProvider.GetFactory(name);
            VuelingFile file = factory.Create(type);
            if (file.Add(student) != null)
            {
                return "Student: " + student.Id + " added";
            }
            else
            {
                return "Student: " + student.Id + " can not added";
            }
        }

        public string DeleteStudent(string name, EnumTypes type, Student student)
        {
            IAbstractFactory factory = FactoryProvider.GetFactory(name);
            VuelingFile file = factory.Create(type);
            if (file.Delete(student) != null)
            {
                return "Student: " + student.Id + " deleted";
            }
            else
            {
                return "Student: " + student.Id + " can not delete";
            }
        }

        public string GetAllStudents(string name, EnumTypes type)
        {
            IAbstractFactory factory = FactoryProvider.GetFactory(name);
            VuelingFile file = factory.Create(type);
            List<Student> list = file.GetAll();
            return ShowStudents(GetAllWithAge(list));
           
        }

        public string UpdateStudent(string name, EnumTypes type, Student student)
        {
            IAbstractFactory factory = FactoryProvider.GetFactory(name);
            VuelingFile file = factory.Create(type);
            if (file.Update(student) != null)
            {
                return "Student: " + student.Id + " updated";
            }
            else
            {
                return "Student: " + student.Id + " can not update";
            }
        }

        private Dictionary<Student, int> GetAllWithAge(List<Student> list)
        {
            Dictionary<Student, int> result = list
                .Select(student => new KeyValuePair<Student, int>(student, CalculateAge(student)))
                .ToDictionary(x => x.Key, x => x.Value);
            return result;
        }

        private int CalculateAge(Student student)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int date = int.Parse(student.DateOfBirth.ToString("yyyyMMdd"));
            int age = (now - date) / 10000;
            return age;
        }
        private string ShowStudents(Dictionary<Student, int> dictionary)
        {
            StringBuilder message = new StringBuilder();
            foreach (var item in dictionary)
            {
                message.Append(item.Key + ", Age: " + item.Value + "\n");
            }
            return message.ToString();
        }
    }
}
