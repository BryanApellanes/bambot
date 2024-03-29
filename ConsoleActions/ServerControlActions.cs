using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using Bam.Net.Automation;
using Bam.Net.CommandLine;
using Bam.Net.CoreServices;
using Bam.Net.Server;
using Bam.Net.Services;
using Bam.Net.Services.Automation;
using Bam.Net.Testing;
using InterSystems.Data.CacheClient.Gateway;


namespace Bam.Net.Application
{
    [Serializable]
    public class ServerControlActions : CommandLineTool
    {
        public ServiceProxyServer ServiceProxyServer { get; set; }
        
        [ConsoleAction("S", "Start bambot server")]
        public void StartServer()
        {
            ConsoleLogger logger = new ConsoleLogger();
            ApplicationServiceRegistry appRegistry = BambotServiceRegistry.ForCurrentProcessMode();
            ServiceProxyServer = appRegistry.ServeRegistry(HostPrefix.FromBamProcessConfig().ToArray(), logger);

            foreach (HostPrefix hostPrefix in ServiceProxyServer.HostPrefixes)
            {
                Message.PrintLine("\t{0}", ConsoleColor.Cyan, hostPrefix.ToString());
            }
            Pause("Bambot service started");
        }

        [ConsoleAction("K", "Kill bambot server")]
        public void KillServer()
        {
            if (ServiceProxyServer != null)
            {
                ServiceProxyServer.Stop();
                Pause("Bambot service stopped");
            }
        }

        [ConsoleAction("config", "Show the current bambot config settings.")]
        public void ShowConfig()
        {
            OutLine($"Config file: {Config.Current.File.FullName}", ConsoleColor.DarkCyan);
            OutLine(Config.Current.File.ReadAllText());
            Thread.Sleep(1000);
        }

        [ConsoleAction("deploy", "Deploy bambot to the specified host")]
        public void Deploy()
        {
            // copy files
            // start bambot
            throw new NotImplementedException();
        }

        [ConsoleAction("cpr")]
        public void CardiopulmonaryResuscitation()
        {
            throw new NotImplementedException();
        }
    }
}