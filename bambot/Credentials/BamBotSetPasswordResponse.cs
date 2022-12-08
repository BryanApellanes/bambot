using System;
using Bam.Remote.Etc;

namespace Bam.Net.Application
{
    public class BamBotSetPasswordResponse : BamBotResponse<EtcUser>
    {
        public BamBotSetPasswordResponse(): base((EtcUser)null)
        {
        }

        public BamBotSetPasswordResponse(Exception ex) : this()
        {
            Exception = ex;
        }
        
        public BamBotSetPasswordResponse(EtcUser data) : base(data)
        {
        }
    }
}