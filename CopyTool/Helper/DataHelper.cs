using CopyTool.Util;
using Sszg.CommonUtil;
using Sszg.DataUtil;
using Sszg.ToolBox.DbEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CopyTool.Helper
{
    public class DataHelper
    {
       static Sszg.DataUtil.Session  session = new Sszg.DataUtil.Session(DbTypeEnum.SqlServerCe, "Temp File Max Size = 2048;Data source=" + @"D:\Program Files (x86)\Huatone\甩手工具箱5.03beta版\DB\toolboxdata.sdf" + ";Password = " + Encoding.UTF8.GetString(Convert.FromBase64String("bXlfTkBlVFMjaE9wMA==")) + ";Max Database Size = 2048; Max Buffer Size = 2048");
     
        public static Sys_sysSort GetSysSort(String cid)
        {
            string text = "select * from sys_sysSort where sysId=1 and keys=" + cid + " and del=0";
            DataTable dataTable = session.GetDataTable(text, null);
            return DataTableToEntity.TransDataTableToEntityList<Sys_sysSort>(dataTable)?.FirstOrDefault();
         
        }
       
        public static IList<Sys_sysProperty> GetPropertyBySortId(int sortId)
        {
            string text = "select * from sys_sysProperty where sortid={0}";
            DataTable dataTable = session.GetDataTable(text, new object[1]
            {
               sortId
            });
            return DataTableToEntity.TransDataTableToEntityList<Sys_sysProperty>(dataTable);
        }
        public static DataTable GetPropertyDtBySortId(int sortId)
        {
            string text = "select * from sys_sysProperty where sortid={0}";
            DataTable dataTable = session.GetDataTable(text, new object[1]
            {
               sortId
            });
            return dataTable;
        }
        public static DataTable GetPropertyValueDtBySortId(int sortId)
        {
            string text = "select * from sys_sysPropertyValue where sortid={0}";
            DataTable dataTable = session.GetDataTable(text, new object[1]
            {
               sortId
            });
            return dataTable;
        }
        public static Sys_sysProperty GetPropertyById(int id)
        {
            string text = "select * from sys_sysProperty where id={0}";
            DataTable dataTable = session.GetDataTable(text, new object[1]
            {
               id
            });
            return DataTableToEntity.TransDataTableToEntityList<Sys_sysProperty>(dataTable)?.FirstOrDefault();
        }

        public static IList<Sys_sysProperty> GetPropertyAllTopLevelProperty(string propertyId)
        {
            IList<Sys_sysProperty> list = new List<Sys_sysProperty>();
            while (true)
            {
                Sys_sysProperty parentPropertyEntity = GetPropertyById(DataConvert.ToInt( propertyId));
                if (parentPropertyEntity == null)
                {
                    break;
                }
                list.Add(parentPropertyEntity);
                if (parentPropertyEntity.Parentid == 0)
                {
                    break;
                }
                propertyId = DataConvert.ToString((object)parentPropertyEntity.Parentid);
            }
            return list;
        }
        public static DataTable GetSizeDetailTableByTypeCode(string typeCode, int sysId)
        {
            string sql = "select * from Sys_sizeDetail with(nolock) where sysId=" + sysId + " and GroupType='" + DbUtil.OerateSpecialChar(typeCode) + "' and del=0";
            return session.GetDataTable(sql, null);
        }
        public static Sys_sizeDetail GetSizeDetailBySizeValue(string sizeValue, string typeCode, int sysId)
        {
            DataTable sizeDetailTableByTypeCode = GetSizeDetailTableByTypeCode(typeCode, sysId);
            if (sizeDetailTableByTypeCode == null || sizeDetailTableByTypeCode.Rows.Count <= 0 || sizeDetailTableByTypeCode.Columns.Count <= 0)
            {
                return null;
            }
            DataRow[] array = sizeDetailTableByTypeCode.Select("SizeValue='" + DbUtil.OerateSpecialChar(sizeValue) + "'");
            if (array == null || array.Length <= 0)
            {
                return null;
            }
            Sys_sizeDetail sys_sizeDetail = new Sys_sizeDetail();
            foreach (DataColumn column in sizeDetailTableByTypeCode.Columns)
            {
                sys_sizeDetail.EntityCustom.SetValue(column.ColumnName, array[0][column]);
            }
            return sys_sizeDetail;
        }
        public static Sys_sizeGroup GetSizeGroupByGroupOnlineID(string typeCode, string groupOnlineID, int sysId)
        {
            return session.GetFristEntityByWhere<Sys_sizeGroup>("sysId=" + sysId + " and GroupType='" + DbUtil.OerateSpecialChar(typeCode) + "' and GroupOnlineID='" + DbUtil.OerateSpecialChar(groupOnlineID) + "' and del=0", null, true);
        }
    }
}
