/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Used as a Window for the ActivePlayer. Displays Player Name and Client ID in title bar,
 * as opposed to a traditional MetroWindow, which only displays the Player Name.
 */

using MahApps.Metro.Controls;
using MasterServer.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MasterServer.UI.Views
{
	public class CustomWindow : MetroWindow
	{
		// Sets ClientIDProperty as the ClientIDText to be displayed on title bar
		public static readonly DependencyProperty ClientIDProperty =
		   DependencyProperty.Register(
			   name: "ClientIDText",
			   propertyType: typeof( string ),
			   ownerType: typeof( CustomWindow ),
			   typeMetadata: new FrameworkPropertyMetadata( defaultValue: "ClientID" ) );
		
		// Property: Get/Set Client ID text
		public string ClientIDText
		{
			get => (string)GetValue( ClientIDProperty );
			set => SetValue( ClientIDProperty, value );
		}
	}
}
