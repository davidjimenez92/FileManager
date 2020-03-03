using System;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
	public interface IAbstractFactory
	{
		VuelingFile Create(EnumTypes type);
	}
}
