/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
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
		private string _configurationValue = "Test";
		public string Rank
		{
			get => _configurationValue;
			set => SetProperty( ref _configurationValue, value, nameof( Rank ) );
		}
	}
}
