using CopyTool.Model;
using Sszg.CommonUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Top.Api.Domain;
using Util;

namespace CopyTool.Util
{
   public class TaoBaoUtils
    {
        public string[] TaobaoPrepareCSVData(ProductItem productItem)
        {
            string[] array = new string[64];
            if (Encoding.Default.GetByteCount(productItem.Name) > 60)
            {
                string[] array2 = productItem.Name.Split(new string[]
                {
                    " "
                }, StringSplitOptions.RemoveEmptyEntries);
                string text = string.Empty;
                if (array2 != null && array2.Length > 0)
                {
                    for (int i = 0; i < array2.Length; i++)
                    {
                        string text2 = array2[i];
                        string text3 = text2;
                        if (text2.StartsWith("【") && text2.IndexOf("】") > 0)
                        {
                            text3 = text2.Substring(text2.IndexOf("】") + 1);
                        }
                        if (Encoding.Default.GetByteCount(text + text3) < 60)
                        {
                            text = text + " " + text3;
                        }
                        else
                        {
                            if (Encoding.Default.GetByteCount(text + text3) == 60)
                            {
                                text += text3;
                            }
                            else
                            {
                                text += text3;
                                //string userConfig = ToolServer.get_ConfigData().GetUserConfig("AppConfig", "DefaultConfig", "ThisToolName", "");
                                //if (!(userConfig == "SNATCHJD"))
                                //{
                                //    text = Encoding.Default.GetString(Encoding.Default.GetBytes(text), 0, 60);
                                //    break;
                                //}
                                //if (DataConvert.ToBoolean(ToolServer.get_ConfigData().GetUserConfig("AppConfig", "SNATCHJD", "SourceItemName", "false")))
                                //{
                                //    text = Encoding.Default.GetString(Encoding.Default.GetBytes(text), 0, 60);
                                //    break;
                                //}
                            }
                        }
                    }
                    productItem.Name = text.TrimEnd(new char[]
                    {
                        '?'
                    });
                }
            }
            array[0] = this.ConvertToSaveCellCommon(productItem.Name);
            array[1] = productItem.ProductSortKeys;
            array[2] = "\"" + string.Empty + "\"";
            array[3] = (string.IsNullOrEmpty(productItem.ActualNewOrOld) ? string.Empty : productItem.ActualNewOrOld.Trim());
            array[4] = (string.IsNullOrEmpty(productItem.Province) ? ("\"" + string.Empty + "\"") : ("\"" + productItem.Province.Trim() + "\""));
            array[5] = (string.IsNullOrEmpty(productItem.City) ? ("\"" + string.Empty + "\"") : ("\"" + productItem.City.Trim() + "\""));
            string text4 = string.IsNullOrEmpty(productItem.SellType) ? string.Empty : productItem.SellType.Trim();
            if (text4.Equals("b"))
            {
                array[6] = "1";
            }
            else
            {
                if (text4.Equals("a"))
                {
                    array[6] = "2";
                }
            }
            array[7] = DataConvert.ToString(productItem.Price);
            array[8] = DataConvert.ToString(productItem.PriceRise);
            array[9] = DataConvert.ToString(productItem.Nums);
            array[10] = (string.IsNullOrEmpty(productItem.validDate) ? string.Empty : productItem.validDate.Trim());
            array[11] = (string.IsNullOrEmpty(productItem.ShipWay) ? string.Empty : productItem.ShipWay.Trim());
            array[12] = productItem.ActualShipSlow;
            array[13] = productItem.ActualShipEMS;
            array[14] = productItem.ActualShipFast;
            array[15] = (string.IsNullOrEmpty(productItem.IsTicket) ? string.Empty : productItem.IsTicket.Trim());
            array[16] = (string.IsNullOrEmpty(productItem.IsRepair) ? string.Empty : productItem.IsRepair.Trim());
            array[17] = productItem.OnSell;
            if (string.IsNullOrEmpty(productItem.IsRmd))
            {
                array[18] = "0";
            }
            else
            {
                array[18] = DataConvert.ToString(DataConvert.ToInt(DataConvert.ToBoolean(productItem.IsRmd.ToLower())));
            }
            array[19] = this.ConvertToSaveCellCommon(productItem.ActualOnSellDate);
            productItem.Content = this.ClearVedio(productItem.Content);
            array[20] = this.ConvertToSaveCell(productItem.Content);
            array[21] = this.ConvertToSaveCellCommon(productItem.PropertyValue);
            array[22] = productItem.ActualShipTpl;
            string discount = productItem.Discount;
            array[23] = (DataConvert.ToBoolean(discount) ? "1" : "0");
            array[24] = "\"\"";
            array[25] = "200";
            array[26] = "";
            array[27] = "0";
            array[28] = this.ConvertToSaveCellCommon(productItem.Photo);
            array[29] = "\"\"";
            array[30] = this.ConvertToSaveCellCommon(productItem.SellProperty);
            array[31] = this.ConvertToSaveCellCommon(productItem.UserInputPropIDs);
            array[32] = this.ConvertToSaveCellCommon(productItem.UserInputPropValues);
            array[33] = this.ConvertToSaveCellCommon(productItem.Code);
            array[34] = this.ConvertToSaveCellCommon(productItem.CustomProperty);
            array[35] = "0";
            array[36] = productItem.OnlineKey;
            array[37] = "0";
            array[38] = "";
            array[39] = DataConvert.ToString(productItem.SszgUserName);
            array[40] = "0";
            array[41] = "0";
            array[42] = "0";
            array[43] = this.ConvertToSaveCell(productItem.FoodParame);
            array[44] = productItem.SubStock;
            array[45] = productItem.ItemSize;
            array[46] = productItem.ItemWeight;
            array[47] = "0";
            array[48] = "-1";
            array[49] = string.Empty;
            array[50] = this.ConvertToSaveCell(productItem.Wirelessdesc);
            array[51] = productItem.Barcode;
            array[52] = this.ConvertToSaveCell(productItem.SellPoint);
            array[53] = productItem.SkuBarcode;
            array[54] = this.ConvertToSaveCellCommon(productItem.CpvMemo);
            array[55] = this.ConvertToSaveCellCommon(productItem.InputCustomCpv);
            array[56] = productItem.Features;
            array[61] = productItem.OperateTypes;
            array[62] = "0";
            return array;
        }

