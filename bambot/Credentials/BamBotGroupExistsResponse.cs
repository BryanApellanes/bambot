using System;

namespace Bam.Net.Application
{
    public class BamBotGroupExistsResponse : BamBotResponse<bool>
    {
        public BamBotGroupExistsResponse(Exception ex) : base(ex)
        {
        }

        public BamBotGroupExistsResponse(bool data) : base(data)
        {
        }
    }
}