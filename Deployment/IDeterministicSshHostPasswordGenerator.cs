using Bam.Net;
using Bambot.Deployment.Data;

namespace Bambot.Deployment
{
    public interface IDeterministicSshHostPasswordGenerator
    {
        GeneratedPassword Generate(SshHostIdentifier sshHostIdentifier, double? julianDate = null);
    }
}