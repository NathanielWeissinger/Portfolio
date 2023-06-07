/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
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
		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return value.ToString();
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return int.Parse( value.ToString() );
		}
	}
}
