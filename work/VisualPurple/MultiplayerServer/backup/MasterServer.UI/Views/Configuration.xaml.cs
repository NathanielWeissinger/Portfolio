using MahApps.Metro.Controls;
using MasterServer.UI.ViewModels;

namespace MasterServer.UI.Views
{
	public partial class Configuration : MetroWindow
	{
		public Configuration()
		{
			InitializeComponent();
		}

		private void ConfigurationWindow_Loaded( object sender, System.Windows.RoutedEventArgs e )
		{
			var vm = (ConfigurationViewModel)DataContext;
			vm.OnLoad.Execute( sender );
		}
	}
}
