using System;

namespace Bau.Libraries.LibPlugins.Core.Plugins
{
	/// <summary>
	///		Interface para los datos de un plugin
	/// </summary>
	public interface IPluginMetaData
	{
		/// <summary>
		///		Nombre del plugin
		/// </summary>
		string Name { get; }

		/// <summary>
		///		Descripción del plugin
		/// </summary>
		string Description { get; }
	}
}
