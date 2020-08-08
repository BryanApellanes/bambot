using System;
using Bam.Remote.Etc;

namespace Bam.Net.Application
{
    public class BamBotAddGroupMemberResponse: BamBotResponse<EtcGroup>
    {
        public BamBotAddGroupMemberResponse(Exception ex) : base(ex)
        {
        }

        public BamBotAddGroupMemberResponse(EtcGroup data) : base(data)
        {
        }
    }
}