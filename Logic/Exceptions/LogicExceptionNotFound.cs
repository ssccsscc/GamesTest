using System;

namespace Logic
{
    [Serializable]
    public class LogicExceptionNotFound : Exception
    {
        public LogicExceptionNotFound(string text) : base(text) { }
    }
}
