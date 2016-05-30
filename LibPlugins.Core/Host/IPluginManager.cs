using System;

namespace Bau.Libraries.LibPlugins.Core.Host
{
	/// <summary>
	///		Interface para las clases controladores de plugins
	/// </summary>
	public interface IPluginManager
	{
		/// <summary>
		///		Inicializa los plugins
		/// </summary>
		void InitPlugins(IHostController objHostController, out string strError);

		/// <summary>
		///		Colección de controladores de plugins
		/// </summary>
		System.Collections.Generic.List<Plugins.IPlugin> PluginsController { get; }
	}
}
