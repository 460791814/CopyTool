using NPOI.HSSF.UserModel;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.UserModel;
using NPOI.XWPF.UserModel;


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Comp
{
    public static class NPOITools
    {
        /// <summary>
        /// 将对象集合导出为Execl
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="datas">对象数据集合</param>
        public static void RenderToExcel<T>(List<T> datas,string path)
        {
            MemoryStream ms = new MemoryStream();
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("导出数据");
            IRow headerRow = sheet.CreateRow(0);
            int rowIndex = 1, piIndex = 0,cellIndex=0;
            Type type = typeof(T);
            PropertyInfo[] pis = type.GetProperties();
            //int pisLen = pis.Length - 2;//减2是多了2个外键引用  
            PropertyInfo pi = null;
            while (piIndex < pis.Length)
            {
                pi = pis[piIndex];
                string displayName = GetDisplayName(type, pi.Name);
                if (!displayName.Equals(string.Empty))
                {//如果该属性指定了DisplayName，则输出  
                    try
                    {
                        headerRow.CreateCell(cellIndex).SetCellValue(displayName);
                    }
                    catch (Exception)
                    {
                        headerRow.CreateCell(cellIndex).SetCellValue("");
                    }
                    cellIndex++;
                }
                piIndex++;
            }


            foreach (T data in datas)
            {
                piIndex = 0;
                cellIndex = 0;
                IRow dataRow = sheet.CreateRow(rowIndex);
                while (piIndex < pis.Length)
                {
                    pi = pis[piIndex];
                    string displayName = GetDisplayName(type, pi.Name);
                    if (!displayName.Equals(string.Empty))
                    {//如果该属性指定了DisplayName，则输出 
                        try
                        {
                            dataRow.CreateCell(cellIndex).SetCellValue(pi.GetValue(data, null).ToString());
                        }
                        catch (Exception)
                        {
                            dataRow.CreateCell(cellIndex).SetCellValue("");
                        }
                        cellIndex++;
                    }
                    piIndex++;
                }
                rowIndex++;
            }
            workbook.Write(ms);
            FileStream dumpFile = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            ms.WriteTo(dumpFile);
            ms.Flush();
            ms.Position = 0;
            dumpFile.Close();
        }

        /// <summary>
        /// 导出分样单
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="list">对象集合</param>
        /// <param name="filetemplatepath">模板路径</param>
        /// <param name="path">生成文件路径</param>
        public static void RenderToWord<T>(List<T> list,string filetemplatepath,string path)
        {
            using (FileStream stream = System.IO.File.OpenRead(filetemplatepath))
            {
                XWPFDocument doc = new XWPFDocument(stream);
                //遍历表格
                var table = doc.Tables[0];
                
                int tableindex = 1;
                foreach (T data in list)
                {
                    //添加更多行
                    if (table.GetRow(tableindex) == null)
                    {
                        CT_Row row = new CT_Row();
                        row.AddNewTc();
                        row.AddNewTc();
                        row.AddNewTc();
                        row.AddNewTc();
                        row.AddNewTc();
                        row.AddNewTc();
                        row.AddNewTc();
                        table.AddRow(new XWPFTableRow(row, table));
                    }
                    //填充单元格数据
                    PropertyInfo[] ps=typeof(T).GetProperties();

                    string samplenum = "", samplename="", checkprojectandstandard="", storcondition="", checkdepar="", urgentlevel="", remarks="";
                    if (ps.First(p => p.Name == "samplenum").GetValue(data, null) != null)
                        samplenum = ps.First(p => p.Name == "samplenum").GetValue(data, null).ToString();
                    if (ps.First(p => p.Name == "samplename").GetValue(data, null) != null)
                        samplename = ps.First(p => p.Name == "samplename").GetValue(data, null).ToString();
                    if (ps.First(p => p.Name == "checkprojectandstandard").GetValue(data, null) != null)
                        checkprojectandstandard = ps.First(p => p.Name == "checkprojectandstandard").GetValue(data, null).ToString();
                    if (ps.First(p => p.Name == "storcondition").GetValue(data, null) != null)
                        storcondition = ps.First(p => p.Name == "storcondition").GetValue(data, null).ToString();
                    if (ps.First(p => p.Name == "checkdepar").GetValue(data, null) != null)
                        checkdepar = ps.First(p => p.Name == "checkdepar").GetValue(data, null).ToString();
                    if (ps.First(p => p.Name == "urgentlevel").GetValue(data, null) != null)
                        urgentlevel = ps.First(p => p.Name == "urgentlevel").GetValue(data, null).ToString();
                    if (ps.First(p => p.Name == "remarks").GetValue(data, null) != null)
                        remarks = ps.First(p => p.Name == "remarks").GetValue(data, null).ToString();
                    
                    table.GetRow(tableindex).GetCell(0).SetText(samplenum);              //样品编号
                    table.GetRow(tableindex).GetCell(1).SetText(samplename);             //样品名称
                    table.GetRow(tableindex).GetCell(2).SetText(checkprojectandstandard);//检验项目及标准
                    table.GetRow(tableindex).GetCell(3).SetText(storcondition);          //存储条件
                    table.GetRow(tableindex).GetCell(4).SetText(checkdepar);             //测试部门
                    table.GetRow(tableindex).GetCell(5).SetText(urgentlevel);            //紧急程度
                    table.GetRow(tableindex).GetCell(6).SetText(remarks);                //备注

                    tableindex++;
                }
                
                //写入文件
                using (MemoryStream ms = new MemoryStream())
                {
                    doc.Write(ms);
                    FileStream dumpFile = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                    ms.WriteTo(dumpFile);
                    ms.Flush();
                    ms.Position = 0;
                    dumpFile.Close();
                }
            }
        }

        public static XWPFParagraph SetCellText(XWPFDocument doc, XWPFTable table, string setText, ParagraphAlignment align, int textPos)
        {
            CT_P para = new CT_P();
            XWPFParagraph pCell = new XWPFParagraph(para, table.Body);
            //pCell.Alignment = ParagraphAlignment.LEFT;//字体  
            pCell.Alignment = align;
            XWPFRun r1c1 = pCell.CreateRun();
            r1c1.SetText(setText);
            //r1c1.FontSize = 12;
            //r1c1.SetFontFamily("华文楷体", FontCharRange.None);//设置雅黑字体  
            //r1c1.SetTextPosition(textPos);//设置高度  
            return pCell;
        }

        /// <summary>
        /// 获取自定义属性
        /// </summary>
        /// <param name="modelType"></param>
        /// <param name="propertyDisplayName"></param>
        /// <returns></returns>
        public static string GetDisplayName(Type modelType, string propertyDisplayName)
        {
            return (System.ComponentModel.TypeDescriptor.GetProperties(modelType)[propertyDisplayName].Attributes[typeof(System.ComponentModel.DisplayNameAttribute)] as System.ComponentModel.DisplayNameAttribute).DisplayName;
        }
    }
}
