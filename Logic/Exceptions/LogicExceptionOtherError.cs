using System;

namespace Logic
{
    [Serializable]
    public class LogicExceptionOtherError : Exception
    {
        public LogicExceptionOtherError(string text) : base(text) { }
    }
}
