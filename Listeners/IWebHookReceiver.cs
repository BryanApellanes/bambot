using Bam.Net.ServiceProxy;

namespace Bam.Net.Application.Listeners
{
    public interface IWebHookReceiver
    {
        WebHookResponse ReceiveWebHook(IHttpContext context);
    }
}