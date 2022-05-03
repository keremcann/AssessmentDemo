using System;

namespace AspNetCore.Entity
{
    [Serializable]
    public abstract class BaseResponseType
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
