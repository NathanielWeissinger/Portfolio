/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Interface used for creating ViewModel instances, and from which all ViewModels inherit from.
 */

using System.ComponentModel;

namespace MasterServer.UI.ViewModels.Contracts
{
	public interface IViewModel : INotifyPropertyChanged, INotifyPropertyChanging
	{

	}
}
