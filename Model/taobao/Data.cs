using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Model.taobao
{
	public class Data
	{
		public List<ApiStackItem> apiStack
		{
			get;
			set;
		}
		public Item item
		{
			get;
			set;
		}
		public string mockData
		{
			get;
			set;
		}
		[JsonProperty(PropertyName = "params")]
		public Params Params
		{
			get;
			set;
		}
		public Props props
		{
			get;
			set;
		}
		public Props2 props2
		{
			get;
			set;
		}
		public Rate rate
		{
			get;
			set;
		}
		public Seller seller
		{
			get;
			set;
		}
		public SkuBase skuBase
		{
			get;
			set;
		}
		public Vertical vertical
		{
			get;
			set;
		}
	}
}
