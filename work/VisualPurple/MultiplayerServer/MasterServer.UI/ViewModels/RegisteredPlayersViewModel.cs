/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Displays list of registered players, pulled from playerdata.json, when prompted. Has search and edit functionality.
 *	At the top of the Master Server Main Menu, under View, click the RegisteredPlayers button to view.
 * See Views->RegisteredPlayers.xaml and Modals->RegisteredPlayerModal.xaml for visual reference.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * TITLE BAR:		"REGISTERED PLAYERS"
 * GRID:			Search Textbox, Clear X Button
 *	TITLE BAR:		Player ID			Name			  Rank	  Unit	  Job Code	    Facilitator?		Status		   Edit
 *	PANEL:			[PlayerID], [First Name, Last Name], [Rank], [Unit], [Job Code], [Facilitator bool], [Status bool], Edit button
 * BUTTONS:			Refresh					Previous	[Page Number]	Next
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
		// Dependencies
		private readonly ILogger _logger;
		private readonly IViewModelFactory _vmFactory;
		private readonly IDialogService _dialogService;

		private List<PlayerRec> _listPlayerRecs;
		private List<PlayerRec> _filteredListPlayerRecsStorage;
		const string _filePath = "playerdata.json";

		// Commands
		public IAsyncRelayCommand EditRegisteredPlayerCommand { get; }
		public IRelayCommand PaginationButtonCommand { get; }
		public IRelayCommand PaginationNextCommand { get; }
		public IRelayCommand PaginationPreviousCommand { get; }

		// Command: Get/Set Asynchronous Relay Load Command
		private IAsyncRelayCommand _onLoad;
		public IAsyncRelayCommand OnLoad
		{
			get => _onLoad;
			set => SetProperty( ref _onLoad, value, nameof( OnLoad ) );
		}

		// Constructor: initializes primary communication, button commands, and UI data
		public RegisteredPlayersViewModel( ILogger InLogger,
			IViewModelFactory InViewModelFactory,
			IDialogService InDialogService )
		{
			_logger = InLogger;
			EditRegisteredPlayerCommand = new AsyncRelayCommand<RegisteredPlayer>( ShowEditRegisteredPlayerModal );
			PaginationButtonCommand = new RelayCommand<int>( ShowPaginationPage );
			PaginationNextCommand = new RelayCommand( NextPaginationPage );
			PaginationPreviousCommand = new RelayCommand( PreviousPaginationPage );

			_vmFactory = InViewModelFactory;
			_dialogService = InDialogService;

			RegisteredPlayers = new ObservableCollection<RegisteredPlayer>();
			ButtonNumbers = new ObservableCollection<Button>();

			_filteredListPlayerRecsStorage = new List<PlayerRec>();
			_listPlayerRecs = new List<PlayerRec>();

			OnLoad = new AsyncRelayCommand( OnLoading );
		}
		
		// Property: Receives textbox input and searches through player data
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

		// Property: Get/Set generated page buttons created from BuildPagination()
		private ObservableCollection<Button> _buttonNumbers;
		public ObservableCollection<Button> ButtonNumbers
		{
			get => _buttonNumbers;
			set => SetProperty( ref _buttonNumbers, value, nameof( ButtonNumbers ) );
		}

		// Property: Get/Set Registered Players that temporarily appear on the panel
		private ObservableCollection<RegisteredPlayer> _registeredPlayers;
		public ObservableCollection<RegisteredPlayer> RegisteredPlayers
		{
			get => _registeredPlayers;
			set => SetProperty( ref _registeredPlayers, value, nameof( RegisteredPlayers ) );
		}

		// Task: When Edit button is pressed, displays new EditRegisteredPlayers window
		private async Task ShowEditRegisteredPlayerModal( RegisteredPlayer InRowData )
		{
			var PlayerViewModel = (EditRegisteredPlayerViewModel)_vmFactory.GetInstance( nameof( EditRegisteredPlayerViewModel ) );
			string PlayerID = InRowData.ID.ToString();
			PlayerViewModel.LoadRegisteredPlayerData( PlayerID );
			PlayerViewModel.RegisteredPlayersVM = this;
			_dialogService.Show( this, PlayerViewModel );
			await Task.CompletedTask;
		}

		// Task: Calls LoadRegisteredPlayers
		public async Task OnLoading()
		{
			LoadRegisteredPlayers( _filePath );
			await Task.CompletedTask;
		}

		// Loads Registered Players data from filepath
		private void LoadRegisteredPlayers( string InFilePath )
		{
			if (File.Exists( InFilePath ))
			{
				_listPlayerRecs.Clear();
				using (StreamReader SReader = new StreamReader( InFilePath ))
				{
					string Players = SReader.ReadToEnd();
					_listPlayerRecs = JsonConvert.DeserializeObject<List<PlayerRec>>( Players );
				}
			}
			SearchTextString = string.Empty;
		}

		// Search function: searches through player data to match with search string.
		// Creates Current and Maximum page number variables, depending on search results
		private int _recsPerPage = 15;
		private int _currentPage;
		private int _pageMaximum;
		private void FilterDataGrid()
		{
			_filteredListPlayerRecsStorage.Clear();

			foreach (var PlayerInstance in _listPlayerRecs)
			{
				if (PlayerInstance.FullName.ToUpper().Contains( SearchTextString.ToUpper() ))
				{
					_filteredListPlayerRecsStorage.Add( PlayerInstance );
				}
			}
			_currentPage = 1;
			_pageMaximum = (int)Math.Ceiling( (float)_filteredListPlayerRecsStorage.Count() / (float)_recsPerPage );
			BuildPagination();
			ShowPaginationPage( _currentPage );
		}

		// Buttons between Previous and Next. When clicked, jumps to selected page number.
		private void BuildPagination()
		{
			Binding PaginationBinding = new Binding();
			PaginationBinding.Path = new System.Windows.PropertyPath( "PaginationButtonCommand" );
			ButtonNumbers.Clear();

			// Creates individual buttons based on number of pages
			for (int i = 1; i <= _pageMaximum; i++)
			{
				Button Btn = new Button
				{
					Content = i,
					Height = 30,
					Width = 30,
					VerticalAlignment = System.Windows.VerticalAlignment.Center,
					FontWeight = System.Windows.FontWeights.Bold,
					Margin = new System.Windows.Thickness( 1 ),
					CommandParameter = i
				};
				Btn.SetBinding( Button.CommandProperty, PaginationBinding );

				ButtonNumbers.Add( Btn );
			}
		}

		// Changes players' data in the panel
		private void ShowPaginationPage( int InPageNumber )
		{
			// Sets page number
			InPageNumber = (InPageNumber < 1) ? 1 : InPageNumber;
			InPageNumber = (InPageNumber > _pageMaximum) ? _pageMaximum : InPageNumber;

			_currentPage = InPageNumber;

			int rangeSelection = (_recsPerPage * InPageNumber) > _filteredListPlayerRecsStorage.Count - 1 ? (_filteredListPlayerRecsStorage.Count) - (_recsPerPage * (InPageNumber - 1)) : _recsPerPage;

			RegisteredPlayers.Clear();
			List<PlayerRec> TempPlayerRecList = _filteredListPlayerRecsStorage.GetRange( ((InPageNumber - 1) * _recsPerPage), rangeSelection );

			// Places Player data into panel list
			foreach (var PlayerInstance in TempPlayerRecList)
			{
				RegisteredPlayer RegisteredPlayerInstance = new RegisteredPlayer();
				RegisteredPlayerInstance.ID = int.Parse( PlayerInstance.PlayerUID );
				RegisteredPlayerInstance.Name = PlayerInstance.FullName;
				RegisteredPlayerInstance.Rank = PlayerInstance.Rank;
				RegisteredPlayerInstance.Unit = PlayerInstance.Unit;
				RegisteredPlayerInstance.JobCode = PlayerInstance.Job;
				RegisteredPlayerInstance.IsActive = PlayerInstance.Status.Equals( "Active" ) ? true : false;
				RegisteredPlayerInstance.IsFacilitator = PlayerInstance.Role.Equals( "Facilitator" ) ? true : false;
				RegisteredPlayers.Add( RegisteredPlayerInstance );
			}

			HighlightPaginationButton();
		}

		// When Next button is pressed, loads new page of registered players
		private void NextPaginationPage()
		{
			ShowPaginationPage( _currentPage + 1 );
		}

		// When Previous button is pressed, loads previous page of registered players
		private void PreviousPaginationPage()
		{
			ShowPaginationPage( _currentPage - 1 );
		}

		// Sets background/foreground colors of page buttons. Current page is highlighted in blue.
		private void HighlightPaginationButton()
		{
			Console.WriteLine( "Test" );
			foreach (Button Btn in ButtonNumbers)
			{
				// Current Page, Highlighted
				if (Btn.Content.Equals( _currentPage ))
				{
					Btn.Background = new SolidColorBrush( Color.FromRgb( 0, 127, 255 ) ); // Blue
					Btn.Foreground = new SolidColorBrush( Colors.White );
				}
				// All other pages
				else
				{
					Btn.Background = new SolidColorBrush( Colors.WhiteSmoke );
					Btn.Foreground = new SolidColorBrush( Colors.Black );
				}
			}
		}
	}
}
