/*
 * Copyright 2023 Visual Purple, LLC. All rights reserved.
 * Authors: David Begg, James Kitzhaber, Timothy Schultz, James Spellman, Nathaniel Weissinger
 * 
 * Handles logger Type requests for verification of container configuration.
 */

using Serilog;
using SimpleInjector;
using SimpleInjector.Advanced;
using System;

namespace MasterServer.UI
{
	public class SerilogContextualLoggerInjectionBehavior : IDependencyInjectionBehavior
	{
		// Dependencies
		private readonly ILogger _loggerInstance;
		private readonly IDependencyInjectionBehavior _diOriginalBehavior;
		private readonly Container _diContainer;

		// Constructor for logging, input arguments defined in Program.cs
		public SerilogContextualLoggerInjectionBehavior(
			ContainerOptions DIOptions,
			LoggerConfiguration SerilogConfig )
		{
			_diOriginalBehavior = DIOptions.DependencyInjectionBehavior; // Default DI behavior
			_diContainer = DIOptions.Container; // Pass-through of original container
			_loggerInstance = SerilogConfig.CreateLogger(); // SerialConfig defines where/how the logger will output the debug data
		}

		// Verifies whether dependency can be injected into container
		public bool VerifyDependency( InjectionConsumerInfo InDIDependency, out string OutMsg ) =>
			_diOriginalBehavior.VerifyDependency( InDIDependency, out OutMsg );

		// Returns InstanceProducer of given container
		public InstanceProducer GetInstanceProducer( InjectionConsumerInfo InDIInfo, bool bThrowOnFailure ) =>
		InDIInfo.Target.TargetType == typeof( ILogger )
			? GetLoggerInstanceProducer( InDIInfo.ImplementationType )
			: _diOriginalBehavior.GetInstanceProducer( InDIInfo, bThrowOnFailure );

		// Returns InstanceProducer of given logger
		private InstanceProducer<ILogger> GetLoggerInstanceProducer( Type InProducerType ) =>
			Lifestyle.Transient.CreateProducer( () => _loggerInstance.ForContext( InProducerType ), _diContainer );
	}
}
