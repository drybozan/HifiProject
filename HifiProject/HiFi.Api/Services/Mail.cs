using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MainProject.Scripts
{
    public class Mail
    {
        public void sendMail(string mailAdres, string baslik, string mesaj)
        {
            SmtpClient client = new SmtpClient();
            MailMessage msg = new MailMessage();
            msg.IsBodyHtml = true;
            msg.To.Add(mailAdres);
            msg.From = new MailAddress("yenimailbdo@yandex.com");
            msg.Subject = baslik;
            msg.Body += mesaj;
            msg.CC.Add(mailAdres);
            NetworkCredential info = new NetworkCredential("yenimailbdo@yandex.com", "skmvvvrjakcsdosc");
            client.Port = 587;
            client.Host = "smtp.yandex.com.tr";
            client.EnableSsl = true;
            client.Credentials = info;
            client.Send(msg);
        }
    }
}