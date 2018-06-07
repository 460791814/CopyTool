using System;
namespace CopyTool.Util
{
	public class DataConvert
	{
		public static short ToShort(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return 0;
			}
			short result;
			try
			{
				result = Convert.ToInt16(o);
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public static long ToLong(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return 0L;
			}
			long result;
			try
			{
				result = Convert.ToInt64(o);
			}
			catch
			{
				result = 0L;
			}
			return result;
		}
		public static int ToInt(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return 0;
			}
			int result;
			try
			{
				result = Convert.ToInt32(o);
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public static bool ToBoolean(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return false;
			}
			string text = DataConvert.ToString(o).ToLower();
			if (text == "true" || text == "1")
			{
				return true;
			}
			bool result;
			try
			{
				bool flag = false;
				bool.TryParse(text, out flag);
				result = flag;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static double ToDouble(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return 0.0;
			}
			double result;
			try
			{
				result = Convert.ToDouble(o);
			}
			catch
			{
				result = 0.0;
			}
			return result;
		}
		public static decimal ToDecimal(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return 0m;
			}
			decimal result;
			try
			{
				result = Convert.ToDecimal(o);
			}
			catch
			{
				result = 0m;
			}
			return result;
		}
		public static string ToString(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return string.Empty;
			}
			string result;
			try
			{
				result = Convert.ToString(o);
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}
		public static DateTime ToDateTime(object o)
		{
			if (o == null || o == DBNull.Value)
			{
				return DateTime.MinValue;
			}
			DateTime result;
			try
			{
				result = Convert.ToDateTime(o);
			}
			catch
			{
				result = DateTime.MinValue;
			}
			return result;
		}
		public static int[] StrToInts(string strValue, char token)
		{
			int[] array = null;
			if (strValue != null)
			{
				string[] array2 = strValue.Split(new char[]
				{
					token
				});
				array = new int[array2.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array[i] = DataConvert.ToInt(array2[i]);
				}
			}
			return array;
		}
		public static string[] StrToStrs(string strValue, char token)
		{
			string[] array = null;
			if (strValue != null)
			{
				string[] array2 = strValue.Split(new char[]
				{
					token
				});
				array = new string[array2.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array[i] = array2[i];
				}
			}
			return array;
		}
		public static long[] StrToLongs(string strValue, char token)
		{
			long[] array = null;
			if (strValue != null)
			{
				string[] array2 = strValue.Split(new char[]
				{
					token
				});
				array = new long[array2.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array[i] = DataConvert.ToLong(array2[i]);
				}
			}
			return array;
		}
		private static string GetString(string str)
		{
			string result;
			switch (str)
			{
			case "1":
				result = "01";
				return result;
			case "2":
				result = "02";
				return result;
			case "3":
				result = "03";
				return result;
			case "4":
				result = "04";
				return result;
			case "5":
				result = "05";
				return result;
			case "6":
				result = "06";
				return result;
			case "7":
				result = "07";
				return result;
			case "8":
				result = "08";
				return result;
			case "9":
				result = "09";
				return result;
			}
			result = str;
			return result;
		}
		public static string FirstCharUpper(string strValue)
		{
			if (strValue == null)
			{
				return "";
			}
			if (strValue.Length >= 2)
			{
				return strValue.Substring(0, 1).ToUpper() + strValue.Substring(1, strValue.Length - 1);
			}
			return strValue;
		}
		public static string FirstCharLower(string strValue)
		{
			if (strValue == null)
			{
				return "";
			}
			if (strValue.Length >= 2)
			{
				return strValue.Substring(0, 1).ToLower() + strValue.Substring(1, strValue.Length - 1);
			}
			return strValue;
		}
		public static bool StrToBool(string str)
		{
			if (str == null || str.Trim().Length <= 0)
			{
				return false;
			}
			str = str.ToLower().Trim();
			if (str == "true" || str == "1")
			{
				return true;
			}
			bool result;
			try
			{
				bool flag = false;
				bool.TryParse(str, out flag);
				result = flag;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static bool StrToInt(string str, out int result)
		{
			result = 0;
			if (str == null || str.Trim().Length <= 0)
			{
				return true;
			}
			if (str.ToLower().Trim() == "true")
			{
				result = 1;
				return true;
			}
			if (str.ToLower().Trim() == "false")
			{
				result = 0;
				return true;
			}
			bool result2;
			try
			{
				if (int.TryParse(str, out result))
				{
					result2 = true;
				}
				else
				{
					result = 0;
					result2 = false;
				}
			}
			catch
			{
				result = 0;
				result2 = false;
			}
			return result2;
		}
		public static bool StrToLong(string str, out long result)
		{
			result = 0L;
			if (str == null || str.Trim().Length <= 0)
			{
				return true;
			}
			if (str.ToLower().Trim() == "true")
			{
				result = 1L;
				return true;
			}
			if (str.ToLower().Trim() == "false")
			{
				result = 0L;
				return true;
			}
			bool result2;
			try
			{
				if (long.TryParse(str, out result))
				{
					result2 = true;
				}
				else
				{
					result = 0L;
					result2 = false;
				}
			}
			catch
			{
				result = 0L;
				result2 = false;
			}
			return result2;
		}
		public static bool StrToShort(string str, out short result)
		{
			result = 0;
			if (str == null || str.Trim().Length <= 0)
			{
				return true;
			}
			if (str.ToLower().Trim() == "true")
			{
				result = 1;
				return true;
			}
			if (str.ToLower().Trim() == "false")
			{
				result = 0;
				return true;
			}
			bool result2;
			try
			{
				if (short.TryParse(str, out result))
				{
					result2 = true;
				}
				else
				{
					result = 0;
					result2 = false;
				}
			}
			catch
			{
				result = 0;
				result2 = false;
			}
			return result2;
		}
	}
}
