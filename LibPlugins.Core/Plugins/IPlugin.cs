using System;

namespace Bau.Libraries.LibPlugins.Core.Plugins
{
	/// <summary>
	///		Interface para los plugins
	/// </summary>
	public interface IPlugin
	{
		/// <summary>
		///		Inicializa las librerías del plugin
		/// </summary>
		void InitLibraries(Host.IHostController objHostController);

		/// <summary>
		///		Muestra un mensaje
		/// </summary>
		string GetHelloMessage();

		/// <summary>
		///		Nombre del plugin
		/// </summary>
		string Name { get; }
	}
}
