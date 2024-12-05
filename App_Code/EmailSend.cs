using System;
using System.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for EmailSend
/// </summary>
public class EmailSend
{

    public EmailSend()
    {

    }

    public static void SendEmail(string mail, string body, string subject)
    {
        SmtpSection secObj = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
        try
        {
            using (MailMessage mm = new MailMessage())
            {
                mm.From = new MailAddress(secObj.Network.ClientDomain);
                mm.To.Add(mail);
                mm.Subject = subject;
                mm.Body = body;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = secObj.Network.Host;
                smtp.EnableSsl = secObj.Network.EnableSsl;
                NetworkCredential NetworkCred = new NetworkCredential(secObj.Network.UserName, secObj.Network.Password);


                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = secObj.Network.Port;
                smtp.Send(mm);
                Console.WriteLine(mm);
            }
        }
        catch (Exception ex) { }
    }
}