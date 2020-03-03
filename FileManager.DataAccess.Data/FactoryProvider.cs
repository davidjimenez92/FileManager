using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Layer;

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
	}
}
