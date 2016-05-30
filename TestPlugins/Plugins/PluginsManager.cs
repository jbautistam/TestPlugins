using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

using Bau.Libraries.LibPlugins.Core.Host;
using Bau.Libraries.LibPlugins.Core.Plugins;

namespace TestPlugins.Plugins
{
	/// <summary>
	///		Manager de plugins
	/// </summary>
	[Export(typeof(IPluginManager))]
	public class PluginsManager : IPluginManager
	{
		#pragma warning disable 0649
		/// <summary>
		///		Plugins
		/// </summary>
    [ImportMany]
    private IEnumerable<Lazy<IPlugin, IPluginMetaData>> objColPlugins;
		#pragma warning restore 0649

		/// <summary>
		///		Inicializa los datos
		/// </summary>
		public void Initialize(Type objTypeMainAssembly, string strPathsPlugins)
		{	CompositionContainer objContainer;
			AggregateCatalog objCatalog = new AggregateCatalog();
			string [] arrStrPaths = strPathsPlugins.Split(';');

				// Añade todas las secciones localizadas en el ensamblado principal
					objCatalog.Catalogs.Add(new AssemblyCatalog(objTypeMainAssembly.Assembly));
				// Añade los directorios de plugins
					if (arrStrPaths.Length > 0)
						foreach (string strPath in arrStrPaths)
							if (System.IO.Directory.Exists(strPath))
								objCatalog.Catalogs.Add(new DirectoryCatalog(strPath));
				// Crea el CompositionContainer con las secciones del catálogo
					objContainer = new CompositionContainer(objCatalog);
				// Rellena los datos importados de este objeto
					try
						{	objContainer.ComposeParts(this);
						}
					catch (CompositionException objException)
						{ Console.WriteLine(objException.ToString());
						}
		}

		/// <summary>
		///		Inicializa los plugins
		/// </summary>
		public void InitPlugins(IHostController objHostController, out string strError)
		{	// Inicializa los argumentos de salida
				strError = "";
			// Inicializa los plugins
				if (Plugins != null)
					foreach (Lazy<IPlugin, IPluginMetaData> objPlugin in Plugins)
						try
							{ objPlugin.Value.InitLibraries(objHostController);
							}
						catch (Exception objException)
							{ strError += $"Error en el método InitLibraries del plugin {objPlugin.Metadata.Name}.\nExcepción: {objException.Message}" + Environment.NewLine;
							}
		}

		/// <summary>
		///		Plugins
		/// </summary>
		public IEnumerable<Lazy<IPlugin, IPluginMetaData>> Plugins 
		{ get { return objColPlugins; }
		}

		/// <summary>
		///		Lista de plugins
		/// </summary>
		public List<IPlugin> PluginsController
		{ get 
				{ List<IPlugin> objColPlugins = new List<IPlugin>();

						// Crea la lista de plugins
							if (Plugins != null)
								foreach (Lazy<IPlugin, IPluginMetaData> objPlugin in Plugins)
									objColPlugins.Add(objPlugin.Value);
						// Devuelve la lista de plugins
							return objColPlugins;	
				}
		}
	}
}
