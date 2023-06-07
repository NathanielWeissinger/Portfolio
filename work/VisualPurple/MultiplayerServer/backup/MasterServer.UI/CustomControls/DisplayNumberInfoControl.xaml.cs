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
	public partial class DisplayNumberInfoControl : UserControl
	{
		public DisplayNumberInfoControl()
		{
			InitializeComponent();
		}

		private string _displayLabelText;
		public string DisplayLabelText
		{
			get { return _displayLabelText; }
			set { _displayLabelText = value; SetValue( DisplayLabelTextProperty, value ); }
		}

		private string _displayInfoNubmer;
		public string DisplayInfoNumber
		{
			get { return _displayInfoNubmer; }
			set { _displayInfoNubmer = value; SetValue( DisplayInfoNumberProperty, value ); }
		}

		public static DependencyProperty DisplayLabelTextProperty = DependencyProperty.Register(
			name: "DisplayLabelText",
			propertyType: typeof( string ),
			ownerType: typeof( DisplayNumberInfoControl ),
			typeMetadata: new FrameworkPropertyMetadata( defaultValue: "Test Label" ) );
		public static DependencyProperty DisplayInfoNumberProperty = DependencyProperty.Register(
			name: "DisplayInfoNumber",
			propertyType: typeof( string ),
			ownerType: typeof( DisplayNumberInfoControl ),
			typeMetadata: new FrameworkPropertyMetadata( defaultValue: "-1" ) );
	}
}
