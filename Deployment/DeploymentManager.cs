using System;
using System.Linq;
using Renci.SshNet;

namespace Bambot.Deployment
{
    public class DeploymentManager
    {
        private DeterministicSshHostPasswordGenerator _deterministicSshHostPasswordGenerator;

        public DeploymentManager()
        {
            _deterministicSshHostPasswordGenerator = new DeterministicSshHostPasswordGenerator();
        }
        
        public void Copy(string host, FileSetDescriptor fileSetDescriptor)
        {
            Copy(new SshHostInfo(), FileSet.FromDescriptor(fileSetDescriptor));
        }

        public void Copy(SshHostInfo hostInfo, FileSet fileSet)
        {
            Copy(hostInfo.HostName, hostInfo.Port, hostInfo.UserName, hostInfo.GeneratedPassword.Show(), fileSet);
        }
        
        public void Copy(string host, int port, string userName, string password, FileSet fileSet, bool overwrite = true)
        {
            using (SftpClient sftpClient = new SftpClient(host, port, userName, password))
            {
                /*foreach()
                sftpClient.UploadFile();*/
                
                throw new NotImplementedException();
            }
        }

        protected bool FileExists(SftpClient sftpClient, string remoteFolder, string remoteFileName)
        {
            bool fileExists = sftpClient.ListDirectory(remoteFolder).Any(f =>
                f.IsRegularFile && f.Name.ToLowerInvariant().Equals(remoteFileName.ToLowerInvariant()));
            return fileExists;
        }
    }
}