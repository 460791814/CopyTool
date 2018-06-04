using Model.taobao.custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.taobao.custom
{
   public  class ApiStackValue
    {
        public Delivery delivery { get; set; }
        public SkuCore skuCore { get; set; }
        public Price price { get; set; }
    }
    public class Price
    {
        /// <summary>
        /// Price
        /// </summary>
        public Model.taobao.Price price { get; set; }
        /// <summary>
        /// ExtraPrices
        /// </summary>
        public List<ExtraPrices> extraPrices { get; set; }
        /// <summary>
        /// PriceTag
        /// </summary>
        public List<PriceTag> priceTag { get; set; }
        /// <summary>
        /// TransmitPrice
        /// </summary>
        public TransmitPrice transmitPrice { get; set; }
    }
}
