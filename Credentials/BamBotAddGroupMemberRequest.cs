using Bam.Remote.Etc;

namespace Bam.Net.Application
{
    public class BamBotAddGroupMemberRequest: BamBotRequest
    {
        public string GroupName { get; set; }
        public string Member { get; set; }
    }
}