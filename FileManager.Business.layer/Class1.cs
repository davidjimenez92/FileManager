﻿using System;
using System.Collections.Generic;
using System.Text;
using FileManager.Common.Layer;
using FileManager.DataAccess.Data;

namespace FileManager.Business.layer
{
    public class Class1
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
            return ShowStudents(file.GetAll());
           
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

        private string ShowStudents(List<Student> list)
        {
            StringBuilder message = new StringBuilder();
            foreach (var item in list)
            {
                message.Append(item + "\n");
            }
            return message.ToString();
        }
    }
}
