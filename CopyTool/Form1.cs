

using CopyTool.Helper;
using CopyTool.Model;
using CopyTool.Service;
using CopyTool.Util;

using Newtonsoft.Json;
using Sszg.CommonUtil;
using Sszg.Tool.ComModule.DbEntity;
using Sszg.Tool.ComModule.Download.ViewEntity;
using Sszg.ToolBox.DbEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Top.Api.Response;
using Util;

namespace CopyTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void db()
        {
            string SqlServerCe_Conn = "Temp File Max Size = 2048;Data source=" + @"D:\Program Files (x86)\Huatone\甩手工具箱5.03beta版\Tool\SNATCH_4PLUS\DB\nsdata.sdf" + ";Password = " + Encoding.UTF8.GetString(Convert.FromBase64String("bXlfTkBlVFMjaE9wMA==")) + ";Max Database Size = 2048; Max Buffer Size = 2048";

            Sszg.DataUtil.Session session = new Sszg.DataUtil.Session(DbTypeEnum.SqlServerCe, SqlServerCe_Conn);
            //string whereSql = "sysId={0} and keys={1} and del=0";
            //object[] parms = new object[2]
            //{
            //    1,
            //    sortKeys
            //};
            //var xx= ss.GetFristEntityByWhere<Sys_sysSort>(whereSql, parms, true);
            // DataTable dataTable = ss.GetDataTable("select * from sp_item", null);
            string text = "select p.*,s.sysSortId,c.content from sp_item p left join sp_sysSort s on s.itemId=p.id left join sp_itemContent c on p.id=c.itemId where p.SszgUserName={0} and p.del=0 order by p.showurl asc";
            DataTable dataTable = session.GetDataTable(text, new object[1]
            {
                "qq460791814"
            });
           
        }
        private void btn_caiji_Click(object sender, EventArgs e)
        {
           
           CaiJiTaoBao();

        }
        private void caiji()
        {
            String url = "http://acs.m.taobao.com/h5/mtop.taobao.detail.getdetail/6.0/?data=%7B%22itemNumId%22%3A%22566940414408%22%7D";
            var html = Utils.SendWebRequest(url);
            ItemJsonEntity60 model = JsonConvert.DeserializeObject<ItemJsonEntity60>(html);
          //  ApiStackValue apiStackValue = JsonConvert.DeserializeObject<ApiStackValue>(model.data.apiStack[0].value);
            List<string[]> _outputList = new List<string[]>();
            string[] item = new string[]
                        {
                            "version 1.00"
                        };
            string[] item2 = new string[]
            {
                            "title",
                            "cid",
                            "seller_cids",
                            "stuff_status",
                            "location_state",
                            "location_city",
                            "item_type",
                            "price",
                            "auction_increment",
                            "num",
                            "valid_thru",
                            "freight_payer",
                            "post_fee",
                            "ems_fee",
                            "express_fee",
                            "has_invoice",
                            "has_warranty",
                            "approve_status",
                            "has_showcase",
                            "list_time",
                            "description",
                            "cateProps",
                            "postage_id",
                            "has_discount",
                            "modified",
                            "upload_fail_msg",
                            "picture_status",
                            "auction_point",
                            "picture",
                            "video",
                            "skuProps",
                            "inputPids",
                            "inputValues",
                            "outer_id",
                            "propAlias",
                            "auto_fill",
                            "num_id",
                            "local_cid",
                            "navigation_type",
                            "user_name",
                            "syncStatus",
                            "is_lighting_consigment",
                            "is_xinpin",
                            "foodparame",
                            "sub_stock_type",
                            "item_size",
                            "item_weight",
                            "buyareatype",
                            "global_stock_type",
                            "global_stock_country",
                            "wireless_desc",
                            "barcode",
                            "subtitle",
                            "sku_barcode",
                            "cpv_memo",
                            "input_custom_cpv",
                            "features",
                            "buyareatype",
                            "sell_promise",
                            "custom_design_flag",
                            "newprepay",
                            "qualification",
                            "add_qualification",
                            "o2o_bind_service"
            };
            var headerRow = new string[]
                    {
                        "宝贝名称",
                        "宝贝类目",
                        "店铺类目",
                        "新旧程度",
                        "省",
                        "城市",
                        "出售方式",
                        "宝贝价格",
                        "加价幅度",
                        "宝贝数量",
                        "有效期",
                        "运费承担",
                        "平邮",
                        "EMS",
                        "快递",
                        "发票",
                        "保修",
                        "放入仓库",
                        "橱窗推荐",
                        "开始时间",
                        "宝贝描述",
                        "宝贝属性",
                        "邮费模版ID",
                        "会员打折",
                        "修改时间",
                        "上传状态",
                        "图片状态",
                        "返点比例",
                        "新图片",
                        "视频",
                        "销售属性组合",
                        "用户输入ID串",
                        "用户输入名-值对",
                        "商家编码",
                        "销售属性别名",
                        "代充类型",
                        "数字ID",
                        "本地ID",
                        "宝贝分类",
                        "账户名称",
                        "宝贝状态",
                        "闪电发货",
                        "新品",
                        "食品专项",
                        "库存计数",
                        "物流体积",
                        "物流重量",
                        "采购地",
                        "库存类型",
                        "国家地区",
                        "无线详情",
                        "商品条形码",
                        "宝贝卖点",
                        "sku 条形码",
                        "属性值备注",
                        "自定义属性值",
                        "尺码库",
                        "采购地",
                        "退换货承诺",
                        "定制工具",
                        "7天退货",
                        "商品资质",
                        "增加商品资质",
                        "关联线下服务"
                    };
            _outputList.Add(item);
            _outputList.Add(item2);
            _outputList.Add(headerRow);

            ProductItem prdModel = new ProductItem();
            prdModel.Name = model.data.item.title;
            prdModel.ProductSortKeys = model.data.item.categoryId;
            prdModel.Province = null;
            prdModel.Price = 2;// DataConvert.ToDecimal(apiStackValue.price.transmitPrice.priceText);
            prdModel.Nums = 12;// DataConvert.ToInt(apiStackValue.skuCore.sku2info.info.quantity);
            prdModel.validDate = "7";
            prdModel.IsTicket = "0";
            prdModel.IsRepair = "0";
            prdModel.OnSell = "0";
            prdModel.IsRmd = "1";
            #region 获取详情
            string descUrl = "http://hws.m.taobao.com/cache/wdesc/5.0?id=566940414408&f=TB1xT81XMjN8KJjSZFC8qv3Gpla&qq-pf-to=pcqq.c2c";

            string descHtml = Utils.SendWebRequest(descUrl);
            Regex reg = new Regex("tfsContent(.*?)'(.*)',");
            if (reg.IsMatch(descHtml))
            {
                Match m = reg.Match(descHtml);

                prdModel.Content = m.Groups[2].Value;
            }
            prdModel.Code = "t" + model.data.item.itemId;
            prdModel.OnlineKey = model.data.item.itemId;
            #endregion
            prdModel.Content = "";
            _outputList.Add(new TaoBaoUtils().TaobaoPrepareCSVData(prdModel));

            WriteDicToFile(@"F:\jar\114.csv", _outputList);
        }
        protected string ConvertCell(string cellContent)
        {
            if (!string.IsNullOrEmpty(cellContent))
            {
                cellContent = cellContent.Trim();
                cellContent = cellContent.Replace("\"", "\"\"");
                return "\"" + cellContent + "\"";
            }
            return string.Empty;
        }
        private void WriteDicToFile(string fileName, List<string[]> dicList)
        {
            int num = 1;
            StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.Unicode);
            int num2 = 0;
            foreach (string[] current in dicList)
            {
                for (int i = 0; i < current.Length; i++)
                {
                    if (num2 != 0 && i != 0 && num != 1 && i != 2)
                    {
                        current[i] = this.ConvertCell(current[i]);
                    }
                }
                string value = string.Empty;
                value = string.Join("\t", current);
                streamWriter.WriteLine(value);
                num2++;
            }
            streamWriter.Flush();
            streamWriter.Close();
        }
        private void CaiJiTaoBao()
        {
            TaoBaoService taobaoService = new TaoBaoService();
            TaoBaoUtils taoBaoUtils = new TaoBaoUtils();
            ItemGetResponse itemResponse = taobaoService.GetItemGetMobileResponseByOnlinekeyNew("566940414408", 0);
            var item = itemResponse.Item;
            List<string[]> _outputList = new List<string[]>();
            _outputList.Add(new string[] { "version 1.00" });
            _outputList.Add(ConfigHelper.TaoBaoHeaderFieldRow);
            _outputList.Add(ConfigHelper.TaoBaoHeaderRow);
            ProductItem productItem = new ProductItem();
            productItem.SysId = 1;//代表淘宝
            productItem.Name = item.Title;
            productItem.ProductSortKeys = DataConvert.ToString(item.Cid);
            productItem.SortKey = productItem.ProductSortKeys;
            productItem.ActualNewOrOld = taoBaoUtils.GetItzemStuffStatus(item.StuffStatus);
            productItem.Province = item.Location.State;
            productItem.City = item.Location.City;
            if (item.Type != "fixed")
            {
                if (item.Type == "auction")
                {
                    productItem.SellType = "a";
                    productItem.SellTypeName = "拍卖";
                }
            }
            else
            {
                productItem.SellType = "b";
                productItem.SellTypeName = "一口价";
            }

            productItem.Price = DataConvert.ToDecimal(item.Price);
            productItem.PriceRise = DataConvert.ToDecimal(item.Increment);
            productItem.Nums = DataConvert.ToInt(item.Num);
            productItem.validDate = DataConvert.ToString(item.ValidThru);
            productItem.ShipWay = (item.FreightPayer == "seller" ? "1" : "2");

            productItem.ActualShipSlow = item.PostFee;
            productItem.ActualShipEMS = item.EmsFee;
            productItem.ActualShipFast = item.ExpressFee;
            productItem.IsTicket = (item.HasInvoice ? "1" : "0");
            productItem.IsRepair = (item.HasWarranty ? "1" : "0");
            productItem.OnSell = item.ApproveStatus == "onsale" ? "1" : "2";
            productItem.IsRmd = DataConvert.ToString(item.HasShowcase);
            productItem.ActualOnSellDate = DataConvert.ToDateTime(item.ListTime).ToString("yyyy-MM-dd HH:mm:ss").Replace("/", "-");
            productItem.Content = item.Desc;
            Dictionary<string, SellProInfo> dictParam = new Dictionary<string, SellProInfo>();
            string empty = string.Empty;
            int sortId = DataHelper.GetSysSort(productItem.ProductSortKeys).Id;
          var propertyList =  taoBaoUtils.SetspPropertyList(item, sortId, out dictParam, out empty);
            foreach (Sp_property prop_item in propertyList)
            {
                prop_item.SysProperty = DataHelper.GetPropertyById(prop_item.Propertyid);
            }
            //里面给productItem.PropertyValue，productItem.UserInputPropIDs,productItem.UserInputPropValues，productItem.Features赋值了
            taoBaoUtils.HandleProperty( productItem, propertyList);

            //productItem.ActualShipTpl
            productItem.Discount = DataConvert.ToString(item.HasDiscount);
            //productItem.Photo
            //productItem.SellProperty

            productItem.Code = taoBaoUtils.GetCode(item.PropsName, item.OuterId);
            //productItem.CustomProperty
            productItem.OnlineKey = DataConvert.ToString(item.NumIid);
            productItem.SszgUserName = "";
            productItem.FoodParame = taoBaoUtils.GetFoodParame(item);
            productItem.SubStock = DataConvert.ToString(item.SubStock);
            if (!string.IsNullOrEmpty(item.ItemSize))
            {
                if (item.ItemSize.StartsWith("bulk:"))
                {
                    productItem.ItemSize = item.ItemSize;
                }
                else
                {
                    productItem.ItemSize = "bulk:" + item.ItemSize;
                }
            }

            productItem.ItemWeight = item.ItemWeight;
            productItem.Wirelessdesc = item.WirelessDesc;
            productItem.Barcode = item.Barcode;
            bool IsSnatchSellPoint = false;
            if (IsSnatchSellPoint)
            {
                string empty2 = Utils.SendWebRequest(productItem.DetailUrl);
                string sellPoint = taoBaoUtils.GetItemSellPoint(empty2);
                if (!string.IsNullOrEmpty(sellPoint))
                {
                    sellPoint = sellPoint.Trim();
                    productItem.SellPoint = ((sellPoint.Length > 150) ? sellPoint.Substring(0, 150) : sellPoint);
                }
            }
               
           
            //productItem.SkuBarcode
            //productItem.CpvMemo
            //productItem.InputCustomCpv


            productItem.OperateTypes = taoBaoUtils.GetOperateTypes(item.DetailUrl);


            _outputList.Add(taoBaoUtils.TaobaoPrepareCSVData(productItem));
            taoBaoUtils.WriteDicToFile(@"F:\jar\113.csv", _outputList);
        }

      
    }
}
