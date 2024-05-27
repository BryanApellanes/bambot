using System;
using Bam.Remote.Etc;

namespace Bam.Application
{
    public class BamBotAddGroupMembersResponse: BamBotResponse<EtcGroup>
    {
        public BamBotAddGroupMembersResponse(Exception ex) : base(ex)
        {
        }

        public BamBotAddGroupMembersResponse(EtcGroup data) : base(data)
        {
        }
    }
}