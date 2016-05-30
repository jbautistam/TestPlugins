using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Bau.Libraries.LibPlugins.Core.Plugins;

namespace TestPlugins
{
	/// <summary>
	///		Ventana principal
	/// </summary>
	public partial class MainWindow : Window
	{	
		public MainWindow()
		{ InitializeComponent();
		}

		/// <summary>
		///		Carga los plugins
		/// </summary>
		private void LoadPlugins()
		{	Plugins.HostController objHostController = new Plugins.HostController();
			Plugins.PluginsManager objPluginsManager = new Plugins.PluginsManager();
			string strError;

				// Inicializa el manager
					objPluginsManager.Initialize(typeof(MainWindow), txtPath.Text);
				// Inicializa los plugins
					objPluginsManager.InitPlugins(objHostController, out strError);
				// Añade los plugins a la lista
					lstPlugins.Items.Clear();
					foreach (IPlugin objPlugin in objPluginsManager.PluginsController)
						lstPlugins.Items.Add($"Plugin {objPlugin.Name} - {objPlugin.GetHelloMessage()}");
				// Añade el manejador de mensajes
					objHostController.MessageAdded += (objSender, strMessage) =>
																								{ Dispatcher.Invoke(() => lstPlugins.Items.Add($"Mensaje recibido en el host: {strMessage}"), 
																																		System.Windows.Threading.DispatcherPriority.Normal);
																								};
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{ LoadPlugins();
		}
	}
}
