/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Displays Ranks, Units, and Job Codes available to players when prompted.
 *	At the top of the Master Server Main Menu, under View, click the Configuration button to view.
 * See Views->Configuration.xaml and Modals->ConfigurationModal.xaml for visual reference.
 * 
 * The data which appears in this ViewModel has this structure:
 * 
 * TITLE BAR:		"Configuration"
 * TABS:			Ranks					Units					Job Codes
 * PANEL:
 *	TITLE BAR:		Order, Rank				Order, Unit				Order, Job Code
 *	GRID BUTTONS:	Save, Delete, Edit		Save, Delete, Edit		Save, Delete, Edit
 *	GRID:			Order Textbox, Rank TB	Order TB, Unit TB		Order TB, Job Code TB
 * BUTTONS:			Add Rank				Add Unit				Add Job Code
 */

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterServer.UI.ViewModels.Contracts;
using Serilog;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Documents;
using MasterServer.Core.Models;
using System.Collections.Generic;
using MasterServer.UI.Helpers;
using System.Collections.ObjectModel;
using MasterServer.UI.Models;
using System.ComponentModel;
using System.Windows.Media.Media3D;
using System.Linq;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using System;
using MvvmDialogs;

namespace MasterServer.UI.ViewModels
{
	public class ConfigurationViewModel : ObservableObject, IViewModel
	{
		// Dependencies
		private readonly ILogger _logger;
		private const string _filePath = "serverdata.json";

		private readonly IDialogService _dialogService;

		// Commands
		public IAsyncRelayCommand CloseWindowCommand { get; }
		public IAsyncRelayCommand OnLoad { get; }
		public IAsyncRelayCommand SaveServerConfigDataCommand { get; }
		public IAsyncRelayCommand DeleteRankItemCommand { get; }
		public IAsyncRelayCommand DeleteUnitItemCommand { get; }
		public IAsyncRelayCommand DeleteJobCodeItemCommand { get; }

		public IAsyncRelayCommand AddRankItemCommand { get; }
		public IAsyncRelayCommand AddUnitItemCommand { get; }
		public IAsyncRelayCommand AddJobCodeItemCommand { get; }

		// Constructor: initializes primary communication, lists, and UI data
		public ConfigurationViewModel(
			ILogger InLogger,
			IDialogService InDialogService )
		{
			_logger = InLogger;
			_dialogService = InDialogService;

			RankList = new ObservableCollection<RanksModel>();
			UnitList = new ObservableCollection<UnitModel>();
			JobCodeList = new ObservableCollection<JobCodeModel>();

			CloseWindowCommand = new AsyncRelayCommand<Window>( CloseWindow );
			OnLoad = new AsyncRelayCommand( OnLoading );

			SaveServerConfigDataCommand = new AsyncRelayCommand( SaveServerConfigData );

			DeleteRankItemCommand = new AsyncRelayCommand<int>( DeleteRankItem );
			DeleteUnitItemCommand = new AsyncRelayCommand<int>( DeleteUnitItem );
			DeleteJobCodeItemCommand = new AsyncRelayCommand<int>( DeleteJobCodeItem );

			AddRankItemCommand = new AsyncRelayCommand( AddRankItem );
			AddUnitItemCommand = new AsyncRelayCommand( AddUnitItem );
			AddJobCodeItemCommand = new AsyncRelayCommand( AddJobCodeItem );
		}

		// Property: Get/Set Import Filepath of Configuration data
		private string _importFilePath;
		public string ImportFilePath
		{
			get => _importFilePath;
			set => SetProperty( ref _importFilePath, value, nameof( ImportFilePath ) );
		}

		// Property: Get/Set List of Ranks
		private ObservableCollection<RanksModel> _rankList;
		public ObservableCollection<RanksModel> RankList
		{
			get => _rankList;
			set
			{
				SetProperty( ref _rankList, value, nameof( RankList ) );
			}
		}

		// Property: Get/Set List of Units
		private ObservableCollection<UnitModel> _unitList;
		public ObservableCollection<UnitModel> UnitList
		{
			get => _unitList;
			set => SetProperty( ref _unitList, value, nameof( UnitList ) );
		}

		// Property: Get/Set List of Job Codes
		private ObservableCollection<JobCodeModel> _jobCodeList;
		public ObservableCollection<JobCodeModel> JobCodeList
		{
			get => _jobCodeList;
			set => SetProperty( ref _jobCodeList, value, nameof( JobCodeList ) );
		}

		// Task: Closes MetroWindow
		private async Task CloseWindow( Window InWindow )
		{
			InWindow.Close();
			await Task.CompletedTask;
		}

		// Task: Loads Configuration data from filepath
		public async Task OnLoading()
		{
			LoadServerConfigData( _filePath );
			await Task.CompletedTask;
		}


