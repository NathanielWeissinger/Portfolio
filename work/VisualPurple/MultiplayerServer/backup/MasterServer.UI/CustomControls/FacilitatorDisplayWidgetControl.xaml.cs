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
	public partial class FacilitatorDisplayWidgetControl : Label
	{
		public FacilitatorDisplayWidgetControl()
		{
			InitializeComponent();
		}

		public bool FacilitatorStatus
		{
			get => (bool)GetValue( FacilitatorStatusProperty );
			set => SetValue( FacilitatorStatusProperty, value );
		}

		public static DependencyProperty FacilitatorStatusProperty = DependencyProperty.Register(
			name: "FacilitatorStatus",
			propertyType: typeof( bool ),
			ownerType: typeof( FacilitatorDisplayWidgetControl ),
			typeMetadata: new FrameworkPropertyMetadata( defaultValue: false ) );
	}
}
