using Bam.Remote.Etc;

namespace Bam.Application
{
    public class BamBotAddGroupMembersRequest: BamBotRequest
    {
        public string GroupName { get; set; }
        public string[] Members { get; set; }
    }
}