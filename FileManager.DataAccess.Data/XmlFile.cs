using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using FileManager.Common.Layer;
using log4net;

namespace FileManager.DataAccess.Data
{
	public class XmlFile : VuelingFile
	{
		public static readonly string path = Environment.GetEnvironmentVariable("xmlFile", EnvironmentVariableTarget.Machine).ToString();
		private static readonly ILog logger = LogManager.GetLogger(typeof(XmlFile));

		private XmlUtil xmlUtil = new XmlUtil(path);

		public override Student Add(Student student)
		{
			xmlUtil.CreateFile(path);
			xmlUtil.AppendStudent(student, path);

			return xmlUtil.GetLastStudent(path);
		}

		public override bool Delete(Student student)
		{
			var doc = xmlUtil.LoadFile(path);
			if (doc != null)
			{
				XElement element = doc.Root.Elements("Student").SingleOrDefault(e => e.Element("Id").Value.Equals(student.Id.ToString()));
				element.Remove();
				doc.Save(path);
				return true;
			}
			return false;
		}

		public override List<Student> GetAll()
		{
			XDocument doc = xmlUtil.LoadFile(path);
			List<Student> list = new List<Student>();
			if (doc != null)
			{
				foreach (var item in doc.Root.Elements("Student"))
				{
					Student student = new Student(int.Parse(item.Element("Id").Value), item.Element("Name").Value,
						item.Element("Surname").Value, DateTime.Parse(item.Element("DateOfBirth").Value));
					list.Add(student);
				}
			}
			return list;
		}

		public override Student Update(Student student)
		{
			XDocument doc = xmlUtil.LoadFile(path);

			XElement element = doc.Root.Elements("Student").SingleOrDefault(e => e.Element("Id").Value.Equals(student.Id.ToString()));

			element.Element("Name").Value = student.Name;
			element.Element("Surname").Value = student.Surname;
			element.Element("DateOfBirth").Value = student.DateOfBirth.ToString("dd/MM/yyyy");

			Student studentUpdated = new Student(student.Id, element.Element("Name").Value, element.Element("Surname").Value,
				DateTime.Parse(element.Element("DateOfBirth").Value));

			doc.Save(path);
			return studentUpdated;

		}



	}
}
