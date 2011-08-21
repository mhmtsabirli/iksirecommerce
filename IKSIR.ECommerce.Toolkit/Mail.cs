using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace IKSIR.ECommerce.Toolkit
{
    public class Mail
    {
        public static bool sendMail(string to, string from, string subject, string body)
        {
            try
            {
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                String[] recipientList = to.TrimEnd(';').Split(';');
                foreach (String email in recipientList)
                {
                    msg.To.Add(email);
                }
                msg.From = new MailAddress(from);
                msg.Subject = subject;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.Priority = System.Net.Mail.MailPriority.High;
                msg.Body = body;

                //Add the Creddentials
                SmtpClient client = new SmtpClient();
                client.Port = Convert.ToInt32(IKSIR.ECommerce.Infrastructure.StaticData.Idevit.MailPort);
                client.Host = IKSIR.ECommerce.Infrastructure.StaticData.Idevit.MailHost;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential(IKSIR.ECommerce.Infrastructure.StaticData.Idevit.MailUserName, IKSIR.ECommerce.Infrastructure.StaticData.Idevit.MailPassword);
                client.EnableSsl = true;
                client.Send(msg);
                //client.SendAsync(msg, (object)msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}