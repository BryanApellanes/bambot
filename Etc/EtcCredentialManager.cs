using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bam.Net;

namespace Bambot.Etc
{
    public class EtcCredentialManager
    {
        public EtcCredentialManager(string etcDirectory = "/etc/")
        {
            Etc = new DirectoryInfo(etcDirectory);
            Passwd = PasswdFile.Load(Path.Combine(etcDirectory, "passwd"));
            Group = GroupFile.Load(Path.Combine(etcDirectory, "group"));
            Shadow = ShadowFile.Load(Path.Combine(etcDirectory, "shadow"));
        }
        
        public PasswdFile Passwd { get; set; }
        public GroupFile Group { get; set; }
        public ShadowFile Shadow { get; set; }
        
        protected DirectoryInfo Etc { get; set; }

        public string[] Users => Passwd.Rows.Select(passwdEntry => passwdEntry.UserName).ToArray();

        public void AddUser(string userName, string password)
        {
            PasswdEntry passwdEntry = Passwd.AddUser(userName);
            GroupEntry groupEntry = Group.AddGroup(userName);
            ShadowEntry shadowEntry = Shadow.AddEntry(userName, password);
            passwdEntry.GroupId = groupEntry.GroupId;
        }
        
        public ShadowEntry this[string userName] => RowsByUser[userName];

        public void Save(string etcDirectoryPath = "/etc/")
        {
            DirectoryInfo dirArg = new DirectoryInfo(etcDirectoryPath);
            DirectoryInfo toUse = !(Etc.FullName.Equals(dirArg.FullName)) ? dirArg : Etc;
            Passwd.Save(Path.Combine(toUse.FullName, "passwd"));
            Group.Save(Path.Combine(toUse.FullName, "group"));
            Shadow.Save(Path.Combine(toUse.FullName, "shadow"));
        }
        
        /// <summary>
        /// Set the password setter implementation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetPasswordSetter<T>() where T : IShadowPasswordSetter, new()
        {
            foreach (string user in Users)
            {
                this[user].Password = this[user].Password.Copy<T>(this[user].Password);
            }
        }
        
        public void SetPassword(string userName, string password)
        {
            if (!RowsByUser.ContainsKey(userName))
            {
                throw new InvalidOperationException($"User not found: {userName}");
            }
            RowsByUser[userName].Password.Set(password);
        }

        private Dictionary<string, ShadowEntry> _rowsByUser;
        private readonly object _rowsByUserLock = new object();
        protected Dictionary<string, ShadowEntry> RowsByUser
        {
            get
            {
                return _rowsByUserLock.DoubleCheckLock(ref _rowsByUser, () =>
                {
                    Dictionary<string, ShadowEntry> result = new Dictionary<string, ShadowEntry>();
                    Shadow.Rows.Each(passwdEntry => result.Add(passwdEntry.UserName, passwdEntry));
                    return result;
                });
            }
        }
    }
}