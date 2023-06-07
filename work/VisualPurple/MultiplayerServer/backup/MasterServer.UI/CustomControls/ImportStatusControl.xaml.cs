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
	public partial class ImportStatusControl : UserControl
	{
		public ImportStatusControl()
		{
			InitializeComponent();
		}

		private string _statusBackgroundColorSuccess = "#E1F0D5";
		private string _statusForegroundColorSuccess = "#3E9E38";
		private string _statusTextSuccess = "File Imported Successfully!";

		private string _statusBackgroundColorFailure = "#F5D6DA";
		private string _statusForegroundColorFailure = "#6C1522";
		private string _statusTextFailure = "There was an issue importing your file. Please view the log for details.";

		private string _statusValue;
		public string Status // HIDDEN, SUCCESS, FAILURE
		{
			set
			{
				_statusValue = value;
				switch (_statusValue.ToUpper())
				{
					case "SUCCESS":
						SetValue( ImportStatusVisibilityProperty, Visibility.Visible );
						SetValue( StatusBackgroundColorProperty, _statusBackgroundColorSuccess );
						SetValue( StatusForegroundColorProperty, _statusForegroundColorSuccess );
						SetValue( StatusTextProperty, _statusTextSuccess );
						SetValue( StatusLogButtonVisibilityProperty, Visibility.Hidden );
						break;
					case "FAILURE":
						SetValue( ImportStatusVisibilityProperty, Visibility.Visible );
						SetValue( StatusBackgroundColorProperty, _statusBackgroundColorFailure );
						SetValue( StatusForegroundColorProperty, _statusForegroundColorFailure );
						SetValue( StatusTextProperty, _statusTextFailure );
						SetValue( StatusLogButtonVisibilityProperty, Visibility.Visible );
						break;
					case "HIDDEN":
					default:
						SetValue( ImportStatusVisibilityProperty, Visibility.Hidden );
						break;
				}
			}
		}

		public static DependencyProperty ImportStatusVisibilityProperty = DependencyProperty.Register( "ImportStatusVisibility", typeof( Visibility ), typeof( ImportStatusControl ) );
		public static DependencyProperty StatusBackgroundColorProperty = DependencyProperty.Register( "StatusBackgroundColor", typeof( string ), typeof( ImportStatusControl ) );
		public static DependencyProperty StatusForegroundColorProperty = DependencyProperty.Register( "StatusForegroundColor", typeof( string ), typeof( ImportStatusControl ) );
		public static DependencyProperty StatusTextProperty = DependencyProperty.Register( "StatusText", typeof( string ), typeof( ImportStatusControl ) );
		public static DependencyProperty StatusLogButtonVisibilityProperty = DependencyProperty.Register( "StatusLogButtonVisibility", typeof( Visibility ), typeof( ImportStatusControl ) );


	}
}
