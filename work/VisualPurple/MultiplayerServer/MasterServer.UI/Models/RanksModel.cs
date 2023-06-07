/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Sets a Rank as part of a list for the server configuration.
 * Inherits index and editable properties from ConfigurationData.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterServer.UI.Models
{
	public class RanksModel : ConfigurationData
	{
		// Property: Get/Set Rank
		private string _configurationValue = "Test";
		public string Rank
		{
			get => _configurationValue;
			set => SetProperty( ref _configurationValue, value, nameof( Rank ) );
		}
	}
}
