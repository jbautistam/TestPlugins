using System;

namespace Bau.Libraries.LibPlugins.Core.Plugins
{
	/// <summary>
	///		Base para los plugins
	/// </summary>
	public abstract class AbstractBasePlugin : IPlugin
	{
		public AbstractBasePlugin(string strName)
		{ Name = strName;
		}

		/// <summary>
		///		Inicializa las librerías del plugin
		/// </summary>
		public abstract void InitLibraries(Host.IHostController objHostController);

		/// <summary>
		///		Obtiene el mensaje de saludo
		/// </summary>
		public abstract string GetHelloMessage();

		/// <summary>
		///		Nombre del plugin
		/// </summary>
		public string Name { get; }

		/// <summary>
		///		Controlador de la aplicación principal
		/// </summary>
		public Host.IHostController HostController { get; protected set; }
	}
}
