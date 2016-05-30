using System;
using System.ComponentModel.Composition;

using Bau.Libraries.LibPlugins.Core.Host;
using Bau.Libraries.LibPlugins.Core.Plugins;

namespace PluginSampleHello
{
	/// <summary>
	///		Controlador del plugin "SampleHello"
	/// </summary>
	[Export(typeof(IPlugin))]
	[ExportMetadata("Name", "SampleHello")]
	[ExportMetadata("Description", "Prueba de plugin")]
	public class PluginSampleHelloController : AbstractBasePlugin
	{	
		public PluginSampleHelloController(): base("SampleHello")
		{
		}

		/// <summary>
		///		Inicializa las librerías
		/// </summary>
		public override void InitLibraries(IHostController objHostController)
		{ System.Timers.Timer tmrMessage = new System.Timers.Timer(5000);

				// Inicializa el controlador
					HostController = objHostController;
				// Inicializa un temporizador para enviar un mensaje al controlador
					tmrMessage.Start();
					tmrMessage.Elapsed += (objSender, objEventArgs) =>
																		{ HostController.ShowMessage("Mensaje enviado desde PluginSampleHelloController");
																		};
				// Muestra el mensaje en la consola
					Console.WriteLine("Inicializando las librerías de SampleHello");
		}

		/// <summary>
		///		Obtiene el mensaje de saludo
		/// </summary>
		public override string GetHelloMessage()
		{ return $"Hello desde PluginSampleHelloController. Mi host es {HostController.ApplicationName}";
		}
	}
}
