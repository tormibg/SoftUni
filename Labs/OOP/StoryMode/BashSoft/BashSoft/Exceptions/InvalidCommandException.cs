using System;

namespace BashSoft.Exceptions
{
    public class InvalidCommandException : Exception
    {
        private const string InvalidCommandMessage = "The command '{0}' is invalid";

        public InvalidCommandException(string messages) : base(String.Format(InvalidCommandMessage, messages))
        {

        }
    }
}