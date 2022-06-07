using System;

namespace MarketWatch.Server.Exceptions
{

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }

        private static string CustomMessage(string entityName, int idEntity)
        {
            return $"{entityName}({idEntity}) not found";
        }
    }
}