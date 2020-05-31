namespace Bam.Net.Application.Listeners
{
    public class WebHookResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}