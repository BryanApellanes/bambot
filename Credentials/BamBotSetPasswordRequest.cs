namespace Bam.Application
{
    public class BamBotSetPasswordRequest :BamBotRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}