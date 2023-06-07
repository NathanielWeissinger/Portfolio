using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterServer.UI.CustomControls
{
	public partial class ConfigurationButtonControl : ToggleButton
	{
		public ConfigurationButtonControl()
		{
			InitializeComponent();
		}

		public static readonly DependencyProperty IsInEditModeProperty = DependencyProperty.Register(
			name: "IsInEditMode",
			propertyType: typeof( bool ),
			ownerType: typeof( ConfigurationButtonControl ),
			typeMetadata: new FrameworkPropertyMetadata( defaultValue: false ) );

		public bool IsInEditMode
		{
			get => (bool)GetValue( IsInEditModeProperty );
			set => SetValue( IsInEditModeProperty, value );
		}
	}
}
