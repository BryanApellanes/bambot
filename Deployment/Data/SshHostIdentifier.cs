using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using Bam.Net;
using Bam.Net.Data.Repositories;

namespace Bambot.Deployment.Data
{
    public class SshHostIdentifier : CompositeKeyAuditRepoData
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string MacAddress { get; set; }
        
        public virtual List<SshHostCredentials> SshHostCredentials { get; set; }

        private static SshHostIdentifier _current;
        private static readonly object _currentLock = new object();
        public static SshHostIdentifier Current
        {
            get
            {
                return _currentLock.DoubleCheckLock(ref _current, () =>
                    new SshHostIdentifier
                    {
                        HostName = Bam.Net.CoreServices.ApplicationRegistration.Data.Machine.Current.Name,
                        Port = 22,
                        MacAddress = Bam.Net.CoreServices.ApplicationRegistration.Data.Machine.Current.GetFirstMac()
                    });
            }
        }
    }
}