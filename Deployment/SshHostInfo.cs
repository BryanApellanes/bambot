using Bam.Net;
using Bam.Net.CoreServices.ApplicationRegistration.Data;

namespace Bambot.Deployment
{
    public class SshHostInfo
    {
        public SshHostInfo()
        {
            UserName = "bambot";
            HostName = Machine.Current.Name;
            Port = 22;
        }

        public SshHostInfo(string hostName, int port = 22)
        {
            HostName = hostName;
            Port = port;
        }
        
        public string HostName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public GeneratedPassword GeneratedPassword { get; set; }

        public static SshHostInfo For(string hostName)
        {
            return new SshHostInfo
            {
                HostName =  hostName
            };
        }
    }
}