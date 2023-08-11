using System;
namespace TaskManager.Backend.Options
{
	public class DatabaseOptions
	{
		public string ConnectionString { get; set; } = string.Empty;
		public string MigrationsAssemblyName { get; set; } = string.Empty;
		public int MaxTryCount { get; set; }
		public int CommandTimeout { get; set; }
		public bool EnableDetailedErrors { get; set; }
		public bool EnabledSensitiveDataLogging { get; set; }
	}
}

