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
		public readonly string path = ConfigurationManager.AppSettings.Get("xmlFile");
		private static readonly ILog logger = LogManager.GetLogger(typeof(XmlFile));

		private XmlUtil xmlUtil = new XmlUtil();

		public override Student Add(Student student)
		{
			xmlUtil.CreateFile();
			student = xmlUtil.AppendStudent(student);

			return student;
		}

		public override bool Delete(Student student)
		{
			XDocument doc = xmlUtil.LoadFile();
			if (doc != null)
			{
				XElement element = doc.Root.Elements("Student").SingleOrDefault(e => e.Element("Id").Value.Equals(student.Id.ToString()));
				element.Remove();
				doc.Save(path);
				return true;
			}
			return false;
		}

		public override List<Student> Get()
		{
			XDocument doc = xmlUtil.LoadFile();
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
			XDocument doc = xmlUtil.LoadFile();
			if (doc != null)
			{
				IEnumerable<XElement> list = doc.Root.Elements("Student").Where(e => e.Element("Id").Value.Equals(student.Id.ToString()));

				list.Elements("Name").FirstOrDefault().Value = student.Name;
				list.Elements("Surname").FirstOrDefault().Value = student.Surname;
				list.Elements("DateOfBirth").FirstOrDefault().Value = student.DateOfBirth.ToString("dd/MM/yyyy");

				doc.Save(path);
				return student;
			}
			logger.Info(student);
			return null;

		}



	}
}
