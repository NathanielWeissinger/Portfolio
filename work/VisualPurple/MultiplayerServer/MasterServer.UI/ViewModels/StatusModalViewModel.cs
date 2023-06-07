/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Obtains, stores, and displays information within panes in the Master Server Main Menu.
 * Each entry within the panes details the names of each of the clients.
 * Servers display Online/Offline status.
 * Players display their client number, along with their player name and client name.
 * See MainWindow.xaml and CustomControls->StatusModalControl.xaml for visual reference.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * TITLE BAR:	"MASTER SERVER"
 * MENU BAR:	File (Restart, Exit), View (Configuration, Logs, Registered Players), Help (About)
 * GRID:		Server Log Pane		Connections				Servers
 *									Lobbies					Active Players
 *									Servers Pane			Lobbies Pane
 *									Active Players Pane
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.Core.Models;
using MasterServer.Events;
using MasterServer.UI.Helpers;
using MasterServer.UI.Models;
using MvvmDialogs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Documents;
//using Microsoft.IdentityServer.Management.Resources;

namespace MasterServer.UI.ViewModels
{
	public class StatusModalViewModel : ObservableObject
	{
		// Dependencies
		private readonly ILogger _logger;
		private readonly ServerData _serverData;
		private readonly IViewModelFactory _vmFactory;
		private readonly IDialogService _dialogService;

		// Commands
		public IAsyncRelayCommand ShowActivePlayerWindowCommand { get; }
		public IAsyncRelayCommand ShowLobbyWindowCommand { get; }
		public IAsyncRelayCommand ShowServerWindowCommand { get; }

		// Constructor: initializes primary communication and UI data
		public StatusModalViewModel(
			ILogger InLogger,
			ServerData InServerData,
			IViewModelFactory InViewModelFactory,
			IDialogService InDialogService )
		{
			_logger = InLogger;
			_serverData = InServerData;
			_vmFactory = InViewModelFactory;
			_dialogService = InDialogService;

			_serverData.OnAddPlayer += ActivePlayerAdded;
			_serverData.OnRemovePlayer += ActivePlayerRemoved;
			_serverData.OnAddLobby += LobbyAdded;
			_serverData.OnRemoveLobby += LobbyRemoved;
			_serverData.OnAddServer += ServerAdded;
			//_ServerData.OnRemoveServer += ServerRemoved;

			ActivePlayersList = new ObservableDictionary<string, string>();
			LobbiesList = new ObservableDictionary<int, string>();
			ServersList = new ObservableDictionary<int, string>();

			ShowActivePlayerWindowCommand = new AsyncRelayCommand<string>( ShowActivePlayerWindow );
			ShowLobbyWindowCommand = new AsyncRelayCommand<int>( ShowLobbyWindow );
			ShowServerWindowCommand = new AsyncRelayCommand<int>( ShowServerWindow );
		}

		// Destructor: Removes temporary properties of calls
		~StatusModalViewModel()
		{
			_serverData.OnAddPlayer -= ActivePlayerAdded;
			_serverData.OnRemovePlayer -= ActivePlayerRemoved;
			_serverData.OnAddLobby -= LobbyAdded;
			_serverData.OnRemoveLobby -= LobbyRemoved;
			_serverData.OnAddServer -= ServerAdded;
			//_serverData.OnRemoveServer -= ServerRemoved;
		}

		// Property: Get/Set List of Active Players
		private ObservableDictionary<string, string> _activePlayersList;
		public ObservableDictionary<string, string> ActivePlayersList
		{
			get => _activePlayersList;
			set => SetProperty( ref _activePlayersList, value, nameof( ActivePlayersList ) );
		}

		// Property:Get/Set List of Lobbies
		private ObservableDictionary<int, string> _lobbiesList;
		public ObservableDictionary<int, string> LobbiesList
		{
			get => _lobbiesList;
			set => SetProperty( ref _lobbiesList, value, nameof( LobbiesList ) );
		}

		// Property: Get/Set List of Servers
		private ObservableDictionary<int, string> _serversList;
		public ObservableDictionary<int, string> ServersList
		{
			get => _serversList;
			set => SetProperty( ref _serversList, value, nameof( ServersList ) );
		}

		// Task: When a Player is double-clicked within the Active Players pane, displays new ActivePlayerViewModel window
		private async Task ShowActivePlayerWindow( string InPlayerID )
		{
			var ActivePlayersVM = (ActivePlayerViewModel)_vmFactory.GetInstance( nameof( ActivePlayerViewModel ) );
			ActivePlayersVM.LoadActivePlayerToView( InPlayerID );
			_dialogService.Show( this, ActivePlayersVM );

			await Task.CompletedTask;
		}

		// Task: When a Lobby is double-clicked within the Lobbies pane, displays new LobbyViewModel window
		private async Task ShowLobbyWindow( int InLobbyID )
		{
			var LobbyVMInstance = (LobbyViewModel)_vmFactory.GetInstance( nameof( LobbyViewModel ) );
			LobbyVMInstance.LoadLobbyWindowInformation( InLobbyID );
			_dialogService.Show( this, LobbyVMInstance );

			await Task.CompletedTask;
		}

		// Task: When a Server is double-clicked within the Servers pane, displays new ServerViewModel window
		private async Task ShowServerWindow( int InServerID )
		{
			var ServerVMInstance = (ServerViewModel)_vmFactory.GetInstance( nameof( ServerViewModel ) );
			ServerVMInstance.LoadActiveServerInformation( InServerID );
			_dialogService.Show( this, ServerVMInstance );

			await Task.CompletedTask;
		}

		// Adds Player details to Active Players pane
		private void ActivePlayerAdded( object InSender, AddPlayerArgs e )
		{
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				ActivePlayersList.Add( e.Player.PlayerUID, e.Player.ToString() );
			} ) );
		}

		// Removes Player details from Active Players pane
		private void ActivePlayerRemoved( object InSender, RemovePlayerArgs e )
		{
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				ActivePlayersList.Remove( e.Player.PlayerUID );
			} ) );
		}

		// Adds Lobby details to Lobbies pane
		private void LobbyAdded( object InSender, AddLobbyArgs e )
		{
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				LobbiesList.Add( e.Lobby.LobbyID, e.Lobby.ToString() );
			} ) );
		}

		// Removes Lobby details from Lobbies pane
		private void LobbyRemoved( object InSender, RemoveLobbyArgs e )
		{
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				LobbiesList.Remove( e.Lobby.LobbyID );
			} ) );
		}

		// Adds Server details to Servers pane
		private void ServerAdded( object InSender, AddServerArgs e )
		{
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				ServersList.Add( e.Server.Client.ClientID, e.Server.ToString() );
			} ) );
		}

		// Removes Server details from Servers pane
		/*private void ServerRemoved(object sender, RemoveServerArgs e)
		{
		    App.Current.Dispatcher.Invoke(new Action(() =>
		    {
		        ServersList.Remove(e.Server.Client.ClientID);
		    }));
		}*/
	}
}
