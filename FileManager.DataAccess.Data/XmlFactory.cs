using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
	public class XmlFactory : StudentDao
	{

		public readonly string path = ConfigurationManager.AppSettings.Get("xmlFile");
		public Student Add(Student student)
		{
			if (!File.Exists(path))
			{
				new XDocument(
					new XElement("Students",
					new XElement("Student",
					new XElement("Id", student.Id),
					new XElement("Name", student.Name),
					new XElement("Surname", student.Surname),
					new XElement("DateOfBirth", student.DateOfBirth.ToString("dd/MM/yyyy"))
					)
					)
				).Save(path);
			}
			else
			{
				student = AppendStudent(student);
			}
			return student;
		}

		public bool Delete(Student student)
		{
			if (File.Exists(path))
			{
				XDocument doc = XDocument.Load(path);
				IEnumerable<XElement> list = doc.Root.Elements("Student").Where(e => e.Element("Id").Value.Equals(student.Id.ToString()));
				if (list.Count() > 0)
				{
					list.Remove();
					doc.Save(path);
					return true;
				}
			}
			return false;
		}

		public List<Student> Get()
		{
			List<Student> list = new List<Student>();
			if (File.Exists(path))
			{
				XDocument doc = XDocument.Load(path);
				foreach (var item in doc.Element("Students").Elements("Student"))
				{
					Student student = new Student(int.Parse(item.Element("Id").Value), item.Element("Name").Value,
						item.Element("Surname").Value, DateTime.Parse(item.Element("DateOfBirth").Value));
					list.Add(student);
				}
			}

			return list;
		}

		public Student Update(Student student)
		{
			if (File.Exists(path))
			{
				XDocument doc = XDocument.Load(path);
				IEnumerable<XElement> list = doc.Root.Elements("Student").Where(e => e.Element("Id").Value.Equals(student.Id.ToString()));
				if (list.Count() > 0)
				{
					list.Elements("Name").FirstOrDefault().Value = student.Name;
					list.Elements("Surname").FirstOrDefault().Value = student.Surname;
					list.Elements("DateOfBirth").FirstOrDefault().Value = student.DateOfBirth.ToString("dd/MM/yyyy");

					doc.Save(path);
					return student;
				}
			}

			return null;
		}

		private Student AppendStudent(Student student)
		{
			if (!GetIds().Contains(student.Id))
			{
				XDocument doc = XDocument.Load(path);
				XElement child = new XElement("Student");
				child.Add(new XElement("Id", student.Id.ToString()));
				child.Add(new XElement("Name", student.Name.ToString()));
				child.Add(new XElement("Surname", student.Surname.ToString()));
				child.Add(new XElement("DateOfBirth", student.DateOfBirth.ToString("dd/MM/yyyy")));
				doc.Root.Add(child);
				doc.Save(path);
				return student;
			}

			return null;
		}
		private List<int> GetIds()
		{
			List<int> list = new List<int>();
			XDocument doc = XDocument.Load(path);
			foreach (var item in doc.Element("Students").Elements("Student").Elements("Id"))
			{
				list.Add(int.Parse(item.Value));
			}
			return list;
		}

	}
}
