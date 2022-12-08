namespace Bam.Net.Application
{
    public class BamBotAddGroupRequest: BamBotRequest
    {
        public string GroupName { get; set; }
        public string[] Members { get; set; }
    }
}