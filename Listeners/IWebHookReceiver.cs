using Bam.ServiceProxy;

namespace Bam.Application.Listeners
{
    public interface IWebHookReceiver
    {
        WebHookResponse ReceiveWebHook(IHttpContext context);
    }
}