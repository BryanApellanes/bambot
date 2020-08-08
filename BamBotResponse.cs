using System;

namespace Bam.Net.Application
{
    public class BamBotResponse<T>: BamBotResponse
    {
        public BamBotResponse(Exception ex)
        {
            Exception = ex;
        }
        
        public BamBotResponse(T data)
        {
            Data = Data;
        }
        
        public new T Data { get; set; }
    }
    
    public class BamBotResponse
    {
        public object Data { get; set; }
        private string _message;
        public string Message
        {
            get
            {
                if (Exception != null)
                {
                    _message = Exception.GetInnerException().Message;
                }

                return _message;
            }
            set => _message = value;
        }

        private bool _success;

        public bool Success
        {
            get
            {
                if (Exception != null)
                {
                    _success = false;
                }

                return _success;
            }
            set => _success = value;
        }
        
        [Exclude]
        public Exception Exception { get; set; }
    }
}