using System;
using Bam.Remote.Etc;

namespace Bam.Application
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