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
	public partial class NumberDisplayControl : UserControl
	{
		public NumberDisplayControl()
		{
			InitializeComponent();
		}

		public static DependencyProperty DisplayNumberProperty = DependencyProperty.Register(
			name: "DisplayNumber",
			propertyType: typeof( string ),
			ownerType: typeof( NumberDisplayControl ),
			typeMetadata: new FrameworkPropertyMetadata( defaultValue: "0" ) );

		public string DisplayNumber
		{
			get => (string)GetValue( DisplayNumberProperty );
			set => SetValue( DisplayNumberProperty, value );
		}
	}
}
