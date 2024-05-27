using System;

namespace Bam.Application
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

        private T _data;
        public new T Data
        {
            get
            {
                if (_data != null)
                {
                    return _data;
                }

                if (base.Data != null)
                {
                    return (T)base.Data;
                }

                return default(T);
            }
            
            set
            {
                _data = value;
                base.Data = value;
            }
        }
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