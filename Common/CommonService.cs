using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;
using MyResourcesApp.Models;
using System.Net;
using System.Net.Mail;

namespace MyResourcesApp.Common
{
    public class CommonService
    {   
        //region private variables
        private readonly ApplicationContext _db;
        static string smtpAddress = "smtp.gmail.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        static string emailFromAddress = "tandinc6@gmail.com"; //Sender Email Address  
        static string password = "choden@2017"; //Sender Password  
        //endregion
        public CommonService(ApplicationContext db)
        {
            _db = db;
        }
        public bool IsPendingOrderExistsForSite(int? id)
        {
            var getSiteDetails = _db.site.Find(id);
            var getOrderDetails = _db.order.FirstOrDefault(o => o.SiteName == getSiteDetails.SiteName && o.CID == getSiteDetails.CustomerID && o.OrderStatusID == (char)OrderStatus.Pending);
            if (getOrderDetails.Equals(null)){
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void SendEmail(String emailToAddress, String subject,String body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }

    }
}
