using System;

namespace TestPlugins.Plugins
{
	/// <summary>
	///		Controlador del host de Plugins
	/// </summary>
	public class HostController : Bau.Libraries.LibPlugins.Core.Host.IHostController
	{	// Eventos públicos
			public event EventHandler<string> MessageAdded;

		public HostController()
		{ ApplicationName = "TestPlugins";
		}

		/// <summary>
		///		Muestra un mensaje
		/// </summary>
		public void ShowMessage(string strMessage)
		{ if (MessageAdded != null)
				MessageAdded(this, strMessage);
		}

		/// <summary>
		///		Nombre de la aplicación
		/// </summary>
		public string ApplicationName { get; }
	}
}
