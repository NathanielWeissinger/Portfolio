using MasterServer.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterServer.UI.CustomControls
{
	public partial class SearchBarControl : UserControl
	{
		public SearchBarControl()
		{
			InitializeComponent();
		}

		public void ClearSearchBar()
		{
			SearchText = "";
		}

		private void Button_Click( object sender, RoutedEventArgs e )
		{
			ClearSearchBar();
		}

		public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register(
			name: "SearchText",
			propertyType: typeof( string ),
			ownerType: typeof( SearchBarControl ),
			typeMetadata: new FrameworkPropertyMetadata( defaultValue: "" ) );

		public string SearchText
		{
			get => (string)GetValue( SearchTextProperty );
			set => SetValue( SearchTextProperty, value );
		}
	}
}
