using System.Windows;
using System.Windows.Controls;

namespace MasterServer.UI.CustomControls
{
	public partial class DisplayStringInfoControl : UserControl
	{
		public DisplayStringInfoControl()
		{
			InitializeComponent();
		}

		private string _displayLabelText;
		public string DisplayLabelText
		{
			get { return _displayLabelText; }
			set { _displayLabelText = value; SetValue( DisplayLabelTextProperty, value ); }
		}

		private string _displayInfoText;
		public string DisplayInfoText
		{
			get { return _displayInfoText; }
			set { _displayInfoText = value; SetValue( DisplayInfoTextProperty, value ); }
		}

		public static DependencyProperty DisplayLabelTextProperty = DependencyProperty.Register(
			name: "DisplayLabelText",
			propertyType: typeof( string ),
			ownerType: typeof( DisplayStringInfoControl ),
			typeMetadata: new FrameworkPropertyMetadata( defaultValue: "Test Label" ) );
		public static DependencyProperty DisplayInfoTextProperty = DependencyProperty.Register(
			name: "DisplayInfoText",
			propertyType: typeof( string ),
			ownerType: typeof( DisplayStringInfoControl ),
			typeMetadata: new FrameworkPropertyMetadata( defaultValue: "Test Text" ) );
	}
}
