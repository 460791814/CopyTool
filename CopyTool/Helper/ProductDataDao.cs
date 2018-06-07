using Sszg.CommonUtil;
using Sszg.DataUtil;
using Sszg.ToolBox.Common;
using Sszg.ToolBox.DbEntity;

using System;
using System.Collections.Generic;
using System.Data;

namespace Sszg.ToolBox.Dao.ToolServer
{
	internal class ProductDataDao 
	{
		private Dictionary<int, Sys_sysProperty> _cachePropertyDic = new Dictionary<int, Sys_sysProperty>();

		private IList<int> _cachePropertyIdList = new List<int>();

		private Dictionary<int, Dictionary<int, int>> _cacheSortIdToParentId = new Dictionary<int, Dictionary<int, int>>();

		private Dictionary<int, IList<int>> _cacheChildSortList = new Dictionary<int, IList<int>>();

		private static object _lockObj = new object();

		private Dictionary<int, int> GetSortIdToParentId(int sysId)
		{
			if (sysId <= 0)
			{
				return new Dictionary<int, int>();
			}
			if (_cacheSortIdToParentId.ContainsKey(sysId))
			{
				return _cacheSortIdToParentId[sysId];
			}
			lock (_lockObj)
			{
				if (_cacheSortIdToParentId.ContainsKey(sysId))
				{
					return _cacheSortIdToParentId[sysId];
				}
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				string sql = "select id,parentId from sys_sysSort with(nolock)  where sysId=" + sysId + " and del=0";
				DataTable dataTable = base.Session.GetDataTable(sql, null);
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num = DataConvert.ToInt(dataTable.Rows[i]["id"]);
					num2 = (dictionary[num] = DataConvert.ToInt(dataTable.Rows[i]["parentId"]));
					IList<int> list = new List<int>();
					if (_cacheChildSortList.ContainsKey(num2))
					{
						list = _cacheChildSortList[num2];
					}
					else
					{
						_cacheChildSortList[num2] = list;
					}
					list.Add(num);
				}
				_cacheSortIdToParentId[sysId] = dictionary;
				return dictionary;
			}
		}

		private IList<int> GetLeavesSortByParentId(int sysId, int parentId)
		{
			IList<int> result = new List<int>();
			Dictionary<int, int> sortIdToParentId = GetSortIdToParentId(sysId);
			IList<int> childSortList = GetChildSortList(parentId);
			if (childSortList != null)
			{
				GetAllChildSortList(ref result, childSortList);
			}
			return result;
		}

		private void GetAllChildSortList(ref IList<int> sortIdList, IList<int> chidSortList)
		{
			if (chidSortList != null)
			{
				for (int i = 0; i < chidSortList.Count; i++)
				{
					IList<int> childSortList = GetChildSortList(chidSortList[i]);
					if (childSortList == null || childSortList.Count <= 0)
					{
						sortIdList.Add(chidSortList[i]);
					}
					else
					{
						GetAllChildSortList(ref sortIdList, childSortList);
					}
				}
			}
		}

		private IList<int> GetChildSortList(int parentSortId)
		{
			if (_cacheChildSortList.ContainsKey(parentSortId))
			{
				return _cacheChildSortList[parentSortId];
			}
			return null;
		}

		public Sys_sysSort GetSortById(int sortId)
		{
			return base.Session.GetEntityByKey<Sys_sysSort>((object)sortId, true);
		}

		public Sys_sysSort GetSortBySysIdAndKeys(int sysId, string sortKeys)
		{
			string whereSql = "sysId={0} and keys={1} and del=0";
			object[] parms = new object[2]
			{
				sysId,
				sortKeys
			};
			return base.Session.GetFristEntityByWhere<Sys_sysSort>(whereSql, parms, true);
		}

		public IList<Sys_sysSort> GetSortsByParentId(int sysId, int parentSortId)
		{
			string whereSql = "sysId={0} and parentId={1} and del=0";
			object[] parms = new object[2]
			{
				sysId,
				parentSortId
			};
			return base.Session.GetEntityListByWhere<Sys_sysSort>(whereSql, parms, true);
		}

