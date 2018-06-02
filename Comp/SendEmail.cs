using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Comp
{
    /// <summary>
    /// 邮件发送类
    /// </summary>
    public class SendEmail
    {
        //private string subject;
        //private string[] mailTo;
        //private string body;
        private string smtpServer;
        private string user;
        private string password;
        private string sender;

        /// <summary>
        /// 初始化邮件发送类
        /// </summary>
        public SendEmail()
        {
            this.smtpServer = "smtp.163.com";
            this.user = "heimacoding@163.com";
            this.password = "sc123456";

            //this.smtpServer = "smtp.qq.com";
            //this.user = "289887416@qq.com";
            //this.password = "sc440330";
            //this.smtpServer = "smtp.gmail.com";
            //this.user = "zxxkservice@gmail.com";
            //this.password = "xueyikeji";

            this.sender = "曲水";
        }
        /// <summary>
        /// 初始化邮件发送类
        /// </summary>
        /// <param name="SMTP">SMTP地址</param>
        /// <param name="User">SMTP用户名</param>
        /// <param name="Pass">SMTP用户密码</param>
        /// <param name="Sender">发送者</param>
        public SendEmail(string SMTP, string User, string Pass, string Sender)
        {
            this.smtpServer = SMTP;
            this.user = User;
            this.password = Pass;
            this.sender = Sender;
        }

        /// <summary>
        /// 单发邮件(将邮件内容发送至一个用户)
        /// </summary>
        /// <param name="MailTo">对方邮箱地址</param>
        /// <param name="Subject">邮件标题</param>
        /// <param name="Body">邮件内容</param>
        /// <returns></returns>
        public bool Send(string MailTo, string Subject, string Body)
        {
            bool Flag = true;
            try
            {
                //string From = user + "@" + smtpServer.Substring(smtpServer.IndexOf(".") + 1);
                MailMessage mailObj = new MailMessage();
                //Add MailTo address
                mailObj.To.Add(MailTo);
                mailObj.IsBodyHtml = true;
                mailObj.Subject = Subject;
                mailObj.From = new MailAddress(user, sender, System.Text.Encoding.UTF8);
                mailObj.Body = Body;
                SmtpClient SmtpMail = new SmtpClient(smtpServer);
                SmtpMail.Credentials = new NetworkCredential(user, password);
                SmtpMail.Send(mailObj);
                SmtpMail = null;
                mailObj.Dispose();
                Flag = true;
            }
            catch(Exception e)
            {
                Flag = false;
            }
            return Flag;
        }

        /// <summary>
        /// 群发邮件(将邮件内容发送至多个用户)
        /// </summary>
        /// <param name="MailTo">对方邮箱地址(n)</param>
        /// <param name="Subject">邮件标题</param>
        /// <param name="Body">邮件内容</param>
        /// <returns></returns>
        public bool Send(string[] MailTo, string Subject, string Body)
        {
            bool Flag = true;
            try
            {
                //string From = user + "@" + smtpServer.Substring(smtpServer.IndexOf(".") + 1);
                MailMessage mailObj = new MailMessage();
                //Add MailTo address
                for (int i = 0; i < MailTo.Length; i++)
                {
                    mailObj.To.Add(MailTo[i]);
                }
                mailObj.IsBodyHtml = true;
                mailObj.Subject = Subject;
                mailObj.From = new MailAddress(user, sender, System.Text.Encoding.UTF8);
                mailObj.Body = Body;
                SmtpClient SmtpMail = new SmtpClient(smtpServer);
                SmtpMail.Credentials = new NetworkCredential(user, password);
                SmtpMail.Send(mailObj);
                SmtpMail = null;
                mailObj.Dispose();
                Flag = true;
                
            }
            catch
            {
                Flag = false;
            }
            return Flag;
        }
    }
}
