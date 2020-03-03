
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
	public class FileFactory : IAbstractFactory
	{
		public VuelingFile Create(EnumTypes type)
		{
			switch (type)
			{
				case EnumTypes.XML:
					return new XmlFile();
				case EnumTypes.TXT:
					return new TxtFile();
				case EnumTypes.JSON:
					return new JsonFile();
				default:
					return null;
			}
		}

	}
}