		public IList<Sys_sysSort> ConvertSortToOtherSys(int curSortId, int otherSysId)
		{
			Session session = base.Session;
			Sys_sysSort entityByKey = session.GetEntityByKey<Sys_sysSort>((object)curSortId, true);
			if (entityByKey == null)
			{
				return new List<Sys_sysSort>();
			}
			if (entityByKey.Sysid == otherSysId)
			{
				IList<Sys_sysSort> list = new List<Sys_sysSort>();
				list.Add(entityByKey);
				return list;
			}
			GetSortIdToParentId(otherSysId);
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
			string sql = "select distinct s.id from sys_sysSort s with(nolock) \r\n                                        inner join sys_prdSortRel r1  with(nolock)  on s.id=r1.prdSysSortId and r1.del=0\r\n                                        inner join sys_prdSortRel r2  with(nolock)  on r1.prdSortId=r2.prdSortId and r2.del=0\r\n                                        where r2.prdSysSortId={0} and r1.sysid={1}";
			object[] parms = new object[2]
			{
				curSortId,
				otherSysId
			};
			DataTable dataTable = session.GetDataTable(sql, parms);
			int num = 0;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				num = DataConvert.ToInt(dataTable.Rows[i]["id"]);
				if (_cacheChildSortList.ContainsKey(num))
				{
					dictionary2[num] = num;
				}
				else
				{
					dictionary[num] = num;
				}
			}
			sql = "select distinct s.id,r.uploadNum from sys_sysSort s  with(nolock) \r\n                            inner join sys_userSortRel r  with(nolock)  on s.id=r.sortid2 \r\n                            where r.sortid1=" + curSortId + " and s.sysid=" + otherSysId + " and s.del=0";
			dataTable = session.GetDataTable(sql, parms);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				num = DataConvert.ToInt(dataTable.Rows[i]["id"]);
				if (_cacheChildSortList.ContainsKey(num))
				{
					dictionary2[num] = num;
				}
				else
				{
					dictionary[num] = num;
				}
			}
			sql = "select s.id from sys_sysSort s  with(nolock) where s.sysid=" + otherSysId + " and s.del=0 and s.Name='" + DbUtil.OerateSpecialChar(entityByKey.Name) + "'";
			dataTable = session.GetDataTable(sql, parms);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				num = DataConvert.ToInt(dataTable.Rows[i]["id"]);
				if (_cacheChildSortList.ContainsKey(num))
				{
					dictionary2[num] = num;
				}
				else
				{
					dictionary[num] = num;
				}
			}
			string text = string.Empty;
			Dictionary<int, int>.Enumerator enumerator = dictionary.GetEnumerator();
			KeyValuePair<int, int> current;
			int num2;
			try
			{
				while (enumerator.MoveNext())
				{
					current = enumerator.Current;
					if (string.IsNullOrEmpty(text))
					{
						num2 = current.Key;
						text = num2.ToString();
					}
					else
					{
						string str = text;
						num2 = current.Key;
						text = str + "," + num2.ToString();
					}
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			enumerator = dictionary2.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					current = enumerator.Current;
					IList<int> leavesSortByParentId = GetLeavesSortByParentId(otherSysId, current.Key);
					if (leavesSortByParentId != null && leavesSortByParentId.Count > 0)
					{
						for (int i = 0; i < leavesSortByParentId.Count; i++)
						{
							if (string.IsNullOrEmpty(text))
							{
								num2 = leavesSortByParentId[i];
								text = num2.ToString();
							}
							else
							{
								string str2 = text;
								num2 = leavesSortByParentId[i];
								text = str2 + "," + num2.ToString();
							}
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			if (string.IsNullOrEmpty(text))
			{
				return new List<Sys_sysSort>();
			}
			sql = "id in (" + text + ")";
			return session.GetEntityListByWhere<Sys_sysSort>(sql, null, true);
		}

		public DataTable GetRelProperty(int curPropertyId, int otherSortId)
		{
			string sql = "select distinct sp.* from sys_sysProperty sp   with(nolock) \r\n                                inner join sys_prdPropertyRel r1   with(nolock)  on r1.sysProId=sp.id and r1.del=0\r\n                                inner join sys_prdPropertyRel r2   with(nolock)  on r1.prdProId=r2.prdProId and r2.del=0\r\n                                where r2.sysProId={0} and sp.sortId={1} and sp.del=0";
			object[] parms = new object[2]
			{
				curPropertyId,
				otherSortId
			};
			return base.Session.GetDataTable(sql, parms);
		}

		public Sys_productDefaultValue GetProductDefaultValue(int proId, string proValue)
		{
			string whereSql = "prdpropertyId={0} and prdpropertyValue={1}";
			object[] parms = new object[2]
			{
				proId,
				proValue
			};
			return base.Session.GetFristEntityByWhere<Sys_productDefaultValue>(whereSql, parms, true);
		}

		public DataTable GetPropertyValueDtBySortId(int sortId)
		{
			string whereSql = "sortId={0}";
			object[] parms = new object[1]
			{
				sortId
			};
			return base.Session.GetDataTable<Sys_sysPropertyValue>(whereSql, parms, true);
		}

		public DataTable GetPropertyDtBySortId(int sortId)
		{
			string whereSql = "sortId={0}";
			object[] parms = new object[1]
			{
				sortId
			};
			return base.Session.GetDataTable<Sys_sysProperty>(whereSql, parms, true);
		}

		public Sys_sysProperty GetPropertyById(int propertyId)
		{
			lock (_lockObj)
			{
				if (_cachePropertyDic.ContainsKey(propertyId))
				{
					return _cachePropertyDic[propertyId];
				}
				Sys_sysProperty entityByKey = base.Session.GetEntityByKey<Sys_sysProperty>((object)propertyId, true);
				if (entityByKey == null)
				{
					return null;
				}
				if (_cachePropertyIdList.Count > 100)
				{
					int key = _cachePropertyIdList[0];
					_cachePropertyIdList.RemoveAt(0);
					if (_cachePropertyDic.ContainsKey(key))
					{
						_cachePropertyDic.Remove(key);
					}
				}
				_cachePropertyIdList.Add(entityByKey.Id);
				_cachePropertyDic[entityByKey.Id] = entityByKey;
				return entityByKey;
			}
		}

		public int GetPropertyIdByProValue(string sortId, string value)
		{
			string sql = "select top(1) ssp.id from sys_sysProperty ssp   with(nolock) ,sys_sysPropertyValue sspv   with(nolock) where sspv.propertyId=ssp.id and ssp.sortId={0} and sspv.value={1}";
			object[] parms = new object[2]
			{
				sortId,
				value
			};
			return base.Session.ExecuteScalarToInt(sql, parms);
		}

		public int GetPropertyIdByProKeys(string sortId, string value, string keys)
		{
			string sql = "select top(1) ssp.id from sys_sysProperty ssp   with(nolock),sys_sysPropertyValue sspv  with(nolock) where sspv.propertyId=ssp.id and ssp.sortId={0} and sspv.value={1}  and ssp.keys={2}";
			object[] parms = new object[3]
			{
				sortId,
				value,
				keys
			};
			return base.Session.ExecuteScalarToInt(sql, parms);
		}

		public int GetPropertyIdByParentProValue(string sortId, string value, string keys, string parentPropertValue)
		{
			string sql = "select top(1) ssp.id from sys_sysProperty ssp  with(nolock),sys_sysPropertyValue sspv  with(nolock) where sspv.propertyId=ssp.id and ssp.sortId={0} \r\n                            and sspv.value={1}  and ssp.keys={2} and parentPropertyValue={3}";
			object[] parms = new object[4]
			{
				sortId,
				value,
				keys,
				parentPropertValue
			};
			return base.Session.ExecuteScalarToInt(sql, parms);
		}

		public Sys_sysPropertyValue GetPropertyValueById(int propertyValueId)
		{
			return base.Session.GetEntityByKey<Sys_sysPropertyValue>((object)propertyValueId, true);
		}

		public DataTable GetPropertyDtWithHasChildProperty(int sortId)
		{
			string sql = "select sp.id,sp.name,sp.parentId,sp.parentPropertyValue,sp.allowNull,sv.hasChildProperty\r\n                                    from sys_sysProperty sp  with(nolock) LEFT OUTER JOIN sys_sysPropertyValue sv   with(nolock)\r\n                                    ON sp.parentProValueId = sv.id\r\n                                    where sp.del=0 and sp.sortId={0}";
			object[] parms = new object[1]
			{
				sortId
			};
			return base.Session.GetDataTable(sql, parms);
		}

		public void InitialPropertyHtmlUpdateState()
		{
			string whereSql = "1=1";
			Sys_sortHtml sys_sortHtml = new Sys_sortHtml();
			sys_sortHtml.Updatestate = 0;
			base.Session.UpdateByWhere(sys_sortHtml, whereSql, null);
		}

		public Sys_sortHtml GetSortHtml(int sortId, int propertyType)
		{
			string whereSql = "sortId={0} and htmlType={1}";
			return base.Session.GetFristEntityByWhere<Sys_sortHtml>(whereSql, new object[2]
			{
				sortId,
				propertyType
			}, true);
		}

		public void InsertOrUpdateSortHtml(int sortId, int propertyType)
		{
			string whereSql = "sortId={0} and htmlType={1}";
			int firstIdByWhere = base.Session.GetFirstIdByWhere<Sys_sortHtml>(whereSql, new object[2]
			{
				sortId,
				propertyType
			});
			if (firstIdByWhere <= 0)
			{
				Sys_sortHtml sys_sortHtml = new Sys_sortHtml();
				sys_sortHtml.Sortid = sortId;
				sys_sortHtml.Htmltype = propertyType;
				sys_sortHtml.Updatestate = 1;
				sys_sortHtml.Modifytime = DateTime.Now;
				base.Session.Insert(sys_sortHtml);
			}
			else
			{
				Sys_sortHtml sys_sortHtml = new Sys_sortHtml();
				sys_sortHtml.Id = firstIdByWhere;
				sys_sortHtml.Updatestate = 1;
				sys_sortHtml.Modifytime = DateTime.Now;
				base.Session.UpdateByKey(sys_sortHtml);
			}
		}

		public string GetPropertyServiceUrl()
		{
			return AppConfig.GetConfig("AppConfig", "Url", "PropertyService");
		}

		public Sys_customProperty GetCustomProperty(int propertyId, string propertyValue)
		{
			string whereSql = "sysPropertyId={0} and propertyValue={1}";
			return base.Session.GetFristEntityByWhere<Sys_customProperty>(whereSql, new object[2]
			{
				propertyId,
				propertyValue
			}, true);
		}

		public DataTable GetSortDtBySysId(int sysId, string fieldNames)
		{
			string empty = string.Empty;
			empty = ((!string.IsNullOrEmpty(fieldNames)) ? ("select " + fieldNames + " from Sys_sysSort with(nolock) where sysId =" + sysId) : ("select * from Sys_sysSort with(nolock) where sysId =" + sysId));
			return base.Session.GetDataTable(empty, null);
		}

		public void SaveUserPropertyNameRel(IList<Sys_userPropertyNameRel> properyNameRelList)
		{
			if (properyNameRelList != null && properyNameRelList.Count > 0)
			{
				Session session = base.Session;
				IList<Sys_userPropertyNameRel> allEntity = session.GetAllEntity<Sys_userPropertyNameRel>();
				Sys_userPropertyNameRel sys_userPropertyNameRel = null;
				for (int i = 0; i < properyNameRelList.Count; i++)
				{
					sys_userPropertyNameRel = GetOldNameRel(allEntity, properyNameRelList[i].Proname1, properyNameRelList[i].Proname2);
					if (sys_userPropertyNameRel == null)
					{
						session.Insert(properyNameRelList[i]);
					}
					else
					{
						properyNameRelList[i].Id = sys_userPropertyNameRel.Id;
						properyNameRelList[i].Modifytime = DateTime.Now;
						session.UpdateByKey(properyNameRelList[i]);
					}
				}
			}
		}

		private Sys_userPropertyNameRel GetOldNameRel(IList<Sys_userPropertyNameRel> oldNameRelList, string name1, string name2)
		{
			if (oldNameRelList == null || oldNameRelList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < oldNameRelList.Count; i++)
			{
				if (oldNameRelList[i].Proname1 == name1 && oldNameRelList[i].Proname2 == name2)
				{
					return oldNameRelList[i];
				}
			}
			return null;
		}

		public DataTable GetPropertyKeyNameDt()
		{
			string sql = "select * from sys_propertyKeyName  with(nolock)";
			return base.Session.GetDataTable(sql, null);
		}

		public DataTable GetPropertyChildNameDt()
		{
			string sql = "select * from sys_propertyChildName  with(nolock)";
			return base.Session.GetDataTable(sql, null);
		}

		public DataTable GetPropertyValueChildNameDt()
		{
			string sql = "select * from sys_propertyValueChildName  with(nolock)";
			return base.Session.GetDataTable(sql, null);
		}

		public DataTable GetPropertyValueKeyNameDt()
		{
			string sql = "select * from sys_propertyValueKeyName  with(nolock)";
			return base.Session.GetDataTable(sql, null);
		}

		public DataTable GetUserPropertyNameRelDt()
		{
			string sql = "select * from sys_userPropertyNameRel  with(nolock)";
			return base.Session.GetDataTable(sql, null);
		}

		public IList<Sys_sysSort> GetSysSortListBySysId(int sysId, out IList<Sys_sysSort> parentSortList)
		{
			parentSortList = new List<Sys_sysSort>();
			IList<Sys_sysSort> entityListByWhere = base.Session.GetEntityListByWhere<Sys_sysSort>("sysid={0} and del=0 order by parentId asc", new object[1]
			{
				sysId
			}, new string[5]
			{
				"id",
				"name",
				"path",
				"sysId",
				"parentId"
			}, true);
			string sql = "select distinct parentId from sys_syssort  with(nolock) where sysid=" + sysId + " and del=0";
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			DataTable dataTable = base.Session.GetDataTable(sql, null);
			int num = 0;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				num = DataConvert.ToInt(dataTable.Rows[i]["parentId"]);
				if (num > 0)
				{
					dictionary[num] = num;
				}
			}
			int num2 = 0;
			Sys_sysSort sys_sysSort = null;
			for (int i = 0; i < entityListByWhere.Count; i++)
			{
				sys_sysSort = entityListByWhere[i];
				num2 = sys_sysSort.Id;
				if (dictionary.ContainsKey(num2))
				{
					entityListByWhere.RemoveAt(i);
					i--;
					parentSortList.Add(sys_sysSort);
				}
			}
			return entityListByWhere;
		}

		public IList<Sys_sysSort> GetChildSysSortListByParentPath(int sysId, string parentPath)
		{
			return base.Session.GetEntityListByWhere<Sys_sysSort>("sysid={0} and del=0 and path like '" + DbUtil.OerateSpecialChar(parentPath) + "%'", new object[1]
			{
				sysId
			}, new string[5]
			{
				"id",
				"name",
				"path",
				"sysId",
				"parentId"
			}, true);
		}

		public int GetMaxUploadNumFromUserSortRel(int ordiSortId, int desSortId)
		{
			string sql = "select top (1) uploadNum from sys_userSortRel  with(nolock)  where sortid1=" + ordiSortId + " and sortid2=" + desSortId + " order by uploadNum desc";
			return base.Session.ExecuteScalarToInt(sql, CommandType.Text);
		}

		public Sys_sizeGroupType GetSizeGroupTypeByTypeCode(string typeCode, int sysId)
		{
			return base.Session.GetFristEntityByWhere<Sys_sizeGroupType>("sysId=" + sysId + " and Code='" + DbUtil.OerateSpecialChar(typeCode) + "' and del=0", null, true);
		}

		public IList<Sys_sizeGroup> GetSizeGroupListByTypeCode(string typeCode, int sysId)
		{
			return base.Session.GetEntityListByWhere<Sys_sizeGroup>("sysId=" + sysId + " and GroupType='" + DbUtil.OerateSpecialChar(typeCode) + "' and del=0", null, true);
		}

		public Sys_sizeGroup GetSizeGroupByGroupOnlineID(string typeCode, string groupOnlineID, int sysId)
		{
			return base.Session.GetFristEntityByWhere<Sys_sizeGroup>("sysId=" + sysId + " and GroupType='" + DbUtil.OerateSpecialChar(typeCode) + "' and GroupOnlineID='" + DbUtil.OerateSpecialChar(groupOnlineID) + "' and del=0", null, true);
		}

		public DataTable GetSizeDetailTableByTypeCode(string typeCode, int sysId)
		{
			string sql = "select * from Sys_sizeDetail with(nolock) where sysId=" + sysId + " and GroupType='" + DbUtil.OerateSpecialChar(typeCode) + "' and del=0";
			return base.Session.GetDataTable(sql, null);
		}
	}
}
