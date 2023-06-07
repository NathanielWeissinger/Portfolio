using MahApps.Metro.Controls;
using MasterServer.UI.ViewModels;
using System.Windows.Controls;

namespace MasterServer.UI.Views
{
	public partial class RegisteredPlayers : MetroWindow
	{
		public RegisteredPlayers()
		{
			InitializeComponent();
		}

		private void RegisteredPlayerWindow_Loaded( object sender, System.Windows.RoutedEventArgs e )
		{
			var vm = (RegisteredPlayersViewModel)DataContext;
			vm.OnLoad.Execute( sender );
		}
	}
}
