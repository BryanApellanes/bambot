namespace Bambot.Deployment
{
    public class FileSetDescriptor
    {
        public SshHostInfo[] SshHostInfos { get; set; }
        public string[] Directories { get; set; }
        public string[] Files { get; set; }
    }
}