/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Converts integer to string, and vice versa.
 * Used by EditRegisteredPlayer.xaml
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MasterServer.UI.Converters
{
	public class IntToStringConverter : IValueConverter
	{
		// Receives integer and converts value to string
		public object Convert( object InValue, Type InTargetType, object InParameter,
							  CultureInfo InCulture )
		{
			return InValue.ToString();
		}

		// Converts string back to integer
		public object ConvertBack( object InValue, Type InTargetType, object InParameter,
								  CultureInfo InCulture )
		{
			return int.Parse( InValue.ToString() );
		}
	}
}
