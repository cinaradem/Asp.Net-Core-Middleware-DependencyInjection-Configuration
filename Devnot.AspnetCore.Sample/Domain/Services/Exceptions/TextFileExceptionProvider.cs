using System;
using System.IO;
using System.Text;

namespace Devnot.AspnetCore.Sample.Domain.Services.Exceptions
{

    public class TextFileExceptionProvider : IExceptionProvider
    {
        public void Write(Exception exception)
        {
            var strMessage = new StringBuilder();
            strMessage.AppendLine($"Message:{exception.Message}");
            strMessage.AppendLine($"StackTrace:{exception.StackTrace}");
            if (exception.InnerException != null)
            {
                strMessage.AppendLine($"Inner Message:{exception.InnerException.Message}");
                strMessage.AppendLine($"Inner StackTrace:{exception.InnerException.StackTrace}");
            }
            Console.Write($"Text File Provider:{exception.Message}");



            File.WriteAllText($@"c:\temp\exception\exception_{DateTime.Now:MMddyyyy_hhss}.txt", strMessage.ToString());

        }

    }
}
