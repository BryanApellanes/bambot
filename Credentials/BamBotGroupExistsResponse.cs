using System;

namespace Bam.Application
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