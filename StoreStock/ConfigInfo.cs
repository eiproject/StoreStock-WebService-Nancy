using System;

namespace StoreStockWeb.Services {
	[Serializable]
	public class ConfigInfo
	{
		public int UpdateInterval { get; set; }
		public string ServerName { get; set; }
	}
}
