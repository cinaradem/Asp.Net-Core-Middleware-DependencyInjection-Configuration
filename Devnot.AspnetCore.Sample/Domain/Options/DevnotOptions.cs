namespace Devnot.AspnetCore.Sample.Domain.Options
{
    public class DevnotOptions
    {
        public string Version { get; set; }
        public ExceptionOptions Exception { get; set; }
        public SearchOptions SearchEngine { get; set; }
    }
    public class ExceptionOptions
    {
        public string Provider { get; set; }
        public string MailProvider { get; set; }
    }
    public class SearchOptions
    {
        public string Provider { get; set; }
        public string MailProvider { get; set; }
        public AzureSearchOptions AzureSearch { get; set; }
    }

    public class AzureSearchOptions
    {
        public string SearchServiceName { get; set; }
        public string SearchServiceQueryApiKey { get; set; }
    }
}
