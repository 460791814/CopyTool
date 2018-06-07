using CopyTool.Model;
using Sszg.CommonUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        private string ConvertToSaveCellCommon(string cell)
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
    }
}
