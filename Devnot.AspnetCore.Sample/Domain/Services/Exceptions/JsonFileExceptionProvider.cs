using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Devnot.AspnetCore.Sample.Domain.Services.Exceptions
{

    public class JsonFileExceptionProvider : IExceptionProvider
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
            Console.Write($"Json File Provider:{exception.Message}");


            var json = JsonConvert.SerializeObject(exception);

            File.WriteAllText($@"c:\temp\exception\exception_{DateTime.Now:MMddyyyy_hhss}.json", json);


        }

    }
}
