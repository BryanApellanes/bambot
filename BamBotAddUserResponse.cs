using Bam.Remote.Etc;

namespace Bam.Net.Application
{
    public class BamBotAddUserResponse: BamBotResponse
    {
        public EtcUser User { get; set; }
    }
}