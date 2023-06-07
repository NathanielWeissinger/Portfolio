using MahApps.Metro.Controls;
using MasterServer.UI.ViewModels;

namespace MasterServer.UI.Views
{
	public partial class Lobby : MetroWindow
	{
		public Lobby()
		{
			InitializeComponent();
		}

		private void LobbyWindow_Loaded( object sender, System.Windows.RoutedEventArgs e )
		{
			var vm = (LobbyViewModel)DataContext;
			vm.OnLoad.Execute( sender );
		}
	}
}
