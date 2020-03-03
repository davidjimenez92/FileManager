using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using FileManager.Common.Layer;
using log4net;

namespace FileManager.DataAccess.Data
{
	public class XmlUtil
	{
		private readonly string path = ConfigurationManager.AppSettings.Get("xmlFile");
		private static readonly ILog logger = LogManager.GetLogger(typeof(XmlUtil));

		public XDocument LoadFile()
		{
			try
			{
				XDocument doc = XDocument.Load(path);
				return doc;
			}
			catch (FileNotFoundException fnfe)
			{
				logger.Error(fnfe.Message);
				return null;
			}
		}

		public void CreateFile()
		{
			if(!IsFileExist())
				new XDocument(new XElement("Students")).Save(path);
		}

		public bool IsFileExist()
		{
			return File.Exists(path);
		}

		public Student AppendStudent(Student student)
		{
			if (!GetIds().Contains(student.Id))
			{
				XDocument doc = LoadFile();
				if (doc != null)
				{
					XElement child = CreateStudentXml(new XElement("Student"), student);
					
					doc.Root.Add(child);
					doc.Save(path);
					return student;
				}
			}

			logger.Error(student);
			return null;
		}

		private XElement CreateStudentXml(XElement element, Student student)
		{
			element.Add(new XElement("Id", student.Id));
			element.Add(new XElement("Name", student.Name));
			element.Add(new XElement("Surname", student.Surname));
			element.Add(new XElement("DateOfBirth", student.DateOfBirth.ToString("dd/MM/yyyy")));

			return element;
		}
		private List<int> GetIds()
		{
			List<int> list = new List<int>();
			XDocument doc = LoadFile();
			foreach (var item in doc.Element("Students").Elements("Student").Elements("Id"))
			{
				list.Add(int.Parse(item.Value));
			}
			return list;
		}
	}
}
