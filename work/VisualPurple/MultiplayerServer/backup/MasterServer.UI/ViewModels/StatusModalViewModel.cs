/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
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
		private readonly ILogger _logger;
		private readonly ServerData _serverData;

		private readonly IViewModelFactory _viewModelFactory;
		private readonly IDialogService _dialogService;

		public IAsyncRelayCommand ShowActivePlayerWindowCommand { get; }
		public IAsyncRelayCommand ShowLobbyWindowCommand { get; }
		public IAsyncRelayCommand ShowServerWindowCommand { get; }

		private ObservableDictionary<string, string> _activePlayersList;
		public ObservableDictionary<string, string> ActivePlayersList
		{
			get => _activePlayersList;
			set => SetProperty( ref _activePlayersList, value, nameof( ActivePlayersList ) );
		}

		private ObservableDictionary<int, string> _lobbiesList;
		public ObservableDictionary<int, string> LobbiesList
		{
			get => _lobbiesList;
			set => SetProperty( ref _lobbiesList, value, nameof( LobbiesList ) );
		}

		private ObservableDictionary<int, string> _serversList;
		public ObservableDictionary<int, string> ServersList
		{
			get => _serversList;
			set => SetProperty( ref _serversList, value, nameof( ServersList ) );
		}

		public StatusModalViewModel(
			ILogger logger,
			ServerData serverData,
			IViewModelFactory viewModelFactory,
			IDialogService dialogService )
		{
			_logger = logger;
			_serverData = serverData;
			_viewModelFactory = viewModelFactory;
			_dialogService = dialogService;

			_serverData.OnAddPlayer += ActivePlayerAdded;
			_serverData.OnRemovePlayer += ActivePlayerRemoved;
			_serverData.OnAddLobby += LobbyAdded;
			_serverData.OnRemoveLobby += LobbyRemoved;
			_serverData.OnAddServer += ServerAdded;
			//_serverData.OnRemoveServer += ServerRemoved;

			ActivePlayersList = new ObservableDictionary<string, string>();
			LobbiesList = new ObservableDictionary<int, string>();
			ServersList = new ObservableDictionary<int, string>();

			ShowActivePlayerWindowCommand = new AsyncRelayCommand<string>( ShowActivePlayerWindow );
			ShowLobbyWindowCommand = new AsyncRelayCommand<int>( ShowLobbyWindow );
			ShowServerWindowCommand = new AsyncRelayCommand<int>( ShowServerWindow );
		}

		~StatusModalViewModel()
		{
			_serverData.OnAddPlayer -= ActivePlayerAdded;
			_serverData.OnRemovePlayer -= ActivePlayerRemoved;
			_serverData.OnAddLobby -= LobbyAdded;
			_serverData.OnRemoveLobby -= LobbyRemoved;
			_serverData.OnAddServer -= ServerAdded;
			//_serverData.OnRemoveServer -= ServerRemoved;
		}

		private void ActivePlayerAdded( object sender, AddPlayerArgs e )
		{
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				ActivePlayersList.Add( e.Player.PlayerUID, e.Player.ToString() );
			} ) );
		}

		private void ActivePlayerRemoved( object sender, RemovePlayerArgs e )
		{
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				ActivePlayersList.Remove( e.Player.PlayerUID );
			} ) );
		}

		private void LobbyAdded( object sender, AddLobbyArgs e )
		{
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				LobbiesList.Add( e.Lobby.LobbyID, e.Lobby.ToString() );
			} ) );
		}

		private void LobbyRemoved( object sender, RemoveLobbyArgs e )
		{
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				LobbiesList.Remove( e.Lobby.LobbyID );
			} ) );
		}

		private void ServerAdded( object sender, AddServerArgs e )
		{
			App.Current.Dispatcher.Invoke( new Action( () =>
			{
				ServersList.Add( e.Server.Client.ClientID, e.Server.ToString() );
				;
			} ) );
		}

		//private void ServerRemoved(object sender, RemoveServerArgs e)
		//{
		//    App.Current.Dispatcher.Invoke(new Action(() =>
		//    {
		//        ServersList.Remove(e.Server.Client.ClientID);
		//    }));
		//}

		private async Task ShowActivePlayerWindow( string playerId )
		{
			var viewModel = (ActivePlayerViewModel)_viewModelFactory.GetInstance( nameof( ActivePlayerViewModel ) );
			viewModel.LoadActivePlayerToView( playerId );
			_dialogService.Show( this, viewModel );

			await Task.CompletedTask;
		}

		private async Task ShowLobbyWindow( int lobbyId )
		{
			var viewModel = (LobbyViewModel)_viewModelFactory.GetInstance( nameof( LobbyViewModel ) );
			viewModel.LoadLobbyWindowInformation( lobbyId );
			_dialogService.Show( this, viewModel );

			await Task.CompletedTask;
		}

		private async Task ShowServerWindow( int serverId )
		{
			var viewModel = (ServerViewModel)_viewModelFactory.GetInstance( nameof( ServerViewModel ) );
			viewModel.LoadActiveServerInformation( serverId );
			_dialogService.Show( this, viewModel );

			await Task.CompletedTask;
		}
	}
}
