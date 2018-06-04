using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.taobao.custom
{


    public class ExtraPrices
    {
        /// <summary>
        /// 500
        /// </summary>
        public string priceMoney { get; set; }
        /// <summary>
        /// 5
        /// </summary>
        public string priceText { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string priceTitle { get; set; }
        /// <summary>
        /// 2
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// true
        /// </summary>
        public string lineThrough { get; set; }
    }

    public class PriceTag
    {
        /// <summary>
        /// 全民疯抢
        /// </summary>
        public string text { get; set; }
    }
    public class TransmitPrice
    {
        /// <summary>
        /// 4.9
        /// </summary>
        public string priceText { get; set; }
    }
    public class sku
    {
        /// <summary>
        /// Price
        /// </summary>
        public Price price { get; set; }
        /// <summary>
        /// 9999999
        /// </summary>
        public string quantity { get; set; }
    }

    public class Sku2info
    {
        /// <summary>
        /// 0
        /// </summary>
        [JsonProperty(PropertyName = "0")]
        public sku info { get; set; }
}

public class SkuItem
{
    /// <summary>
    /// 北京
    /// </summary>
    public string location { get; set; }
}

public class SkuCore
{
    /// <summary>
    /// Sku2info
    /// </summary>
    public Sku2info sku2info { get; set; }
    /// <summary>
    /// SkuItem
    /// </summary>
    public SkuItem skuItem { get; set; }
}

}
