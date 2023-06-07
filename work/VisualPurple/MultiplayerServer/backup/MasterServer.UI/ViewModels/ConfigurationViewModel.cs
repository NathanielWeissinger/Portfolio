/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
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
		private readonly ILogger _Logger;
		private const string _FilePath = "serverdata.json";

		private readonly IDialogService _DialogService;

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

		// Constructor: 
		public ConfigurationViewModel(
			ILogger InLogger,
			IDialogService InDialogService )
		{
			_Logger = InLogger;
			_DialogService = InDialogService;

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

		// Property: Get/Set 
		private string _ImportFilePath;
		public string ImportFilePath
		{
			get => _ImportFilePath;
			set => SetProperty( ref _ImportFilePath, value, nameof( ImportFilePath ) );
		}

		// Property: Get/Set 
		private ObservableCollection<RanksModel> _RankList;
		public ObservableCollection<RanksModel> RankList
		{
			get => _RankList;
			set
			{
				SetProperty( ref _RankList, value, nameof( RankList ) );
			}
		}

		// Property: Get/Set 
		private ObservableCollection<UnitModel> _UnitList;
		public ObservableCollection<UnitModel> UnitList
		{
			get => _UnitList;
			set => SetProperty( ref _UnitList, value, nameof( UnitList ) );
		}

		// Property: Get/Set 
		private ObservableCollection<JobCodeModel> _JobCodeList;
		public ObservableCollection<JobCodeModel> JobCodeList
		{
			get => _JobCodeList;
			set => SetProperty( ref _JobCodeList, value, nameof( JobCodeList ) );
		}

		private async Task CloseWindow( Window window )
		{
			window.Close();
			await Task.CompletedTask;
		}

		public async Task OnLoading()
		{
			LoadServerConfigData( _FilePath );
			await Task.CompletedTask;
		}


		// 
		private ServerDataModel _ServerConfigData;
		private void LoadServerConfigData( string InFilePath )
		{
			if (File.Exists( InFilePath ))
			{
				using (StreamReader SReader = new StreamReader( InFilePath ))
				{
					string json = SReader.ReadToEnd();
					_ServerConfigData = JsonConvert.DeserializeObject<ServerDataModel>( json );
				}
			}
			if (_ServerConfigData != null)
			{
				RankList.Clear();
				UnitList.Clear();
				JobCodeList.Clear();

				for (int i = 0; i < _ServerConfigData.Ranks.Count; i++)
				{
					RanksModel ConfData = new RanksModel
					{
						Order = i + 1,
						Rank = _ServerConfigData.Ranks[i],
					};
					RankList.Add( ConfData );
				}
				for (int i = 0; i < _ServerConfigData.Units.Count; i++)
				{
					UnitModel ConfData = new UnitModel
					{
						Order = i + 1,
						Unit = _ServerConfigData.Units[i],
					};
					UnitList.Add( ConfData );
				}
				for (int i = 0; i < _ServerConfigData.Jobs.Count; i++)
				{
					JobCodeModel ConfData = new JobCodeModel
					{
						Order = i + 1,
						JobCode = _ServerConfigData.Jobs[i],
					};
					JobCodeList.Add( ConfData );
				}
			}
		}

		// Task: 
		private async Task SaveServerConfigData()
		{
			ServerDataModel SaveServerData = new ServerDataModel();

			List<RanksModel> RanksOutList = RankList.OrderBy( o => o.Order ).ToList();
			List<UnitModel> UnitsOutList = UnitList.OrderBy( o => o.Order ).ToList();
			List<JobCodeModel> JobCodeOutList = JobCodeList.OrderBy( o => o.Order ).ToList();

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
			File.WriteAllText( _FilePath, Json );

			LoadServerConfigData( _FilePath );

			await Task.CompletedTask;
		}

		// Task: 
		private async Task DeleteRankItem( int InOrderNum )
		{
			RanksModel Item = RankList.FirstOrDefault( x => x.Order == InOrderNum );
			RankList.Remove( Item );

			await SaveServerConfigData();
			await Task.CompletedTask;
		}

		// Task: 
		private async Task DeleteUnitItem( int InOrderNum )
		{
			UnitModel Item = UnitList.FirstOrDefault( x => x.Order == InOrderNum );
			UnitList.Remove( Item );

			await SaveServerConfigData();
			await Task.CompletedTask;
		}

		// Task: 
		private async Task DeleteJobCodeItem( int InOrderNum )
		{
			JobCodeModel Item = JobCodeList.FirstOrDefault( x => x.Order == InOrderNum );
			JobCodeList.Remove( Item );

			await SaveServerConfigData();
			await Task.CompletedTask;
		}

		// Task: 
		private async Task AddRankItem()
		{
			RanksModel RM = new RanksModel
			{
				Rank = "",
				Order = RankList.Count + 1,
				IsEditMode = true
			};

			RankList.Add( RM );

			await Task.CompletedTask;
		}

		// Task: 
		private async Task AddUnitItem()
		{
			UnitModel UM = new UnitModel
			{
				Unit = "",
				Order = UnitList.Count + 1,
				IsEditMode = true
			};

			UnitList.Add( UM );

			await Task.CompletedTask;
		}

		// Task: 
		private async Task AddJobCodeItem()
		{
			JobCodeModel JCM = new JobCodeModel
			{
				JobCode = "",
				Order = JobCodeList.Count + 1,
				IsEditMode = true
			};

			JobCodeList.Add( JCM );

			await Task.CompletedTask;
		}
	}
}

