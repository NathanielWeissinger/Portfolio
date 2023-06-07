/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 */

using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterServer.UI.Models
{
	public class ConfigurationData : ObservableObject
	{
		private int _orderNumber = 0;

		[Key]
		public int Order
		{
			get => _orderNumber;
			set => SetProperty( ref _orderNumber, value, nameof( Order ) );
		}

		private bool _isEditMode = false;
		public bool IsEditMode
		{
			get => _isEditMode;
			set
			{
				SetProperty( ref _isEditMode, value, nameof( IsEditMode ) );
			}
		}
	}
}
