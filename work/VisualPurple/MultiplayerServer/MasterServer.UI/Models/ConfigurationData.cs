/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Primary class for inheritance by Unit, Rank, and Job Code models.
 * Provides models with index and editable properties.
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
		// Property: Get/Set order number (index) in list
		private int _orderNumber = 0;
		[Key] // Applies Key type as an attribute to property
		public int Order
		{
			get => _orderNumber;
			set => SetProperty( ref _orderNumber, value, nameof( Order ) );
		}

		// Property: Get/Set whether model is editable (default false)
		private bool _bIsEditMode = false;
		public bool IsEditMode
		{
			get => _bIsEditMode;
			set
			{
				SetProperty( ref _bIsEditMode, value, nameof( IsEditMode ) );
			}
		}
	}
}
