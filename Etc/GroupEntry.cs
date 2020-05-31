using System.Linq;
using Bam.Net;

namespace Bambot.Etc
{
    /// <summary>
    /// Represents a single line in the /etc/group file.
    /// </summary>
    public class GroupEntry
    {
        public GroupEntry()
        {
            Password = "x";
        }
        
        public string GroupName { get; set; }
        public string Password { get; set; }
        public int GroupId { get; set; }
        public string Users { get; set; }

        public override string ToString()
        {
            return $"{GroupName}:{Password}:{GroupId}:{Users}";
        }

        public static GroupEntry[] Parse(string fileContent)
        {
            string[] lines = fileContent.DelimitSplit("\n");
            return lines.Select(line => ParseLine(line.Trim())).ToArray();
        }

        private static GroupEntry ParseLine(string line)
        {
            string[] split = line.Split(":");
            return new GroupEntry
            {
                GroupName = split[0],
                Password = split[1],
                GroupId = int.Parse(split[2]),
                Users = split[3],
            };
        }
    }
}