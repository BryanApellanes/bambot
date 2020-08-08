using System;

namespace Bam.Net.Application
{
    public class BamBotUserExistsResponse : BamBotResponse<bool>
    {
        public BamBotUserExistsResponse(Exception ex) : base(ex)
        {
        }

        public BamBotUserExistsResponse(bool data) : base(data)
        {
        }
    }
}