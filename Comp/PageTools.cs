using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp
{
    /// <summary>
    /// 页面工具
    /// </summary>
    public static class PageTools
    {
        /// <summary>
        /// 获取图片真实路径
        /// </summary>
        public static string GetImgPath(string ImgPath)
        {
            //需要依据配置动态获取
            if (string.IsNullOrEmpty(ImgPath))
            {
                return "";
            }
            else
            {
                return ImgPath.Replace("{%uploaddir%}", $"{Utils.GetConfig("manage")}/upimg/");
            }
        }

        /// <summary>
        /// 生成订单编号（下单渠道1位+时间信息4位+下单时间的Unix时间戳后8位（加上随机码随机后的数字）+用户user id后4位）
        /// </summary>
        /// <returns>新生成的订单编号</returns>
        public static string NewOrderNo(int channel, int userid)
        {
            StringBuilder orderno = new StringBuilder();
            orderno.Append(channel.ToString("00"));
            orderno.Append(DateTime.Now.ToString("MMdd"));
            var sjc = ConvertDateTimeToInt(DateTime.Now).ToString();
            orderno.Append(sjc.Substring(sjc.Length - 8, 8));
            orderno.Append(userid.ToString("0000"));
            return orderno.ToString();
        }

        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }

    }
}
