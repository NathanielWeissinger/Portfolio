/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.Core.Models;
using MasterServer.UI.Helpers;
using MasterServer.UI.ViewModels.Contracts;
using MvvmDialogs;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace MasterServer.UI.ViewModels
{
	public class RegisteredPlayersViewModel : ObservableObject, IViewModel
	{
		private readonly ILogger _logger;
		const string _filePath = "playerdata.json";

		public IAsyncRelayCommand EditRegisteredPlayerCommand { get; }
		public IRelayCommand PaginationButtonCommand { get; }
		public IRelayCommand PaginationNextCommand { get; }
		public IRelayCommand PaginationPreviousCommand { get; }

		private IAsyncRelayCommand _onLoad;
		public IAsyncRelayCommand OnLoad
		{
			get => _onLoad;
			set => SetProperty( ref _onLoad, value, nameof( OnLoad ) );
		}

		private readonly IViewModelFactory _viewModelFactory;
		private readonly IDialogService _dialogService;

		private string _searchTextString;
		public string SearchTextString
		{
			get => _searchTextString;
			set
			{
				SetProperty( ref _searchTextString, value, nameof( SearchTextString ) );
				FilterDataGrid();
			}
		}

		private List<PlayerRec> _listPlayerRecs;
		private List<PlayerRec> _filteredListPlayerRecsStorage;

		private ObservableCollection<Button> _buttonNubmers;
		public ObservableCollection<Button> ButtonNumbers
		{
			get => _buttonNubmers;
			set => SetProperty( ref _buttonNubmers, value, nameof( ButtonNumbers ) );
		}

		private ObservableCollection<RegisteredPlayer> _registeredPlayers;
		public ObservableCollection<RegisteredPlayer> RegisteredPlayers
		{
			get => _registeredPlayers;
			set => SetProperty( ref _registeredPlayers, value, nameof( RegisteredPlayers ) );
		}

		public RegisteredPlayersViewModel( ILogger logger,
			IViewModelFactory viewModelFactory,
			IDialogService dialogService )
		{
			_logger = logger;
			EditRegisteredPlayerCommand = new AsyncRelayCommand<RegisteredPlayer>( ShowEditRegisteredPlayerModal );
			PaginationButtonCommand = new RelayCommand<int>( ShowPaginationPage );
			PaginationNextCommand = new RelayCommand( NextPaginationPage );
			PaginationPreviousCommand = new RelayCommand( PreviousPaginationPage );


			_viewModelFactory = viewModelFactory;
			_dialogService = dialogService;

			RegisteredPlayers = new ObservableCollection<RegisteredPlayer>();
			ButtonNumbers = new ObservableCollection<Button>();

			_filteredListPlayerRecsStorage = new List<PlayerRec>();
			_listPlayerRecs = new List<PlayerRec>();

			OnLoad = new AsyncRelayCommand( OnLoading );
		}

		private async Task ShowEditRegisteredPlayerModal( RegisteredPlayer rowData )
		{
			var viewModel = (EditRegisteredPlayerViewModel)_viewModelFactory.GetInstance( nameof( EditRegisteredPlayerViewModel ) );
			string playerID = rowData.Id.ToString();
			viewModel.LoadRegisteredPlayerData( playerID );
			viewModel.RegisteredPlayersVM = this;
			_dialogService.Show( this, viewModel );
			await Task.CompletedTask;
		}

		public async Task OnLoading()
		{
			LoadRegisteredPlayers( _filePath );
			await Task.CompletedTask;
		}

		private void LoadRegisteredPlayers( string FilePath )
		{
			if (File.Exists( FilePath ))
			{
				_listPlayerRecs.Clear();
				using (StreamReader r = new StreamReader( FilePath ))
				{
					string players = r.ReadToEnd();
					_listPlayerRecs = JsonConvert.DeserializeObject<List<PlayerRec>>( players );
				}
			}
			SearchTextString = string.Empty;
		}

		private int _recsPerPage = 15;
		private int _currentPage;
		private int _pageMaximum;
		private void FilterDataGrid()
		{
			_filteredListPlayerRecsStorage.Clear();

			foreach (var player in _listPlayerRecs)
			{
				if (player.FullName.ToUpper().Contains( SearchTextString.ToUpper() ))
				{
					_filteredListPlayerRecsStorage.Add( player );
				}
			}
			_currentPage = 1;
			_pageMaximum = (int)Math.Ceiling( (float)_filteredListPlayerRecsStorage.Count() / (float)_recsPerPage );
			BuildPagination();
			ShowPaginationPage( _currentPage );
		}

		private void BuildPagination()
		{
			Binding paginationBinding = new Binding();
			paginationBinding.Path = new System.Windows.PropertyPath( "PaginationButtonCommand" );
			ButtonNumbers.Clear();
			for (int i = 1; i <= _pageMaximum; i++)
			{
				Button btn = new Button
				{
					Content = i,
					Height = 30,
					Width = 30,
					VerticalAlignment = System.Windows.VerticalAlignment.Center,
					FontWeight = System.Windows.FontWeights.Normal,
					Margin = new System.Windows.Thickness( 1 ),
					CommandParameter = i
				};
				btn.SetBinding( Button.CommandProperty, paginationBinding );

				ButtonNumbers.Add( btn );
			}
		}
		private void ShowPaginationPage( int pageNumber )
		{
			pageNumber = (pageNumber < 1) ? 1 : pageNumber;
			pageNumber = (pageNumber > _pageMaximum) ? _pageMaximum : pageNumber;

			_currentPage = pageNumber;

			int rangeSelection = (_recsPerPage * pageNumber) > _filteredListPlayerRecsStorage.Count - 1 ? (_filteredListPlayerRecsStorage.Count) - (_recsPerPage * (pageNumber - 1)) : _recsPerPage;

			RegisteredPlayers.Clear();
			List<PlayerRec> tempPlayerRecList = _filteredListPlayerRecsStorage.GetRange( ((pageNumber - 1) * _recsPerPage), rangeSelection );

			foreach (var player in tempPlayerRecList)
			{
				RegisteredPlayer registeredPlayer = new RegisteredPlayer();
				registeredPlayer.Id = int.Parse( player.PlayerUID );
				registeredPlayer.Name = player.FullName;
				registeredPlayer.Rank = player.Rank;
				registeredPlayer.Unit = player.Unit;
				registeredPlayer.JobCode = player.Job;
				registeredPlayer.IsActive = player.Status.Equals( "Active" ) ? true : false;
				registeredPlayer.IsFacilitator = player.Role.Equals( "Facilitator" ) ? true : false;
				RegisteredPlayers.Add( registeredPlayer );
			}

			HighlightPaginationButton();
		}

		private void NextPaginationPage()
		{
			ShowPaginationPage( _currentPage + 1 );
		}
		private void PreviousPaginationPage()
		{
			ShowPaginationPage( _currentPage - 1 );
		}

		private void HighlightPaginationButton()
		{
			foreach (Button btn in ButtonNumbers)
			{
				if (btn.Content.Equals( _currentPage ))
				{
					btn.Background = new SolidColorBrush( Color.FromRgb( 0, 127, 255 ) );
					btn.Foreground = new SolidColorBrush( Colors.White );
				}
				else
				{
					btn.Background = new SolidColorBrush( Colors.WhiteSmoke );
					btn.Foreground = new SolidColorBrush( Colors.Black );
				}
			}
		}
	}
}
