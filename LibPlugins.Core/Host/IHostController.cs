using System;

namespace Bau.Libraries.LibPlugins.Core.Host
{
	/// <summary>
	///		Interface para la aplicación Host
	/// </summary>
	public interface IHostController
	{ 
		/// <summary>
		///		Muestra un mensaje
		/// </summary>
		void ShowMessage(string strMessage);

		/// <summary>
		///		Nombre de la aplicación
		/// </summary>
		string ApplicationName { get; }
	}
}
