using Bam.Net.Services.Automation;
using Bam.Remote.Etc;

namespace Bam.Net.Application
{
    public class BamBot: IEtcCredentialManager
    {
        public IEtcCredentialManager EtcCredentialManager { get; set; }
        public CommandService CommandService { get; set; }

        [Exclude]
        public EtcUser AddUser(string userName, string password)
        {
            return EtcCredentialManager.AddUser(userName, password);
        }

        public BamBotAddUserResponse AddUser(BamBotAddUserRequest request)
        {
            EtcUser user = AddUser(request.UserName, request.Password);
            return new BamBotAddUserResponse
            {
                User = user
            };
        }
        
        [Exclude]
        public EtcUser SetPassword(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public BamBotAddUserResponse SetPassword(BamBotAddUserRequest request)
        {
            EtcUser user = SetPassword(request.UserName, request.Password);
            return new BamBotAddUserResponse
            {
                User = user
            };
        }
        
        [Exclude]
        public EtcGroup AddGroup(string groupName, params string[] members)
        {
            throw new System.NotImplementedException();
        }

        [Exclude]
        public EtcGroup AddGroupMember(string groupName, string member)
        {
            throw new System.NotImplementedException();
        }

        [Exclude]
        public EtcGroup AddGroupMembers(string groupName, params string[] members)
        {
            throw new System.NotImplementedException();
        }

        [Exclude]
        public bool UserExists(string userName)
        {
            throw new System.NotImplementedException();
        }

        [Exclude]
        public bool GroupExists(string groupName)
        {
            throw new System.NotImplementedException();
        }
    }
}