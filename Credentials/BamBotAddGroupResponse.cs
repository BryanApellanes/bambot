using System;
using Bam.Remote.Etc;

namespace Bam.Application
{
    public class BamBotAddGroupResponse: BamBotResponse<EtcGroup>
    {
        public BamBotAddGroupResponse(Exception ex) : base(ex)
        {
        }

        public BamBotAddGroupResponse(EtcGroup data) : base(data)
        {
        }
    }
}