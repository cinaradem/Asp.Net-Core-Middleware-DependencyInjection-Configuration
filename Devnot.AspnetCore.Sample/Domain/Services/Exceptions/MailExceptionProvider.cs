using Devnot.AspnetCore.Sample.Domain.Services.Exceptions;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Devnot.AspnetCore.Sample.Domain.Services.Exceptions
{

    public class MailExceptionProvider : IExceptionProvider
    {
        public void Write(Exception exception)
        {
            Console.Write($"Mail Provider:{exception.Message}");

            var strMessage = new StringBuilder();
            strMessage.AppendLine($"Message:{exception.Message}");
            strMessage.AppendLine($"StackTrace:{exception.StackTrace}");
            if (exception.InnerException != null)
            {
                strMessage.AppendLine($"Inner Message:{exception.InnerException.Message}");
                strMessage.AppendLine($"Inner StackTrace:{exception.InnerException.StackTrace}");
            }
            File.WriteAllText(@"c:\temp\exception\textmessage.txt", strMessage.ToString());
            SendMail("log@devnot.com", "adem.cinar@outlook.com", "Exception", strMessage.ToString());


        }
        private bool SendMail(string from, string to, string subject, string body)
        {
            Console.WriteLine("Mail Gönderildi");
            return true;
        }
    }
}
