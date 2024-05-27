using System;
using Bam.Services;
//using Bam.Services.Automation;
using Bam.Remote.Etc;

namespace Bam.Application
{
    [Proxy("bambot")]
    public class BamBot//: DeployableCommandLineTool, IEtcCredentialManager
    {
        public BamBot(IEtcCredentialManager etcCredentialManager = null)
        {
            EtcCredentialManager = etcCredentialManager ?? new EtcCredentialManager();
        }
        
        protected IEtcCredentialManager EtcCredentialManager { get; set; }
/*        
        [Inject]
        public CommandService CommandService { get; set; }*/

        [Exclude]
        public EtcUser AddUser(string userName, string password)
        {
            return EtcCredentialManager.AddUser(userName, password);
        }

        public BamBotAddUserResponse AddUser(BamBotAddUserRequest request)
        {
            try
            {
                EtcUser user = AddUser(request.UserName, request.Password);
                return new BamBotAddUserResponse(user);
            }
            catch (Exception ex)
            {
                return new BamBotAddUserResponse(ex);
            }
        }
        
        [Exclude]
        public EtcUser SetPassword(string userName, string password)
        {
            return EtcCredentialManager.SetPassword(userName, password);
        }

        public BamBotSetPasswordResponse SetPassword(BamBotSetPasswordRequest request)
        {
            try
            {
                EtcUser user = SetPassword(request.UserName, request.Password);
                return new BamBotSetPasswordResponse(user);
            }
            catch (Exception ex)
            {
                return new BamBotSetPasswordResponse(ex);
            }
        }

        [Exclude]
        public EtcGroup AddGroup(string groupName, params string[] members)
        {
            return EtcCredentialManager.AddGroup(groupName, members);
        }

        public BamBotAddGroupResponse AddGroup(BamBotAddGroupRequest request)
        {
            try
            {
                EtcGroup group = AddGroup(request.GroupName, request.Members);
                return new BamBotAddGroupResponse(group);
            }
            catch (Exception ex)
            {
                return new BamBotAddGroupResponse(ex);
            }
        }

        [Exclude]
        public EtcGroup AddGroupMember(string groupName, string member)
        {
            return EtcCredentialManager.AddGroupMember(groupName, member);
        }

        public BamBotAddGroupMemberResponse AddGroupMember(BamBotAddGroupMemberRequest request)
        {
            try
            {
                EtcGroup group = AddGroupMember(request.GroupName, request.Member);
                return new BamBotAddGroupMemberResponse(group);
            }
            catch (Exception ex)
            {
                return new BamBotAddGroupMemberResponse(ex);
            }
        }

        [Exclude]
        public EtcGroup AddGroupMembers(string groupName, params string[] members)
        {
            return EtcCredentialManager.AddGroupMembers(groupName, members);
        }

        public BamBotAddGroupMembersResponse AddGroupMembers(BamBotAddGroupMembersRequest request)
        {
            try
            {
                EtcGroup group = AddGroupMembers(request.GroupName, request.Members);
                return new BamBotAddGroupMembersResponse(group);
            }
            catch (Exception ex)
            {
                return new BamBotAddGroupMembersResponse(ex);
            }
        }

        [Exclude]
        public bool UserExists(string userName)
        {
            return EtcCredentialManager.UserExists(userName);
        }

        public BamBotUserExistsResponse UserExists(BamBotUserExistsRequest request)
        {
            try
            {
                bool exists = UserExists(request.UserName);
                return new BamBotUserExistsResponse(exists);
            }
            catch (Exception ex)
            {
                return new BamBotUserExistsResponse(ex);
            }
        }

        [Exclude]
        public bool GroupExists(string userName)
        {
            return EtcCredentialManager.GroupExists(userName);
        }

        public BamBotGroupExistsResponse GroupExists(BamBotUserExistsRequest request)
        {
            try
            {
                bool exists = GroupExists(request.UserName);
                return new BamBotGroupExistsResponse(exists);
            }
            catch (Exception ex)
            {
                return new BamBotGroupExistsResponse(ex);
            }
        }
    }
}