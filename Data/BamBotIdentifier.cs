using Bam.Remote.Deployment.Data;

namespace Bam.Application.Data
{
    public class BamBotIdentifier: SshHostIdentifier
    {
        public int BamBotPort { get; set; }
    }
}