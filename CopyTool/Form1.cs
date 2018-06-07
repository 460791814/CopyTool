

using CopyTool.Helper;
using CopyTool.Model;
using CopyTool.Service;
using CopyTool.Util;

using Newtonsoft.Json;
using Sszg.CommonUtil;
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

        private void CaiJiTaoBao()
        {
            TaoBaoService taobaoService = new TaoBaoService();
            ItemGetResponse itemResponse = taobaoService.GetItemGetMobileResponseByOnlinekeyNew("566940414408", 1);
            var item = itemResponse.Item;
            List<string[]> _outputList = new List<string[]>();
            _outputList.Add(new string[] { "version 1.00" });
            _outputList.Add(ConfigHelper.TaoBaoHeaderRow);
            _outputList.Add(ConfigHelper.TaoBaoHeaderFieldRow);
            ProductItem productItem = new ProductItem();
            productItem.Name = item.Title;
            productItem.ProductSortKeys = DataConvert.ToString(item.Cid);
            //productItem.ActualNewOrOld
            productItem.Province = item.Location.State;
            productItem.City = item.Location.City;
            //productItem.SellType
            //prdModel.Price = DataConvert.ToDecimal(apiStackValue.price.transmitPrice.priceText);
            //productItem.PriceRise
            //prdModel.Nums = DataConvert.ToInt(apiStackValue.skuCore.sku2info.info.quantity);
            //productItem.validDate
            //productItem.ShipWay
            //productItem.ActualShipSlow;
            //productItem.ActualShipEMS;
            //productItem.ActualShipFast;
            //productItem.IsTicket
            //productItem.IsRepair
            //productItem.OnSell
            //productItem.IsRmd
            //productItem.ActualOnSellDate
            //productItem.Content
            //productItem.PropertyValue
            //productItem.ActualShipTpl
            //productItem.Discount  //23
            //productItem.Photo
            //productItem.SellProperty
            //productItem.UserInputPropIDs
            //productItem.UserInputPropValues
            //productItem.Code
            //productItem.CustomProperty
            // productItem.OnlineKey
            productItem.SszgUserName = "";
            //productItem.FoodParame
            //productItem.SubStock
            //productItem.ItemSize
            // productItem.ItemWeight
            //productItem.Wirelessdesc
            //productItem.Barcode
            //productItem.SellPoint
            //productItem.SkuBarcode
            //productItem.CpvMemo
            //productItem.InputCustomCpv
            //productItem.Features
            //productItem.OperateTypes
            TaoBaoUtils taoBaoUtils = new TaoBaoUtils();
            _outputList.Add(taoBaoUtils.TaobaoPrepareCSVData(productItem));
            taoBaoUtils.WriteDicToFile(@"C:\Users\songchao\Desktop\淘宝\113.csv", _outputList);
        }

      
    }
}
