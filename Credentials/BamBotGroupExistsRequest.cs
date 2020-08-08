namespace Bam.Net.Application
{
    public class BamBotGroupExistsRequest: BamBotRequest
    {
        public string GroupName { get; set; }
        public bool Exists { get; set; }
    }
}