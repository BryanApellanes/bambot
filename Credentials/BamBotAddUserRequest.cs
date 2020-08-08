namespace Bam.Net.Application
{
    public class BamBotAddUserRequest: BamBotRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}