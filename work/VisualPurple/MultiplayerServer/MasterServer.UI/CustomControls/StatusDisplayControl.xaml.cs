using System.Windows;
using System.Windows.Controls;

namespace MasterServer.UI.CustomControls
{
	public partial class StatusDisplayControl : Label
	{
		public StatusDisplayControl()
		{
			InitializeComponent();
		}


		public static readonly DependencyProperty ActiveStatusProperty = DependencyProperty.Register(
			name: "ActiveStatus",
			propertyType: typeof( bool ),
			ownerType: typeof( StatusDisplayControl ),
			typeMetadata: new FrameworkPropertyMetadata(
				defaultValue: false,
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault )
			);
		public bool ActiveStatus
		{
			get => (bool)GetValue( ActiveStatusProperty );
			set => SetValue( ActiveStatusProperty, value );
		}
	}
}
