namespace Bam.Application
{
    public class BamBotUpdateGroupRequest: BamBotRequest
    {
        public string GroupName { get; set; }
        public string[] MembersToAdd { get; set; }
        public string[] MembersToRemove { get; set; }
        public string[] MembersToSet { get; set; }
    }
}