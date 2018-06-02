using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
 
    public class ApiStack
    {
        /// <summary>
        /// esi
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// {"delivery":{"from":"广东珠海","to":"北京","areaId":"110100","postage":"快递: 免运费","extras":{},"overseaContraBandFlag":"false","addressWeexUrl":"https://market.m.taobao.com/apps/market/detailrax/address-picker.html?spm=a2116h.app.0.0.16d957e9nDYOzv&wh_weex=true"},"item":{"showShopActivitySize":"2","sellCount":"935","skuText":"请选择 付款方式 "},"traceDatas":{"dinamic+TB_detail_ask_all_two_questions":{"module":"tb_detail_ask_all_two_questions"},"dinamic+TB_detail_guarantee":{"module":"tb_detail_guarantee"},"dinamic+TB_detail_brand_info":{"module":"tb_detail_brand_info"},"dinamic+TB_detail_endorsement":{"module":"tb_detail_endorsement"},"dinamic+TB_detail_tip_presale":{"module":"tb_detail_tip_presale"},"dinamic+TB_detail_subInfo_superMarket":{"module":"tb_detail_subInfo_superMarket"},"bizTrackParams":{"aliBizCodeToken":"YWxpLmNoaW5hLnRhb2Jhby5qaXlvdWppYQ==","aliBizCode":"ali.china.taobao.jiyoujia"},"dinamic+TB_detail_ask_all_no_question":{"module":"tb_detail_ask_all_no_question"},"dinamic+TB_detail_comment_head":{"module":"tb_detail_comment_head"},"dinamic+TB_detail_kernel_params":{"module":"tb_detail_kernel_params"},"dinamic_o2o+TB_detail_o2o":{"module":"TB_detail_o2o"},"dinamic+TB_detail_subInfo_jhs_normal":{"module":"tb_detail_subInfo_jhs_normal"},"dinamic+TB_detail_new_person_bag_banner":{"module":"tb_detail_new_person_bag_banner"},"dinamic+TB_detail_title_tmallMarket":{"module":"tb_detail_title_tmallMarket"},"dinamic+TB_detail_buyer_photo":{"module":"tb_detail_buyer_photo"},"dinamic+TB_detail_subInfo_preSellForTaobaoB":{"module":"tb_detail_subInfo_preSellForTaobaoB"},"dinamic+TB_detail_title_xinxuan":{"module":"tb_detail_title_xinxuan"},"dinamic+TB_detail_trade_guarantee":{"module":"tb_detail_trade_guarantee"},"dinamic+TB_detail_subInfo_preSellForTaobaoC":{"module":"tb_detail_subInfo_preSellForTaobaoC"},"dinamic+TB_detail_tmallfeature":{"module":"tb_detail_tmallfeature"},"dinamic+TB_detail_sub_logistics":{"module":"tb_detail_sub_logistics"},"dinamic+TB_detail_price_coupon":{"module":"tb_detail_price_coupon"},"dinamic+TB_detail_comment_tag":{"module":"tb_detail_comment_tag"},"dinamic+TB_detail_coupon":{"module":"tb_detail_coupon"},"dinamic+TB_detail_tip_presale2":{"module":"tb_detail_tip_presale2"},"dinamic+TB_detail_tip_price":{"module":"tb_detail_tip_price"},"dinamic+TB_detail_delivery":{"module":"tb_detail_delivery"},"dinamic+TB_detail_ship_time":{"module":"tb_detail_ship_time"},"dinamic+TB_detail_ask_all_aliMedical":{"module":"tb_detail_ask_all_aliMedical"},"dinamic+TB_detail_priced_coupon":{"module":"tb_detail_priced_coupon"},"dinamic+TB_detail_tax":{"module":"tb_detail_tax"},"dinamic+TB_detail_comment_empty":{"module":"tb_detail_comment_empty"},"dinamic+TB_detail_comment_single_hot":{"module":"tb_detail_comment_single_hot"},"dinamic+TB_detail_logistics":{"module":"tb_detail_logistics"}},"resource":{"share":{"name":"分享","iconType":"1","params":{"iconFont":"ꄪ","iconColor":"#999999"}},"bigPromotion":{},"newBigPromotion":{},"entrances":{},"coupon":{"h5LinkUrl":"//h5.m.taobao.com/jxt/coupon-tb.html"}},"consumerProtection":{"items":[{"title":"不支持7天无理由","desc":"本商品不支持七天无理由"},{"title":"集分宝"},{"title":"支付宝支付"}],"passValue":"all"},"skuCore":{"sku2info":{"0":{"price":{"priceMoney":"1280","priceText":"12.8","type":"2"},"quantity":"554518"},"3604432292539":{"price":{"priceMoney":"1280","priceText":"12.8","type":"2"},"quantity":"554518"}},"skuItem":{"location":"北京"}},"vertical":{"askAll":{"askText":"杂音多吗，讲的怎么样","askIcon":"https://img.alicdn.com/tps/TB1tVU6PpXXXXXFaXXXXXXXXXXX-102-60.png","linkUrl":"//h5.m.taobao.com/wendajia/question2017.html?refId=566940414408","title":"问大家(5)","questNum":"5","showNum":"2","modelList":[{"askText":"杂音多吗，讲的怎么样","answerCountText":"2个回答"},{"askText":"视频是几几年的","answerCountText":"2个回答"}]}},"params":{"trackParams":{"abtest":"","layoutId":null},"aliAbTestTrackParams":{}},"layout":{},"trade":{"buyEnable":"true","cartEnable":"true","buyParam":{},"cartParam":{},"isBanSale4Oversea":"false","hintBanner":{}},"feature":{"cainiaoNoramal":"true","hasSku":"true","showSku":"true","noShareGroup":"true","superActTime":"false","newAddress":"true"},"price":{"price":{"priceMoney":"1280","priceText":"12.8","type":"2"},"extraPrices":[],"transmitPrice":{"priceText":"12.8"}},"skuVertical":{}}
        /// </summary>
        public string value { get; set; }
    }

    public class Item
    {
        /// <summary>
        /// 566940414408
        /// </summary>
        public string itemId { get; set; }
        /// <summary>
        /// 2018全套web前端开发视频培训教程HTML5 H5 CSS JS VUE node 实战
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// Images
        /// </summary>
        public List<string> images { get; set; }
        /// <summary>
        /// 124710007
        /// </summary>
        public string categoryId { get; set; }
        /// <summary>
        /// 50014927
        /// </summary>
        public string rootCategoryId { get; set; }
        /// <summary>
        /// 9349881
        /// </summary>
        public string brandValueId { get; set; }
        /// <summary>
        /// 请选择付款方式 
        /// </summary>
        public string skuText { get; set; }
        /// <summary>
        /// CountMultiple
        /// </summary>
        public List<string> countMultiple { get; set; }
        /// <summary>
        /// 365
        /// </summary>
        public string commentCount { get; set; }
        /// <summary>
        /// 380
        /// </summary>
        public string favcount { get; set; }
        /// <summary>
        /// http://h5.m.taobao.com/app/detail/desc.html?_isH5Des=true#!id=566940414408&type=0&f=TB1bFmfiRyWBuNkSmFP8qtguVla&sellerType=C
        /// </summary>
        public string taobaoDescUrl { get; set; }
        /// <summary>
        /// //mdetail.tmall.com/templates/pages/desc?id=566940414408
        /// </summary>
        public string tmallDescUrl { get; set; }
        /// <summary>
        /// http://h5.m.taobao.com/app/detail/desc.html?_isH5Des=true#!id=566940414408&type=1&f=TB1_pifiRyWBuNkSmFP8qtguVla&sellerType=C
        /// </summary>
        public string taobaoPcDescUrl { get; set; }
        /// <summary>
        /// OpenDecoration
        /// </summary>
        public bool openDecoration { get; set; }
    }

    public class TrackParams
    {
        /// <summary>
        /// 9349881
        /// </summary>
        public string brandId { get; set; }
        /// <summary>
        /// C
        /// </summary>
        public string BC_type { get; set; }
        /// <summary>
        /// 124710007
        /// </summary>
        public string categoryId { get; set; }
    }

    public class Params
    {
        /// <summary>
        /// TrackParams
        /// </summary>
        public TrackParams trackParams { get; set; }
    }

    public class 基本信息
    {
        /// <summary>
        /// 全额支付
        /// </summary>
        public string 付款方式 { get; set; }
    }

    public class GroupProps
    {
        /// <summary>
        /// 基本信息
        /// </summary>
        public List<基本信息> 基本信息 { get; set; }
    }

    public class Props
    {
        /// <summary>
        /// GroupProps
        /// </summary>
        public List<GroupProps> groupProps { get; set; }
    }

    public class Props2
    {
    }

    public class RateList
    {
        /// <summary>
        /// 转储后大概看了一下，内容很多，文件夹整理的也很有层次，还给标了序号、备注等等方便新手入门。~
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 蒙**丶
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// http://gtms03.alicdn.com/tps/i3/TB1yeWeIFXXXXX5XFXXuAZJYXXX-210-210.png_80x80.jpg
        /// </summary>
        public string headPic { get; set; }
        /// <summary>
        /// 6
        /// </summary>
        public string memberLevel { get; set; }
        /// <summary>
        /// 2018-05-26
        /// </summary>
        public DateTime dateTime { get; set; }
        /// <summary>
        /// 付款方式:全额支付
        /// </summary>
        public string skuInfo { get; set; }
        /// <summary>
        /// Images
        /// </summary>
        public List<string> images { get; set; }
        /// <summary>
        /// 3
        /// </summary>
        public string tmallMemberLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string headExtraPic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string memberIcon { get; set; }
        /// <summary>
        /// false
        /// </summary>
        public string isVip { get; set; }
    }

    public class Rate
    {
        /// <summary>
        /// 365
        /// </summary>
        public string totalCount { get; set; }
        /// <summary>
        /// RateList
        /// </summary>
        public List<RateList> rateList { get; set; }
    }

    public class AskAll
    {
        /// <summary>
        /// https://gw.alicdn.com/tps/TB1J7X6KXXXXXc4XXXXXXXXXXXX-102-60.png
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// "杂音多吗，讲的怎么样"
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// //h5.m.taobao.com/wendajia/question2017.html?refId=566940414408
        /// </summary>
        public string link { get; set; }
    }

    public class Entrances
    {
        /// <summary>
        /// AskAll
        /// </summary>
        public AskAll askAll { get; set; }
    }

    public class Resource
    {
        /// <summary>
        /// Entrances
        /// </summary>
        public Entrances entrances { get; set; }
    }

    public class Evaluates
    {
        /// <summary>
        /// 宝贝描述
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 4.9 
        /// </summary>
        public string score { get; set; }
        /// <summary>
        /// desc
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 1
        /// </summary>
        public string level { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        public string levelText { get; set; }
        /// <summary>
        /// #FF5000
        /// </summary>
        public string levelTextColor { get; set; }
        /// <summary>
        /// #FFF1EB
        /// </summary>
        public string levelBackgroundColor { get; set; }
    }

    public class Seller
    {
        /// <summary>
        /// 2564509013
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 128436588
        /// </summary>
        public string shopId { get; set; }
        /// <summary>
        /// 萌犬学技术
        /// </summary>
        public string shopName { get; set; }
        /// <summary>
        /// tmall://page.tm/shop?item_id=566940414408&shopId=128436588
        /// </summary>
        public string shopUrl { get; set; }
        /// <summary>
        /// //shop.m.taobao.com/shop/shop_index.htm?user_id=2564509013&item_id=566940414408
        /// </summary>
        public string taoShopUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shopIcon { get; set; }
        /// <summary>
        /// 66
        /// </summary>
        public string fans { get; set; }
        /// <summary>
        /// 3
        /// </summary>
        public string allItemCount { get; set; }
        /// <summary>
        /// ShowShopLinkIcon
        /// </summary>
        public bool showShopLinkIcon { get; set; }
        /// <summary>
        /// 本店共3件宝贝在热卖
        /// </summary>
        public string shopCard { get; set; }
        /// <summary>
        /// C
        /// </summary>
        public string sellerType { get; set; }
        /// <summary>
        /// C
        /// </summary>
        public string shopType { get; set; }
        /// <summary>
        /// Evaluates
        /// </summary>
        public List<Evaluates> evaluates { get; set; }
        /// <summary>
        /// len今生
        /// </summary>
        public string sellerNick { get; set; }
        /// <summary>
        /// 7
        /// </summary>
        public string creditLevel { get; set; }
        /// <summary>
        /// //gw.alicdn.com/tfs/TB1TqTMiv6H8KJjy0FjXXaXepXa-132-24.png
        /// </summary>
        public string creditLevelIcon { get; set; }
        /// <summary>
        /// 2015-08-08 16:31:05
        /// </summary>
        public DateTime starts { get; set; }
        /// <summary>
        /// 99.14%
        /// </summary>
        public string goodRatePercentage { get; set; }
    }

    public class Skus
    {
        /// <summary>
        /// 3604432292539
        /// </summary>
        public string skuId { get; set; }
        /// <summary>
        /// 14829532:72110507
        /// </summary>
        public string propPath { get; set; }
    }

    public class Values
    {
        /// <summary>
        /// 72110507
        /// </summary>
        public string vid { get; set; }
        /// <summary>
        /// 全额支付
        /// </summary>
        public string name { get; set; }
    }

  

    public class SkuBase
    {
        /// <summary>
        /// Skus
        /// </summary>
        public List<Skus> skus { get; set; }
        /// <summary>
        /// Props
        /// </summary>
        public List<Props> props { get; set; }
    }

    public class ModelList
    {
        /// <summary>
        /// 杂音多吗，讲的怎么样
        /// </summary>
        public string askText { get; set; }
        /// <summary>
        /// 2个回答
        /// </summary>
        public string answerCountText { get; set; }
    }

    public class Model4XList
    {
        /// <summary>
        /// 杂音多吗，讲的怎么样
        /// </summary>
        public string askText { get; set; }
        /// <summary>
        /// 2个回答
        /// </summary>
        public string answerCountText { get; set; }
        /// <summary>
        /// //gw.alicdn.com/tfs/TB1lneilZLJ8KJjy0FnXXcFDpXa-36-36.png
        /// </summary>
        public string askIcon { get; set; }
        /// <summary>
        /// #162B36
        /// </summary>
        public string askTextColor { get; set; }
    }

   

    public class Vertical
    {
        /// <summary>
        /// AskAll
        /// </summary>
        public AskAll askAll { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// ApiStack
        /// </summary>
        public List<ApiStack> apiStack { get; set; }
        /// <summary>
        /// Item
        /// </summary>
        public Item item { get; set; }
        /// <summary>
        /// {"delivery":{},"trade":{"buyEnable":true,"cartEnable":true},"feature":{"hasSku":true,"showSku":true},"price":{"price":{"priceText":"12.80"}},"skuCore":{"sku2info":{"0":{"price":{"priceMoney":1280,"priceText":"12.80","priceTitle":"价格"},"quantity":100},"3604432292539":{"price":{"priceMoney":1280,"priceText":"12.80","priceTitle":"价格"},"quantity":100}},"skuItem":{"hideQuantity":true}}}
        /// </summary>
        public string mockData { get; set; }
        /// <summary>
        /// Params
        /// </summary>
       // public Params params { get; set; }
    /// <summary>
    /// Props
    /// </summary>
    public Props props { get; set; }
    /// <summary>
    /// Props2
    /// </summary>
    public Props2 props2 { get; set; }
    /// <summary>
    /// Rate
    /// </summary>
    public Rate rate { get; set; }
    /// <summary>
    /// Resource
    /// </summary>
    public Resource resource { get; set; }
    /// <summary>
    /// Seller
    /// </summary>
    public Seller seller { get; set; }
    /// <summary>
    /// SkuBase
    /// </summary>
    public SkuBase skuBase { get; set; }
    /// <summary>
    /// Vertical
    /// </summary>
    public Vertical vertical { get; set; }
}

public class Root
{
    /// <summary>
    /// wdetail
    /// </summary>
    public string api { get; set; }
    /// <summary>
    /// 6.0
    /// </summary>
    public string v { get; set; }
    /// <summary>
    /// Ret
    /// </summary>
    public List<string> ret { get; set; }
    /// <summary>
    /// Data
    /// </summary>
    public Data data { get; set; }
}

}