        internal string GetOperateTypes(string detailUrl)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(detailUrl))
            {
                string content = Utils.SendWebRequest(detailUrl);
                string operateTypes = GetNumber3c(content);
                string stringToEscape = "{\"bathrobe_field_tag_image_1\" : \"\", \"bathrobe_field_tag_image_2\" : \"\",\"var_item_board_inspection_report\" : \"\",\"var_item_glove_inspection_report_1\" : \"\",\"var_item_light_inspection_report_2\" : \"\",\"var_org_auth_tri_c_code\" : \"" + operateTypes + "\",\"var_tri_c_cer_image\" : \"\", \"var_tri_c_cer_image_2\" : \"\" }";
                result = Uri.EscapeDataString(stringToEscape);
            }
            return result;
        }

        internal string GetFoodParame(Item item)
        {
           // StringBuilder sb = new StringBuilder();
            string text = string.Empty;
            if (item != null && item.FoodSecurity != null)
            {
                FoodSecurity foodSecurityByItemId = item.FoodSecurity;
               
                if (!string.IsNullOrEmpty(foodSecurityByItemId.Contact))
                {
                    text = text + "contact:" + foodSecurityByItemId.Contact + ";";
                }
                if (!string.IsNullOrEmpty(foodSecurityByItemId.DesignCode))
                {
                    text = text + "design_code:" + foodSecurityByItemId.DesignCode + ";";
                }
                if (!string.IsNullOrEmpty(foodSecurityByItemId.Factory))
                {
                    text = text + "factory:" + foodSecurityByItemId.Factory + ";";
                }
                if (!string.IsNullOrEmpty(foodSecurityByItemId.FactorySite))
                {
                    text = text + "factory_site:" + foodSecurityByItemId.FactorySite + ";";
                }
                if (!string.IsNullOrEmpty(foodSecurityByItemId.FoodAdditive))
                {
                    text = text + "food_additive:" + foodSecurityByItemId.FoodAdditive + ";";
                }
                if (!string.IsNullOrEmpty(foodSecurityByItemId.Mix))
                {
                    text = text + "mix:" + foodSecurityByItemId.Mix + ";";
                }
                if (!string.IsNullOrEmpty(foodSecurityByItemId.Period))
                {
                    text = text + "period:" + foodSecurityByItemId.Period + ";";
                }
                if (!string.IsNullOrEmpty(foodSecurityByItemId.PlanStorage))
                {
                    text = text + "plan_storage:" + foodSecurityByItemId.PlanStorage + ";";
                }
                if (!string.IsNullOrEmpty(foodSecurityByItemId.PrdLicenseNo))
                {
                    text = text + "prd_license_no:" + foodSecurityByItemId.PrdLicenseNo + ";";
                }
                if (!string.IsNullOrEmpty(foodSecurityByItemId.HealthProductNo))
                {
                    text = text + "health_product_no:" + foodSecurityByItemId.HealthProductNo + ";";
                }
                if (!string.IsNullOrEmpty(DataConvert.ToString((object)foodSecurityByItemId.ProductDateEnd)))
                {
                    text = text + "product_date_end:" + foodSecurityByItemId.ProductDateEnd + ";";
                }
                if (!string.IsNullOrEmpty(DataConvert.ToString((object)foodSecurityByItemId.ProductDateStart)))
                {
                    text = text + "product_date_start:" + foodSecurityByItemId.ProductDateStart + ";";
                }
                if (!string.IsNullOrEmpty(DataConvert.ToString((object)foodSecurityByItemId.StockDateEnd)))
                {
                    text = text + "stock_date_end:" + foodSecurityByItemId.StockDateEnd + ";";
                }
                if (!string.IsNullOrEmpty(DataConvert.ToString((object)foodSecurityByItemId.StockDateStart)))
                {
                    text = text + "stock_date_start:" + foodSecurityByItemId.StockDateStart + ";";
                }
                if (!string.IsNullOrEmpty(foodSecurityByItemId.Supplier))
                {
                    text = text + "supplier:" + foodSecurityByItemId.Supplier + ";";
                }
                if (!string.IsNullOrEmpty(text))
                {
                    text = text.TrimEnd(';');
                }
      
            }
            return text;
        }

        public string ConvertToSaveCellCommon(string cell)
        {
            if (string.IsNullOrEmpty(cell))
            {
                return "\"" + string.Empty + "\"";
            }
            cell = cell.Replace("\"", "");
            return "\"" + cell + "\"";
        }
        protected string ConvertToSaveCell(string cell)
        {
            if (string.IsNullOrEmpty(cell))
            {
                return "\"" + string.Empty + "\"";
            }
            cell = cell.Replace("\"", "\"\"");
            cell = cell.Replace("\u00a0", "&nbsp;");
            cell = cell.Replace("\r\n", "");
            return "\"" + cell + "\"";
        }
        private string ClearVedio(string content)
        {
            Regex regex = new Regex("(?is)<EMBED[^<>]*video.taobao[^<>]*>\\s*?</EMBED>|(?is)<EMBED[^<>]*video.taobao[^<>]*>");
            return regex.Replace(content, string.Empty);
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
        public void WriteDicToFile(string fileName, List<string[]> dicList)
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

        public string GetItzemStuffStatus(string stuffStatus)
        {
            switch (stuffStatus)
            {
                case "new":
                    return "5";
                case "unused":
                    return "8";
                case "second":
                    return "6";
                default:
                    return string.Empty;
            }
        }

        public string GetCode(string propsName,string outerId) {
           
           string text = propsName;
          
            if (!string.IsNullOrEmpty(text) && text.IndexOf("货号") >= 0)
            {
                int num = text.IndexOf("货号");
                if (num + 3 < text.Length)
                {
                    text = text.Substring(num + 3);
                }
                num = text.IndexOf(';');
                if (num > 0)
                {
                    text = text.Substring(0, text.IndexOf(';'));
                }
                if (text.Length > 20)
                {
                    text = text.Substring(0, 20);
                }
                 
            }
            else
            {
                text = outerId;
            }
            return text;
        }
        public string GetNumber3c(string downloadResponseContent)
        {
            string text = string.Empty;
            if (string.IsNullOrEmpty(downloadResponseContent))
            {
                return text;
            }
            string pattern = "<li\\s*title=\"?(?<number3c>[^>]*?)\"?\\s*>.*?证书编号.*?[^<]*?</li>";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(downloadResponseContent);
            if (match != null && match.Success && !string.IsNullOrEmpty(match.Groups["number3c"].Value))
            {
                text = match.Groups["number3c"].Value;
            }
            if (string.IsNullOrEmpty(text))
            {
                string pattern2 = "baike.taobao.com/view.htm?[^\"]*?wd=(?<number3c>\\d*)[^\"]*?\"";
                regex = new Regex(pattern2);
                match = regex.Match(downloadResponseContent);
                if (match != null && match.Success && !string.IsNullOrEmpty(match.Groups["number3c"].Value))
                {
                    text = match.Groups["number3c"].Value;
                }
            }
            return text;
        }
    }
}
