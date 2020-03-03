using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FileManager.Common.Layer;
using log4net;

namespace FileManager.DataAccess.Data
{
	public class XmlUtil
	{
		private static readonly ILog logger = LogManager.GetLogger(typeof(XmlUtil));
		private readonly string path;

		public XmlUtil(string path)
		{
			this.path = path;
		}

		public XDocument LoadFile(string path)
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

		public void CreateFile(string path)
		{
			if (!IsFileExist(path))
				try
				{
					new XDocument(new XElement("Students")).Save(path);
				}
				catch (ArgumentNullException ane)
				{
					logger.Error(path);
					logger.Error(ane.Message);
					throw ane;
				}
		}

		public bool IsFileExist(string path)
		{
			return File.Exists(path);
		}

		public Student AppendStudent(Student student, string path)
		{
			if (!GetIds(path).Contains(student.Id))
			{
				XDocument doc = LoadFile(path);
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

		public Student GetLastStudent(string path)
		{
			XElement element = LoadFile(path).Root.Elements("Student").Last();
			Student student = new Student(int.Parse(element.Element("Id").Value), element.Element("Name").Value,
				element.Element("Surname").Value, DateTime.Parse(element.Element("DateOfBirth").Value));

			return student;
		}

		private XElement CreateStudentXml(XElement element, Student student)
		{
			element.Add(new XElement("Id", student.Id));
			element.Add(new XElement("Name", student.Name));
			element.Add(new XElement("Surname", student.Surname));
			element.Add(new XElement("DateOfBirth", student.DateOfBirth.ToString("dd/MM/yyyy")));

			return element;
		}
		private List<int> GetIds(string path)
		{
			List<int> list = new List<int>();
			XDocument doc = LoadFile(path);
			foreach (var item in doc.Element("Students").Elements("Student").Elements("Id"))
			{
				list.Add(int.Parse(item.Value));
			}
			return list;
		}

	}
}
