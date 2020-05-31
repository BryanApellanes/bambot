using System;
using System.Linq;
using Bam.Net;
using Bam.Net.Logging;
using Bam.Net.Testing;
using Bambot.Etc;
using Renci.SshNet;

namespace Bambot.Deployment
{
    public class SshRemoteHost : CommandLineTestInterface, IRemoteSshHost
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string LoginUserName { get; set; }
        public string LoginPassword { get; set; }

        public string[] ListUsers()
        {
            string etcPasswdContent = Execute("cat /etc/passwd");
            PasswdEntry[] etcPasswdEntries = PasswdEntry.Parse(etcPasswdContent);
            return etcPasswdEntries.Select(pwd=> pwd.UserName).ToArray();
        }

        public bool AddUser(string userName, string password)
        {
            try
            {
                string output = AddUser(HostName, Port, LoginUserName, LoginPassword, userName, password);
                Log.Info("{0}:{1}:{2}: {3}", nameof(SshRemoteHost), HostName, nameof(AddUser), output);
                return true;
            }
            catch (Exception ex)
            {
                Log.Warn("Exception adding user to {0}: {1}", HostName, ex.Message);
                return false;
            }
        }

        public bool DeleteUser(string userName)
        {
            try
            {
                string output = DeleteUser(HostName, Port, LoginUserName, LoginPassword, userName);
                Log.Info("{0}:{1}:{2}: {3}", nameof(SshRemoteHost), HostName, nameof(AddUser), output);
            }
            catch (Exception ex)
            {
                Log.Warn("Exception deleting user to {0}: {1}", HostName, ex.Message);
                return false;
            }

            return true;
        }

        public string[] ListGroups()
        {
            throw new NotImplementedException();
        }
        
        public bool DeleteGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public string Execute(string command)
        {
            return Execute(HostName, Port, LoginUserName, LoginPassword, command);
        }

        public bool Upload(string localFilePath, string remoteFilePath)
        {
            throw new NotImplementedException();
        }

        public bool Download(string remoteFilePath, string localFilePath)
        {
            throw new NotImplementedException();
        }
        
        public string DeleteUser(string hostName, int port, string loginUserName, string loginPassword,
            string userNameToDelete)
        {
            return Execute(hostName, port, loginUserName, loginPassword, $"userdel {loginUserName}");
        }
        
        public string AddUser(string hostName, int port, string loginUserName, string loginPassword,
            string newUserName, string newUserPassword)
        {
            // TODO: fix this implementation to modify files directly or set sudo to not require password on the host or both
            return Execute(hostName, port, loginUserName, loginPassword,
                $"useradd {newUserName}; echo -e \"{newUserPassword}\n{newUserPassword}\" | passwd {newUserName}");
        }
        
        public string[] ListNetworkInterfaces(string hostName, int port, string userName, string password)
        {
            return Execute(hostName, port, userName, password, "ls /sys/class/net").DelimitSplit(" ");
        }
        
        public string GetMacAddress(string hostName, int port, string userName, string password, string interfaceName = "eth0")
        {
            return Execute(hostName, port, userName, password, $"cat /sys/class/net/{interfaceName}/address");
        }
        
        public static string Execute(string hostName, int port, string userName, string password, string command)
        {
            using (SshClient sshClient = new SshClient(hostName, port, userName, password))
            {
                sshClient.Connect();
                SshCommand sshCommand = sshClient.RunCommand(command);
                return sshCommand.Result;
            }
        }
    }
}