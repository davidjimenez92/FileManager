
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
	public class FileFactory : IAbstractFactory
	{
		private readonly string path = ConfigurationManager.AppSettings.Get("fileConfig");

		public VuelingFile Create(EnumTypes type)
		{
			var myAssembly = Assembly.GetExecutingAssembly();
			XElement root = XElement.Load(path);
			IEnumerable<XElement> repository =
				from element in root.Elements("Type")
				where (string)element.Attribute("Id") == type.ToString()
				select element;
			var fileType = repository.First().Element("class").Value;
			Type newFileManager = myAssembly.GetType(fileType);
			return Activator.CreateInstance(newFileManager) as VuelingFile;
		}

	}
}
