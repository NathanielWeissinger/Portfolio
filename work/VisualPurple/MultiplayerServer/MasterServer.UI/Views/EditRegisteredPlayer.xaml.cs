using MahApps.Metro.Controls;
using MasterServer.UI.ViewModels;

namespace MasterServer.UI.Views
{
	public partial class EditRegisteredPlayer : MetroWindow
	{
		public EditRegisteredPlayer()
		{
			InitializeComponent();
		}
		private void EditPlayerWindow_Loaded( object sender, System.Windows.RoutedEventArgs e )
		{
			var vm = (EditRegisteredPlayerViewModel)DataContext;
			vm.OnLoad.Execute( sender );
		}
	}
}
