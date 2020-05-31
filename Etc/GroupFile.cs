using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bam.Net;

namespace Bambot.Etc
{
    public class GroupFile
    {
        public GroupFile()
        {
            _rows = new List<GroupEntry>();
        }
        
        private List<GroupEntry> _rows;
        public GroupEntry[] Rows
        {
            get => _rows.ToArray();
            set => _rows = new List<GroupEntry>(value);
        }

        public GroupEntry AddGroup(string groupName)
        {
            GroupEntry groupEntry = new GroupEntry()
            {
                GroupName = groupName,
                GroupId = NextGroupId()
            };
            _rows.Add(groupEntry);
            return groupEntry;
        }

        private Dictionary<string, GroupEntry> _rowsByGroup;
        private readonly object _rowsByGroupLock = new object();
        protected Dictionary<string, GroupEntry> RowsByGroup
        {
            get
            {
                return _rowsByGroupLock.DoubleCheckLock(ref _rowsByGroup, () =>
                {
                    Dictionary<string, GroupEntry> result = new Dictionary<string, GroupEntry>();
                    Rows.Each(groupEntry => result.Add(groupEntry.GroupName, groupEntry));
                    return result;
                });
            }
        }
        
        public GroupEntry this[string groupName] => RowsByGroup[groupName];
        private Dictionary<uint, GroupEntry> _rowsByGroupId;
        private readonly object _rowsByGroupIdLock = new object();
        protected Dictionary<uint, GroupEntry> RowsByGroupId
        {
            get
            {
                return _rowsByGroupIdLock.DoubleCheckLock(ref _rowsByGroupId, () =>
                {
                    Dictionary<uint, GroupEntry> result = new Dictionary<uint, GroupEntry>();
                    Rows.Each(groupEntry => result.Add(groupEntry.GroupId, groupEntry));
                    return result;
                });
            }
        }

        public uint NextGroupId()
        {
            return RowsByGroupId.Keys.ToArray().Largest() + 1;
        }
        
        public string Print()
        {
            StringBuilder result = new StringBuilder();
            foreach (GroupEntry entry in Rows)
            {
                result.AppendLine(entry.ToString());
            }

            return result.ToString();
        }

        public void Save(string filePath = "/etc/group", bool overwrite = true)
        {
            Print().SafeWriteToFile(filePath, overwrite);
        }
        
        public static GroupFile Load(string filePath = "/etc/group")
        {
            return new GroupFile
            {
                Rows = GroupEntry.Parse(File.ReadAllText(filePath)),
            };
        }
    }
}