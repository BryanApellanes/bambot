using Bam.Net.Data.Repositories;

namespace Bambot.Deployment.Data
{
    public class SshHostCredentials : CompositeKeyAuditRepoData
    {
        public virtual SshHostIdentifier SshHostIdentifier { get; set; }
        
        [CompositeKey]
        public string UserName { get; set; }
        
        public string SharedSecret { get; set; }
        
        public double JulianDate { get; set; }
    }
}