using System;

namespace FileManager.DataAccess.Data
{
	public static class FactoryProvider
	{
		public static IAbstractFactory GetFactory(string choice)
		{
			if ("FileManager.Presentation.WinSite".Equals(choice))
			{
				return new FileFactory();
			}
			return null;
		}

		public static IAbstractFactory GetFactory(object productName)
		{
			throw new NotImplementedException();
		}
	}
}
