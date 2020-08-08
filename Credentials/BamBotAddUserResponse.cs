using System;
using Bam.Remote.Etc;

namespace Bam.Net.Application
{
    public class BamBotAddUserResponse: BamBotResponse<EtcUser>
    {
        public BamBotAddUserResponse(Exception ex) : base(ex)
        {
        }

        public BamBotAddUserResponse(EtcUser data) : base(data)
        {
        }
    }
}