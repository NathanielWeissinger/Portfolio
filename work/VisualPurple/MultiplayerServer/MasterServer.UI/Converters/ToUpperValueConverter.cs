/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Receives string and capitalizes all characters.
 * Used by ActivePlayer.xaml
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
	public class ToUpperValueConverter : IValueConverter
	{
		// Receives string and capitalizes all characters.
		public object Convert( object InValue, Type InTargetType, object InParameter,
							  CultureInfo InCulture )
		{
			// Checks to see if object is a string
			if (InValue is string)
			{
				return InValue.ToString().ToUpper();
			}
			return String.Empty;
		}

		// Supposed to convert uppercase string back to its normal case, but since there is no
		// frame of reference, this method performs no action;
		// standard function to include for Converter class
		public object ConvertBack( object InValue, Type InTargetType, object InParameter,
								  CultureInfo InCulture )
		{
			return Binding.DoNothing;
		}
	}
}