		// Loads Configuration data from serverdata.json, deserializes it, and places data into UI
		// Configuration data includes list of Ranks, Units, and Job Codes
		private ServerDataModel _serverConfigData;
		private void LoadServerConfigData( string InFilePath )
		{
			// Loads data from filepath and deserializes it
			if (File.Exists( InFilePath ))
			{
				using (StreamReader SReader = new StreamReader( InFilePath ))
				{
					string json = SReader.ReadToEnd();
					_serverConfigData = JsonConvert.DeserializeObject<ServerDataModel>( json );
				}
			}

			// Places data into UI
			if (_serverConfigData != null)
			{
				RankList.Clear();
				UnitList.Clear();
				JobCodeList.Clear();

				// Loops through all loaded Models for UI import
				for (int i = 0; i < _serverConfigData.Ranks.Count; i++)
				{
					RanksModel ConfData = new RanksModel
					{
						Order = i + 1,
						Rank = _serverConfigData.Ranks[i],
					};
					RankList.Add( ConfData );
				}
				for (int i = 0; i < _serverConfigData.Units.Count; i++)
				{
					UnitModel ConfData = new UnitModel
					{
						Order = i + 1,
						Unit = _serverConfigData.Units[i],
					};
					UnitList.Add( ConfData );
				}
				for (int i = 0; i < _serverConfigData.Jobs.Count; i++)
				{
					JobCodeModel ConfData = new JobCodeModel
					{
						Order = i + 1,
						JobCode = _serverConfigData.Jobs[i],
					};
					JobCodeList.Add( ConfData );
				}
			}
		}

		// Task: Under Ranks tab, after Rank Item is edited and Save button is pressed, saves data to serverdata.json
		private async Task SaveServerConfigData()
		{
			ServerDataModel SaveServerData = new ServerDataModel();

			List<RanksModel> RanksOutList = RankList.OrderBy( o => o.Order ).ToList();
			List<UnitModel> UnitsOutList = UnitList.OrderBy( o => o.Order ).ToList();
			List<JobCodeModel> JobCodeOutList = JobCodeList.OrderBy( o => o.Order ).ToList();

			// Loops through all Models and saves data
			foreach (var Rank in RanksOutList)
			{
				SaveServerData.Ranks.Add( Rank.Rank );
			}
			foreach (var Units in UnitsOutList)
			{
				SaveServerData.Units.Add( Units.Unit );
			}
			foreach (var JobCode in JobCodeOutList)
			{
				SaveServerData.Jobs.Add( JobCode.JobCode );
			}

			string Json = JsonConvert.SerializeObject( SaveServerData, Formatting.Indented );
			File.WriteAllText( _filePath, Json );

			LoadServerConfigData( _filePath );

			await Task.CompletedTask;
		}

		// Task: Under Ranks tab, if a Rank Item exists and Delete button is pressed, deletes item and saves to serverdata.json
		private async Task DeleteRankItem( int InOrderNum )
		{
			RanksModel Item = RankList.FirstOrDefault( x => x.Order == InOrderNum );
			RankList.Remove( Item );

			await SaveServerConfigData();
			await Task.CompletedTask;
		}

		// Task: Under Units tab, if a Unit Item exists and Delete button is pressed, deletes item and saves to serverdata.json
		private async Task DeleteUnitItem( int InOrderNum )
		{
			UnitModel Item = UnitList.FirstOrDefault( x => x.Order == InOrderNum );
			UnitList.Remove( Item );

			await SaveServerConfigData();
			await Task.CompletedTask;
		}

		// Task: Under Job Codes tab, if a Job Code Item exists and Delete button is pressed, deletes item and saves to serverdata.json
		private async Task DeleteJobCodeItem( int InOrderNum )
		{
			JobCodeModel Item = JobCodeList.FirstOrDefault( x => x.Order == InOrderNum );
			JobCodeList.Remove( Item );

			await SaveServerConfigData();
			await Task.CompletedTask;
		}

		// Task: Under the Ranks tab, when Add Rank button is pressed, creates new editable rank item
		private async Task AddRankItem()
		{
			// Rank Models have two variables: Rank, and Order (placement on the list)
			RanksModel RM = new RanksModel
			{
				Rank = "",
				Order = RankList.Count + 1,
				IsEditMode = true
			};

			RankList.Add( RM );

			await Task.CompletedTask;
		}

		// Task: Under the Units tab, when Add Unit button is pressed, creates new editable unit item
		private async Task AddUnitItem()
		{
			// Unit Models have two variables: Unit name, and Order (placement on the list)
			UnitModel UM = new UnitModel
			{
				Unit = "",
				Order = UnitList.Count + 1,
				IsEditMode = true
			};

			UnitList.Add( UM );

			await Task.CompletedTask;
		}

		// Task: Under the Job Codes tab, when Add Job Code button is pressed, creates new editable job code item
		private async Task AddJobCodeItem()
		{
			JobCodeModel JCM = new JobCodeModel
			{
				// Job Code Models have two variables: Job Code, and Order (placement on the list)
				JobCode = "",
				Order = JobCodeList.Count + 1,
				IsEditMode = true
			};

			JobCodeList.Add( JCM );

			await Task.CompletedTask;
		}
	}
}

