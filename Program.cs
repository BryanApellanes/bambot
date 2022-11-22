using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bam.Net.CommandLine;
using Bam.Net.Testing;

namespace Bam.Net.Application
{
    [Serializable]
    public class Program_bak : DeployableCommandLineTool
    {
        static void Main(string[] args)
        {
            TryWritePid(true);
            IsolateMethodCalls = false;
            if (!ExecuteMain(args, (a) =>
            {
                Message.PrintLine("Error parsing arguments: {0}", ConsoleColor.Red, a.Message);
                Environment.Exit(1);
            }))
            {
                Interactive();
            };
        }
    }
}
