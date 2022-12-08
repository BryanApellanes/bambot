using Bam.Remote.Deployment.Data;

namespace Bam.Net.Application.Data
{
    public class BamBotIdentifier: SshHostIdentifier
    {
        public int BamBotPort { get; set; }
    }
}