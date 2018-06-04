using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Model.taobao
{
	public class GroupPropsItem
	{
		[JsonProperty(PropertyName = "基本信息")]
		public List<Dictionary<string, string>> BaseInfo
		{
			get;
			set;
		}
	}
}
