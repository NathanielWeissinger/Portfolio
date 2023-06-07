using MahApps.Metro.Controls;
using MasterServer.UI.ViewModels;

namespace MasterServer.UI
{
	public partial class MainWindow : MetroWindow
	{
		public MainWindow( MainWindowViewModel viewModel )
		{
			DataContext = viewModel;
			InitializeComponent();
		}

		private void MetroWindow_Loaded( object sender, System.Windows.RoutedEventArgs e )
		{
			var vm = (MainWindowViewModel)DataContext;
			vm.OnLoad.Execute( sender );
		}
	}
}
