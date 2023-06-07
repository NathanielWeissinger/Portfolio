/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Sets a Unit as part of a list for the server configuration.
 * Inherits index and editable properties from ConfigurationData.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterServer.UI.Models
{
	public class UnitModel : ConfigurationData
	{
		// Property: Get/Set Unit
		private string _configurationValue = "Test";
		public string Unit
		{
			get => _configurationValue;
			set => SetProperty( ref _configurationValue, value, nameof( Unit ) );
		}
	}
}
